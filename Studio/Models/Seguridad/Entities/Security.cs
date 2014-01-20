using Studio.Models.Seguridad.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Studio.Models.Seguridad.Entities
{
    public partial class Security : DbContext
    {
        public Security()
            //: base(@"Data Source=PCURICH\SQLEXPRESS;Initial Catalog=Studio.Models.Transaccional.Entities.MusicStoreEntities;Integrated Security=True")
        {
            //RegistrarTablas(); //Metodos Genericos
            this.Configuration.LazyLoadingEnabled = false; //http://sebys.com.ar/2011/06/01/entity-framework-4-1-cf-y-lazy-load/
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Rols { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<License> Licenses { get; set; }
        public DbSet<Element> Elements { get; set; }
                
    }
}