using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.DTO
{
    public class TecnicoDTO
    {
        public string Nombre { get; set; }
        public string Codigo { get; set; }
        public decimal SueldoBase { get; set; }
        // public int SucursalId { get; set; }
        public string NombreSucursal { get; set; }
        public Sucursal Sucursal { get; set; }
        public ICollection<TecnicoElemento> ElementosAsignados { get; set; }

    }
}
