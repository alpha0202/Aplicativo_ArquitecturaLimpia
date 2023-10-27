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
        private readonly IFiltrarByIdTecnicoInportPort _inputPortById;
        private readonly IFiltrarByIdTecnicoOutputPort _outputPortById;
        private readonly IBorrarTecnicoInputPort _inputPortBorrar;
        private readonly IBorrarTecnicoOutputPort _outputPortBorrar;

        public TecnicoController(IListarTecnicosInputPort inputPortlistar,
                                 IListarTecnicosOutputPort outputPortList,
                                 IGuardarTecnicoInputPort inputPortGuardar,
                                 IGuardarTecnicoOutputPort outputPortGuardar,
                                 IFiltrarTecnicoInputPort inputPortFiltro,
                                 IFiltrarTecnicoOutputPort outputPortFiltro,
                                 IFiltrarByIdTecnicoInportPort inputPortById,
                                 IFiltrarByIdTecnicoOutputPort outputPortById,
                                 IBorrarTecnicoInputPort inputPortBorrar,
                                 IBorrarTecnicoOutputPort outputPortBorrar)
        {
            _inputPortlistar = inputPortlistar;
            _outputPortList = outputPortList;
            _inputPortGuardar = inputPortGuardar;
            _outputPortGuardar = outputPortGuardar;
            _inputPortFiltro = inputPortFiltro;
            _outputPortFiltro = outputPortFiltro;
            _inputPortById = inputPortById;
            _outputPortById = outputPortById;
            _inputPortBorrar = inputPortBorrar;
            _outputPortBorrar = outputPortBorrar;
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


        public int SaveTecnico(GuardarTecnicoDTO tecnico)
        {
           
            _inputPortGuardar.Handler(tecnico);
           return ((IPresenter<int>)_outputPortGuardar).Content;

            
        }

        public List<TecnicoElementoDTO> FilterByNombreTecnico(string nombre)
        {
            
           _inputPortFiltro.Handler(nombre);
            var res = ((IPresenter<List<TecnicoElementoDTO>>)_outputPortFiltro).Content;
            return res;
        }

        public FiltrarByIdDTO GetTecnicobyId(int idtecnico)
        {
            _inputPortById.Handler(idtecnico);
            var res = ((IPresenter<FiltrarByIdDTO>)_outputPortById).Content;
            return res;
        }

        public int BorrarTecnico(int idtecnico)
        {
            _inputPortBorrar.Handler(idtecnico);
            var res =((IPresenter<int>)_outputPortBorrar).Content;
            return res;
        }



    }
}
