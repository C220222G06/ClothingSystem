using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClothingSystem.EntidadesDeNegocio;
using Microsoft.EntityFrameworkCore;
namespace ClothingSystem.AccesoADatos
{
    public class BDContexto : DbContext
    {
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-DEV01\SQLEXPRESS02;Initial Catalog=SeguridadWebdb;Integrated Security=True");
        }
    }
}
