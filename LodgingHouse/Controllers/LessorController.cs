using LodgingHouse.Helper;
using LodgingHouse.Models;
using Model.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;


namespace LodgingHouse.Controllers
{
    [Authorize(Roles = "lessor")]
    public class LessorController : ApiController
    {
        ILessorService _lessorService;
        IUserService _userService;

        public LessorController(ILessorService lessorService, IUserService userService)
        {
            _lessorService = lessorService;
            _userService = userService;
        }


        public LessorViewModel Get()
        {
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var loggedUserId = claims.ToList()[0].Value;
            var loggedUserEmail = claims.ToList()[1].Value;

            var user = _userService.GetById(loggedUserId);
            var lessor = _lessorService.GetById(loggedUserId);

            return LessorHelper.ToLessorViewModel(user, lessor, loggedUserEmail);
        }

        [HttpPost]
        public Boolean Update(LessorViewModel lessorViewModel)
        {
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var loggedUserId = claims.ToList()[0].Value;
            var loggedUserEmail = claims.ToList()[1].Value;

            var user = _userService.GetById(loggedUserId);
            user.FullName = lessorViewModel.FullName;
            user.PhoneNumber = lessorViewModel.PhoneNumber;
            user.Dob = lessorViewModel.Dob;
            user.Gender = lessorViewModel.Gender;
            user.Avatar = lessorViewModel.Avatar;
            user.UpdatedBy = user.Id;
            user.UpdatedDate = DateTime.Now;
            _lessorService.Save();

            var lessor = _lessorService.GetById(loggedUserId);
            lessor.LodgingHouseName = lessorViewModel.LodgingHouseName;
            lessor.Address = lessorViewModel.Address;
            lessor.UpdatedBy = user.Id;
            lessor.UpdatedDate = DateTime.Now;
            _lessorService.Update(lessor);
            _lessorService.Save();

            return true;
        }
    }
}