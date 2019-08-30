Imports ReloadWS.DTO
Imports ReloadWS.DAL.Api
Imports ReloadWS.DTO.Request

Public Module RangosModule
    Public estado As Estado

    Private Property Rangos As List(Of DTO.Rango)

    Sub New()
        estado = New Estado()
        Rangos = RangoDB.GetAll().ToList()
    End Sub

    Public Function getRangos() As Rango()

        Return Rangos.ToArray()

        'Dim rang As New List(Of Rango)()

        'DAL.RangoDB.addRango()

        'Return rang.ToArray()

    End Function

End Module
