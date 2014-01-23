using System;
using System.ComponentModel;

namespace Studio.Areas.Seguridad.Models
{
    [Serializable]
    public class ViewElement
    {
        [DisplayName("Aplicacion")]
        public int Aplicacion { get; set; }

        [DisplayName("Area")]
        public int Area { get; set; }

        [DisplayName("Controlador")]
        public int Controller { get; set; }

        [DisplayName("Vista")]
        public int Vista { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Resumen")]
        public string Resumen { get; set; }

        [DisplayName("Active")]
        public bool Active { get; set; }

        public ViewElement()
        {
            //Aplicacion = new SelectList(Enumerable.Empty<Element>(), "Id", "Name");
            //Area = new SelectList(Enumerable.Empty<Element>(), "Id", "Name");
            //Controller = new SelectList(Enumerable.Empty<Element>(), "Id", "Name");
            //Vista = new SelectList(Enumerable.Empty<Element>(), "Id", "Name");
        }
    }
}