using Microsoft.Extensions.DependencyInjection;
using PruebaLaboratorio.InputPort.Tecnico;
using PruebaLaboratorio.Interactor.Tecnico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Interactor
{
    public static class DependencyContainerInteractor
    {
        public static IServiceCollection DependencyInteractor(this IServiceCollection services)
        {
            services.AddScoped<IListarTecnicosInputPort, ListarTecnicoInteractor>();
            services.AddScoped<IGuardarTecnicoInputPort, GuardarTecnicoInteractor>();
            services.AddScoped<IFiltrarTecnicoInputPort, FiltrarTecnicoInteractor>();
            services.AddScoped<IFiltrarByIdTecnicoInportPort, FiltrarByIdTecnicoInteractor>();
            services.AddScoped<IBorrarTecnicoInputPort, BorrarTecnicoInteractor>();

            return services;
        }

    }
}
