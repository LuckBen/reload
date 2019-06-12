Imports ReloadWS.Security
Public Module Helper

    Dim tf As New TaskFactory()

    Sub New()

    End Sub
    Public Function obtenerCodigoEstadoHttp(ByVal estado As Estado) As Net.HttpStatusCode


        If (estado.hayError) Then

            Return IIf(estado.internalError, Net.HttpStatusCode.InternalServerError, Net.HttpStatusCode.BadRequest)

        Else
            Return Net.HttpStatusCode.OK
        End If


    End Function

    Private Sub enviarMail(ByVal destinatario As String, ByVal contenido As String)

        Dim mail As New Security.cEmail()
        mail.Emisor = System.Configuration.ConfigurationSettings.AppSettings("mail_emisor").ToString()
        mail.PassEmisor = System.Configuration.ConfigurationSettings.AppSettings("mail_password").ToString()
        mail.Host = System.Configuration.ConfigurationSettings.AppSettings("mail_host").ToString()
        mail.Puerto = System.Configuration.ConfigurationSettings.AppSettings("mail_port").ToString()
        mail.Receptor = destinatario
        mail.Desarrollo = contenido
        mail.Html = True

        mail.Enviar()

    End Sub

    Public Sub enviarMailActivacionMail(ByVal destinatario As String)

        Dim path As String = System.IO.Directory.GetCurrentDirectory() + "\\plantillas\activarMail.html"
        Dim contenidoHtml As String = System.IO.File.ReadAllText(path).Replace("@mail@", destinatario)

        If (String.IsNullOrEmpty(contenidoHtml)) Then
            Throw New NullReferenceException("No hay contenido en la plantilla activarMail.html")
        End If

        tf.StartNew(Sub()
                        enviarMail(destinatario, contenidoHtml)
                    End Sub)

    End Sub

End Module
