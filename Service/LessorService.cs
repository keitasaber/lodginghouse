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
    public interface ILessorService
    {
        Lessor Add(Lessor lessor);

        Lessor GetById(string id);

        void Update(Lessor entity);

        IEnumerable<Lessor> GetByCondition(string keyword);
        void Save();
    }
    public class LessorService : ILessorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private ILessorRepository _lessorRepository;

        public LessorService(IUnitOfWork unitOfWork, ILessorRepository lessorRepository)
        {
            _unitOfWork = unitOfWork;
            _lessorRepository = lessorRepository;
        }

        public Lessor Add(Lessor lessor)
        {
            return _lessorRepository.Add(lessor);
        }

        public IEnumerable<Lessor> GetByCondition(string keyword)
        {
            return _lessorRepository.GetMulti(x => x.LodgingHouseName.Contains(keyword));
        }

        public Lessor GetById(string id)
        {
            return _lessorRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(Lessor entity)
        {
           _lessorRepository.Update(entity);
        }
    }
}
