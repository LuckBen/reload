Imports ReloadWS.DTO
Public Module CacheModule

    Private Elements As List(Of CacheComponent)
    Private tmrCache As System.Timers.Timer
    Sub New()
        Elements = New List(Of CacheComponent)()
        'tmrCache = New Timers.Timer(60000)
        'AddHandler tmrCache.Elapsed, AddressOf verifyElements
        'tmrCache.Start()
    End Sub

    Sub verifyElements()

        Dim minutesCache As Integer = Integer.Parse(System.Configuration.ConfigurationSettings.AppSettings("minutos_cache").ToString())

        SyncLock Elements

            Elements.RemoveAll(Function(x) (DateTime.Now - x.tiempo).TotalMinutes > minutesCache)

        End SyncLock

    End Sub

    Public Sub setElement(ByVal id As String, ByVal element As Object)
        Try
            Dim cacheElement As New CacheComponent()
            cacheElement.id = id
            cacheElement.objeto = element
            cacheElement.tiempo = DateTime.Now
            cacheElement.tipo = element.GetType()
        Catch ex As Exception

        End Try
    End Sub

    Public Function getElementInCache(ByVal id As String, ByVal tipo As Type) As Object

        Try
            Dim elemento = Elements.Single(Function(x) x.id.Equals(id) AndAlso x.tipo = tipo).objeto

            Return elemento

        Catch ex As Exception
            Return Nothing
        End Try

    End Function

End Module
