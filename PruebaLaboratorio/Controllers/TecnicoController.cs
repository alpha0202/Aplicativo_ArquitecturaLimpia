using Microsoft.AspNetCore.Mvc;
using PruebaLaborario.Entities;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.Entities.Dto;
using PruebaLaboratorio.Entities.DTO;

namespace PruebaLaboratorio.Controllers
{
    public class TecnicoController : Controller
    {
        private readonly ITecnicoRepository _tecnicoRepository;

        public TecnicoController(ITecnicoRepository tecnicoRepository)
        {
            _tecnicoRepository = tecnicoRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IEnumerable<TecnicoElementoDTO> GetAllTecnicosElementos()
        {
            return _tecnicoRepository.GetAllTecnicos();
        }

    }
}
