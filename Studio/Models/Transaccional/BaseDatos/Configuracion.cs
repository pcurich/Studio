using Studio.Models.Transaccional.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Studio.Models.Transaccional.BaseDatos
{
    public partial class MusicStoreEntities : DbContext
    {
        private class AlbumConfiguration : EntityTypeConfiguration<Album>
        {
            public AlbumConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("Albums");
            }
        }

        private class ArtistConfiguration : EntityTypeConfiguration<Artist>
        {
            public ArtistConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("Artists");
            }
        }

        private class CartConfiguration : EntityTypeConfiguration<Cart>
        {
            public CartConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("Carts");
            }
        }

        private class GenreConfiguration : EntityTypeConfiguration<Genre>
        {
            public GenreConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("Genres");
            }
        }

        private class OrderConfiguration : EntityTypeConfiguration<Order>
        {
            public OrderConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("Orders");
            }
        }

        private class OrderDetailConfiguration : EntityTypeConfiguration<OrderDetail>
        {
            public OrderDetailConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("OrderDetails");
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlbumConfiguration());
            modelBuilder.Configurations.Add(new ArtistConfiguration());
            modelBuilder.Configurations.Add(new CartConfiguration());
            modelBuilder.Configurations.Add(new GenreConfiguration());
            modelBuilder.Configurations.Add(new OrderConfiguration());
            modelBuilder.Configurations.Add(new OrderDetailConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}