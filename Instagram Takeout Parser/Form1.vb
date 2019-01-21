Imports Newtonsoft
Public Class Form1

    Dim comments As comments
    Dim connections As connections
    Dim contacts As List(Of contatto)
    Dim likes As likes
    Dim media As media
    Dim messages As List(Of convo_block)
    Dim profile As UserProfile
    Dim saved As Saved
    Dim searches As List(Of Search)
    Dim settings As Settings

    Dim path As String = "F:\TEMP\6\"
    Dim json_list As New List(Of KeyValuePair(Of String, String))

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadJson(path)
        parseJson()
        ExportReportIndexPage()
    End Sub

    Sub loadJson(path)
        Dim folder As New IO.DirectoryInfo(path)
        Dim files = folder.GetFiles("*.json")
        For Each file In files
            Dim text = IO.File.ReadAllText(file.FullName)
            json_list.Add(New KeyValuePair(Of String, String)(file.Name.Replace(".json", ""), text))
        Next

    End Sub


    Sub parseJson()
        For Each file In json_list
            Select Case file.Key
                Case "comments"
                    comments = Json.JsonConvert.DeserializeObject(Of comments)(file.Value)
                Case "connections"
                    connections = Json.JsonConvert.DeserializeObject(Of connections)(file.Value)
                Case "contacts"
                    contacts = Json.JsonConvert.DeserializeObject(Of List(Of contatto))(file.Value)
                Case "likes"
                    likes = Json.JsonConvert.DeserializeObject(Of likes)(file.Value)
                Case "media"
                    media = Json.JsonConvert.DeserializeObject(Of media)(file.Value)
                Case "messages"
                    messages = Json.JsonConvert.DeserializeObject(Of List(Of convo_block))(file.Value)
                Case "profile"
                    profile = Json.JsonConvert.DeserializeObject(Of UserProfile)(file.Value)
                Case "saved"
                    saved = Json.JsonConvert.DeserializeObject(Of Saved)(file.Value)
                Case "searches"
                    searches = Json.JsonConvert.DeserializeObject(Of List(Of Search))(file.Value)
                Case "settings"
                    settings = Json.JsonConvert.DeserializeObject(Of Settings)(file.Value)
                Case Else

            End Select
        Next

    End Sub

    Sub ExportLikesPage()
        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS & TABCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Like di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", TABJS)
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", likes.export)
        IO.File.WriteAllText("likes.html", html_code)
    End Sub

    Sub ExportCommentsPage()
        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS & TABCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Commenti di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", TABJS)
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", comments.export)
        IO.File.WriteAllText("comments.html", html_code)
    End Sub

    Sub ExportConnectionsPage()
        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS & TABCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Connessioni di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", TABJS)
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", connections.export)
        IO.File.WriteAllText("connections.html", html_code)
    End Sub

    Sub ExportMediaPage()
        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS & TABCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Media di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", TABJS)
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", media.export)
        IO.File.WriteAllText("media.html", html_code)
        CopyMediaFolders(path)
    End Sub

    Sub ExportContactsPage()

        Dim content As String = "
<h2>Contatti (" & contacts.Count & ")</h2>
<table>
  <tr>
    <th>Nome</th>
    <th>Cognome</th>
    <th>Numero</th>
  </tr>"
        For Each contact In contacts
            content &= contact.export & vbCrLf
        Next
        content &= "</table>"

        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Contatti di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", "")
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", content)
        IO.File.WriteAllText("contacts.html", html_code)
    End Sub

    Sub ExportReportIndexPage()
        Dim html_code As String = startPageHTML
        Dim report_menu As String = ""

        report_menu &= "<a href='.\comments.html'>Visualizza commenti</a>" & vbCrLf
        report_menu &= "<a href='.\connections.html'>Visualizza Connessioni</a>" & vbCrLf
        report_menu &= "<a href='.\contacts.html'>Visualizza " & contacts.Count.ToString & " Contatti</a>" & vbCrLf
        report_menu &= "<a href='.\likes.html'>Visualizza Like</a>" & vbCrLf
        report_menu &= "<a href='.\media.html'>Visualizza Media</a>" & vbCrLf
        report_menu &= "<a href='.\messages.html'>Visualizza " & messages.Count.ToString & " Conversazioni</a>" & vbCrLf
        report_menu &= "<a href='.\saved.html'>Visualizza Elementi Salvati</a>" & vbCrLf
        report_menu &= "<a href='.\searches.html'>Visualizza " & searches.Count & " Ricerche</a>" & vbCrLf
        report_menu &= "<a href='.\settings.html'>Visualizza Impostazioni</a>" & vbCrLf

        ExportCommentsPage()
        ExportConnectionsPage()
        ExportContactsPage()
        ExportLikesPage()
        ExportMediaPage()

        html_code = html_code.Replace("CSS_PLACEHOLDER", startpageCSS)
        html_code = html_code.Replace("INDEX_PAGE_TTILE_PLACEHOLDER", "Report Instagram Takeout di " & profile.name)
        html_code = html_code.Replace("USER_PLACEHOLDER", profile.name)
        html_code = html_code.Replace("PROPIC_URL_PLACEHOLDER", profile.profile_pic_url)
        html_code = html_code.Replace("PROFILE_INFO_PLACEHOLDER", profile.export)
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu)

        IO.File.WriteAllText("Index.html", html_code)
    End Sub

    Sub CopyMediaFolders(SourcePath)
        If IO.Directory.Exists(IO.Path.Combine(SourcePath, "direct")) Then
            My.Computer.FileSystem.CopyDirectory(IO.Path.Combine(SourcePath, "direct"), "direct", FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
        End If

        If IO.Directory.Exists(IO.Path.Combine(SourcePath, "stories")) Then
            My.Computer.FileSystem.CopyDirectory(IO.Path.Combine(SourcePath, "stories"), "stories", FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
        End If

        If IO.Directory.Exists(IO.Path.Combine(SourcePath, "videos")) Then
            My.Computer.FileSystem.CopyDirectory(IO.Path.Combine(SourcePath, "videos"), "videos", FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
        End If
        If IO.Directory.Exists(IO.Path.Combine(SourcePath, "photos")) Then
            My.Computer.FileSystem.CopyDirectory(IO.Path.Combine(SourcePath, "photos"), "photos", FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
        End If

        If IO.Directory.Exists(IO.Path.Combine(SourcePath, "profile")) Then
            My.Computer.FileSystem.CopyDirectory(IO.Path.Combine(SourcePath, "profile"), "profile", FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
        End If
    End Sub
End Class
