using Microsoft.AspNetCore.Mvc;
using PruebaLaborario.Entities;
using PruebaLaboratorio.Entities.Interfaces;

namespace PruebaLaboratorio.Controllers
{
    public class ElementoController : Controller
    {
        private readonly IElementoRepository _elementoRepository;

        public ElementoController(IElementoRepository elementoRepository)
        {
            _elementoRepository = elementoRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        public List<Elemento> GetAllElementos()
        {
            var res =  _elementoRepository.GetAllElementos();

            return res;
        }

    }
}
