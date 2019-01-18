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

    Sub ExportCommentsPage()
        Dim html_code As String = TableHTML
        html_code = html_code.Replace("TABLECSS_PLACEHOLDER", tableCSS)
        html_code = html_code.Replace("TABLE_PAGE_PLACEHOLDER", "Commenti di " & profile.name)
        html_code = html_code.Replace("PAGE_CONTENT_PLACEHOLDER", comments.export)
        IO.File.WriteAllText("comments.html", html_code)
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


        html_code = html_code.Replace("CSS_PLACEHOLDER", startpageCSS)
        html_code = html_code.Replace("INDEX_PAGE_TTILE_PLACEHOLDER", "Report Instagram Takeout di " & profile.name)
        html_code = html_code.Replace("USER_PLACEHOLDER", profile.name)
        html_code = html_code.Replace("PROPIC_URL_PLACEHOLDER", profile.profile_pic_url)
        html_code = html_code.Replace("PROFILE_INFO_PLACEHOLDER", profile.export)
        html_code = html_code.Replace("REPORT_LIST_PLACEHOLDER", report_menu)

        IO.File.WriteAllText("Index.html", html_code)
    End Sub

End Class
