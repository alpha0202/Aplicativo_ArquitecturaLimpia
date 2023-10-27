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


        public int AgregarTecnico(Tecnico tecnico);

        public void ActualizarTecnico(Tecnico tecnico);


        public Tecnico GetByIDTecnico(int id);

        public List<Tecnico> FilterByNombreTecnico(string nombre);


        public void BorrarTecnico(int id);

        public (int, int) GetIDElementoAsignado(int id);
    }
}
