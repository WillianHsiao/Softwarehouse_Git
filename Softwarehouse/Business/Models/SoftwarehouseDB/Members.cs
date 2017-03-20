﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Models.SoftwarehouseDB
{
    //[Table("MemberData")]
    public partial class Members
    {
        public Members()
        {

        }

        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("Account")]
        public string Account { get; set; }

        [Column("Password")]
        public string Password { get; set; }

        [Column("Email")]
        public string Email { get; set; }
    }
}
