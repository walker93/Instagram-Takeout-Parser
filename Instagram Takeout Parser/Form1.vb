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

    Dim Default_path As String = "C:\Users\walke\Documents\Downloads\canaleamir_20190201"
    Dim json_list As New List(Of KeyValuePair(Of String, String))
    Dim report_menu As String = ""
    WithEvents progressIndicator As New Progress(Of Tuple(Of Integer, String))
    Public Shared input_path As String
    Public Shared output_path As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MaximumSize = New Size(Screen.PrimaryScreen.WorkingArea.Width * 2, Height)
        MinimumSize = New Size(Width, Height)

        input_path_lbl.Text = Default_path
        input_path = Default_path
        output_path = IO.Path.Combine(Default_path, "REPORT")
        OutputPath_txt.Text = output_path
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        IO.Directory.CreateDirectory(output_path)
        progressBar.Visible = True
        percent_lbl.Visible = True


        loadJson(input_path, progressIndicator)
        parseJson()
        ExportReportIndexPage(progressIndicator)

        progressBar.Visible = False
        percent_lbl.Visible = False
        My.Computer.Audio.PlaySystemSound(System.Media.SystemSounds.Asterisk)
    End Sub

    Sub loadJson(path As String, progress As IProgress(Of Tuple(Of Integer, String)))
        json_list.Clear()
        Dim folder As New IO.DirectoryInfo(path)
        Dim files = folder.GetFiles("*.json")
        Dim i = 1
        For Each file In files
            reportP(progress, i, files.Length, "Lettura file " & file.Name)
            Dim text = IO.File.ReadAllText(file.FullName)
            json_list.Add(New KeyValuePair(Of String, String)(file.Name.Replace(".json", ""), text))
            i += 1
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
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu)
        IO.File.WriteAllText(IO.Path.Combine(output_path, "likes.html"), html_code)
    End Sub

    Sub ExportCommentsPage()
        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS & TABCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Commenti di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", TABJS)
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", comments.export)
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu)
        IO.File.WriteAllText(IO.Path.Combine(output_path, "comments.html"), html_code)
    End Sub

    Sub ExportSettingsPage()
        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS & TABCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Impostazioni di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", TABJS)
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", settings.export)
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu)
        IO.File.WriteAllText(IO.Path.Combine(output_path, "settings.html"), html_code)
    End Sub

    Sub ExportConnectionsPage()
        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS & TABCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Connessioni di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", TABJS)
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", connections.export)
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu)
        IO.File.WriteAllText(IO.Path.Combine(output_path, "connections.html"), html_code)
    End Sub

    Sub ExportSavedPage()
        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS & TABCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Salvataggi di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", TABJS)
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", saved.export)
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu)
        IO.File.WriteAllText(IO.Path.Combine(output_path, "saved.html"), html_code)
    End Sub

    Sub ExportMediaPage(progress As IProgress(Of Tuple(Of Integer, String)))
        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS & TABCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Media di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", TABJS)
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", media.export)
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu)
        IO.File.WriteAllText(IO.Path.Combine(output_path, "media.html"), html_code)
        CopyMediaFolders(input_path, output_path, progress)
    End Sub

    Sub ExportContactsPage(progress As IProgress(Of Tuple(Of Integer, String)))

        Dim content As String = "
<h2>Contatti (" & contacts.Count & ")</h2>
<table>
  <tr>
    <th>Nome</th>
    <th>Cognome</th>
    <th>Numero</th>
  </tr>"
        For Each contact In contacts
            reportP(progress, contacts.IndexOf(contact), contacts.Count, "Esporto Contatti")
            content &= contact.export & vbCrLf
        Next
        content &= "</table>"

        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Contatti di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", "")
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", content)
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu)
        IO.File.WriteAllText(IO.Path.Combine(output_path, "contacts.html"), html_code)
    End Sub

    Sub ExportSearchesPage(progress As IProgress(Of Tuple(Of Integer, String)))
        Dim content As String = "
