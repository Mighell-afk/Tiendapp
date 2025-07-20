
@Code
    ViewData("Title") = "Index"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Create</title>
</head>
<body>
    <div>
        <h3>Crear Nueva Ciudad</h3>
        <form action="Create" method="post">
            <input type="text" name="txtDescripcion" />
            <br />
            <button type="submit">Guardar</button>
        </form>
    </div>
</body>
</html>
