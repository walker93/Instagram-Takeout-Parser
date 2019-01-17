Module Classi_JSON

    Public Class comments
        Public Property live_comments() As Object
        Public Property media_comments()() As Media_Comments
    End Class

    Public Class Media_Comments
        Public Property timestamp As Date
        Public Property text As String
        Public Property user As String
    End Class

    '--------------------

    Public Class contatti
        Public Property array() As contatto
    End Class

    Public Class contatto
        Public Property contact As String
        Public Property first_name As String
        Public Property last_name As String
    End Class

    '--------------------

    Public Class likes
        Public Property comment_likes()() As Comment_Likes
        Public Property media_likes()() As Media_Likes
    End Class

    Public Class Comment_Likes
        Public Property timestamp As Date
        Public Property user As String
    End Class

    Public Class Media_Likes
        Public Property timestamp As Date
        Public Property user As String
    End Class

    '------------------------

    Public Class media
        Public Property direct() As Direct
        Public Property photos() As Photo
        Public Property profile() As Profile
        Public Property stories() As Story
        Public Property videos() As Video
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

    Public Class messages
        Public Property conversations() As convo_block
    End Class

    Public Class convo_block
        Public Property conversation() As Conversation
        Public Property participants() As String
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
        Public Property likes() As _Like
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
        Public Property saved_collections() As Saved_Collections
        Public Property saved_media()() As Object
    End Class

    Public Class Saved_Collections
        Public Property name As String
        Public Property created_at As Date
        Public Property updated_at As Date
        Public Property media()() As Object
    End Class

    '----------------------------------

    Public Class searches
        Public Property searches() As Search
    End Class

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
