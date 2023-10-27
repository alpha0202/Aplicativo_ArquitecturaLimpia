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
    public class FiltrarByIdTecnicoInteractor : IFiltrarByIdTecnicoInportPort
    {
        private readonly ITecnicoRepository _tecnicoRepository;
        private readonly IFiltrarByIdTecnicoOutputPort _tecnicoOutputById;

        public FiltrarByIdTecnicoInteractor(ITecnicoRepository tecnicoRepository, 
                                            IFiltrarByIdTecnicoOutputPort tecnicoOutputById)
        {
            _tecnicoRepository = tecnicoRepository;
            _tecnicoOutputById = tecnicoOutputById;
        }

        public void Handler(int idtecnico)
        {
           
            
                int resultadoElementos1;
                int resultadoElementos2;

                var TecFilter = _tecnicoRepository.GetByIDTecnico(idtecnico);
                (resultadoElementos1, resultadoElementos2) = _tecnicoRepository.GetIDElementoAsignado(idtecnico);

                FiltrarByIdDTO byIdDTO = new FiltrarByIdDTO
                {
                    idtecnico = TecFilter.TecnicoId,
                    nombretec = TecFilter.Nombre,
                    codigotec = TecFilter.Codigo,
                    sueldobasetec = (decimal)TecFilter.SueldoBase,
                    sucursalid = (int)TecFilter.SucursalId,
                    elementoid = resultadoElementos1,
                    cantidadelementos = resultadoElementos2

                };

               _tecnicoOutputById.Handler(byIdDTO);




            
        }
    }
}