<h2>Ricerche (" & searches.Count & ")</h2>
<table>
  <tr>
    <th>Ricerca cliccata</th>
    <th>Timestamp</th>
    <th>Tipo</th>
  </tr>"
        For Each search In searches
            reportP(progress, searches.IndexOf(search), searches.Count, "Esporto Ricerche")
            content &= search.export & vbCrLf
        Next
        content &= "</table>"

        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Ricerche di " & profile.name)
        html_code = html_code.Replace("JS_PLACEHOLDER", "")
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", content)
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu)
        IO.File.WriteAllText(IO.Path.Combine(output_path, "searches.html"), html_code)
    End Sub

    Sub ExportConversationsPage(progress As IProgress(Of Tuple(Of Integer, String)))
        'conversations are exported in single files with the conversations.html as index with iframe
        IO.Directory.CreateDirectory(IO.Path.Combine(output_path, "messages"))
        Dim i As Integer = 1
        Dim files As New Dictionary(Of String, String)
        Dim name As String
        Dim path As String
        For Each convo In messages
            name = convo.getConvoName(profile.username)
            path = IO.Path.Combine("messages", i & "-" & name & ".html")
            files.Add(path, convo.getConvoName(profile.username))
            IO.File.WriteAllText(output_path & "\" & files.Last.Key, convo.export(profile.username, progress))
            i += 1
        Next
        Dim list As String = ""

        For Each file In files
            list &= ConvoLinkHTML.Replace("CONVO_INDEX_PLACEHOLDER", file.Key).Replace("CONVO_NAME_PLACEHOLDER", file.Value)
        Next
        Dim indexPage As String = convoListHTML.Replace("CONVO_LIST_PLACEHOLDER", list).Replace("TITLE_PLACEHOLDER", "Conversazioni di " & profile.username).Replace("REPORT_LIST_PLACEHOLDER", report_menu)

        IO.File.WriteAllText(IO.Path.Combine(output_path, "messages.html"), indexPage)
    End Sub

    Sub ExportReportIndexPage(progress As IProgress(Of Tuple(Of Integer, String)))
        Dim html_code As String = startPageHTML

        report_menu &= "<a href='.\Index.html'>HOME PAGE</a>" & vbCrLf
        report_menu &= "<a href='.\comments.html'>Visualizza commenti</a>" & vbCrLf
        report_menu &= "<a href='.\connections.html'>Visualizza Connessioni</a>" & vbCrLf
        report_menu &= "<a href='.\contacts.html'>Visualizza " & contacts.Count.ToString & " Contatti</a>" & vbCrLf
        report_menu &= "<a href='.\likes.html'>Visualizza Like</a>" & vbCrLf
        report_menu &= "<a href='.\media.html'>Visualizza Media</a>" & vbCrLf
        report_menu &= "<a href='.\messages.html'>Visualizza " & messages.Count.ToString & " Conversazioni</a>" & vbCrLf
        report_menu &= "<a href='.\saved.html'>Visualizza Elementi Salvati</a>" & vbCrLf
        report_menu &= "<a href='.\searches.html'>Visualizza " & searches.Count & " Ricerche</a>" & vbCrLf
        report_menu &= "<a href='.\settings.html'>Visualizza Impostazioni</a>" & vbCrLf

        reportP(progress, 1, 5, "Esportazione Commenti") : ExportCommentsPage()
        reportP(progress, 2, 5, "Esportazione Connessioni") : ExportConnectionsPage()
        reportP(progress, 3, 5, "Esportazione Impostazioni") : ExportSettingsPage()
        reportP(progress, 4, 5, "Esportazione Like") : ExportLikesPage()
        reportP(progress, 5, 5, "Esportazione Elementi Salvati") : ExportSavedPage()

        ExportMediaPage(progress)
        ExportContactsPage(progress)
        ExportSearchesPage(progress)
        ExportConversationsPage(progress)

        html_code = html_code.Replace("CSS_PLACEHOLDER", startpageCSS)
        html_code = html_code.Replace("INDEX_PAGE_TTILE_PLACEHOLDER", "Report Instagram Takeout di " & profile.name)
        html_code = html_code.Replace("USER_PLACEHOLDER", profile.name)

        html_code = html_code.Replace("PROPIC_URL_PLACEHOLDER", DownloadUrl(profile.profile_pic_url))
        html_code = html_code.Replace("PROFILE_INFO_PLACEHOLDER", profile.export)
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu.Replace("<a href='.\Index.html'>HOME PAGE</a>", ""))

        IO.File.WriteAllText(IO.Path.Combine(output_path, "Index.html"), html_code)
        reportP(progress, 10, 10, "Completato")
    End Sub

    Sub CopyMediaFolders(SourcePath As String, OutputPath As String, progress As IProgress(Of Tuple(Of Integer, String)))
        Dim folders_array() As String = {"direct", "stories", "videos", "photos", "profile"}
        Dim i = 1
        For Each folder In folders_array
            reportP(progress, i, folders_array.Length, "Copio media in " & folder)
            i += 1
            If IO.Directory.Exists(IO.Path.Combine(SourcePath, folder)) Then
                My.Computer.FileSystem.CopyDirectory(IO.Path.Combine(SourcePath, folder),
                                                    IO.Path.Combine(OutputPath, folder),
                                                    FileIO.UIOption.OnlyErrorDialogs, FileIO.UICancelOption.DoNothing)
            End If
        Next
    End Sub

    Private Sub btn_Browse_input_Click(sender As Object, e As EventArgs) Handles btn_Browse_input.Click
        FolderBrowserDialog1.ShowNewFolderButton = False
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            input_path = FolderBrowserDialog1.SelectedPath
            input_path_lbl.Text = input_path
            output_path = IO.Path.Combine(input_path, "REPORT")
            OutputPath_txt.Text = output_path
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FolderBrowserDialog1.ShowNewFolderButton = True
        If FolderBrowserDialog1.ShowDialog = DialogResult.OK Then
            output_path = FolderBrowserDialog1.SelectedPath
            OutputPath_txt.Text = output_path
        End If
    End Sub

    Public Shared Sub reportP(progress As IProgress(Of Tuple(Of Integer, String)), current As Integer, total As Integer, text As String)
        progress.Report(New Tuple(Of Integer, String)((current / total) * 100, text))
        Application.DoEvents()
    End Sub

    Private Sub progressIndicator_ProgressChanged(sender As Object, e As Tuple(Of Integer, String)) Handles progressIndicator.ProgressChanged
        progressBar.Value = e.Item1
        status_lbl.Text = e.Item2
        percent_lbl.Text = e.Item1.ToString & "%"
    End Sub
End Class
