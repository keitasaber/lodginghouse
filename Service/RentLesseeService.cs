using Data.Infrastructure;
using Data.Repositories;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IRentLesseeService
    {
        IEnumerable<RentLessee> GetByLessorId(string lessorId);

        void Save();
    }
    public class RentLesseeService : IRentLesseeService
    {
        IRentLesseeRepository _rentLesseeRepository;
        IUnitOfWork _unitOfWork;

        public RentLesseeService(IRentLesseeRepository rentLesseeRepository, IUnitOfWork unitOfWork)
        {
            _rentLesseeRepository = rentLesseeRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<RentLessee> GetByLessorId(string lessorId)
        {
            return _rentLesseeRepository.GetMulti(x => x.LessorId == lessorId);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
