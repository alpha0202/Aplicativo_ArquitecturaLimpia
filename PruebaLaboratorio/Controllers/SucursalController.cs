using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using PruebaLaborario.Entities;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.EFCore.Repository;
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



        #region pruebas de acciones tecnicos
        //public Tecnico GetTecnicobyId(int id)
        //{
        //    var res = _tecnico.GetByIDTecnico(id);
        //    return res;
        //}

        //public List<Tecnico> GetAllTecnicos()
        //{
        //    var res = _tecnico.GetAllTecnicos();
        //    return res;
        //}

        //public List<Tecnico> FilterByNombreTecnico(string nombre)
        //{
        //    var data = _tecnico.FilterByNombreTecnico(nombre);
        //    return data;
        //}

        //public List<TecnicoElementoDTO> Tecnicos(TecnicoElementoDTO dto)
        //{
        //    var data = _tecnico.GetAllTecnicos().Select(a => new TecnicoElementoDTO
        //     {
        //         TecnicoId = a.TecnicoId,
        //         NombreTec = a.Nombre,
        //         CodigoTec = a.Codigo,
        //         SueldoBaseTec = (decimal)a.SueldoBase,
        //         SucursalNombre = a.Sucursal.Nombre,
        //         CantidadElementos = a.ElementosAsignados.Count


        //     }).ToList();

        //    return data;

        //}
        #endregion
    }
}
