@Code
    ViewData("Title") = "VentasPorCliente"
    Layout = "~/Views/Plantillas/Dashboard.vbhtml"
End Code


<!-- CABECERA DE LA VENTA -->
<div class="card mb-3">
    <div class="card-body d-flex align-items-center">
        <label id="txtclienteDetalle" class="me-3 mb-0">Cliente: </label>

        <label class="me-3 mb-0">Venta: <input id="inputventa" type="text"  placeholder="Ingrese el ID de venta"   class="form-control form-control-sm d-inline-block" style="width: 200px;"></label>
        <div>
            <button id="btnBuscarVenta" onclick="obtenerVenta()" data-toggle="modal" data-target="#modalproducto" class="btn btn-primary">Buscar Venta    </button>
            <button id="btnBuscarVentaCliente" onclick="$('#modalcliente').modal('show')" data-toggle="modal" data-target="#modalproducto" class="btn btn-primary">Buscar Ventas Cliente    </button>
        </div>
    </div>
</div>

<!-- TABLA DE PRODUCTOS -->
<div class="card flex-grow-1 mb-3" style="overflow-y: auto; max-height: 60vh;">
    <table class="table table-bordered table-hover mb-0">
        <thead class="table-dark sticky-top">
            <tr>
                <th>ID PRODUCTO</th>
                <th>NOMBRE</th>
                <th>PRECIO</th>
                <th>STOCK</th>
                <th>CANTIDAD</th>
            </tr>
        </thead>
        <tbody id="tbody">
        </tbody>
    </table>
</div>

<!-- FOOTER FIJO -->
<div class="card">
    <div class="card-body d-flex justify-content-between">
        <div>Total de artículos: <span id="totalItems">0</span></div>
        <div>Monto total: <span id="totalMonto">₲0</span></div>
    </div>


</div>


<!-- Modal CLIENTE -->
<div class="modal fade" id="modalcliente" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
    <div class="modal-dialog modal-lg" role="document">
        <div class="modal-content"> 
            <div class="modal-header">
                <h5 class="modal-title" id="modalLabel">Buscar Ventas</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Cerrar">
                    <span aria-hidden="true">&times;</span>
                </button>
            </div>
            <div class="modal-body">
                <button onclick="obtenerVentasCliente()" id="btnCargarProductos" class="btn btn-primary mb-3">Cargar Ventas Cliente</button>
                <input id="txtcliente" class="form-control mb-3" type="search" placeholder="Buscar Cliente..." />
                <div id="listaVentas" style="max-height:300px; overflow-y:auto; border:1px solid #ccc; padding:10px;">
                    <!-- Productos cargados aquí -->
                </div>
            </div>
            <div class="modal-footer">
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>

<script src="@Url.Content("~/scripts/js/Venta.js")"></script>
