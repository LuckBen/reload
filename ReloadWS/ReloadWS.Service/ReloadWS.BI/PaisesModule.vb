Imports ReloadWS.DAL.Api
Imports ReloadWS.DTO
Public Module PaisesModule

    Public estado As Estado

    Sub New()
        estado = New Estado()
    End Sub

    Public Sub insertarPaises()

        estado.iniciar()
        Try
            PaisesDB.insertarPaises()
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

    End Sub

    Public Function getPaises() As Pais()
        estado.iniciar()
        Try
            Return PaisesDB.getPaises()
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try
    End Function
End Module


