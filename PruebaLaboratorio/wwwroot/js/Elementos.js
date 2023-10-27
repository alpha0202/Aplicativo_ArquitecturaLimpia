window.onload = function () {
    ListElementos();
}


function ListElementos() {
    pintar({
        url: "Elemento/GetAllElementos",
        cabeceras: ["Id", "Nombre"],
        propiedades: ["elementoId", "nombre"],
        propiedadId: "elementoId",
        editar: false,
        eliminar: false,


    })


}