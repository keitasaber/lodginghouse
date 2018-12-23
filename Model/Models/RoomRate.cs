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

        [Required]
        public string MonthlyRate { get; set; }

        [Required]
        public float AirConditioner { get; set; }

        [Required]
        public float ElectricityFee { get; set; }

        [Required]
        public float WaterFee { get; set; }

        [Required]
        public DateTime From { get; set; }
        
        [Required]
        public DateTime To { get; set; }

        [Required]
        public bool IsPayed { get; set; }

    }
}
