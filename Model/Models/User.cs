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
    public class User : SameAttribute
    {
        [Key]
        public string Id { get; set; }

        [MaxLength(256)]
        public string FullName { get; set; }

        public string Dob { get; set; }

        [Column(TypeName = "ntext")]
        public string Avatar { get; set; }

        public int PhoneNumber { get; set; }
    }
}
