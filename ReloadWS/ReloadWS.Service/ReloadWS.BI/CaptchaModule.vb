Imports ReloadWS.DAL

Public Module CaptchaModule

    Public Property estado As DTO.Estado
    Private Property listadoCaptchas As List(Of DTO.Captcha)
    Sub New()
        estado = New DTO.Estado()
        listadoCaptchas = getAll()
    End Sub
    Public Function getAll() As List(Of DTO.Captcha)

        Dim listado As New List(Of DTO.Captcha)()
        Try

            listado = CaptchaDB.getAll()

        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

        Return listado

    End Function

    Public Function getRandom() As DTO.Captcha

        Dim captcha As New DTO.Captcha()

        Try
            Dim random As New Random()
            captcha = listadoCaptchas(random.Next(0, listadoCaptchas.Count() - 1))
        Catch ex As Exception
            estado.capturarError(ex, True)

        End Try
        Return captcha

    End Function

End Module
