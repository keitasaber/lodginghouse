using LodgingHouse.Models;
using Model.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;

namespace LodgingHouse.Controllers
{
    [Authorize(Roles = "lessor")]
    public class RoomRateController : ApiController
    {
        // GET: RoomRate
        IRoomRateService _roomRateService;
        IPersonPerRoomService _personPerRoomService;
        IUserService _userService;
        

        public RoomRateController(IRoomRateService roomRateService, IPersonPerRoomService personPerRoomService, IUserService userService)
        {
            _roomRateService = roomRateService;
            _personPerRoomService = personPerRoomService;
            _userService = userService;
        }

        public IEnumerable<RoomRateViewModel> GetAll()
        {
            List<RoomRateViewModel> roomRateViewModelList = new List<RoomRateViewModel>();
            List<string> roomIdList = new List<string>();
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var loggedUserId = claims.ToList()[0].Value;
            var loggedUserEmail = claims.ToList()[1].Value;

            var roomRateList = _roomRateService.GetByLessorId(loggedUserId).ToList();
            var personPerRoomGroupList = _personPerRoomService.GetByLessorId(loggedUserId).GroupBy(x => x.RoomId).ToList();

            foreach (var room in roomRateList)
            {
                RoomRateViewModel roomRateViewModel = new RoomRateViewModel()
                {
                    RoomName = room.RoomName,
                    LessorId = room.LessorId,
                    RoomId = room.RoomId
                };
                var personPerRoomByRoomIdList = personPerRoomGroupList.Where(x => x.Key == room.RoomId).ToList();
                foreach (var personPerRoomByRoomIdItem in personPerRoomByRoomIdList)
                {
                    List<User> lesseeIdList = new List<User>();
                    foreach (var personPerRoom in personPerRoomByRoomIdItem.ToList())
                    {
                        var lessee = _userService.GetById(personPerRoom.LesseeId);
                        lesseeIdList.Add(lessee);
                    }
                    roomRateViewModel.LesseeList = lesseeIdList;
                }
                roomRateViewModelList.Add(roomRateViewModel);
            }

            return roomRateViewModelList;
        }

        [HttpPost]
        public bool AddRoom(RoomRateViewModel roomRateViewModel)
        {
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var loggedUserId = claims.ToList()[0].Value;
            RoomRate roomRate = new RoomRate()
            {
                LessorId = loggedUserId,
                RoomId = roomRateViewModel.RoomName,
                RoomName = roomRateViewModel.RoomName,
                CreatedBy = loggedUserId,
                CreatedDate = DateTime.Now
            };
            var newRoom = _roomRateService.Add(roomRate);
            _roomRateService.Save();
            foreach (var rentLessorId in roomRateViewModel.LesseeIdUpdateOrAddList)
            {
                _personPerRoomService.Add(new PersonPerRoom
                {
                    LessorId = loggedUserId,
                    LesseeId = rentLessorId,
                    RoomId = newRoom.RoomId,
                    CreatedBy = loggedUserId,
                    CreatedDate = DateTime.Now
                });
                _personPerRoomService.Save();
            }
            if (newRoom != null)
            {
                return true;
            }
            return false;
        }


    }
}