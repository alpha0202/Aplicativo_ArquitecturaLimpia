using Microsoft.EntityFrameworkCore;
using PruebaLaborario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.EFCore
{
    public class LaboratorioDBContext :DbContext
    {
        public LaboratorioDBContext(DbContextOptions options) :base(options)
        { 
                
            
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveColumnType("date");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());



        }

        public DbSet<Tecnico> Tecnicos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<Elemento> Elementos { get; set; }
        public DbSet<TecnicoElemento> TecnicoElementos { get; set; }

    }
}
