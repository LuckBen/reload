Imports ReloadWS.DAL
Imports ReloadWS.DTO
Public Module PaisesModule

    Public estado As Estado

    Sub New()
        estado = New Estado()
    End Sub

    Public Sub insertarPaises(ByVal paises As DTO.Pais())

        estado.iniciar()
        Try
            DAL.PaisesDB.insertarPaises(paises)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

    End Sub


End Module


