using Microsoft.EntityFrameworkCore;
using PruebaLaborario.Entities;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.Entities.Dto;
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

        public List<Tecnico> GetAllTecnicos()
        {
           return _dBContext.Tecnicos.Include(e => e.ElementosAsignados)
                                                .ThenInclude(t => t.Elemento)
                                            .Include(s => s.Sucursal)
                                            .ToList();
          
        }


        public bool AgregarTecnico(Tecnico tecnico)
        {
            bool result = false;
            _dBContext.Add(tecnico);
            _dBContext.SaveChanges();
            result = true;

            return result;

            //bool result = false;

            //try
            //{
            //    if (tecnico.CantidadElementos <= 0 || tecnico.CantidadElementos >= 10)
            //    {
            //        throw new Exception("la cantidad debe estar en el rango establecido entre 1 y 10 cantidades por elemento asignado");

            //    }
            //    Tecnico tec = new Tecnico
            //    {
            //        Nombre = tecnico.NombreTec,
            //        Codigo = tecnico.CodigoTec,
            //        SueldoBase=tecnico.SueldoBaseTec,
            //        ElementosAsignados = new List<TecnicoElemento>
            //        {
            //            new TecnicoElemento
            //            {
            //                TecnicoId = tecnico.IdTecnico,
            //                CantidadAsignada = tecnico.CantidadElementos,
            //                Elemento = new Elemento
            //                {
            //                    Nombre = tecnico.NombreElemento
            //                }
            //            }
            //        },
            //        Sucursal = new Sucursal
            //        {
            //            Nombre = tecnico.SucursalNombre
            //        }
            //    };

            //    _dBContext.Add(tec);
            //    //_dBContext.AddRange(tecnico.ElementosAsignados);
            //    _dBContext.SaveChanges();
            //    result = true;

            //}
            //catch (Exception)
            //{

            //    result = false;
            //}

            //return result;
        }







    }
}
