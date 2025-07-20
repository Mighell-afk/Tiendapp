Imports System.Web.Mvc

Namespace Controllers
    Public Class CiudadController
        Inherits Controller

        Dim db As TiendaEntities = New TiendaEntities


        ' GET: Ciudad
        Function Index() As ActionResult
            Dim listCiudad As New List(Of Ciudad)
            listCiudad = db.Ciudad.ToList
            Return View(listCiudad)
        End Function



        ' CREAR UNA NUEVA CIUDAD
        Function Create() As ActionResult
            Return View()
        End Function

        <HttpPost>
        Function Create(form As FormCollection) As ActionResult
            Dim objCiudad As New Ciudad
            objCiudad.Nombre = form("txtDescripcion")

            db.Ciudad.Add(objCiudad)
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function

        ' EDITAR UNA CIUDAD
        Function Edit(id As Integer) As ActionResult
            Dim objCiudad As Ciudad = db.Ciudad.Find(id)
            Return View(objCiudad)
        End Function

        ' EDITAR UNA CIUDAD
        <HttpPost>
        Function Edit(objCiudad As Ciudad) As ActionResult
            If ModelState.IsValid Then
                db.Entry(objCiudad).State = Entity.EntityState.Modified
                db.SaveChanges()
                Return RedirectToAction("Index")
            End If
            Return View(objCiudad)
        End Function


        ' ELIMINAR UNA CIUDAD
        Function Delete(id As Integer) As ActionResult
            Dim objCiudad As New Ciudad
            objCiudad = db.Ciudad.Find(id)
            Return View(objCiudad)
        End Function

        <HttpPost>
        Function Delete(objCiudad As Ciudad) As ActionResult
            db.Entry(objCiudad).State = Entity.EntityState.Deleted
            db.SaveChanges()
            Return RedirectToAction("Index")
        End Function


        Function ListarCiudad() As JsonResult
            Dim ListadoCiudades = From cd In db.Ciudad
                                  Select New With {cd.CiudadID, cd.Nombre}

            Return New JsonResult With {.Data = ListadoCiudades, .JsonRequestBehavior = JsonRequestBehavior.AllowGet}
        End Function

    End Class
End Namespace