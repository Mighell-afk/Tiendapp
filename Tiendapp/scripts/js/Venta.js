let detalleVenta = {
    cont: 0,
    total: 0,
    productos: [],
    cantidades: [],
    subtotales: []
};

let precio = 0;

$('#cboProducto').ready(function () {
    precio = $('#cboProducto option:selected').data("precio");
});

$('#cboProducto').change(function () {
    precio = $('option:selected', this).data("precio");
});

function mensajeAlerta(titulo, mensaje) {
    $('#TituloAlerta').text(titulo);
    $('#MensajeAlerta').text(mensaje);
    $('#AlertaModal').modal('show');
}

function agregar_detalle() {
    let producto_id = document.getElementById('cboProducto').value
    const descripcion = $('#cboProducto option:selected').text();
    const cantidad = parseInt($('#txtCantidad').val());

    if (producto_id === '#') {
        mensajeAlerta("Atención", "Debe seleccionar un Producto");
        return;
    }

    if (!cantidad || cantidad <= 0) {
        mensajeAlerta("Atención", "Debe ingresar una cantidad válida");
        return;
    }

    const subtotal = precio * cantidad;

    detalleVenta.productos.push(producto_id);
    detalleVenta.cantidades.push(cantidad);
    detalleVenta.subtotales.push(subtotal);
    detalleVenta.total += subtotal;

    const row = `
        <tr id="fila-${detalleVenta.cont}">
            <td>${descripcion}</td>
            <td>${precio}</td>
            <td>${cantidad}</td>
            <td>${subtotal}</td>
        </tr>
    `;

    $('#detalle').append(row);

    detalleVenta.cont++;
    $('#txtTotal').text(detalleVenta.total);
    $('#btnCerrar').click();
    $('#txtCantidad').val(0);
}

function ListarProductos() {
    $.get('/Venta/ListarProductos', crearComboProductos);
}

function crearComboProductos(data) {
    console.log(data)
    let contenido = `<option data-precio="0" value="#">-- Seleccione un Producto --</option>`;

    data.forEach(fila => {
        contenido += `<option data-precio="${fila.Precio}" value="${fila.ProductoID}">${fila.Nombre}</option>`;
    });

    $('#cboProducto').html(contenido);
}

function EliminarDetalleVenta() {
    for (let i = 0; i < detalleVenta.cont; i++) {
        $(`#fila-${i}`).remove();
    }

    detalleVenta = {
        cont: 0,
        total: 0,
        productos: [],
        tipoPagos: [],
        cantidades: [],
        subtotales: []
    };

    $('#txtTotal').text(0);
}

function Guardar() {
    const clienteId = $('#cboCliente').val();
    const tipoPago_id = $('#cboTipoPago').val();
    const fecha = $('#txtFecha').val();

    if (!clienteId) {
        mensajeAlerta("Atención", "Debe seleccionar un Cliente");
        return;
    }

    if (!fecha) {
        mensajeAlerta("Atención", "Debe seleccionar la fecha");
        return;
    }

    if (detalleVenta.productos.length === 0) {
        mensajeAlerta("Atención", "Debe agregar al menos un producto");
        return;
    }

    $.ajax({
        type: 'POST',
        url: '/Venta/Guardar/',
        processData: false,
        contentType: false,
        headers: { "Content-Type": "application/json" },
        data: JSON.stringify({
            ClienteID: clienteId,
            TipoPagoID: tipoPago_id,
            Fecha: fecha,
            Productos: detalleVenta.productos,
            Cantidad: detalleVenta.cantidades,
        }),
        success: function (data) {
            if (data == 0) {
                alert('Ocurrió un error');
            } else {
                alert('Registro guardado!');
                EliminarDetalleVenta();
            }
        }
    });
}


/////PARTE LISTA DE VENTAS CLIENTES

