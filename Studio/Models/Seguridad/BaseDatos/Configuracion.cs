using Studio.Models.Seguridad.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Studio.Models.Seguridad.BaseDatos
{
    public partial class Security : DbContext
    {
        private class UserConfiguration : EntityTypeConfiguration<User>
        {
            public UserConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("Users");
            }
        }

        private class RolConfiguration : EntityTypeConfiguration<Rol>
        {
            public RolConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("Rols");
            }
        }

        private class LocationConfiguration : EntityTypeConfiguration<Location>
        {
            public LocationConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("Locations");
            }
        }

        private class LicenseConfiguration : EntityTypeConfiguration<License>
        {
            public LicenseConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("Locations");
            }
        }

        private class ElementConfiguration : EntityTypeConfiguration<Element>
        {
            public ElementConfiguration()
            {
                Property(p => p.Id).IsRequired();
                Property(p => p.FechaCreacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.FechaModificacion).IsRequired().HasColumnType("datetime2");
                Property(p => p.UsuarioCreacion).IsRequired();
                Property(p => p.UsuarioModificacion).IsRequired();
                ToTable("Locations");
            }
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RolConfiguration());
            modelBuilder.Configurations.Add(new LocationConfiguration());
            modelBuilder.Configurations.Add(new LicenseConfiguration());
            modelBuilder.Configurations.Add(new ElementConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}