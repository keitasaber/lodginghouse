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
    public interface IAspNetUserService
    {
        void Update(AspNetUser entity);

        AspNetUser GetSingleById(string id);

        void Save();
    }
    public class AspNetUserService : IAspNetUserService
    {
        private IAspNetUserRepository _aspNetUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AspNetUserService(IAspNetUserRepository aspNetUserRepository, IUnitOfWork unitOfWork)
        {
            _aspNetUserRepository = aspNetUserRepository;
            _unitOfWork = unitOfWork;
        }

        public AspNetUserService()
        {
        }

        public void Update(AspNetUser entity)
        {
            _aspNetUserRepository.Update(entity);
        }

        public AspNetUser GetSingleById(string id)
        {
            return _aspNetUserRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
