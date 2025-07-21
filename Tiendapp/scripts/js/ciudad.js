Listar();

function Listar() {
    $.get('/Ciudad/ListarCiudad', function (data) {
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
    contenido += "</tr>";

    var fila;

    for (var i = 0; i < data.length; i++) {
        fila = data[i];

        contenido += "<tr>";
        contenido += "<td>" + fila.CiudadID + "</td>";
        contenido += "<td>" + fila.Nombre + "</td>";
        contenido += "<td>" + `<a href='/Ciudad/Edit/${fila.CiudadID}' class='btn btn-primary'>Modificar</a> - <a href='/Ciudad/Delete/${fila.CiudadID}' class='btn btn-danger'>Eliminar</a>` + "</td>"
        contenido += "</tr>";
    }

    contenido += "</table>";

    document.getElementById("DIVciudad").innerHTML = contenido;
}


