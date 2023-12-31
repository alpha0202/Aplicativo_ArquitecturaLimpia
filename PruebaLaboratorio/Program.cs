using Microsoft.EntityFrameworkCore;
using PruebaLaborario.Entities.Interfaces;
using PruebaLaboratorio.EFCore;
using PruebaLaboratorio.EFCore.Repository;
using PruebaLaboratorio.Entities.Interfaces;
using PruebaLaboratorio.Interactor;
using PruebaLaboratorio.Presenter;
using System.Text.Json.Serialization;

namespace PruebaLaboratorio
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); ;

            //inyectar el dbContext 
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<LaboratorioDBContext>(options =>
                                                                options.UseSqlServer(connectionString));

            //inyectar la interfaz 
            builder.Services.AddScoped<ITecnicoRepository, TecnicoRepository>();
            builder.Services.AddScoped<ISucursalesRepository, SucursalesRepository>();
            builder.Services.AddScoped<IElementoRepository, ElementoRepository>();




            //inyectar context interactor
            builder.Services.DependencyInteractor();
            //inyectar context presenter
            builder.Services.DependencyPresenter();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Tecnico}/{action=Index}/{id?}");

            app.Run();
        }
    }
}