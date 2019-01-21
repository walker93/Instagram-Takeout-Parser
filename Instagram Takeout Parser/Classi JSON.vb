﻿Imports Newtonsoft.Json

Module Classi_JSON

    Public Class comments
        Public Property live_comments() As Object
        Public Property media_comments()(3) As Object

        Public Function export() As String
            Dim result As String = commentsHTML
            Dim extraHTML As String = "
<h2>Commenti a Live (" & live_comments.count & ")</h2>
<table>
  <tr>
    <th>TimeStamp</th>
    <th>Testo</th>
    <th>Utente Commentato</th>
  </tr>
"
            For Each live_c In live_comments
                extraHTML &= "<tr>"
                extraHTML &= "<td>" & CType(live_c(0), Date).ToString("yyyy/MM/dd HH:mm:ss") & "</td>"
                extraHTML &= "<td>" & live_c(1) & "</td>"
                extraHTML &= "<td>" & live_c(2) & "</td>"
                extraHTML &= "</tr>"
            Next
            extraHTML &= "</table>"
            result = result.Replace("COMMENT_LIVE_PLACEHOLDER", extraHTML)

            extraHTML = "
<h2>Commenti a Media (" & media_comments.count & ")</h2>
<table>
  <tr>
    <th>TimeStamp</th>
    <th>Testo</th>
    <th>Utente Commentato</th>
  </tr>
"
            For Each media_c In media_comments
                extraHTML &= "<tr>"
                extraHTML &= "<td>" & CType(media_c(0), Date).ToString("yyyy/MM/dd HH:mm:ss") & " </td>"
                extraHTML &= "<td>" & media_c(1) & "</td>"
                extraHTML &= "<td>" & media_c(2) & "</td>"
                extraHTML &= "</tr>"
            Next
            extraHTML &= "</table>"
            result = result.Replace("COMMENT_MEDIA_PLACEHOLDER", extraHTML)

            Return result
        End Function

    End Class

    '--------------------

    Public Class contatto
        Public Property contact As String
        Public Property first_name As String
        Public Property last_name As String

        Public Function export() As String
            Dim result As String = "<tr>"

            result &= "<td>" & first_name & " </td>"
            result &= "<td>" & last_name & "</td>"
            result &= "<td>" & contact & "</td>"

            result &= "</tr>"

            Return result
        End Function
    End Class

    '--------------------

    Public Class likes
        Public Property comment_likes()(2) As Object
        Public Property media_likes()(2) As Object

        Public Function export() As String
            Dim result As String = LikesHTML
            Dim extraHTML As String = "
<h2>Like a commenti (" & comment_likes.count & ")</h2>
<table>
  <tr>
    <th>TimeStamp</th>
    <th>Utente</th>
  </tr>
"
            For Each comment_l In comment_likes
                extraHTML &= "<tr>"
                extraHTML &= "<td>" & CType(comment_l(0), Date).ToString("yyyy/MM/dd HH:mm:ss") & "</td>"
                extraHTML &= "<td>" & comment_l(1) & "</td>"
                extraHTML &= "</tr>"
            Next
            extraHTML &= "</table>"
            result = result.Replace("COMMENT_LIKE_PLACEHOLDER", extraHTML)

            extraHTML = "
<h2>Like a Media (" & media_likes.count & ")</h2>
<table>
  <tr>
    <th>TimeStamp</th>
    <th>Utente</th>
  </tr>
"
            For Each media_l In media_likes
                extraHTML &= "<tr>"
                extraHTML &= "<td>" & CType(media_l(0), Date).ToString("yyyy/MM/dd HH:mm:ss") & " </td>"
                extraHTML &= "<td>" & media_l(1) & "</td>"
                extraHTML &= "</tr>"
            Next
            extraHTML &= "</table>"
            result = result.Replace("MEDIA_LIKE_PLACEHOLDER", extraHTML)

            Return result
        End Function

    End Class

    '------------------------

    Public Class media
        Public Property direct As List(Of Direct)
        Public Property photos As List(Of Photo)
        Public Property profile As List(Of Profile)
        Public Property stories As List(Of Story)
        Public Property videos As List(Of Video)


        Public Function export() As String
            Dim result As String = mediaHTML
            Dim resto As Integer = 0
            Dim extraHTML As String = "
