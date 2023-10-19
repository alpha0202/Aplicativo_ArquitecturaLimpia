﻿using PruebaLaboratorio.Entities.Dto;
using PruebaLaboratorio.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaborario.Entities.Interfaces
{
    public interface ITecnicoRepository
    {

        IEnumerable<TecnicoElementoDTO> GetAllTecnicos();





    }
}