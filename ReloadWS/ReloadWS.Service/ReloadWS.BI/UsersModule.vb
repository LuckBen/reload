Imports ReloadWS
Imports ReloadWS.DTO

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

            usuario = DAL.UsuariosService.obtenerUsuario(loginRequest.login)

            If IsNothing(usuario) Then
                Throw New DTO.InvalidDataException("El usuario no es correcto")
            End If

            If Not (usuario.password.ToUpper() = loginRequest.password.ToUpper()) Then
                Throw New DTO.InvalidDataException("La contraseña no es correcta")
            End If

            Dim token As String = TokenModule.generarToken(loginRequest.login)

            If (String.IsNullOrEmpty(token)) Then
                Throw New DTO.InvalidDataException("Error al generar token")
            End If

            respuesta.extra = token
            respuesta.estado = estado
            respuesta.contenido = usuario

            usuariosConectados.agregar(New DTO.Sujeto With {
                                          .codigo = usuario.codigo.ToUpper()
                                          }, token)

        Catch ex As DTO.InvalidDataException
            estado.capturarError(ex, False)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

        Return respuesta

    End Function

    Public Sub grabarInfo(ByVal username As String, ByVal info As UsuarioInfo)

        estado.iniciar()
        Try

            If (IsNothing(info) OrElse IsNothing(username)) Then
                Throw New InvalidDataException("Datos invalidos")
            End If

            DAL.UsuariosService.grabarInfo(username, info)

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

            If Not (IsNothing(DAL.UsuariosService.obtenerUsuario(registroRequest.usuario))) Then
                Throw New DTO.InvalidDataException("El usuario ya existe.")
            End If

            If Not (IsNothing(DAL.UsuariosService.obtenerUsuarioPorMail(registroRequest.mail))) Then
                Throw New DTO.InvalidDataException("El mail ya existe.")
            End If

            DAL.UsuariosService.grabar(New DTO.Usuario With {
                                       .codigo = registroRequest.usuario,
                                       .password = registroRequest.password,
                                       .mail = registroRequest.mail,
                                       .activo = False
                                   })

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

            DAL.UsuariosService.actualizarActivoPorMail(mail)

        Catch ex As DTO.InvalidDataException
            estado.capturarError(ex, False)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

    End Sub

End Module
