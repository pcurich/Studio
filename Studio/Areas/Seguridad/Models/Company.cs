﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Areas.Seguridad.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Town { get; set; }
    }
}