using PruebaLaboratorio.Entities.Dto;
using PruebaLaboratorio.OutputPort.Tecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Presenter.Tecnicos
{
    public class FiltrarByIdTecnicoPresenter : IFiltrarByIdTecnicoOutputPort, IPresenter<FiltrarByIdDTO>
    {
        public FiltrarByIdDTO Content { get; private set; }

        public void Handler(FiltrarByIdDTO byIdDTO)
        {
           Content = byIdDTO;
        }
    }
}
