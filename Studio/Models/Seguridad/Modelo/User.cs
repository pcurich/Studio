using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Models.Seguridad.Modelo
{
    public class User:DbAble
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public int RolId { get; set; }
        public Rol Rol { get; set; }

        public Location Location { get; set; }
    }
}