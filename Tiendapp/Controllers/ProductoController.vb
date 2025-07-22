Imports System.Web.Mvc

Namespace Controllers
    Public Class ProductoController
        Inherits Controller

        Dim db As TiendaEntities = New TiendaEntities

        ' GET: Producto
        Function Index() As ActionResult
            Dim listProducto As New List(Of Producto)
            listProducto = db.Producto.ToList
            Return View(listProducto)
        End Function

        Function ListarProducto() As JsonResult
            Dim ListadoProducto = From p In db.Producto
                                  Select New With {
                              p.ProductoID,
                              p.Nombre,
                              p.Precio,
                              p.Stock,
                              .CategoriaNombre = If(p.CategoriaProducto IsNot Nothing, p.CategoriaProducto.Descripcion, "Sin categoría")
                          }
            Return Json(ListadoProducto, JsonRequestBehavior.AllowGet)
        End Function
        ' CREAR UNA NUEVO PRODUCTO
        Function Create() As ActionResult
            ViewBag.Categorias = db.CategoriaProducto.Where(Function(c) c.EstaActivo = "S").ToList()
            Return View()
        End Function

        <HttpPost>
        Function Create(form As FormCollection) As ActionResult
            Dim objProducto As New Producto
            objProducto.Nombre = form("txtDescripcion")
            objProducto.Precio = form("txtPrecio")
            objProducto.Stock = form("txtStock")
            objProducto.CategoriaID = form("CategoriaID")

            db.Producto.Add(objProducto)
            db.SaveChanges()
            Return RedirectToAction("")
        End Function
    End Class
End Namespace