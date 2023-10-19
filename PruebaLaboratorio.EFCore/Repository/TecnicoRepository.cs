using Microsoft.EntityFrameworkCore;
using PruebaLaborario.Entities;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.Entities.Dto;
using PruebaLaboratorio.Entities.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.EFCore.Repository
{
    public class TecnicoRepository : ITecnicoRepository

    {
        private readonly LaboratorioDBContext _dBContext;

        public TecnicoRepository(LaboratorioDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public IEnumerable<TecnicoElementoDTO> GetAllTecnicos()
        {
            //var dataLst =  _dBContext.Tecnicos.Include(e => e.ElementosAsignados)
            //                                    .ThenInclude(t=>t.Elemento)
            //                                .Include(s=>s.Sucursal)                             
            //                                .ToList();

          //var data =   _dBContext.Tecnicos.Select(a => new TecnicoDTO
          //  {
          //      Nombre = a.Nombre,
          //      Codigo = a.Codigo,
          //      SueldoBase = (decimal)a.SueldoBase,
          //      NombreSucursal = a.Sucursal.Nombre,
          //      ElementosAsignados = a.ElementosAsignados,

          //  }).ToList();

            var data = _dBContext.TecnicoElementos.Select(a => new TecnicoElementoDTO
            {
                Nombre = a.Tecnico.Nombre,
                Codigo = a.Tecnico.Codigo,
                SueldoBase = (decimal)a.Tecnico.SueldoBase,
                CantidadElementos = a.CantidadAsignada,
                Sucursal = a.Tecnico.Sucursal.Nombre
                

            }).ToList();

            return data;
        }

    }
}
