using Microsoft.AspNetCore.Mvc;
using PruebaLaborario.Entities;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.Entities.Dto;

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

        public List<Tecnico> GetAllTecnicosElementos()
        {
            return _tecnicoRepository.GetAllTecnicos();
        }

    }
}
