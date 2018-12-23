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
    public class PersonPerRoom : SameAttribute
    {
        [Key, Column(Order = 1)]
        public string LessorId { get; set; }
        [Key, Column(Order = 2)]
        public int RoomId { get; set; }
        [Key, Column(Order = 3)]
        public string LesseeId { get; set; }

    }
}