<h2>Direct (" & direct.Count & ")</h2>
<table>
"
            For i = 0 To direct.Count \ 4 - 1
                extraHTML &= "<tr>"
                extraHTML &= "<td class='photo'>" & direct(4 * i).taken_at.ToUniversalTime.ToString("yyyy/MM/dd HH:mm:ss") & "UTC<br>" & "<img src='./" & direct(4 * i).path & "'/></td>"
                extraHTML &= "<td class='photo'>" & direct(4 * i + 1).taken_at.ToUniversalTime.ToString("yyyy/MM/dd HH:mm:ss") & "UTC<br>" & "<img src='./" & direct(4 * i + 1).path & "'/></td>"
                extraHTML &= "<td class='photo'>" & direct(4 * i + 2).taken_at.ToUniversalTime.ToString("yyyy/MM/dd HH:mm:ss") & "UTC<br>" & "<img src='./" & direct(4 * i + 2).path & "'/></td>"
                extraHTML &= "<td class='photo'>" & direct(4 * i + 3).taken_at.ToUniversalTime.ToString("yyyy/MM/dd HH:mm:ss") & "UTC<br>" & "<img src='./" & direct(4 * i + 3).path & "'/></td>"
                extraHTML &= "</tr>"
            Next
            resto = direct.Count Mod 4
            If resto > 0 Then
                extraHTML &= "<tr>"
                For y = resto - 1 To 0 Step -1
                    extraHTML &= "<td class='photo'>" & direct(direct.Count - resto).taken_at.ToUniversalTime.ToString("yyyy/MM/dd HH:mm:ss") & "UTC<br>" & "<img src='./" & direct(direct.Count - resto).path & "'/></td>"
                Next
                extraHTML &= "</tr>"
            End If
            extraHTML &= "</table>"
            result = result.Replace("DIRECT_PLACEHOLDER", extraHTML)

            extraHTML = "
<h2>Foto (" & photos.Count & ")</h2>
<table>
"
            For i = 0 To photos.Count \ 4 - 1
                extraHTML &= "<tr>"
                extraHTML &= "<td class='photo'>" & photos(4 * i).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & "<img src='./" & photos(4 * i).path & "'/><br>" & photos(4 * i).caption & "</td>"
                extraHTML &= "<td class='photo'>" & photos(4 * i + 1).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & "<img src='./" & photos(4 * i + 1).path & "'/><br>" & photos(4 * i + 1).caption & "</td>"
                extraHTML &= "<td class='photo'>" & photos(4 * i + 2).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & "<img src='./" & photos(4 * i + 2).path & "'/><br>" & photos(4 * i + 2).caption & "</td>"
                extraHTML &= "<td class='photo'>" & photos(4 * i + 3).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & "<img src='./" & photos(4 * i + 3).path & "'/><br>" & photos(4 * i + 3).caption & "</td>"
                extraHTML &= "</tr>"
            Next
            resto = photos.Count Mod 4
            If resto > 0 Then
                extraHTML &= "<tr>"
                For y = resto - 1 To 0 Step -1
                    extraHTML &= "<td class='photo'>" & photos(photos.Count - resto).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & "<img src='./" & photos(photos.Count - resto).path & "'/><br>" & photos(photos.Count - resto).caption & "</td>"
                Next
                extraHTML &= "</tr>"
            End If
            extraHTML &= "</table>"
            result = result.Replace("PHOTO_PLACEHOLDER", extraHTML)


            extraHTML = "
<h2>Video (" & videos.Count & ")</h2>
<table>
"
            For i = 0 To videos.Count \ 4 - 1
                extraHTML &= "<tr>"
                extraHTML &= "<td class='photo'>" & videos(4 * i).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & "<video controls><source src='./" & videos(4 * i).path & "'></video><br>" & videos(4 * i).caption & "</td>"
                extraHTML &= "<td class='photo'>" & videos(4 * i + 1).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & "<video controls><source src='./" & videos(4 * i + 1).path & "'></video><br>" & videos(4 * i + 1).caption & "</td>"
                extraHTML &= "<td class='photo'>" & videos(4 * i + 2).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & "<video controls><source src='./" & videos(4 * i + 2).path & "'></video><br>" & videos(4 * i + 2).caption & "</td>"
                extraHTML &= "<td class='photo'>" & videos(4 * i + 3).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & "<video controls><source src='./" & videos(4 * i + 3).path & "'></video><br>" & videos(4 * i + 3).caption & "</td>"
                extraHTML &= "</tr>"
            Next
            resto = videos.Count Mod 4
            If resto > 0 Then
                extraHTML &= "<tr>"
                For y = resto - 1 To 0 Step -1
                    extraHTML &= "<td class='photo'>" & videos(videos.Count - resto).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & "<video controls><source src='./" & videos(videos.Count - resto).path & "'></video><br>" & videos(videos.Count - resto).caption & "</td>"
                Next
                extraHTML &= "</tr>"
            End If
            extraHTML &= "</table>"
            result = result.Replace("VIDEO_PLACEHOLDER", extraHTML)


            extraHTML = "
