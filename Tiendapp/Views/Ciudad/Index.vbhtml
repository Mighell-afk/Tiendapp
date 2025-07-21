@Modeltype IEnumerable(Of Ciudad)
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code


<!-- Button trigger modal -->
<a href="/Ciudad/Create" class="btn btn-success">Crear Nueva Ciudad</a>


<div id="DIVciudad">

</div>

<script src="~/scripts/js/jquery-3.7.1.min.js"></script>
<script src="~/scripts/js/ciudad.js"></script>

@*<!DOCTYPE html>

    <html>
    <head>
        <meta name="viewport" content="width=device-width" />
        <title>Ciudad</title>
    </head>

    <body>
        <div>
            <h1>Modalidades</h1>
            <a href="Create">Crear Nueva Ciudad</a>
            <table border="1">
                <tr>
                    <th>Codigo</th>
                    <th>Descripcion</th>
                    <th>FechaAlta</th>
                </tr>
                @For Each items In Model
                    @<tr>
                        <td>@items.CiudadID</td>
                        <td>@items.Nombre</td>

                        <td>
                            <a href="Edit/@items.CiudadID">Modificar</a> -
                            <a href="Delete/@items.CiudadID">Eliminar</a>
                        </td>
                    </tr>
                Next

            </table>
        </div>
    </body>
    </html>*@
