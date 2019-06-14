Public Class UsuariosConectados
    Private usuariosConectados As Dictionary(Of String, DTO.UsuarioConectado)
    Public Sub New()
        usuariosConectados = New Dictionary(Of String, DTO.UsuarioConectado)()
    End Sub

    Public Function agregar(ByVal user As DTO.Sujeto, ByVal token As String) As Boolean

        If (usuariosConectados.ContainsKey(user.codigo)) Then

            If (usuariosConectados(user.codigo).tokens.Contains(token)) Then

                Return False
            End If

            usuariosConectados(user.codigo).tokens.Add(token)
            Return True

        Else
            Dim userCon As New DTO.UsuarioConectado()
            userCon.emisionToken = DateTime.Now
            userCon.tokens.Add(token)
            userCon.usuario = user
            usuariosConectados.Add(user.codigo.ToUpper(), userCon)
            Return True
        End If
    End Function

    Public Sub quitarToken(ByVal usuario As String, ByVal token As String)
        usuario = usuario.ToUpper()
        If (existe(usuario)) Then
            SyncLock usuariosConectados
                usuariosConectados(usuario).tokens.Remove(token)
            End SyncLock
        End If


    End Sub

    Public Function existe(ByVal usuario As String) As Boolean
        Return usuariosConectados.ContainsKey(usuario)
    End Function

    Public Function obtenerUsuario(ByVal usuario As String) As DTO.Sujeto
        Return usuariosConectados(usuario).usuario
    End Function

    Public Function obtenerTokens(ByVal usuario As String) As List(Of String)


        Return usuariosConectados(usuario).tokens

    End Function

End Class
