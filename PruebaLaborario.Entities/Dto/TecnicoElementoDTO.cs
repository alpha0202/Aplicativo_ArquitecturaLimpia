using PruebaLaborario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Entities.Dto
{
    public class TecnicoElementoDTO
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public decimal SueldoBase { get; set; }
        public string Sucursal { get; set; }
        public int CantidadElementos { get; set; }

        
    }
}
