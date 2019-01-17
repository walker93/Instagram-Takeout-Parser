Imports Newtonsoft
Public Class Form1

    Dim comments As comments
    Dim connections As connections
    Dim contacts As List(Of contatto)
    Dim likes As likes
    Dim media As media
    Dim messages As messages
    Dim profile As UserProfile
    Dim saved As Saved
    Dim searches As searches
    Dim settings As Settings

    Dim path As String = "F:\TEMP\6\"
    Dim json_list As New List(Of KeyValuePair(Of String, String))

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadJson(path)
        parseJson()

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
                    messages = Json.JsonConvert.DeserializeObject(Of messages)(file.Value)
                Case "profile"
                    profile = Json.JsonConvert.DeserializeObject(Of UserProfile)(file.Value)
                Case "saved"
                    saved = Json.JsonConvert.DeserializeObject(Of Saved)(file.Value)
                Case "searches"
                    searches = Json.JsonConvert.DeserializeObject(Of searches)(file.Value)
                Case "settings"
                    settings = Json.JsonConvert.DeserializeObject(Of Settings)(file.Value)
                Case Else

            End Select


        Next

    End Sub

End Class
