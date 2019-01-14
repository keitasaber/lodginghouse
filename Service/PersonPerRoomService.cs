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
    public interface IPersonPerRoomService
    {
        IEnumerable<PersonPerRoom> GetAll();

        PersonPerRoom Add(PersonPerRoom personPerRoom);

        IEnumerable<PersonPerRoom> GetByLessorId(string id);

        void Save();
    }
    class PersonPerRoomService : IPersonPerRoomService
    {
        IUnitOfWork _unitOfWork;
        IPersonPerRoomRepository _personPerRoomRepository;

        public PersonPerRoomService(IUnitOfWork unitOfWork, IPersonPerRoomRepository personPerRoomRepository)
        {
            _unitOfWork = unitOfWork;
            _personPerRoomRepository = personPerRoomRepository;
        }

        public PersonPerRoom Add(PersonPerRoom personPerRoom)
        {
            return _personPerRoomRepository.Add(personPerRoom);
        }

        public IEnumerable<PersonPerRoom> GetAll()
        {
            return _personPerRoomRepository.GetAll();
        }

        public IEnumerable<PersonPerRoom> GetByLessorId(string id)
        {
            return _personPerRoomRepository.GetMulti(x => x.LessorId == id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
