
@Code
    ViewData("Title") = "Crear Producto"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code


<!DOCTYPE html>

<html>
<head>
    <meta name="viewport" content="width=device-width" />
    <title>Nuevo Producto</title>
</head>
<body class="bg-light">

    <div class="container d-flex justify-content-center align-items-center" style="min-height: 100vh;">
        <div class="card shadow p-4" style="width: 400px;">
            <h3 class="text-center mb-4">Crear Nuevo Producto</h3>
            <form action="Create" method="post">
                <div class="mb-3">
                    <label for="txtDescripcion" class="form-label">Nombre</label>
                    <input type="text" id="txtDescripcion" name="txtDescripcion" class="form-control" placeholder="Ingresar nombre" autocomplete="off" required>
                </div>

                <div class="mb-3">
                    <label for="txtPrecio" class="form-label">Precio</label>
                    <input type="number" id="txtPrecio" name="txtPrecio" step="1" min="0" class="form-control" placeholder="Ingresar precio" required>
                </div>

                <div class="mb-3">
                    <label for="txtStock" class="form-label">Stock</label>
                    <input type="number" id="txtStock" name="txtStock" min="0" class="form-control" placeholder="Ingresar stock" required>
                </div>

                <div class="mb-3">
                    <label>Categoría</label>
                    <select id="CategoriaID" name="CategoriaID" class="form-select" required>
                        <option value="">Seleccione</option>
                        @Code
                            For Each cat In ViewBag.Categorias
                        End Code
                        <option value="@cat.CategoriaID">@cat.Descripcion</option>
                        @Code
                        Next
                        End Code
                    </select>
                </div>

                <button type="submit" class="btn btn-success w-100">Guardar</button>
            </form>
        </div>
    </div>

</body>
</html>
</html>
