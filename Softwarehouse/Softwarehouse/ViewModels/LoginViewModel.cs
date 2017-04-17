﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Softwarehouse.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string UserAccount { get; set; }
        [DataType(DataType.Password),Required]
        public string Password { get; set; }
    }
}