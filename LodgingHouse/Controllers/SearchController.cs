using LodgingHouse.Models;
using Model.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
namespace LodgingHouse.Controllers
{
    [Authorize]
    public class SearchController : ApiController
    {
        ILessorService _lessorService;
        public SearchController(ILessorService lessorService)
        {
            _lessorService = lessorService;
        }

        // GET: Search
        // GET api/search
        public IEnumerable<Lessor> Get(LodgingHouseModel lodgingHouseModel)
        {
            ClaimsIdentity identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var loggedUserId = claims.ToList()[0].Value;

            var data = _lessorService.GetByCondition(lodgingHouseModel.LessorName);

            return data;
        }
    }
}