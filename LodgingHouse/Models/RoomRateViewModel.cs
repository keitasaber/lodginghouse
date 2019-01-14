using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LodgingHouse.Models
{
    public class RoomRateViewModel
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public string LessorId { get; set; }
        public List<User> LesseeList { get; set; }
        public List<string> LesseeIdUpdateOrAddList { get; set; }
    }
}