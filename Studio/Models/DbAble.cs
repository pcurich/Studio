using System;
using System.ComponentModel.DataAnnotations;

namespace Studio.Models
{
    public class DbAble
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        public bool Estado { get; set; }

        public bool Eliminado { get; set; }

        public DateTime FechaCreacion = DateTime.Now;

        public DateTime FechaModificacion = DateTime.Now;

        public string UsuarioCreacion { get; set; }

        public string UsuarioModificacion { get; set; }
    }
}