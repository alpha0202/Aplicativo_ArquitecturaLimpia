using PruebaLaboratorio.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.OutputPort.Tecnico
{
    public interface IListarTecnicosOutputPort
    {
        public void Handler(List<TecnicoElementoDTO> dTOs);
    }
}
