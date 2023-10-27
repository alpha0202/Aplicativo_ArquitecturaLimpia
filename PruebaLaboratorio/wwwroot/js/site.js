// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

window.onload = function () {
    ListTecnicos();
}


async function ListTecnicos() {
    var sucursales = await fetchGet("Sucursal/GetAllSucursales", "json", null, true)
    var elementos = await fetchGet("Elemento/GetAllElementos", "json", null, true)
    pintar({
        url: "Tecnico/GetAllTecnicosElementos",
        cabeceras: ["Nombre", "Codigo", "Sueldo", "Sucursal", "Total Elementos Asinados"],
        propiedades: ["nombreTec", "codigoTec", "sueldoBaseTec", "sucursalNombre", "cantidadElementos"],
        propiedadId: "tecnicoId",
        editar: true,
        eliminar: true,
        urleliminar: "Tecnico/BorrarTecnico",
        nombreparametroeliminar: "idtecnico",
        popup: true,
        titlePopup: "Tecnico"


    },
        {
            url: "Tecnico/FilterByNombreTecnico",
            formulario: [
                [
                    {
                        class: "col-md-6",
                        label: "Filtrar nombre tecnico",
                        type: "text",
                        name: "nombre"
                    }
                ]
            ]

        },
        {
            type: "popup",
            urlguardar: "Tecnico/SaveTecnico",
            urlrecuperar: "Tecnico/GetTecnicobyId",
            parametrorecuperar: "idtecnico",
            formulario: [
                [
                    {
                        class: "d-none",
                        label: "Id Tecnico",
                        type: "text",
                        name: "idtecnico"
                    },
                    {
                        class: "col-md-6",
                        label: "Nombre Tecnico",
                        type: "text",
                        name: "nombretec",
                        classControl: "ob max-200"
                    },
                    {
                        class: "col-md-6",
                        label: "Codigo",
                        type: "text",
                        name: "codigotec",
                        classControl: "ob sln"
                    },
                    {
                        class: "col-md-6",
                        label: "Sueldo",
                        type: "number",
                        name: "sueldobasetec",
                        classControl: "ob snyd"
                    },
                    {
                        class: "col-md-6",
                        label: "Seleccione Sucursal",
                        type: "combobox",
                        name: "sucursalid",
                        data: sucursales,
                        id: "cboSucursales",
                        propiedadmostrar: "nombre",
                        valuemostrar: "sucursalId",
                        classControl: "ob"

                    },
                    {
                        class: "col-md-6",
                        label: "Seleccione Elemento",
                        type: "combobox",
                        name: "elementoid",
                        data: elementos,
                        id: "cboElementos",
                        propiedadmostrar: "nombre",
                        valuemostrar: "elementoId",
                        classControl: "ob"

                    },
                    {
                        class: "col-md-6",
                        label: "cantidad por elementos",
                        type: "number",
                        name: "cantidadelementos",
                        classControl: "ob snyd max-10 "
                    },

                ]
            ]
        },



    )









}






function validarNumero(input) {
    // Obtén el valor del campo de entrada como un número
    const numero = parseFloat(input.value);

    // Verifica si es un número válido
    if (!isNaN(numero)) {
        if (numero >= 1 && numero <= 10) {

            return true;
        } else {

            alert("Por favor, ingresa un número entre 1 y 10.");
            input.value = '';
            return false;
        }
    } else {
        alert("Por favor, ingresa un número válido.");
        input.value = '';
        return false;
    }
}

function Editar(id) {
    alert(id)
    LimpiarDatos("frmGuardar");
    document.getElementById("btnNuevo").click();
    document.getElementById("lblTitulo").innerHTML = "Editar Tecnico";
    set("txtIdTecnico", id)
    recuperarGenerico("Sucursal/GetTecnicobyId/?id=" + id, "frmGuardar")
}
function Nuevo() {
    LimpiarDatos("frmGuardar");
    document.getElementById("lblTitulo").innerHTML = "Nuevo Tecnico";
}

function Limpiar() {
    set("nombre", "");
    ListTecnicos();
}




