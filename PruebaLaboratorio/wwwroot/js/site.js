// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = function () {
    ListTecnicos();
}


function ListTecnicos() {
    pintar({
        url: "Tecnico/GetAllTecnicosElementos",
        cabeceras: ["Nombre", "Codigo", "Sueldo", "Sucursal","Cantidad Elementos"],
        propiedades: ["Nombre", "Codigo", "SueldoBase", "Sucursal", "CantidadElementos"],
        propiedadId: "TecnicoElementoId",
        editar: true,
        eliminar: true,


    })

    
}