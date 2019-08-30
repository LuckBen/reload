Imports ReloadWS.DAL.Api
Imports ReloadWS.DTO
Imports ReloadWS.DTO.Request

Public Module UsersModule

    Public estado As DTO.Estado
    Public usuariosConectados As UsuariosConectados
    Sub New()
        estado = New DTO.Estado()
        usuariosConectados = New UsuariosConectados()
    End Sub

    Public Function Logeo(ByVal loginRequest As DTO.Request.LoginRequest) As DTO.Response.Response(Of DTO.Usuario)

        estado.iniciar()
        Dim usuario As New DTO.Usuario
        Dim respuesta As New DTO.Response.Response(Of DTO.Usuario)()

        Try

            If (IsNothing(loginRequest)) Then
                Throw New InvalidDataException("No se especificaron datos")
            End If

            usuario = UsuariosDB.obtenerUsuario(loginRequest.login)

            If IsNothing(usuario) Then
                Throw New DTO.InvalidDataException("El usuario no es correcto")
            End If

            If Not (usuario.password.ToUpper() = loginRequest.password.ToUpper()) Then
                Throw New DTO.InvalidDataException("La contraseña no es correcta")
            End If

            If Not (usuario.activo) Then
                Throw New DTO.InvalidDataException("Debe activar la cuenta, revise su email")
            End If

            Dim token As String = TokenModule.generarToken(loginRequest.login)

            If (String.IsNullOrEmpty(token)) Then
                Throw New DTO.InvalidDataException("Error al generar token")
            End If

            respuesta.extra = token
            respuesta.estado = estado
            respuesta.contenido = usuario

            usuariosConectados.agregar(New DTO.Sujeto With {
                                          .id = usuario.id,
                                          .codigo = usuario.codigo.ToUpper()
                                          }, token)

        Catch ex As DTO.InvalidDataException
            estado.capturarError(ex, False)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

        Return respuesta

    End Function

    Public Sub cambiarClave(requestCambioClave As Request(Of RequestCambioClave))

        estado.iniciar()
        Try
            If (IsNothing(requestCambioClave)) Then
                Return
            End If

            Dim usuario = UsuariosDB.obtenerUsuario(requestCambioClave.usuario)

            If (IsNothing(usuario)) Then
                Throw New InvalidDataException("Usuario inexistente")
            End If

            If (String.IsNullOrEmpty(requestCambioClave.contenido.claveActual) OrElse String.IsNullOrEmpty(requestCambioClave.contenido.claveNueva)) Then
                Throw New InvalidDataException("Debe ingresar la clave")
            End If

            If Not (usuario.password.Equals(requestCambioClave.contenido.claveActual)) Then
                Throw New InvalidDataException("La clave no es correcta")
            End If

            UsuariosDB.grabarClave(usuario.codigo, requestCambioClave.contenido.claveNueva)

            estado.mensaje = "Clave actualizada con éxito!"

        Catch ex As InvalidDataException
            estado.capturarError(ex, False)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try
    End Sub

    Public Function obtenerUsuario(obtenerUsuarioRequest As Request(Of String)) As Usuario
        estado.iniciar()
        Try

            If (IsNothing(obtenerUsuarioRequest)) Then
                Throw New InvalidDataException("No se especifico usuario")
            End If

            Return UsuariosDB.obtenerUsuario(obtenerUsuarioRequest.contenido)

        Catch ex As InvalidDataException
            estado.capturarError(ex, False)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try
    End Function

    Public Sub grabarMail(usuarioCodigo As String, mail As String)
        estado.iniciar()
        Try
            Dim usuario = UsuariosDB.obtenerUsuarioPorMail(mail)

            Try
                Dim mailAddress = New System.Net.Mail.MailAddress(mail)
            Catch ex As Exception
                Throw New InvalidDataException("El mail no es valido")
            End Try

            If (Not IsNothing(usuario) AndAlso usuario.codigo <> usuarioCodigo) Then
                Throw New InvalidDataException("El mail está en uso")
            End If

            UsuariosDB.grabarMail(usuarioCodigo, mail)
        Catch ex As InvalidDataException
            estado.capturarError(ex, False)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try
    End Sub

    Public Sub grabarInfo(ByVal username As String, ByVal info As UsuarioInfo)

        estado.iniciar()
        Try

            If (IsNothing(info) OrElse IsNothing(username)) Then
                Throw New InvalidDataException("Datos invalidos")
            End If

            UsuariosDB.grabarInfo(username, info)

        Catch ex As InvalidDataException
            estado.capturarError(ex, False)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try


    End Sub

    Public Sub Registro(ByVal registroRequest As DTO.Request.RegistroRequest)

        estado.iniciar()

        Try

            If (IsNothing(registroRequest)) Then
                Throw New DTO.InvalidDataException("No se especificaron datos")
            End If

            If (String.IsNullOrEmpty(registroRequest.usuario)) Then
                Throw New DTO.InvalidDataException("No se especifico nombre ")
            End If

            If (String.IsNullOrEmpty(registroRequest.password)) Then
                Throw New DTO.InvalidDataException("No se especifico password")
            End If

            If Not (IsNothing(UsuariosDB.obtenerUsuario(registroRequest.usuario))) Then
                Throw New DTO.InvalidDataException("El usuario ya existe.")
            End If

            If Not (IsNothing(UsuariosDB.obtenerUsuarioPorMail(registroRequest.mail))) Then
                Throw New DTO.InvalidDataException("El mail ya existe.")
            End If

            Try
                Dim dirCorreo As New System.Net.Mail.MailAddress(registroRequest.mail)

            Catch ex As Exception
                Throw New InvalidDataException("El mail no es válido")
            End Try

            Dim rango = BI.RangosModule.getRangos().Where(Function(x) x.puntosRequeridos = 0).FirstOrDefault()

            Dim usuario = New DTO.Usuario With {
                                       .id = Helper.generarID(),
                                       .codigo = registroRequest.usuario,
                                       .password = registroRequest.password,
                                       .mail = registroRequest.mail,
                                       .activo = False,
                                       .info = New UsuarioInfo With {
                                       .fechaAlta = DateTime.Now.ToShortDateString()
                                        },
                                        .rango = rango
                                   }

            UsuariosDB.grabar(usuario)

            estado.mensaje = "Registrado satisfactoriamente, verifique su mail!"

        Catch ex As DTO.InvalidDataException

            estado.capturarError(ex, False)

        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

    End Sub


    ''' <summary>
    ''' verificar el mail 
    ''' </summary>
    ''' <param name="mail"></param>
    Public Sub verificarMail(ByVal mail As String)

        estado.iniciar()
        Try

            If (String.IsNullOrEmpty(mail)) Then
                Throw New DTO.InvalidDataException("Mail no especificado")
            End If

            UsuariosDB.actualizarActivoPorMail(mail)

        Catch ex As DTO.InvalidDataException
            estado.capturarError(ex, False)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

    End Sub

End Module
