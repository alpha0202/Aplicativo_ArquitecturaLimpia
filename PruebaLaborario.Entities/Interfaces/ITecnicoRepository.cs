using PruebaLaboratorio.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaborario.Entities.Interfaces
{
    public interface ITecnicoRepository
    {

        List<Tecnico> GetAllTecnicos();


        public bool AgregarTecnico(Tecnico tecnico);


    }
}
