Listar();

function Listar() {
    $.get('/Raza/ListarRazas', function (data) {
        crearListado(data);
    })
}

function crearListado(data) {

    var contenido = "";

    contenido += "<table class='table table-hover'>";
    contenido += "<tr>";
    contenido += "<th>Código</th>";
    contenido += "<th>Descripción</th>";
    contenido += "<th>Activo</th>";
    contenido += "</tr>";

    var fila;

    for (var i = 0; i < data.length; i++) {
        fila = data[i];

        contenido += "<tr>";
        contenido += "<td>" + fila.RazaID + "</td>";
        contenido += "<td>" + fila.Descripcion + "</td>";
        contenido += "<td>" + fila.EstaActivo + "</td>";
        contenido += "</tr>";
    }

    contenido += "</table>";

    document.getElementById("DIVRaza").innerHTML = contenido;
}

function Guardar() {

    var descripcion = document.getElementById('txtDescripcion').value;
    var estaActivo = document.getElementById('cboEstaActivo').value;
    var frm = new FormData();

    frm.append('Descripcion', descripcion);
    frm.append('EstaActivo', estaActivo);
    frm.append('RazaID', 0);

    $.ajax({
        type: 'POST',
        url: '/Raza/Guardar',
        processData: false,
        contentType: false,
        data: frm,
        success: function (data) {

            if (data == 0) {
                alert('Ocurrió un error');
            }
            else {
                alert('Registro guardado!');
                document.getElementById('btnCerrar').click();
                Listar();
            }
        }

    });
}