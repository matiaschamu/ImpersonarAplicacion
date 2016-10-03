Imports System.Xml
Imports System.Security.Cryptography
Imports System.IO
Imports System.Security.Principal

Public Class Inicio

    Private ReadOnly mkey() As Byte = {214, 125, 32, 14, 52, 61, 82, 97, 105, 43, 214, 230, 141, 2, 37, 84, 52, 64, 243, 8, 4, 2, 3, 47}
    Private ReadOnly miv() As Byte = {245, 2, 37, 95, 154, 243, 1, 99}

    Private Sub Inicio_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            Dim ArchivoConfig As String = My.Application.Info.DirectoryPath & "\ImpConfig.xml"
            If System.IO.File.Exists(ArchivoConfig) Then

                Dim Xx As New XmlDocument, ListaNodos As XmlNodeList
                Dim Lista As ArrayList = New ArrayList()

                Xx.Load(ArchivoConfig)
                ListaNodos = Xx.SelectNodes("/Impersonar/PathAplicacion")
                Dim mPathAplicacion As String = ListaNodos.Item(0).InnerText
                TextBoxAplicacion.Text = mPathAplicacion
                ListaNodos = Xx.SelectNodes("/Impersonar/LineaComandos")
                Dim mLineaComandos As String = ListaNodos.Item(0).InnerText
                TextBoxLineaComandos.Text = mLineaComandos
                ListaNodos = Xx.SelectNodes("/Impersonar/Usuario")
                Dim mUsuario As String = ListaNodos.Item(0).InnerText
                ListaNodos = Xx.SelectNodes("/Impersonar/Contraseña")
                Dim mPassword As String = ListaNodos.Item(0).InnerText
                ListaNodos = Xx.SelectNodes("/Impersonar/Retardo")
                Dim mRetardo As String = ListaNodos.Item(0).InnerText
                TextBoxRetardo.Text = mRetardo

                If System.IO.File.Exists(mPathAplicacion) Then

                    mUsuario = Decrypt(mUsuario)
                    mPassword = Decrypt(mPassword)

                    Dim Pass As New System.Security.SecureString
                    For i = 1 To mPassword.Length
                        Pass.AppendChar(Mid(mPassword, i, 1))
                    Next

                    ' Dim P As New RunAs_Impersonator
                    'P.ImpersonateStart("", Usuario, Password)
                    'Dim UsuarioNecesario As String = My.Computer.Name & "\" & Usuario
                    'Dim UsuarioActual As String = WindowsIdentity.GetCurrent.Name
                    'If UsuarioNecesario.ToLower <> UsuarioActual.ToLower Then

                    'End If
                    'Label5.Text = WindowsIdentity.GetCurrent.Name

                    Dim Start As New ProcessStartInfo(mPathAplicacion, mLineaComandos)
                    Start.Password = Pass
                    Start.UserName = mUsuario
                    Start.UseShellExecute = False
                    'Start.LoadUserProfile = True
                    'Start.Verb = "Runasuser"
                    Start.RedirectStandardOutput = True
                    ' Start.WorkingDirectory = "c:\"
                    System.Threading.Thread.Sleep(5000)
                    Process.Start(Start)

                    'P.ImpersonateStop()
                    'Label5.Text = WindowsIdentity.GetCurrent.Name
                    'System.IO.File.WriteAllText(My.Application.Info.DirectoryPath & "\Nueva Carpeta\ddd.txt", "Te Cague!")
                    '
                    'Process.Start(PathAplicacion, LineaComandos, Usuario, Pass, "")
                End If
                Me.Close()
            End If
        Catch ex As Exception
            If MsgBox(ex.Message & vbCrLf & "Desea reconfigurar la aplicacion?", MsgBoxStyle.Critical Or MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton2, "Error") = MsgBoxResult.No Then
                Me.Close()
                Exit Sub
            End If
        End Try
    End Sub

    Private Sub ButtonSelectPath_Click(sender As System.Object, e As System.EventArgs) Handles ButtonSelectPath.Click
        Dim A As New OpenFileDialog
        If A.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBoxAplicacion.Text = A.FileName
            TextBoxLineaComandos.Text = ""
            TextBoxUsuario.Text = ""
            TextBoxContraseña.Text = ""
            TextBoxRetardo.Text = 5000
        End If
    End Sub

    Private Sub ButtonGuardar_Click(sender As System.Object, e As System.EventArgs) Handles ButtonGuardar.Click
        Dim Xx As New XmlDocument()
        Dim Nod As System.Xml.XmlNode
        Nod = Xx.AppendChild(Xx.CreateNode(System.Xml.XmlNodeType.Element, "Impersonar", ""))
        Dim N1 As System.Xml.XmlNode = Xx.CreateElement("PathAplicacion")
        N1.InnerText = TextBoxAplicacion.Text
        Nod.AppendChild(N1)
        N1 = Xx.CreateElement("LineaComandos")
        N1.InnerText = TextBoxLineaComandos.Text
        Nod.AppendChild(N1)
        N1 = Xx.CreateElement("Usuario")
        N1.InnerText = Encrypt(TextBoxUsuario.Text)
        Nod.AppendChild(N1)
        N1 = Xx.CreateElement("Contraseña")
        N1.InnerText = Encrypt(TextBoxContraseña.Text)
        Nod.AppendChild(N1)
        N1 = Xx.CreateElement("Retardo")
        N1.InnerText = TextBoxRetardo.Text
        Nod.AppendChild(N1)

        Xx.Save(My.Application.Info.DirectoryPath & "\ImpConfig.xml")
        Me.Close()
    End Sub

    Private Function Encrypt(ByVal input() As Byte) As Byte()
        Dim m_des As New TripleDESCryptoServiceProvider
        Return Transform(input, m_des.CreateEncryptor(mkey, miv))
    End Function

    Private Function Decrypt(ByVal input() As Byte) As Byte()
        Dim m_des As New TripleDESCryptoServiceProvider
        Return Transform(input, m_des.CreateDecryptor(mkey, miv))
    End Function

    Private Function Encrypt(ByVal text As String) As String
        Dim m_des As New TripleDESCryptoServiceProvider
        Dim m_utf8 As New System.Text.ASCIIEncoding
        Dim input() As Byte = m_utf8.GetBytes(text)
        Dim output() As Byte = Transform(input, _
                        m_des.CreateEncryptor(mkey, miv))
        Return Convert.ToBase64String(output)
    End Function

    Private Function Decrypt(ByVal text As String) As String
        Dim m_des As New TripleDESCryptoServiceProvider
        Dim m_utf8 As New System.Text.ASCIIEncoding
        Dim input() As Byte = Convert.FromBase64String(text)
        Dim output() As Byte = Transform(input, _
                         m_des.CreateDecryptor(mkey, miv))
        Return m_utf8.GetString(output)
    End Function

    Private Function Transform(ByVal input() As Byte, _
        ByVal CryptoTransform As ICryptoTransform) As Byte()
        ' create the necessary streams
        Dim memStream As MemoryStream = New MemoryStream
        Dim cryptStream As CryptoStream = New  _
            CryptoStream(memStream, CryptoTransform, _
            CryptoStreamMode.Write)
        ' transform the bytes as requested
        cryptStream.Write(input, 0, input.Length)
        cryptStream.FlushFinalBlock()
        ' Read the memory stream and convert it back into byte array
        memStream.Position = 0
        Dim result(CType(memStream.Length - 1, System.Int32)) As Byte
        memStream.Read(result, 0, CType(result.Length, System.Int32))
        ' close and release the streams
        memStream.Close()
        cryptStream.Close()
        ' hand back the encrypted buffer
        Return result
    End Function




















































    'Sub Main()
    '    Try
    '        ' Create a new TripleDESCryptoServiceProvider object
    '        ' to generate a key and initialization vector (IV).
    '        Dim tDESalg As New TripleDESCryptoServiceProvider

    '        ' Create a string to encrypt.
    '        Dim sData As String = "Here is some data to encrypt."
    '        Dim FileName As String = "CText.txt"

    '        ' Encrypt text to a file using the file name, key, and IV.

    '        ' Decrypt the text from a file using the file name, key, and IV.
    '        Dim Final As String = DecryptTextFromFile(FileName, tDESalg.Key, tDESalg.IV)

    '        ' Display the decrypted string to the console.
    '        Console.WriteLine(Final)
    '    Catch e As Exception
    '        Console.WriteLine(e.Message)
    '    End Try
    'End Sub


    'Private Function EncryptTextToFile(ByVal Data As String, ByVal Key() As Byte, ByVal iv() As Byte) As String
    '    Try
    '        ' Create or open the specified file.
    '        Dim fStream As New MemoryStream()
    '        'fStream.Write(, 0, Data.Length)
    '        Dim tDESalg As New TripleDESCryptoServiceProvider
    '        tDESalg.Key = Key
    '        tDESalg.IV = iv
    '        ' Create a CryptoStream using the FileStream 
    '        ' and the passed key and initialization vector (IV).
    '        Dim cStream As New CryptoStream(fStream, New TripleDESCryptoServiceProvider().CreateEncryptor(tDESalg.Key, tDESalg.IV), CryptoStreamMode.Write)

    '        cStream.Write(System.Text.ASCIIEncoding.ASCII.GetBytes(Data), 0, Data.Length)
    '        cStream.FlushFinalBlock()

    '        ' Create a StreamWriter using the CryptoStream.
    '        ' Dim sWriter As New StreamWriter(cStream)

    '        ' Write the data to the stream 
    '        ' to encrypt it.
    '        ' sWriter.WriteLine(Data)
    '        fStream.Position = 0
    '        Dim Encriptado(fStream.Length) As Byte
    '        fStream.Read(Encriptado, 0, fStream.Length)

    '        cStream.Close()
    '        fStream.Close()
    '        Return System.Text.ASCIIEncoding.ASCII.GetString(Encriptado)

    '    Catch e As CryptographicException
    '        Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
    '    Catch e As UnauthorizedAccessException
    '        Console.WriteLine("A file error occurred: {0}", e.Message)
    '    End Try
    '    Return Nothing
    'End Function


    'Function DecryptTextFromFile(ByVal Mensaje As String, ByVal Key() As Byte, ByVal IV() As Byte) As String
    '    Try
    '        ' Create or open the specified file. 
    '        Dim fStream As New MemoryStream(System.Text.ASCIIEncoding.ASCII.GetBytes(Mensaje))

    '        Dim tDESalg As New TripleDESCryptoServiceProvider
    '        tDESalg.Key = Key
    '        tDESalg.IV = IV
    '        ' Create a CryptoStream using the FileStream 
    '        ' and the passed key and initialization vector (IV).
    '        Dim cStream As New CryptoStream(fStream, New TripleDESCryptoServiceProvider().CreateDecryptor(tDESalg.Key, tDESalg.IV), CryptoStreamMode.Read)

    '        ' Create a StreamReader using the CryptoStream.
    '        Dim sReader As New StreamReader(cStream)

    '        ' Read the data from the stream 
    '        ' to decrypt it.
    '        Dim val As String = sReader.ReadLine()

    '        ' Close the streams and
    '        ' close the file.
    '        sReader.Close()
    '        cStream.Close()
    '        fStream.Close()

    '        ' Return the string. 
    '        Return val
    '    Catch e As CryptographicException
    '        Console.WriteLine("A Cryptographic error occurred: {0}", e.Message)
    '        Return Nothing
    '    Catch e As UnauthorizedAccessException
    '        Console.WriteLine("A file error occurred: {0}", e.Message)
    '        Return Nothing
    '    End Try
    'End Function

End Class
