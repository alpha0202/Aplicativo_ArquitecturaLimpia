using PruebaLaborario.Entities;
using PruebaLaboratorio.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.EFCore.Repository
{
    public class ElementoRepository : IElementoRepository
    {
        private readonly LaboratorioDBContext _dBContext;

        public ElementoRepository(LaboratorioDBContext dBContext)
        {
            _dBContext = dBContext;
        }


        public List<Elemento> GetAllElementos()
        {
           var data = _dBContext.Elementos.ToList();

            return data;
        }
        
    }
}
