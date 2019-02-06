Module DownloadFile

    Public Function DownloadUrl(url As String) As String

        If My.Computer.Network.IsAvailable Then
            Dim uri As Uri
            If Uri.TryCreate(url, UriKind.Absolute, uri) Then
                Dim filename As String = GetFileExtensionFromUrl(url) 'Date.Now.Ticks.ToString & 
                Dim path As String = IO.Path.Combine(Form1.output_path, "messages\downloaded", filename)
                IO.Directory.CreateDirectory(IO.Path.Combine(Form1.output_path, "messages\downloaded"))
                Dim web As New Net.WebClient()
                web.CachePolicy = New Net.Cache.RequestCachePolicy(Net.Cache.RequestCacheLevel.Default)
                Try
                    web.DownloadFile(uri, path)
                    path = path.Replace(Form1.output_path & "\messages\", "").Replace("\", "/")
                    Return path
                Catch webEx As Net.WebException
                    If webEx.Status = Net.WebExceptionStatus.Timeout Then MsgBox("timeout")
                    Return ""
                End Try
            End If
        Else
            MsgBox("Rete internet non disponibile", MsgBoxStyle.Critical + MsgBoxStyle.OkOnly, "Connessione Assente")
        End If
        Return ""
    End Function

    Public Function GetFileExtensionFromUrl(ByVal url As String) As String
        url = url.Split("?"c)(0)
        url = url.Split("/"c).Last()
        Return url 'If(url.Contains("."c), url.Substring(url.LastIndexOf("."c)), "")
    End Function
End Module
