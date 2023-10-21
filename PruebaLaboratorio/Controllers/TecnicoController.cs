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
        private readonly IGuardarTecnicoInputPort _inputPortGuardar;
        private readonly IGuardarTecnicoOutputPort _outputPortGuardar;
        private readonly IFiltrarTecnicoInputPort _inputPortFiltro;
        private readonly IFiltrarTecnicoOutputPort _outputPortFiltro;

        public TecnicoController(IListarTecnicosInputPort inputPortlistar,
                                 IListarTecnicosOutputPort outputPortList,
                                 IGuardarTecnicoInputPort inputPortGuardar,
                                 IGuardarTecnicoOutputPort outputPortGuardar,
                                 IFiltrarTecnicoInputPort inputPortFiltro,
                                 IFiltrarTecnicoOutputPort outputPortFiltro)
        {
            _inputPortlistar = inputPortlistar;
            _outputPortList = outputPortList;
            _inputPortGuardar = inputPortGuardar;
            _outputPortGuardar = outputPortGuardar;
            _inputPortFiltro = inputPortFiltro;
            _outputPortFiltro = outputPortFiltro;
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


        public bool SaveTecnico(GuardarTecnicoDTO tecnico)
        {
            bool res;
            _inputPortGuardar.Handler(tecnico);
            res = ((IPresenter<bool>)_outputPortGuardar).Content;

            return res;
        }

        public List<TecnicoElementoDTO> FilterByNombreTecnico(string nombre)
        {
            
           _inputPortFiltro.Handler(nombre);
            var res = ((IPresenter<List<TecnicoElementoDTO>>)_outputPortFiltro).Content;
            return res;
        }
    }
}
