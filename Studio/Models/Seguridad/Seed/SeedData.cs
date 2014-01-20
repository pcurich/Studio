using Studio.Models.Seguridad.Entities;
using Studio.Models.Seguridad.Modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Studio.Models.Seguridad.Seed
{
    public class SeedData : DropCreateDatabaseIfModelChanges<Security>
    {
        protected override void Seed(Security context)
        {
            var rol = new List<Rol>
            {
                new Rol{ Name="Seguridad" }, //todo 
                new Rol{ Name="Administrador" }, // todo menos seguridad
                new Rol{ Name="Supervisor" },// ventas, caja y almacen
                new Rol{ Name="Cajero" }, //ventas y caha
                new Rol{ Name="Vendedor" },// ventas
                new Rol{ Name="Contabilidad" }, //graficos y reportes
                new Rol{ Name="Gerencia" }, //graficos
                new Rol{ Name="Invitado" }, //graficos
            };

            new List<User>
            {
                new User{UserName="system", Password="system", Rol=rol.Single(r=>r.Name=="Seguridad")},
                new User{UserName="admin", Password="admin", Rol=rol.Single(r=>r.Name=="Administrador")},
                new User{UserName="pcurich", Password="pcurich", Rol=rol.Single(r=>r.Name=="Gerencia")},
                new User{UserName="fferrary", Password="fferrary", Rol=rol.Single(r=>r.Name=="Supervisor")},
                new User{UserName="contador", Password="contador", Rol=rol.Single(r=>r.Name=="Contabilidad")},
                new User{UserName="cajero", Password="cajero", Rol=rol.Single(r=>r.Name=="Cajero")},
                new User{UserName="vendedor", Password="vendedor", Rol=rol.Single(r=>r.Name=="Vendedor")},
                new User{UserName="guest", Password="guest", Rol=rol.Single(r=>r.Name=="Invitado")}
            }.ForEach(a => context.Users.Add(a));

            new List<License>
            {
                new License{Name="lectura"},
                new License{Name="Escritura"},
                new License{Name="Ninguno"}
            }.ForEach(a => context.Licenses.Add(a));
        }
    }
}