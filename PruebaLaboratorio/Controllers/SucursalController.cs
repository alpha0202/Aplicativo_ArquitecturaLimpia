using Microsoft.AspNetCore.Mvc;
using PruebaLaborario.Entities;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.Entities.Dto;
using PruebaLaboratorio.Entities.Interfaces;

namespace PruebaLaboratorio.Controllers
{
    public class SucursalController : Controller
    {
        private readonly ISucursalesRepository _sucursalesRepository;
        private readonly ITecnicoRepository _tecnico;

        public SucursalController(ISucursalesRepository sucursalesRepository, ITecnicoRepository tecnico)
        {
            _sucursalesRepository = sucursalesRepository;
            _tecnico = tecnico;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<Sucursal> GetAllSucursales()
        {
          return  _sucursalesRepository.GetSucursal();
        }

        public bool SaveTecnico(GuardarTecnicoDTO tecnico)
        {
            bool res;
            res = _tecnico.AgregarTecnico(tecnico);
            return res;
        }

    }
}
