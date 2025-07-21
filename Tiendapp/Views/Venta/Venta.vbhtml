@ModelType IEnumerable(Of Cliente)
@Code
    ViewData("Title") = "Venta"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code


<div class="card">
    <div class="card-body">
        <div class="row mb-3">
            <label class="col-form-label" for="cboCliente">Cliente</label>
            <div class="col-sm-12">
                <select class="form-select" id="cboCliente">
                    @For Each item In Model
                        @<option value="@item.ClienteID">@item.NombreApellido</option>
                    Next
                </select>
            </div>
        </div>

        <div class="row mb-3">
            <label class="col-form-label" for="txtFecha">Cliente</label>
            <div class="col-sm-12">
                <input id="txtFecha" class="form-control" type="date" />
            </div>
        </div>
    </div>
</div>
<div class="card">
    <div class="card-hader text-end">
        <button onclick="ListarProductos()" type="button" class="btn btn-success" data-bs-toggle="modal" data-bs-target="#exampleModal">
            Agregar
        </button>
    </div>
    <div class="card-body">
        <table class="table table-bordered" id="detalle">
            <thead>
                <tr>
                    <th>Producto</th>
                    <th>Precio</th>
                    <th>SubTotal</th>
                </tr>
            </thead>
            <tbody>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3" class="text-center">Total</td>
                    <td><h5 id="txtTotal">Gs. 0</h5></td>
                </tr>
            </tfoot>
        </table>
    </div>
    <button onclick="Guardar" class="btn btn-primary">Guardar</button>
</div>
<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h1 class="modal-title fs-5" id="exampleModalLabel">Agregar Product</h1>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <div class="row mb-3">
                    <label class="col-form-label" for="cboProducto">Producto</label>
                    <div class="col-sm-12">
                        <select id="cboProducto" class="form-select">
                        </select>
                    </div>
                </div>
                <div class="row mb-3">
                    <label class="col-form-label" for="txtCantidad">Cantidad</label>
                    <div class="col-sm-12">
                        <input type="number" id="txtCantidad" min="0" class="form-control" />
                    </div>
                </div>
            </div>
            <div class="modal-footer">
                <button id="btnCerrar" type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar</button>
                <button type="button" class="btn btn-primary" onclick="agregar_detalle()">Guardar</button>
            </div>
        </div>
    </div>
</div>

<div class="AlertaModal" tabindex="-1">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header">
                <h5 class="TituloAlerta">Modal title</h5>
                <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body">
                <p id="MensajeAlerta"></p>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Acceptar</button>
            </div>
        </div>
    </div>
</div>

<script src="~/scripts/js/jquery-3.7.1.min.js"></script>
<script src="~/scripts/js/Venta.js"></script>