window.onload = function () {
    ListSucursales();
}


function ListSucursales() {
    pintar({
        url: "Sucursal/GetAllSucursales",
        cabeceras: ["Id","Nombre"],
        propiedades: ["SucursalId", "Nombre"],
        propiedadId: "SucursalId",
        editar: true,
        eliminar: true,


    })


}