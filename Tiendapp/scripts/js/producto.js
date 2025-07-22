Listar();

function Listar() {
    $.get('/Producto/ListarProducto', function (data) {
        crearListado(data);
        console.log(data)
    })
}

function crearListado(data) {
    var contenido = "";

    contenido += "<table class='table table-hover'>";
    contenido += "<tr>";
    contenido += "<th>Código</th>";
    contenido += "<th>Nombre</th>";
    contenido += "<th>Precio</th>";
    contenido += "<th>Stock</th>";
    contenido += "<th>Categoría</th>";
    contenido += "<th>Acciones</th>";
    contenido += "</tr>";

    var fila;

    for (var i = 0; i < data.length; i++) {
        fila = data[i];

        contenido += "<tr>";
        contenido += "<td>" + fila.ProductoID + "</td>";
        contenido += "<td>" + fila.Nombre + "</td>";
        contenido += "<td>" + fila.Precio + "</td>";
        contenido += "<td>" + fila.Stock + "</td>";
        contenido += "<td>" + fila.CategoriaNombre + "</td>";
        contenido += "<td>" + `<a href='Edit/${fila.ProductoID}' class='btn btn-primary'>Modificar</a> - <a href='Delete/${fila.ProductoID}' class='btn btn-danger'>Eliminar</a>` + "</td>"
        contenido += "</tr>";
    }

    contenido += "</table>";

    document.getElementById("DIVproducto").innerHTML = contenido;
}


