using PruebaLaborario.Entities;
using PruebaLaboratorio.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.EFCore.Repository
{
    public class SucursalesRepository : ISucursalesRepository
    {
        private readonly LaboratorioDBContext _dBContext;

        public SucursalesRepository(LaboratorioDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public List<Sucursal> GetSucursal()
        {
           var data = _dBContext.Sucursales.ToList();
            return data;
        }
    }
}
