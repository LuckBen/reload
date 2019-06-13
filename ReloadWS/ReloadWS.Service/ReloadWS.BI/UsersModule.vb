Imports ReloadWS

Public Module UsersModule

    Public estado As Security.Estado
    Public usuariosConectados As Dictionary(Of String, DTO.UsuarioConectado)

    Sub New()
        estado = New Security.Estado()
    End Sub

    Public Function Logeo(ByVal loginRequest As DTO.Request.LoginRequest) As DTO.Usuario

        estado.iniciar()
        Dim usuario As New DTO.Usuario

        Try

            usuario = DAL.UsuariosService.obtenerUsuario(loginRequest.login)

            If Not IsNothing(usuario) Then
                If (usuario.password.ToUpper() = loginRequest.password.ToUpper()) Then

                Else
                    Throw New NullReferenceException("La contraseña no es correcta")
                End If
            Else
                Throw New NullReferenceException("El usuario no es correcto")
            End If

        Catch ex As NullReferenceException
            estado.capturarError(ex.Message, False)
        Catch ex As Exception
            estado.capturarError("Ocurrió un error inesperado", True)
        End Try

        Return usuario

    End Function

    Public Sub Registro(ByVal registroRequest As DTO.Request.RegistroRequest)

        estado.iniciar()

        Try

            If (IsNothing(registroRequest)) Then
                Throw New NullReferenceException("No se especificaron datos")
            End If

            If (String.IsNullOrEmpty(registroRequest.usuario)) Then
                Throw New NullReferenceException("No se especifico nombre ")
            End If

            If (String.IsNullOrEmpty(registroRequest.password)) Then
                Throw New NullReferenceException("No se especifico password")
            End If

            If Not (IsNothing(DAL.UsuariosService.obtenerUsuario(registroRequest.usuario))) Then
                Throw New SyntaxErrorException("El usuario ya existe.")
            End If

            If Not (IsNothing(DAL.UsuariosService.obtenerUsuarioPorMail(registroRequest.mail))) Then
                Throw New SyntaxErrorException("El mail ya existe.")
            End If

            DAL.UsuariosService.grabar(New DTO.Usuario With {
                                       .codigo = registroRequest.usuario,
                                       .password = registroRequest.password,
                                       .mail = registroRequest.mail,
                                       .activo = False
                                   })

        Catch ex As SyntaxErrorException

            estado.capturarError(ex.Message, False)

        Catch ex As Exception
            estado.capturarError("Ocurrió un error inesperado", True)
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
                Throw New NullReferenceException("Mail no especificado")
            End If

            DAL.UsuariosService.actualizarActivoPorMail(mail)

        Catch ex As NullReferenceException
            estado.capturarError(ex.Message, False)
        Catch ex As Exception
            estado.capturarError("Ocurrió un error inesperado", True)
        End Try

    End Sub

End Module