<h2>Storie (" & stories.Count & ")</h2>
<table>
"
            Dim startvideo As String = "<video controls><source "
            Dim startimg As String = "<img "

            For i = 0 To stories.Count \ 4 - 1
                extraHTML &= "<tr>"
                extraHTML &= "<td class='photo'>" & stories(4 * i).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & If(stories(4 * i).path.Contains("mp4"), startvideo, startimg) & "src='./" & stories(4 * i).path & If(stories(4 * i).path.Contains("mp4"), "'></video>", "'/>") & "<br>" & stories(4 * i).caption & "</td>"
                extraHTML &= "<td class='photo'>" & stories(4 * i + 1).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & If(stories(4 * i).path.Contains("mp4"), startvideo, startimg) & "<br>" & "src='./" & stories(4 * i + 1).path & If(stories(4 * i).path.Contains("mp4"), "'></video>", "'/>") & "<br>" & stories(4 * i + 1).caption & "</td>"
                extraHTML &= "<td class='photo'>" & stories(4 * i + 2).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & If(stories(4 * i).path.Contains("mp4"), startvideo, startimg) & "<br>" & "src='./" & stories(4 * i + 2).path & If(stories(4 * i).path.Contains("mp4"), "'></video>", "'/>") & "<br>" & stories(4 * i + 2).caption & "</td>"
                extraHTML &= "<td class='photo'>" & stories(4 * i + 3).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & If(stories(4 * i).path.Contains("mp4"), startvideo, startimg) & "<br>" & "src='./" & stories(4 * i + 3).path & If(stories(4 * i).path.Contains("mp4"), "'></video>", "'/>") & "<br>" & stories(4 * i + 3).caption & "</td>"
                extraHTML &= "</tr>"
            Next
            resto = stories.Count Mod 4
            If resto > 0 Then
                extraHTML &= "<tr>"
                For y = resto - 1 To 0 Step -1
                    extraHTML &= "<td class='photo'>" & stories(stories.Count - resto).taken_at.ToString("yyyy/MM/dd HH:mm:ss") & "<br>" & If(stories(stories.Count - resto).path.Contains("mp4"), startvideo, startimg) & "src='./" & stories(stories.Count - resto).path & If(stories(stories.Count - resto).path.Contains("mp4"), "'></video>", "'/>") & "<br>" & stories(stories.Count - resto).caption & "</td>"
                Next
                extraHTML &= "</tr>"
            End If
            extraHTML &= "</table>"
            result = result.Replace("STORIE_PLACEHOLDER", extraHTML)

            Return result
        End Function

    End Class

    Public Class Direct
        Public Property taken_at As Date
        Public Property path As String
    End Class

    Public Class Photo
        Public Property caption As String
        Public Property taken_at As Date
        Public Property path As String
    End Class

    Public Class Profile
        Public Property caption As String
        Public Property taken_at As Date
        Public Property is_active_profile As Boolean
        Public Property path As String
    End Class

    Public Class Story
        Public Property caption As String
        Public Property taken_at As Date
        Public Property path As String
    End Class

    Public Class Video
        Public Property caption As String
        Public Property taken_at As Date
        Public Property path As String
    End Class

    '------------------------------

    Public Class convo_block
        Public Property conversation As List(Of Conversation)
        Public Property participants As List(Of String)
    End Class

    Public Class Conversation
        Public Property sender As String
        Public Property created_at As Date
        Public Property text As String
        Public Property story_share As String
        Public Property media_owner As String
        Public Property media_share_caption As String
        Public Property media_share_url As String
        Public Property link As String
        Public Property likes As List(Of _Like)
        Public Property heart As String
        Public Property video_call_action As String
        Public Property media As String
        Public Property live_video_share As String
    End Class

    Public Class _Like
        Public Property username As String
        Public Property _date As Date
    End Class

    '-----------------------

    Public Class UserProfile
        Public Property date_joined As Date
        Public Property email As String
        Public Property gender As String
        Public Property name As String
        Public Property phone_number As String
        Public Property private_account As Boolean
        Public Property profile_pic_url As String
        Public Property username As String

        Public Function export() As String
            Dim result As String = ""
            result &= "<p><b>Username: </b>" & username & "</p>" & vbCrLf
            result &= "<p><b>Data Iscrizione: </b>" & date_joined.ToString("yyyy/MM/dd HH:mm:ss") & "</p>" & vbCrLf
            result &= "<p><b>Email: </b>" & email & "</p>" & vbCrLf
            result &= "<p><b>Sesso: </b>" & gender & "</p>" & vbCrLf
            result &= "<p><b>Numero di Telefono: </b>" & phone_number & "</p>" & vbCrLf
            result &= "<p><b>Profilo Privato: </b>" & If(private_account, "Si", "No") & "</p>" & vbCrLf
            Return result
        End Function
    End Class

    '-----------------------

    Public Class Saved
        Public Property saved_collections As List(Of Saved_Collections)
        Public Property saved_media()(2) As Object
    End Class

    Public Class Saved_Collections
        Public Property name As String
        Public Property created_at As Date
        Public Property updated_at As Date
        Public Property media()(2) As Object
    End Class

    '----------------------------------

    Public Class Search
        Public Property search_click As String
        Public Property time As Date
        Public Property type As String
    End Class

    '--------------------

    Public Class Settings
        Public Property allow_comments_from As String
        Public Property blocked_commenters() As Object
        Public Property filtered_keywords() As Object
    End Class

    '--------------------

    Public Class connections
        Public Property blocked_users As Object
        Public Property followers As Object
        Public Property following As Object
        Public Property follow_requests_sent As Object
        Public Property following_hashtags As Object

        Public Function export() As String
            Dim result As String = ConnectionsHTML

            Dim extraHTML As String = "
