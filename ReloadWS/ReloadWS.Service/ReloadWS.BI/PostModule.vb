Imports ReloadWS.DTO
Imports ReloadWS.DAL
Imports ReloadWS.DTO.Request

Public Module PostModule

    Public estado As Estado

    Public postsDestacados As List(Of DTO.PostDestacado)

    Sub New()
        estado = New Estado()
        cargarPostDestacados()
    End Sub

    Private Sub cargarPostDestacados()

        estado.iniciar()
        Try

            postsDestacados = New List(Of PostDestacado)()

            Dim postsMemoriaPuntos = Integer.Parse(System.Configuration.ConfigurationSettings.AppSettings("cuantos_posts_destacados_por_puntos_en_memoria"))
            Dim postsMemoriaComentarios = Integer.Parse(System.Configuration.ConfigurationSettings.AppSettings("cuantos_posts_destacados_por_comentarios_en_memoria"))
            Dim postsMemoriaRecientes = Integer.Parse(System.Configuration.ConfigurationSettings.AppSettings("cuantos_posts_destacados_por_recientes_en_memoria"))

            SyncLock postsDestacados

                postsDestacados.AddRange(DAL.PostDB.obtenerPostRecientes(postsMemoriaRecientes))
                postsDestacados.AddRange(DAL.PostDB.obtenerPostPorPuntos(postsMemoriaPuntos))
                postsDestacados.AddRange(DAL.PostDB.obtenerPostPorComentarios(postsMemoriaComentarios))

            End SyncLock

        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

    End Sub

    Private Sub verifyPost(post As Post)
        If (IsNothing(post)) Then
            Throw New InvalidDataException("El post no existe")
        End If

        If (IsNothing(post.propietario)) Then
            Throw New InvalidDataException("El propietario no existe")
        End If

        If (IsNothing(post.categoria)) Then
            Throw New InvalidDataException("No se especificó categoria")
        End If

        If (String.IsNullOrEmpty(post.titulo)) Then
            Throw New InvalidDataException("No se puede dejar el titulo vacio")
        End If

        If (String.IsNullOrEmpty(post.contenido)) Then
            Throw New InvalidDataException("Se debe especificar el contenido")
        End If

        If (IsNothing(post.tags) OrElse post.tags.Count = 0) Then
            Throw New InvalidDataException("Debe ingresar tags")
        End If
    End Sub

    Public Sub comment(commentary As Comentario)

        estado.iniciar()

        Try
            PostDB.comment(commentary)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

    End Sub

    Public Sub addPost(ByVal post As Post)

        estado.iniciar()
        Try

            verifyPost(post)

            assingDefaultValues(post)

            DAL.PostDB.addPost(post)

            DAL.UsuariosDB.addPost(post)

        Catch ex As InvalidDataException
            estado.capturarError(ex, False)

        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

    End Sub

    Private Sub assingDefaultValues(post As Post)
        post._id = Helper.generarID()
        post.favoritos = 0
        post.puntos = 0
        post.visitas = 0
        post.activo = True
        post.fechaAlta = DateTime.Now
        post.fechaModificacion = DateTime.Now

        If (post.contenido.Contains("<img")) Then
            post.contenido = post.contenido.Replace("<img src", "<img style='width: 100%' src")
        End If

        post.comentarios = New List(Of Comentario)()
    End Sub

    Public Sub deletePost(post As Post)

        estado.iniciar()
        Try
            If (String.IsNullOrEmpty(post._id)) Then
                Throw New NullReferenceException("No existe el post")
            End If

            PostDB.deletePost(post)
            UsuariosDB.deletePost(post)

        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try
    End Sub

    Public Function editPost(post As Post) As Post

        estado.iniciar()
        Dim ePost As New Post()

        Try

            If (String.IsNullOrEmpty(post._id)) Then
                Throw New NullReferenceException("id del post nulo")
            End If

            verifyPost(post)

            DAL.PostDB.editPost(post)
            DAL.UsuariosDB.editPost(post)

        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try

        Return ePost

    End Function

    Public Function getPost(idPost As String) As Post
        estado.iniciar()
        Try
            Return DAL.PostDB.getPost(idPost)
        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try
        Return Nothing
    End Function

    Public Function getRecientes() As Post()
        estado.iniciar()
        Try

            Return (From p In postsDestacados Where p.destaque = PostDestacado.TIPO_DESTAQUE.RECIENTE
                    Select p.post).ToArray()

        Catch ex As Exception
            estado.capturarError(ex, True)
        End Try
        Return Nothing

    End Function

    Public Function getPostDestacados(ByVal tipoDestaque As PostDestacado.TIPO_DESTAQUE) As Post()

        Return (From p In postsDestacados.Where(Function(x) x.destaque = tipoDestaque)
                Select p.post).ToArray()

    End Function
End Module
