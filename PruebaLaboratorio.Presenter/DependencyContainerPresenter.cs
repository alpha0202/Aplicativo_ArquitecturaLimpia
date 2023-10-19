using Microsoft.Extensions.DependencyInjection;
using PruebaLaboratorio.OutputPort.Tecnico;
using PruebaLaboratorio.Presenter.Tecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaLaboratorio.Presenter
{
    public static class DependencyContainerPresenter
    {
        public static IServiceCollection DependencyPresenter(this IServiceCollection services)
        {

            services.AddScoped<IListarTecnicosOutputPort, ListarTecnicosPresenter>();
            return services;
        }

    }
}
