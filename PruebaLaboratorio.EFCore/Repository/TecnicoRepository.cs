﻿using Microsoft.EntityFrameworkCore;
using PruebaLaborario.Entities;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.Entities.Dto;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
            List<Tecnico> lstRes = new List<Tecnico>();

           lstRes = _dBContext.Tecnicos.Include(e => e.ElementosAsignados)
                                                .ThenInclude(t => t.Elemento)
                                            .Include(s => s.Sucursal)
                                            .ToList();
          return lstRes;
        }


        public int AgregarTecnico(Tecnico tecnico)
        {
            int guardado = 0;
            var tecFilter = _dBContext.Tecnicos.Where(t => t.Nombre.Contains(tecnico.Nombre) 
                                                        || t.TecnicoId == tecnico.TecnicoId)
                                                 .Include(e => e.ElementosAsignados)
                                                  .ThenInclude(t => t.Elemento)
                                                 .Include(s => s.Sucursal)
                                                 .ToList();

            if (tecFilter is null)
            {
                _dBContext.Add(tecnico);
                _dBContext.AddRange(tecnico.ElementosAsignados);
               var res =  _dBContext.SaveChanges();
                guardado = 1;
            }
            else
            {
                guardado = 0;
            }
            return guardado;

       
        }

        public void ActualizarTecnico(Tecnico tecnico)
        {
            try
            {
                if (tecnico is null)
                {
                    throw new Exception("no existe información para actualizar");

                }


                //tecExist = _dBContext.Tecnicos.Where(t => t.TecnicoId == tecnico.TecnicoId).FirstOrDefault();
                var tecExist = _dBContext.Tecnicos.Include(te => te.ElementosAsignados).FirstOrDefault(te => te.TecnicoId == tecnico.TecnicoId);

                if (tecExist == null)
                {
                    throw new Exception("no existe información para actualizar");
                }

                if (tecExist.SucursalId != tecnico.SucursalId)
                {
                    throw new Exception("no puede cambiar de sucursal");
                }

                tecExist.Nombre = tecnico.Nombre;
                tecExist.SueldoBase = tecnico.SueldoBase;
                tecExist.Codigo = tecnico.Codigo;
                //tecExist.ElementosAsignados = tecnico.ElementosAsignados;
                tecExist.Sucursal = tecnico.Sucursal;

                _dBContext.TecnicoElementos.RemoveRange(tecExist.ElementosAsignados); //primero se retira el listado de elementos
                _dBContext.Tecnicos.Update(tecExist);
                _dBContext.TecnicoElementos.AddRange(tecnico.ElementosAsignados); // se vuelven a insertar

                _dBContext.SaveChanges();

            }
            catch (Exception e)
            {

                throw new Exception(e.Message, e);
            }


        }

        public Tecnico GetByIDTecnico(int id)
        {
            var tec = _dBContext.Tecnicos.Include(e => e.ElementosAsignados)
                                            .ThenInclude(t => t.Elemento)
                                          .Include(s => s.Sucursal)
                                          .Where(t => t.TecnicoId == id)
                                          .FirstOrDefault();

            return tec;
        }

        public List<Tecnico> FilterByNombreTecnico(string nombre)
        {
            var tecFilter = _dBContext.Tecnicos.Where(t => t.Nombre.Contains(nombre))
                                                .Include(e => e.ElementosAsignados)                                   
                                                 .ThenInclude(t => t.Elemento)
                                                .Include(s => s.Sucursal)
                                                .ToList();
            return tecFilter;
        }

        public (int, int) GetIDElementoAsignado(int id)
        {
            int res, cantidad;
            try
            {
                var filter = _dBContext.TecnicoElementos.FirstOrDefault(t => t.TecnicoId == id);

                if (filter == null)
                {
                    res = 0;
                    cantidad = 0;

                    return (res, cantidad);
                }
                else
                {
                    res = filter.ElementoId;
                    cantidad = filter.CantidadAsignada;

                }
                return (res, cantidad);

            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            
        }


        public void BorrarTecnico(int idtecnico)
        {
            //int result = 0;
            var tec = _dBContext.Tecnicos.Include(e => e.ElementosAsignados)
                                           .ThenInclude(t => t.Elemento)
                                         .Include(s => s.Sucursal)
                                         .Where(t => t.TecnicoId == idtecnico)
                                         .FirstOrDefault();

            if (tec == null)
            {
                //return result= 0;
            }
            else
            {
                _dBContext.TecnicoElementos.RemoveRange(tec.ElementosAsignados);
                _dBContext.Tecnicos.Remove(tec);
                _dBContext.SaveChanges();
                //result = 1;
            }


            //return result;
        }
    }
}
