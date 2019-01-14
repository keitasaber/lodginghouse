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
    public interface IRoomRateService
    {
        IEnumerable<RoomRate> GetAll();

        IEnumerable<RoomRate> GetByLessorId(string id);

        RoomRate Add(RoomRate roomRate);

        void Save();
    }
    public class RoomRateService : IRoomRateService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IRoomRateRepository _roomRaterRepository;

        public RoomRateService(IUnitOfWork unitOfWork, IRoomRateRepository roomRateRepository)
        {
            _unitOfWork = unitOfWork;
            _roomRaterRepository = roomRateRepository;
        }

        public RoomRate Add(RoomRate roomRate)
        {
            return _roomRaterRepository.Add(roomRate);
        }

        public IEnumerable<RoomRate> GetAll()
        {
            return _roomRaterRepository.GetAll();
        }

        public IEnumerable<RoomRate> GetByLessorId(string id)
        {
            return _roomRaterRepository.GetMulti(x => x.LessorId == id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
