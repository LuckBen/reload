Imports ReloadWS

Public Module UsersModule


    Public Function Logeo(ByVal loginRequest As DTO.Request.LoginRequest) As DTO.Response.LoginResponse

        Return New DTO.Response.LoginResponse()

    End Function

    Public Sub Registro(ByVal registroRequest As DTO.Request.RegistroRequest)
        DAL.UsuariosService.grabar(New DTO.Usuario With {
                                   .codigo = registroRequest.usuario,
                                   .password = registroRequest.password
                                   })
    End Sub

End Module
