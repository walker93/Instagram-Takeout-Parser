Imports Newtonsoft.Json

Module Classi_JSON

    Public Class comments
        Public Property live_comments() As Object
        Public Property media_comments()(3) As Object

        Public Function export() As String
            Dim result As String = ""


            Return result
        End Function

    End Class

    '--------------------

    Public Class contatto
        Public Property contact As String
        Public Property first_name As String
        Public Property last_name As String
    End Class

    '--------------------

    Public Class likes
        Public Property comment_likes()(2) As Object
        Public Property media_likes()(2) As Object
    End Class

    '------------------------

    Public Class media
        Public Property direct As List(Of Direct)
        Public Property photos As List(Of Photo)
        Public Property profile As List(Of Profile)
        Public Property stories As List(Of Story)
        Public Property videos As List(Of Video)
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
        Public Property follow_requests_sent As Object
        Public Property followers As Object
        Public Property following As Object
        Public Property following_hashtags As Object
    End Class

    Public Class keyValue
        Public Property key As Date
    End Class

End Module
