using LodgingHouse.Models;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace LodgingHouse.Helper
{
    public static class LessorHelper
    {
        public static LessorViewModel ToLessorViewModel(User user, Lessor lessor, string email)
        {
            LessorViewModel lessorViewModel = new LessorViewModel()
            {
                Id = user.Id,
                Email = email,
                FullName = user.FullName,
                Dob = user.Dob,
                Avatar = user.Avatar,
                LodgingHouseName = lessor.LodgingHouseName,
                Description = lessor.Description,
                PhoneNumber = user.PhoneNumber,
                Address = lessor.Address,
                OverViewImage = lessor.OverViewImage,
                TotalRoom = lessor.TotalRoom,
                UpdatedDay = user.UpdatedDate.Value.Day,
                UpdatedMonth = user.UpdatedDate.Value.Month,
                UpdatedYear = user.UpdatedDate.Value.Year
            };

            return lessorViewModel;
        }
    }
}