﻿using PruebaLaborario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Entities.Dto
{
    public class TecnicoElementoDTO
    {
        public int TecnicoId { get; set; }
        public string NombreTec { get; set; }
        public string CodigoTec { get; set; }
        public decimal SueldoBaseTec { get; set; }
        public string SucursalNombre { get; set; }
        public int CantidadElementos { get; set; }

        
    }
}
