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
    public interface ILesseeService
    {
        Lessee Add(Lessee Lessee);

        void Save();
    }

    public class LesseeService : ILesseeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILesseeRepository _lesseeRepository;

        public LesseeService(IUnitOfWork unitOfWork, ILesseeRepository lesseeRepository)
        {
            _unitOfWork = unitOfWork;
            _lesseeRepository = lesseeRepository;
        }

        public Lessee Add(Lessee lessee)
        {
            return _lesseeRepository.Add(lessee);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
