using Studio.Models.Transaccional.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Studio.Models.Transaccional.Entities
{

    public partial class MusicStoreEntities:DbContext
    {

        public MusicStoreEntities()
            //: base(@"Data Source=PCURICH\SQLEXPRESS;Initial Catalog=Studio.Models.Transaccional.Entities.MusicStoreEntities;Integrated Security=True")
        {
            //RegistrarTablas(); //Metodos Genericos
            this.Configuration.LazyLoadingEnabled = false; //http://sebys.com.ar/2011/06/01/entity-framework-4-1-cf-y-lazy-load/
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}