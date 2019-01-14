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

    public interface IUserService
    {
        User Add(User user);

        User GetById(string id);

        void Update(User entity);

        void Save();
    }
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public User Add(User user)
        {
            return _userRepository.Add(user);
        }

        public void Update(User entity)
        {
            _userRepository.Update(entity);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public User GetById(string id)
        {
            return _userRepository.GetSingleById(id);
        }
    }
}
