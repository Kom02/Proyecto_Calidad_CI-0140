﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace EmprendeUCR_WebApplication.Data.Entities
{
    public class Shopping_Cart
    {
        [Key]

        public string Email { get; set; }
    }
}
