using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaborario.Entities.Configuraciones
{
    public class TecnicoElementoConfig : IEntityTypeConfiguration<TecnicoElemento>
    {
        public void Configure(EntityTypeBuilder<TecnicoElemento> builder)
        {
            builder.HasKey(prop => new { prop.ElementoId, prop.TecnicoId });
        }
    }
}
