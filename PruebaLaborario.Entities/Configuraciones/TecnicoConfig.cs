using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaborario.Entities.Configuraciones
{
    public class TecnicoConfig : IEntityTypeConfiguration<Tecnico>
    {
        public void Configure(EntityTypeBuilder<Tecnico> builder)
        {
            builder.Property(pro => pro.Nombre).IsRequired();
            builder.Property(pro=>pro.SueldoBase).IsRequired();
            builder.Property(pro=>pro.Codigo).IsRequired();
            builder.Property(pro=>pro.SueldoBase).HasColumnType("decimal");


        }
    }
}
