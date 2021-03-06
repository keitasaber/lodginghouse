﻿using Model.Share;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Models
{
    public class Lessor : SameAttribute
    {
        [Key]
        public string Id { get; set; }

        public string LodgingHouseName { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        [Column(TypeName = "ntext")]
        public string Address { get; set; }

        [Column(TypeName = "ntext")]
        public string OverViewImage { get; set; }

        [Required]
        public int TotalRoom { get; set; }
    }
}
