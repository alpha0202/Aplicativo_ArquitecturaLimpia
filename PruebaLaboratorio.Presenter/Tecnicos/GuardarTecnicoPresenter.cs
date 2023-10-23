using PruebaLaboratorio.OutputPort.Tecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Presenter.Tecnicos
{
    public class GuardarTecnicoPresenter : IGuardarTecnicoOutputPort, IPresenter<int>
    {
        public int Content {get; private set;}

        public void Hadler(int res)
        {
            Content = res;
        }
    }
}
