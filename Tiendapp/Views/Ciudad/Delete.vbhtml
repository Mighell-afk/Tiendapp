
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Delete</title>
</head>
<body>
    <div>
        <h3>Eliminar Ciudad</h3>
        <form action="Delete" method="post">
            <input type="hidden" name="CiudadID" value="@Model.CiudadID" />
            <p> Descripcion: "@Model.Nombre" </p>
            <br />
            <button type="submit">Eliminar</button>
        </form>
    </div>
</body>
</html>
