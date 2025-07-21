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
