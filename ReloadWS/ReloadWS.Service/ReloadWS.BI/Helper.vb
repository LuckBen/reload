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

    Private Sub enviarMail(ByVal destinatario As String, ByVal asunto As String, ByVal contenido As String)

        Dim mail As New Security.cEmail()
        mail.Emisor = System.Configuration.ConfigurationSettings.AppSettings("mail_emisor").ToString()
        mail.PassEmisor = System.Configuration.ConfigurationSettings.AppSettings("mail_password").ToString()
        mail.Host = System.Configuration.ConfigurationSettings.AppSettings("mail_host").ToString()
        mail.Puerto = System.Configuration.ConfigurationSettings.AppSettings("mail_port").ToString()
        mail.Receptor = destinatario
        mail.Asunto = asunto
        mail.Desarrollo = contenido
        mail.Html = True

        tf.StartNew(Sub()
                        mail.Enviar()
                    End Sub)

    End Sub

    Public Sub enviarMailActivacionMail(ByVal destinatario As String)

        Dim path As String = System.IO.Directory.GetCurrentDirectory() + "\\plantillas\activarMail.html"
        Dim contenidoHtml As String = System.IO.File.ReadAllText(path).Replace("@mail@", destinatario)

        If (String.IsNullOrEmpty(contenidoHtml)) Then
            Throw New NullReferenceException("No hay contenido en la plantilla activarMail.html")
        End If

        Dim asunto As String = System.Configuration.ConfigurationSettings.AppSettings("mail_asunto_activacion_mail").ToString()
        enviarMail(destinatario,asunto, contenidoHtml)


    End Sub

End Module
