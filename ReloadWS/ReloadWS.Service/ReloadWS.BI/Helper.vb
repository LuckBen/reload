Imports ReloadWS.Security

Imports System.Security.Cryptography
Imports System.IO
Imports System.ServiceModel.Channels
Imports System.ServiceModel
Imports System.ServiceModel.Web

Public Module Helper

    Dim tf As New TaskFactory()

    Sub New()

    End Sub
    Public Function obtenerCodigoEstadoHttp(ByVal estado As DTO.Estado) As Net.HttpStatusCode


        If (estado.hayError) Then

            Return IIf(estado.internalError, Net.HttpStatusCode.InternalServerError, Net.HttpStatusCode.BadRequest)

        Else
            Return Net.HttpStatusCode.OK
        End If


    End Function

    Private Sub enviarMail(ByVal destinatario As String, ByVal asunto As String, ByVal contenido As String)

        Dim mail As New DTO.cEmail()
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

        Try

            Dim path As String = System.IO.Directory.GetCurrentDirectory() + "\\plantillas\activarMail.html"
            Dim contenidoHtml As String = System.IO.File.ReadAllText(path).Replace("@mail@", destinatario)

            Dim asunto As String = System.Configuration.ConfigurationSettings.AppSettings("mail_asunto_activacion_mail").ToString()
            enviarMail(destinatario, asunto, contenidoHtml)

        Catch ex As Exception

        End Try


    End Sub

    Public Function getIPAddress() As String

        Dim context As OperationContext = OperationContext.Current
        Dim properties As MessageProperties = context.IncomingMessageProperties
        Dim remoteEndPoint As RemoteEndpointMessageProperty = properties(RemoteEndpointMessageProperty.Name)
        Return remoteEndPoint.Address

    End Function

    Public Function generarID() As String

        Dim r As New Random()

        Dim id As String = DateTime.Today.Year.ToString() &
                            DateTime.Today.Month.ToString() &
                            DateTime.Today.Day.ToString() &
                            DateTime.Now.TimeOfDay.Minutes.ToString() &
                            DateTime.Now.TimeOfDay.Seconds.ToString() &
                            r.Next(0, 1000).ToString()

        Return id
    End Function

    Public Function getToken() As String
        Return WebOperationContext.Current.IncomingRequest.Headers("Token")
    End Function

End Module
