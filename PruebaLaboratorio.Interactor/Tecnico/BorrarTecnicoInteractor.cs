using PruebaLaborario.Entities;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.InputPort.Tecnico;
using PruebaLaboratorio.OutputPort.Tecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Interactor.Tecnico
{
    internal class BorrarTecnicoInteractor : IBorrarTecnicoInputPort
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IBorrarTecnicoOutputPort _outputPortBorrar;

        public BorrarTecnicoInteractor(ITecnicoRepository tecnicoRepository,
                                       IBorrarTecnicoOutputPort outputPortBorrar)
        {
            _tecnicoRepository = tecnicoRepository;
            _outputPortBorrar = outputPortBorrar;
        }

        public void Handler(int idtecnico)
        {
            int result = 0;

            try
            {
                _tecnicoRepository.BorrarTecnico(idtecnico);
                result = 1;
            }
            catch (Exception)
            {

                result = 0;
            }

           _outputPortBorrar.Handler(result);
        }
    }
}
