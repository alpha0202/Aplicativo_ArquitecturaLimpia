using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Entities.Dto
{
    public class FiltrarByIdDTO
    {
      
        public int IdTecnico { get; set; }
        public string NombreTec { get; set; }
        public string CodigoTec { get; set; }
        public decimal SueldoBaseTec { get; set; }
        public int SucursalId { get; set; }
        public int ElementoId { get; set; }
        public int CantidadElementos { get; set; }

    }
}
