Imports System.Web.Mvc

Namespace Controllers
    Public Class VentaController
        Inherits Controller

        Dim db As TiendaEntities = New TiendaEntities

        ' GET: Venta
        Function Index() As ActionResult
            Dim model As New VentaViewModel With {
                .Clientes = db.Cliente.ToList(),
                .TiposPago = db.TipoPago.ToList()
            }
            Return View(model)
        End Function
        Function ListarProductos() As JsonResult
            Dim ListadoProductos = From producto In db.Producto
                                   Select New With {producto.ProductoID, producto.Nombre, producto.Precio}
            Return New JsonResult With {.Data = ListadoProductos, .JsonRequestBehavior = JsonRequestBehavior.AllowGet}
        End Function

        <HttpPost>
        Function Guardar(ClienteID As Integer, TipoPagoID As Integer, Fecha As Date, Productos() As Integer, Cantidad() As Integer) As Integer
            Dim respuesta As Integer = 0

            Using Transaction As System.Data.Entity.DbContextTransaction = db.Database.BeginTransaction
                Try
                    ' Guardar Cabecera
                    Dim objVenta As New Venta
                    With objVenta
                        .ClienteID = ClienteID
                        .FechaVenta = Fecha
                        .TipoPagoID = TipoPagoID
                    End With
                    db.Venta.Add(objVenta)
                    db.SaveChanges()


                    For i As Integer = 0 To Productos.Length - 1
                        Dim objDetalle As New DetalleVenta
                        With objDetalle
                            .VentaID = objVenta.VentaID
                            .ProductoID = Productos(i)
                            .Cantidad = Cantidad(i)
                        End With
                        db.DetalleVenta.Add(objDetalle)
                        db.SaveChanges()
                    Next

                    Transaction.Commit()
                    respuesta = 1
                Catch ex As Exception
                    Transaction.Rollback()
                    respuesta = 0
                End Try
            End Using

            Return respuesta
        End Function


    End Class

    Public Class VentaViewModel
        Public Property Clientes As IEnumerable(Of Cliente)
        Public Property TiposPago As IEnumerable(Of TipoPago)
    End Class
End Namespace