using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Studio.Areas.Seguridad.Models
{
    public class ViewElement
    {
        public int IdAplicacion { get; set; }
        public int IdArea { get; set; }
        public int IdController{ get; set; }
        public int IdVista { get; set; }
        public string Nombre{ get; set; }
        public string Descripcion { get; set; }

        public ViewElement()
        {
        }
    }
}