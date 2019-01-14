using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LodgingHouse.Models
{
    public class LessorViewModel
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string Dob { get; set; }

        public string Avatar { get; set; }

        public int PhoneNumber { get; set; }

        public bool Gender { get; set; }

        public string LodgingHouseName { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public string OverViewImage { get; set; }

        public int TotalRoom { get; set; }

        public int UpdatedDay { get; set; }
               
        public int UpdatedMonth { get; set; }
               
        public int UpdatedYear { get; set; }
    }
}