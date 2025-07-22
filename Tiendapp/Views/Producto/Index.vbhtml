@Modeltype IEnumerable(Of Producto)
@Code
    ViewData("Title") = "ListarProducto"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code

<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Producto</title>
</head>
<body class="bg-light">
    <div class="container mt-5">

        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2>Lista de Productos</h2>
            <a href="Producto/Create" class="btn btn-success">Crear Nuevo Producto</a>
        </div>

        <div class="card shadow">
            <div class="card-body">
                    <div id="DIVproducto">
                    </div>
            </div>
        </div>

    </div>

    <script src="~/scripts/js/jquery-3.7.1.min.js"></script>
    <script src="~/scripts/js/producto.js"></script>
</body>
</html>
