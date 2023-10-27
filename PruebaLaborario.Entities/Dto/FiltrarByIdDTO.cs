using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Entities.Dto
{
    public class FiltrarByIdDTO
    {
      
        public int idtecnico { get; set; }
        public string nombretec { get; set; }
        public string codigotec { get; set; }
        public decimal sueldobasetec { get; set; }
        public int sucursalid { get; set; }
        public int elementoid { get; set; }
        public int cantidadelementos { get; set; }

    }
}
