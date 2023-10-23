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


        public void AgregarTecnico(Tecnico tecnico)
        {
            //int result = 0;

            _dBContext.Add(tecnico);
            _dBContext.AddRange(tecnico.ElementosAsignados);
           var res =  _dBContext.SaveChanges();
            //if(res >=  0)
            //{
            //    result = 1;

            //}
            //else
            //{
            //    result = 0;
            //}


            //return result;

       
        }

        public void ActualizarTecnico(Tecnico tecnico)
        {
            if (tecnico is null)
            {
                throw new Exception("no existe información para actualizar");

            }

          var tec = new Tecnico();
             tec = _dBContext.Tecnicos.Where(t => t.TecnicoId == tecnico.TecnicoId).FirstOrDefault();
            if (tec != null)
            {
                tec.Nombre = tecnico.Nombre;
                tec.SueldoBase = tecnico.SueldoBase;
                tec.Codigo = tecnico.Codigo;
                tec.ElementosAsignados = tecnico.ElementosAsignados;
                tec.Sucursal = tecnico.Sucursal;

            }
            _dBContext.Tecnicos.Update(tec);
            _dBContext.SaveChanges();

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

        public int GetIDElementoAsignado(int id)
        {
            var filter = _dBContext.TecnicoElementos.Single(t=> t.TecnicoId == id);
             var res =  filter.ElementoId;

            return res;
        }


        public bool BorrarTecnico(int id)
        {
            bool result = false;
            var tec = _dBContext.Tecnicos.Include(e => e.ElementosAsignados)
                                           .ThenInclude(t => t.Elemento)
                                         .Include(s => s.Sucursal)
                                         .Where(t => t.TecnicoId == id)
                                         .FirstOrDefault();

            if (tec == null)
            {
                return result= false;
            }
            else
            {
                _dBContext.TecnicoElementos.RemoveRange(tec.ElementosAsignados);
                _dBContext.Tecnicos.Remove(tec);
                _dBContext.SaveChanges();
            }


            return result;
        }
    }
}
