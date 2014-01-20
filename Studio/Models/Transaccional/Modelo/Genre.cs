using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Models.Transaccional.Modelo
{
    public class Genre:DbAble
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}