async function obtenerVenta() {
    const id = document.getElementById("inputventa").value

    $.ajax({
        type: 'GET',
        url: '/Venta/RecuperarVenta/' + id,
        success: function (data) {
            // Validamos si hay al menos un producto en la respuesta
            if (!data.venta || data.detalleventa.length === 0) {
                alert("⚠️ No se encontró un producto con el código ingresado.");
                return;
            }

            console.log(data.detalleventa);
            añadirDetalleVenta(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("❌ Error al recuperar el producto: " + jqXHR.status + " - " + jqXHR.statusText);
            console.error("Detalles del error:", errorThrown, jqXHR.responseText);
        }
    });
}
function obtenerVentasCliente() {
    let id = document.getElementById("txtcliente").value
    console.log("Código ingresado: " + id);

    $.ajax({
        type: 'GET',
        url: '/Venta/ObtenerVentasConCliente/' + id,
        success: function (data) {
            // Validamos si hay al menos un producto en la respuesta
            if (!data || data.length === 0) {
                alert("⚠️ No se encontró un producto con el código ingresado.");
                return
            }

            cargarventascliente(data)
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("❌ Error al recuperar el producto: " + jqXHR.status + " - " + jqXHR.statusText);
            console.error("Detalles del error:", errorThrown, jqXHR.responseText);
            return
        }
    });
}



async function cargarventascliente(data) {

    var contenido = "";

    contenido += "<table class='table table-hover'>";
    contenido += "<tr>";
    contenido += "<th></th>";
    contenido += "<th>ClienteID</th>";
    contenido += "<th>VentaID</th>";
    contenido += "<th>FechaVenta</th>";
    contenido += "</tr>";

    var fila;

    for (var i = 0; i < data.length; i++) {
        fila = data[i];
        console.log("FILA ", fila)

        contenido += `<tr>`;
        contenido += `<td><a onclick="obtenerVenta('${fila.VentaID}')">Seleccionar</a></td>`;
        contenido += "<td>" + fila.ClienteID + "</td>";
        contenido += "<td>" + fila.VentaID + "</td>";
        contenido += "<td>" + fila.FechaVenta + "</td>";

        contenido += "</tr>";
    }

    contenido += "</table>";

    document.getElementById("listaVentas").innerHTML = contenido;


}

async function obtenerVenta(idventa) {
    var id


    if (!idventa) {
        id = document.getElementById("inputventa").value
    } else {
        id = idventa

    }

    console.log(idventa)
    console.log(id)


    $.ajax({
        type: 'GET',
        url: '/Venta/RecuperarVenta/' + id,
        success: function (data) {
            // Validamos si hay al menos un producto en la respuesta
            if (!data.venta || data.detalleventa.length === 0) {
                alert("⚠️ No se encontró un producto con el código ingresado.");
                return;
            }

            console.log(data.detalleventa);
            añadirDetalleVenta(data);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert("❌ Error al recuperar el producto: " + jqXHR.status + " - " + jqXHR.statusText);
            console.error("Detalles del error:", errorThrown, jqXHR.responseText);
        }
    });
}

function añadirDetalleVenta(data) {
    const tbody = document.getElementById("tbody");
    tbody.innerHTML = ""
    var cantidadarticulos = 0
    var montototal = 0

    for (let i = 0; i < data.detalleventa.length; i++) {

        const nuevaFila = document.createElement("tr");


        nuevaFila.innerHTML = `
            <td>${data.detalleventa[i].ProductoID}</td>
            <td>${data.detalleventa[i].Nombre}</td>
            <td>${data.detalleventa[i].Precio}</td>
             <td>${data.detalleventa[i].Stock}</td>
            <td>${data.detalleventa[i].Cantidad}</td>
        `;
        cantidadarticulos += data.detalleventa[i].Cantidad
        montototal += (data.detalleventa[i].Precio * data.detalleventa[i].Cantidad)
        tbody.appendChild(nuevaFila);


    }
    document.getElementById("txtclienteDetalle").innerText = `Cliente: ${data.venta.ClienteID}`
    document.getElementById("totalMonto").innerText = `₲ ${montototal}`
    document.getElementById("totalItems").innerText = cantidadarticulos

}
