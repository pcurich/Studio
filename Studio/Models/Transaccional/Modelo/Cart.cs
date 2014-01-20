using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Models.Transaccional.Modelo
{
    public class Cart:DbAble
    {
        public int AlbumId { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }

        public Album Album { get; set; }
    }
}