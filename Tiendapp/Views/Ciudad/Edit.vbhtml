@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code

<!DOCTYPE html>
<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Editar Ciudad</title>
</head>
<body>
    <div>
        <h3>Editar Ciudad</h3>
        <form action="Edit" method="post">
            <input type="hidden" name="CiudadID" value="@Model.CiudadID" />

            <label>Descripción:</label>
            <input type="text" name="Nombre" value="@Model.Nombre" />

            <br /><br />
            <button type="submit">Guardar cambios</button>
        </form>
    </div>
</body>
</html>
