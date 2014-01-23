using Studio.Models.Seguridad.Modelo;
using System.ComponentModel;
using System.Linq;
using System.Web.Mvc;

namespace Studio.Areas.Seguridad.Models
{
    public class ViewElement
    {
        [DisplayName("Aplicacion")]
        public SelectList Aplicacion { get; set; }

        [DisplayName("Area")]
        public SelectList Area { get; set; }

        [DisplayName("Controlador")]
        public SelectList Controller { get; set; }

        [DisplayName("Vista")]
        public SelectList Vista { get; set; }

        [DisplayName("Nombre")]
        public string Nombre { get; set; }

        [DisplayName("Resumen")]
        public string Resumen { get; set; }

        [DisplayName("Active")]
        public bool Active { get; set; }

        public ViewElement()
        {
            Aplicacion = new SelectList(Enumerable.Empty<Element>(), "Id", "Name");
            Area = new SelectList(Enumerable.Empty<Element>(), "Id", "Name");
            Controller = new SelectList(Enumerable.Empty<Element>(), "Id", "Name");
            Vista = new SelectList(Enumerable.Empty<Element>(), "Id", "Name");
        }
    }
}