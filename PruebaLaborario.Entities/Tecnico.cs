using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaborario.Entities
{
    public class Tecnico
    {


        public int TecnicoId { get; set; }
        public string Nombre { get; set; }

        [RegularExpression("[a-zA-Z,0-9]")]
        public string Codigo { get; set; }
        public decimal SueldoBase { get; set; }

        // Relación con Sucursal
        public int SucursalId { get; set; }
        public Sucursal Sucursal { get; set; }

        // Relación con Elementos asignados
        public ICollection<TecnicoElemento> ElementosAsignados { get; set; }


    }
}
