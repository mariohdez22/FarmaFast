
let enviarProducto = () =>
{
    let id = document.getElementById("HiddenId").value;
    let nombre = document.getElementById("HiddenNombre").value;
    let precio = document.getElementById("HiddenPrecio").value;

    document.querySelector('.inputId').value = id;
    document.querySelector('.inputProducto').value = nombre;
    document.querySelector('.inputPrecio').value = precio;
}

//---------------------------------------------------------------------------------------------------------------------------------------

const botonDetalle = document.getElementById("BtnAgregarProductos");

var num = 0

let val = 0

let AgregarDetalle = () =>
{
    let idproducto = document.querySelector('.inputId').value;
    let nombre = document.querySelector('.inputProducto').value;
    let precio = document.querySelector('.inputPrecio').value;
    let cantidad = document.querySelector('.inputCantidad').value;

    let ContenedorDatosDetalle = document.getElementById("ScrollDatosDetalle");

    //-------------------------------------------------------------------------------
    //creacion de los datos roleplay

    ContenedorDatosDetalle.innerHTML +=
    `
        <div id="DatosDetalle">

           <div id="CampoDetalleTitulo"><p>${nombre}</p></div>
           <div id="CampoDetalle"><p>${precio}</p></div>
           <div id="CampoDetalle"><p>${cantidad}</p></div>
           <div id="CampoDetalle"><p id="Subtotal[${num}]">${(parseFloat(cantidad) * parseFloat(precio)).toFixed(2)}</p></div>
           <a id="BtnEliminarDetalle" onclick="EliminarProducto(event)"><i class="bi bi-x-circle-fill"></i></a>

           <input name="DetalleVentas.Index" type="hidden" value="${num}">
           <input name="DetalleVentas[${num}].Idproducto" type="hidden" value="${idproducto}">
           <input name="DetalleVentas[${num}].Precio" type="hidden" value="${precio}">
           <input name="DetalleVentas[${num}].Cantidad" type="hidden" value="${cantidad}">

        </div>
    ` 

    val += parseFloat(document.getElementById(`Subtotal[${num}]`).innerHTML)
    document.getElementById("inputSubTotal").value = (val).toFixed(2);
    document.querySelector('.dataSubtotal').innerHTML = (val).toFixed(2);

    document.getElementById("inputTotal").value = (val * 1.13).toFixed(2);
    document.querySelector('.dataTotal').innerHTML = (val * 1.13).toFixed(2);

    //-------------------------------------------------------------------------------

    document.querySelector('.inputId').value = "";
    document.querySelector('.inputProducto').value = "";
    document.querySelector('.inputPrecio').value = "";
    document.querySelector('.inputCantidad').value = "";

    num++;

}

botonDetalle.addEventListener("click", () => {

    AgregarDetalle()

})

//---------------------------------------------------------------------------------------------------------------------------------------

let EliminarTodo = () =>
{
    const contenedor = document.getElementById("ScrollDatosDetalle")

    while (contenedor.firstChild) {
        contenedor.removeChild(contenedor.firstChild)
    }

    //---------------------------------------

    const nuevoTotal = val * 0

    document.getElementById("inputSubTotal").value = (nuevoTotal).toFixed(2);
    document.querySelector('.dataSubtotal').innerHTML = (nuevoTotal).toFixed(2);

    document.getElementById("inputTotal").value = (nuevoTotal).toFixed(2);
    document.querySelector('.dataTotal').innerHTML = (nuevoTotal).toFixed(2);
}    

//---------------------------------------------------------------------------------------------------------------------------------------

let EliminarProducto = (event) =>
{
    console.log("hola xd")

    const btnEliminar = event.target;

    const fila = btnEliminar.closest("#DatosDetalle");

    fila.parentNode.removeChild(fila);

    ////-------------------------------------

    const subtotal = fila.querySelector('#Subtotal')

    const nuevoTotal = val -= parseFloat(subtotal.textContent)

    document.getElementById("inputSubTotal").value = (nuevoTotal).toFixed(2);
    document.querySelector('.dataSubtotal').innerHTML = (nuevoTotal).toFixed(2);

    document.getElementById("inputTotal").value = (nuevoTotal * 1.13).toFixed(2);
    document.querySelector('.dataTotal').innerHTML = (nuevoTotal * 1.13).toFixed(2);
}

//---------------------------------------------------------------------------------------------------------------------------------------

let GeneradorCodigo = () =>
{
    let longitud = 6;
    let caracteres = 'ABCDEFGHIJKLMNOPQRSTUVWXYZ';
    let codigo = '';
    for (let i = 0; i < longitud; i++)
    {
        codigo += caracteres.charAt(Math.floor(Math.random() * caracteres.length));
    }
    return codigo;
}

document.addEventListener("DOMContentLoaded", function (event) {

    document.querySelector(".codigoVenta").value = GeneradorCodigo();

});