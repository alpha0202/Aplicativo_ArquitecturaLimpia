using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaborario.Entities
{
    public class TecnicoElemento
    {
        public int TecnicoElementoId { get; set; }
        public int TecnicoId { get; set; }
        public Tecnico Tecnico { get; set; }
        public int ElementoId { get; set; }
        public Elemento Elemento { get; set; }
        [Range(1, 10)]
        public int CantidadAsignada { get; set; }

    }
}
