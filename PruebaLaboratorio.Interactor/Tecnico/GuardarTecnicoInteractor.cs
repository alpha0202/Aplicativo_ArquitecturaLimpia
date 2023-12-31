﻿using Microsoft.EntityFrameworkCore;
using PruebaLaborario.Entities;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.Entities.Dto;
using PruebaLaboratorio.InputPort.Tecnico;
using PruebaLaboratorio.OutputPort.Tecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Interactor.Tecnico
{
    public class GuardarTecnicoInteractor : IGuardarTecnicoInputPort
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IGuardarTecnicoOutputPort _outputPortGuardar;

        public GuardarTecnicoInteractor(ITecnicoRepository tecnicoRepository,
                                        IGuardarTecnicoOutputPort outputPortGuardar)
        {
            _tecnicoRepository = tecnicoRepository;
            _outputPortGuardar = outputPortGuardar;
        }


        public void Handler(GuardarTecnicoDTO tecnico)
        {
            int result = 0;

            try
            {
                if (tecnico.CantidadElementos <= 0 || tecnico.CantidadElementos >= 10)
                {
                    throw new Exception("la cantidad debe estar en el rango establecido entre 1 y 10 cantidades por elemento asignado");

                }
                PruebaLaborario.Entities.Tecnico tec = new PruebaLaborario.Entities.Tecnico
                {
                    TecnicoId = tecnico.IdTecnico,
                    Nombre = tecnico.NombreTec,
                    Codigo = tecnico.CodigoTec,
                    SueldoBase = tecnico.SueldoBaseTec,
                    SucursalId = tecnico.SucursalId,
                    ElementosAsignados = new List<TecnicoElemento>
                    {
                        new TecnicoElemento
                        {
                            TecnicoId = tecnico.IdTecnico,
                            CantidadAsignada = tecnico.CantidadElementos,
                            ElementoId = tecnico.ElementoId,
                           
                        }
                    },
                   
                };

                if(tecnico.IdTecnico == 0)
                {
                  var res =  _tecnicoRepository.AgregarTecnico(tec);
                    //_dBContext.AddRange(tecnico.ElementosAsignados);
                    if (res != 0)
                    {
                        result = 1;

                    }
                    result = 0;
                }
                else
                {
                    _tecnicoRepository.ActualizarTecnico(tec);
                    result = 1;
                }


            }
            catch (Exception)
            {

                result = 0;
            }

            _outputPortGuardar.Hadler(result);
        }
    }
}
