using Model.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class RoomRate : SameAttribute
    {
        [Key, Column(Order = 1)]
        public string LessorId { get; set; }

        [Key, Column(Order = 2)]
        public string RoomId { get; set; }

        public string RoomName { get; set; }

        public string MonthlyRate { get; set; }

        public float AirConditioner { get; set; }

        public float ElectricityFee { get; set; }

        public float WaterFee { get; set; }

        public DateTime? From { get; set; }
        
        public DateTime? To { get; set; }

        public bool IsPayed { get; set; }

    }
}
