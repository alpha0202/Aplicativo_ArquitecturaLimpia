using PruebaLaboratorio.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.InputPort.Tecnico
{
    public interface IGuardarTecnicoInputPort
    {
        public void Handler(GuardarTecnicoDTO dTO);
    }
}
