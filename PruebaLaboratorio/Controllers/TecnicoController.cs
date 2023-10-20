using Microsoft.AspNetCore.Mvc;
using PruebaLaborario.Entities;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.Entities.Dto;
using PruebaLaboratorio.InputPort.Tecnico;
using PruebaLaboratorio.OutputPort.Tecnico;
using PruebaLaboratorio.Presenter;

namespace PruebaLaboratorio.Controllers
{
    public class TecnicoController : Controller
    {
        private readonly IListarTecnicosInputPort _inputPortlistar;
        private readonly IListarTecnicosOutputPort _outputPortList;

        public TecnicoController(IListarTecnicosInputPort inputPortlistar, 
                                 IListarTecnicosOutputPort outputPortList )
        {
            _inputPortlistar = inputPortlistar;
            _outputPortList = outputPortList;
        }

        public IActionResult Index()
        {
            return View();
        }

        public List<TecnicoElementoDTO> GetAllTecnicosElementos()
        {
            _inputPortlistar.Handler();
            return ((IPresenter<List<TecnicoElementoDTO>>)_outputPortList).Content;
        }

     


    }
}
