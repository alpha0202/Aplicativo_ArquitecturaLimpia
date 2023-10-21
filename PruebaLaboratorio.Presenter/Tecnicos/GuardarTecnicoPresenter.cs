using PruebaLaboratorio.OutputPort.Tecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Presenter.Tecnicos
{
    public class GuardarTecnicoPresenter : IGuardarTecnicoOutputPort, IPresenter<bool>
    {
        public bool Content {get; private set;}

        public void Hadler(bool res)
        {
            Content = res;
        }
    }
}
