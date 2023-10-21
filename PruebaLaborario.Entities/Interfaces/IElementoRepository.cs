using PruebaLaborario.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Entities.Interfaces
{
    public interface IElementoRepository
    {
        public List<Elemento> GetAllElementos();
    }
}
