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
    public class FiltrarTecnicoInteractor : IFiltrarTecnicoInputPort
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IFiltrarTecnicoOutputPort _outputPortFiltro;

        public FiltrarTecnicoInteractor(ITecnicoRepository tecnicoRepository, 
                                        IFiltrarTecnicoOutputPort outputPortFiltro)
        {
            _tecnicoRepository = tecnicoRepository;
            _outputPortFiltro = outputPortFiltro;
        }
        public void Handler(string nombre)
        {
           var listaFiltro = _tecnicoRepository.FilterByNombreTecnico(nombre).Select(t => new TecnicoElementoDTO
           {
               TecnicoId = t.TecnicoId,
               NombreTec = t.Nombre,
               CodigoTec = t.Codigo,
               SueldoBaseTec = (decimal)t.SueldoBase,
               SucursalNombre = t.Sucursal.Nombre,
               CantidadElementos = t.ElementosAsignados.Count

           }).ToList();
            _outputPortFiltro.Handler(listaFiltro);
        }
    }
}
