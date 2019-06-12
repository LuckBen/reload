Imports ReloadWS

Public Module UsersModule

    Public estado As Security.Estado

    Sub New()
        estado = New Security.Estado()
    End Sub

    Public Function Logeo(ByVal loginRequest As DTO.Request.LoginRequest) As DTO.Response.LoginResponse

        Return New DTO.Response.LoginResponse()

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
