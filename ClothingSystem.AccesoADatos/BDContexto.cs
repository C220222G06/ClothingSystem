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
            //  optionsBuilder.UseSqlServer(@"workstation id=ClothingSystemdb.mssql.somee.com;packet size=4096;user id=carlos1_SQLLogin_1;pwd=gniotvqytu;data source=ClothingSystemdb.mssql.somee.com;persist security info=False;initial catalog=ClothingSystemdb");
            optionsBuilder.UseSqlServer(@"Data Source=MABA\SQLEXPRESS;Initial Catalog=ClothingSystemdb;Integrated Security=True");
        }
    }
}
