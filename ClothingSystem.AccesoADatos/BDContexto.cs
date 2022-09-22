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
        public DbSet<Marca> Marca { get; set; }
        public DbSet<Ropa> Ropa { get; set; }
        public DbSet<RopaFoto> RopaFoto { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           // optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-OOE8CFG\SQLEXPRESS;Initial Catalog=ClothingSystemdb;Integrated Security=True");
          optionsBuilder.UseSqlServer(@"Data Source=MABA\SQLEXPRESS;Initial Catalog=ClothingSystemdb;Integrated Security=True");
        }
    }
}
