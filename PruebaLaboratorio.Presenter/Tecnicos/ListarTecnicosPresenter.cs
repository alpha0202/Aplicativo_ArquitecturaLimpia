﻿using PruebaLaboratorio.Entities.Dto;
using PruebaLaboratorio.OutputPort.Tecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Presenter.Tecnicos
{
    public class ListarTecnicosPresenter : IListarTecnicosOutputPort, IPresenter<List<TecnicoElementoDTO>>
    {
        public List<TecnicoElementoDTO> Content {  get; private set; }

        public void Handler(List<TecnicoElementoDTO> dTOs)
        {
           Content = dTOs;
        }
    }
}
