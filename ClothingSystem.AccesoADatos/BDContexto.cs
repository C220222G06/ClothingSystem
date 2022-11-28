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
            
            optionsBuilder.UseSqlServer(@"workstation id=ClothingSystemAPIdb.mssql.somee.com;packet size=4096;user id=Adonay1B_SQLLogin_1;pwd=abrojnm86g;data source=ClothingSystemAPIdb.mssql.somee.com;persist security info=False;initial catalog=ClothingSystemAPIdb");

        }
    }
}
