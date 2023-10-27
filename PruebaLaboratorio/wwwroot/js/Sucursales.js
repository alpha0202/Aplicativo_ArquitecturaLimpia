window.onload = function () {
    ListSucursales();
}


function ListSucursales() {
    pintar({
        url: "Sucursal/GetAllSucursales",
        cabeceras: ["Id","Nombre"],
        propiedades: ["sucursalId", "nombre"],
        propiedadId: "sucursalId",
        editar: false,
        eliminar: false,


    })


}