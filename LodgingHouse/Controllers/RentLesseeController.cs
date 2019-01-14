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
    public class RentLesseeController : ApiController
    {
        IUserService _userService;
        IRentLesseeService _rentLesseeService;

        public RentLesseeController(IUserService userService, IRentLesseeService rentLesseeService)
        {
            _userService = userService;
            _rentLesseeService = rentLesseeService;
        }


        // GET: RentLessee
        public IEnumerable<User> GetAllByLessorId()
        {
            List<RoomRateViewModel> roomRateViewModelList = new List<RoomRateViewModel>();
            List<string> roomIdList = new List<string>();
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var loggedUserId = claims.ToList()[0].Value;

            var lesseeList = _rentLesseeService.GetByLessorId(loggedUserId).ToList();
            List<User> userList = new List<User>(); 
            foreach(var lessee in lesseeList)
            {
                userList.Add(_userService.GetById(lessee.LesseeId));
            }
            return userList;
        }
    }
}