<h2>Utenti Bloccati (" & blocked_users.count & ")</h2>
<table>
  <tr>
    <th>TimeStamp</th>
    <th>Utente</th>
  </tr>"
            For Each entry In blocked_users
                extraHTML &= "<tr>"
                extraHTML &= "<td>" & CType(entry.value, Date).ToString("yyyy/MM/dd HH:mm:ss") & "</td>"
                extraHTML &= "<td>" & entry.name & "</td>"
                extraHTML &= "</tr>"
            Next
            extraHTML &= "</table>"
            result = result.Replace("BLOCKED_PLACEHOLDER", extraHTML)

            extraHTML = "
<h2>Utenti che seguono (" & followers.count & ")</h2>
<table>
  <tr>
    <th>TimeStamp</th>
    <th>Utente</th>
  </tr>"
            For Each entry In followers
                extraHTML &= "<tr>"
                extraHTML &= "<td>" & CType(entry.value, Date).ToString("yyyy/MM/dd HH:mm:ss") & "</td>"
                extraHTML &= "<td>" & entry.name & "</td>"
                extraHTML &= "</tr>"
            Next
            extraHTML &= "</table>"
            result = result.Replace("FOLLOWERS_PLACEHOLDER", extraHTML)

            extraHTML = "
<h2>Utenti seguiti (" & following.count & ")</h2>
<table>
  <tr>
    <th>TimeStamp</th>
    <th>Utente</th>
  </tr>"
            For Each entry In following
                extraHTML &= "<tr>"
                extraHTML &= "<td>" & CType(entry.value, Date).ToString("yyyy/MM/dd HH:mm:ss") & "</td>"
                extraHTML &= "<td>" & entry.name & "</td>"
                extraHTML &= "</tr>"
            Next
            extraHTML &= "</table>"
            result = result.Replace("FOLLOWING_PLACEHOLDER", extraHTML)

            extraHTML = "
<h2>Richieste di Follow inviate (" & follow_requests_sent.count & ")</h2>
<table>
  <tr>
    <th>TimeStamp</th>
    <th>Utente</th>
  </tr>"
            For Each entry In follow_requests_sent
                extraHTML &= "<tr>"
                extraHTML &= "<td>" & CType(entry.value, Date).ToString("yyyy/MM/dd HH:mm:ss") & "</td>"
                extraHTML &= "<td>" & entry.name & "</td>"
                extraHTML &= "</tr>"
            Next
            extraHTML &= "</table>"
            result = result.Replace("REQUESTS_PLACEHOLDER", extraHTML)

            extraHTML = "
<h2>Hashtag seguiti (" & following_hashtags.count & ")</h2>
<table>
  <tr>
    <th>TimeStamp</th>
    <th>Utente</th>
  </tr>"
            For Each entry In following_hashtags
                extraHTML &= "<tr>"
                extraHTML &= "<td>" & CType(entry.value, Date).ToString("yyyy/MM/dd HH:mm:ss") & "</td>"
                extraHTML &= "<td>" & entry.name & "</td>"
                extraHTML &= "</tr>"
            Next
            extraHTML &= "</table>"
            result = result.Replace("HASHTAGS_PLACEHOLDER", extraHTML)

            Return result
        End Function

    End Class

End Module
