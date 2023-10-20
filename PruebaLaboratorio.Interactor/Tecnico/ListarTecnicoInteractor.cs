using Microsoft.EntityFrameworkCore;
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
    public class ListarTecnicoInteractor : IListarTecnicosInputPort
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IListarTecnicosOutputPort _outputPort;

        public ListarTecnicoInteractor(ITecnicoRepository tecnicoRepository,IListarTecnicosOutputPort tecnicosOutputPort)
        {
            _tecnicoRepository = tecnicoRepository;
            _outputPort = tecnicosOutputPort;
        }


        public void Handler()
        {
            var data = _tecnicoRepository.GetAllTecnicos().Select(a => new TecnicoElementoDTO
            {
                TecnicoId = a.TecnicoId,
                NombreTec = a.Nombre,
                CodigoTec = a.Codigo,
                SueldoBaseTec = (decimal)a.SueldoBase,
                SucursalNombre = a.Sucursal.Nombre,
                CantidadElementos = a.ElementosAsignados.Count


            }).ToList();
            _outputPort.Handler(data);
        }

    }
}
