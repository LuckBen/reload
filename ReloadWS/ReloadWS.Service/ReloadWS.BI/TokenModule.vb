Public Module TokenModule
    Enum INTEGRIDAD_TOKEN
        CORRUPTO
        OK
        EXPIRADO
        NO_ENCONTRADO
        NO_CORRESPONDE_USUARIO
        USUARIO_NO_ENCONTRADO
    End Enum

    Private Property Clave As Byte()
    Private Property IV As Byte()
    Private Property tiempoLimiteTokenMinutos As Integer
    Private Const TOKEN_IP As Integer = 0
    Private Const TOKEN_USER As Integer = 1
    Private Const TOKEN_TIME As Integer = 2

    Sub New()
        tiempoLimiteTokenMinutos = Integer.Parse(System.Configuration.ConfigurationSettings.AppSettings("tiempo_limite_token_minutos"))
        Clave = System.Text.Encoding.ASCII.GetBytes(System.Configuration.ConfigurationSettings.AppSettings("JWT_SECRET_KEY"))
        IV = System.Text.Encoding.ASCII.GetBytes("Devjoker7.37hAES")
    End Sub

    Public Function generarToken(ByVal username As String) As String
        Dim cadena As String = Helper.getIPAddress() & "_" & username.ToUpper() & "_" & DateTime.Now.ToString()
        Return encriptar(cadena)
    End Function

    Public Function obtenerTokenCliente() As String
        Return Helper.getToken()
    End Function

    Private Function encriptar(ByVal cadena As String)
        Dim inputBytes As Byte() = System.Text.Encoding.ASCII.GetBytes(cadena)
        Dim encripted As Byte()

        Dim cripto As New System.Security.Cryptography.RijndaelManaged()

        Using ms As New System.IO.MemoryStream(inputBytes.Length)
            Using objCryptoStream As New System.Security.Cryptography.CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), System.Security.Cryptography.CryptoStreamMode.Write)
                objCryptoStream.Write(inputBytes, 0, inputBytes.Length)
                objCryptoStream.FlushFinalBlock()
                objCryptoStream.Close()

            End Using
            encripted = ms.ToArray()
        End Using
        Return Convert.ToBase64String(encripted)
    End Function

    Private Function desencriptar(ByVal cadena As String) As String
        Dim inputBytes As Byte() = Convert.FromBase64String(cadena)
        Dim resultBytes(inputBytes.Length) As Byte
        Dim textolimpio As String = String.Empty
        Dim cripto As New System.Security.Cryptography.RijndaelManaged()
        Using ms As New System.IO.MemoryStream(inputBytes)

            Using objCryptoStream As New System.Security.Cryptography.CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), System.Security.Cryptography.CryptoStreamMode.Read)
                Using rs As New System.IO.StreamReader(objCryptoStream, True)
                    textolimpio = rs.ReadToEnd()
                End Using
            End Using

        End Using
        Return textolimpio

    End Function


    Public Function validarIntegridadToken(ByVal token As String, ByVal ipCliente As String) As INTEGRIDAD_TOKEN
        Try
            Dim arrayToken As String() = desencriptar(token).Split("_")
            Dim ip As String = arrayToken(TOKEN_IP)
            Dim usuarioToken As String = arrayToken(TOKEN_USER)
            Dim fechatoken As String = arrayToken(TOKEN_TIME)

            If Not (BI.UsersModule.usuariosConectados.existe(usuarioToken)) Then
                Return INTEGRIDAD_TOKEN.USUARIO_NO_ENCONTRADO
            End If

            Dim tokensLista As String = BI.UsersModule.usuariosConectados.obtenerTokens(usuarioToken).SingleOrDefault(Function(x) x.Equals(token))

            If String.IsNullOrEmpty(tokensLista) Then
                Return INTEGRIDAD_TOKEN.NO_CORRESPONDE_USUARIO
            End If

            Dim diferencia As Double = Math.Abs(DateTime.Now.TimeOfDay.TotalMinutes - DateTime.Parse(fechatoken).TimeOfDay.TotalMinutes)

            If (diferencia > tiempoLimiteTokenMinutos) Then
                Return INTEGRIDAD_TOKEN.EXPIRADO
            End If

            Return INTEGRIDAD_TOKEN.OK

        Catch ex As Exception

        End Try
        Return INTEGRIDAD_TOKEN.CORRUPTO
    End Function


End Module
