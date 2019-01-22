Module HTML

    Public startPageHTML As String = "
<html>
<head>
  <meta charset='utf-8' />
  <title>INDEX_PAGE_TTILE_PLACEHOLDER</title>
  <style>CSS_PLACEHOLDER</style>
</head>
<body>
<h1 align=center>
Report Instagram Takeout
</h1>
<br>
<h2 align=center>
USER_PLACEHOLDER
</h2>
<div class='profile_info'>
<img class='profile_pic' src='PROPIC_URL_PLACEHOLDER'/>
<div class='center_self'>
 PROFILE_INFO_PLACEHOLDER
</div>
</div>
<div class='data_block'>
  REPORT_LIST_PLACEHOLDER
</div>
</body>
</html>"

    Public startpageCSS As String = "
.profile_info{
  justify-content: center;
  align-items: center;
  width: 100%;
  display: flex;
  flex-direction: row;
}

.center_self {
  align-self: center;
}

.data_block{
  padding-left: 5%;
  display: flex;
  flex-direction: column;
}

.profile_pic{
  margin: 5px;
  height: 150px;
  width: 150px;
}

h1 {
  font-size: 3em;
}
h2 {
  font-size: 2.5em;  
}
"

    Public tableCSS As String = "
table {
  width:100%;
  table-layout: fixed;
}
table, th, td {
  border: 1px solid black;
  border-collapse: collapse;
}
th, td {
  padding: 15px;
  text-align: left;
}
table tr:nth-child(even) {
  background-color: #eee;
}
table tr:nth-child(odd) {
 background-color: #fff;
}
table th {
  background-color: black;
  color: white;
}
img, video{
    height: 250px;
}

td.photo {
    text-align: center;
    font-size: 1.5em;
}
"

    Public TableHTML As String = "
<html>
<head>
<meta charset='utf-8' />
<title>TABLE_PAGE_PLACEHOLDER</title>
<style>
TABLECSS_PLACEHOLDER
</style>
<script>
JS_PLACEHOLDER
</script>
</head>
<body>
PAGE_CONTENT_PLACEHOLDER
</body>
"


    Public ConnectionsHTML As String = "

<!-- Tab links -->
<div class='tab'>
  <button class='tablinks' onclick='openDiv(event, ""blocked"")' id='default'>Utenti Bloccati</button>
  <Button Class='tablinks' onclick='openDiv(event, ""followers"")'>Utenti che seguono</button>
  <Button Class='tablinks' onclick='openDiv(event, ""following"")'>Utenti seguiti</button>
  <Button Class='tablinks' onclick='openDiv(event, ""follow-sent"")'>Richieste di Follow inviate</button>
  <Button Class='tablinks' onclick='openDiv(event, ""hashtags"")'>Hashtag seguiti</button>
</div>

<!-- Tab content -->
<div id = 'blocked' Class='tabcontent'>
  BLOCKED_PLACEHOLDER
</div>

<div id = 'followers' Class='tabcontent'>
  FOLLOWERS_PLACEHOLDER
</div>

<div id = 'following' Class='tabcontent'>
  FOLLOWING_PLACEHOLDER
</div>
<div id = 'follow-sent' Class='tabcontent'>
    REQUESTS_PLACEHOLDER
</div>
<div id = 'hashtags' Class='tabcontent'>
    HASHTAGS_PLACEHOLDER
</div>
<script>openDiv(event, 'blocked');</script>
"
    Public TABCSS As String = "
/* Style the tab */
.tab {
  overflow: hidden;
  border: 1px solid #ccc;
  background-color: #f1f1f1;
}

/* Style the buttons that are used to open the tab content */
.tab button {
  background-color: inherit;
  float: left;
  border: none;
  outline: none;
  cursor: pointer;
  padding: 14px 16px;
  transition: 0.3s;
}

/* Change background color of buttons on hover */
.tab button:hover {
  background-color: #ddd;
}

/* Create an active/current tablink class */
.tab button.active {
  background-color: #ccc;
}

/* Style the tab content */
.tabcontent {
  display: none;
  padding: 6px 12px;
  border: 1px solid #ccc;
  border-top: none;
}
"

    Public TABJS As String = "
function openDiv(evt, DivName) {
  // Declare all variables
  var i, tabcontent, tablinks;

  // Get all elements with class='tabcontent' and hide them
  tabcontent = document.getElementsByClassName('tabcontent');
  for (i = 0; i < tabcontent.length; i++) {
    tabcontent[i].style.display = 'none';
  }

  // Get all elements with class='tablinks' and remove the class 'active'
  tablinks = document.getElementsByClassName('tablinks');
  for (i = 0; i < tablinks.length; i++) {
    tablinks[i].className = tablinks[i].className.replace(' active', '');
  }

  // Show the current tab, and add an 'active' class to the button that opened the tab
  document.getElementById(DivName).style.display = 'block';
  if (!evt) {
    tablinks[0].className += ' active';
  } else {
    evt.currentTarget.className += ' active';
  }
}

document.addEventListener('DOMContentLoaded', function() {
  var lazyloadImages = document.querySelectorAll('img.lazy');    
  var lazyloadThrottleTimeout;
  
  function lazyload () {
    if(lazyloadThrottleTimeout) {
      clearTimeout(lazyloadThrottleTimeout);
    }    
    
    lazyloadThrottleTimeout = setTimeout(function() {
        var scrollTop = window.pageYOffset;
        lazyloadImages.forEach(function(img) {
            if(img.offsetTop < (window.innerHeight + scrollTop)) {
              img.src = img.dataset.src;
              img.classList.remove('lazy');
            }
        });
        if(lazyloadImages.length == 0) { 
          document.removeEventListener('scroll', lazyload);
          window.removeEventListener('resize', lazyload);
          window.removeEventListener('orientationChange', lazyload);
        }
    }, 20);
  }
  
  document.addEventListener('scroll', lazyload);
  window.addEventListener('resize', lazyload);
  window.addEventListener('orientationChange', lazyload);
});

"

    Public LikesHTML As String = "

<!-- Tab links -->
<div class='tab'>
  <button class='tablinks' onclick='openDiv(event, ""comment"")' id='default'>Like a commenti</button>
  <button Class='tablinks' onclick='openDiv(event, ""media"")'>Like a Media</button>
</div>

<!-- Tab content -->
<div id = 'comment' Class='tabcontent'>
  COMMENT_LIKE_PLACEHOLDER
</div>

<div id = 'media' Class='tabcontent'>
  MEDIA_LIKE_PLACEHOLDER
</div>

<script>openDiv(event, 'comment');</script>
"


    Public commentsHTML As String = "
<!-- Tab links -->
<div class='tab'>
  <button class='tablinks' onclick='openDiv(event, ""comment"")' id='default'>Commento a Live</button>
  <button Class='tablinks' onclick='openDiv(event, ""media"")'>Commento a Media</button>
</div>

<!-- Tab content -->
<div id = 'comment' Class='tabcontent'>
  COMMENT_LIVE_PLACEHOLDER
</div>

<div id = 'media' Class='tabcontent'>
  COMMENT_MEDIA_PLACEHOLDER
</div>

<script>openDiv(event, 'comment');</script>
"

    Public savedHTML As String = "
<!-- Tab links -->
<div class='tab'>
  <button class='tablinks' onclick='openDiv(event, ""collection"")' id='default'>Collezioni Salvate</button>
  <button Class='tablinks' onclick='openDiv(event, ""media"")'>Media Salvati</button>
</div>

<!-- Tab content -->
<div id = 'collection' Class='tabcontent'>
  SAVED_COLLECTION_PLACEHOLDER
</div>

<div id = 'media' Class='tabcontent'>
  SAVED_MEDIA_PLACEHOLDER
</div>

<script>openDiv(event, 'collection');</script>
"


    Public mediaHTML As String = "

<!-- Tab links -->
<div class='tab'>
  <button class='tablinks' onclick='openDiv(event, ""direct"")' id='default'>Direct</button>
  <Button Class='tablinks' onclick='openDiv(event, ""photo"")'>Foto</button>
  <Button Class='tablinks' onclick='openDiv(event, ""video"")'>Video</button>
  <Button Class='tablinks' onclick='openDiv(event, ""storie"")'>Storie</button>
  <Button Class='tablinks' onclick='openDiv(event, ""profilepic"")'>Immagini Profilo</button>
</div>

<!-- Tab content -->
<div id = 'direct' Class='tabcontent'>
  DIRECT_PLACEHOLDER
</div>

<div id = 'photo' Class='tabcontent'>
  PHOTO_PLACEHOLDER
</div>

<div id = 'video' Class='tabcontent'>
  VIDEO_PLACEHOLDER
</div>
<div id = 'storie' Class='tabcontent'>
    STORIE_PLACEHOLDER
</div>
<div id = 'profilepic' Class='tabcontent'>
    PROPIC_PLACEHOLDER
</div>
<script>openDiv(event, 'direct');</script>
"

    Public frameheaderHTML As String = "<html>
    <head>
        <style>CSS_PLACEHOLDER</style>
    </head>
<body>
<div class=convo>
"
    Public frameCSS As String = "
.like {
  top: 5px;
  line-height: 1.2em;
  position: relative;
  background-color: unset !important;
  
}
p.media_share {
  text-align: center;
  margin: 0px;
}
img.media_share {
  width: 40%;
  margin-left: 30%;
  padding: 3px;
  border-style: solid;
  border-width: 0px 2px 0px 2px;
  border-radius: 0px;
  border-color: #666666
}

img.media {
  width: 40%;
  margin-left: 30%;
  border-radius: 10px;
}

.message{
  box-shadow: 2px 2px 2px grey;
  background-color: #E6FFCC;
  border-radius: 20px;
  padding: 10px;
  width: 40%;
  font-family: sans-serif;
  margin-top: 10px;
}

.sent{
  align-self: flex-end;
  background-color: #CCF5FF;
}

.MessageText {
    white-space: pre-line;
}

.InfoText {
  font-style: italic;
}

.center{
  align-self: center;
}

.Timestamp{
  color: RGBA(100,100,100,70);
  font-size: 9pt;
}

.Sender {
  color: #0069CC;
  border-style: solid;
  border-width: 0px 0px 2px 0px;
  border-radius: 5px;
  display: table;
}

.convo {
  display: flex;
  flex-direction: column;
}

#frame {
  right: 0px;
  width: 80%;
  position: absolute;
}
"
    Public framemessageHTML As String = "
<div class='message SENTCLASS_PLACEHOLDER CENTER_PLACEHOLDER'>
  SENDER_PLACEHOLDER
  STORY_PLACEHOLDER
  LIVE_PLACEHOLDER
  VIDEOCALL_PLACEHOLDER
  TEXT_PLACEHOLDER
  HEART_PLACEHOLDER
  LINK_PLACEHOLDER
  MEDIA_URL_PLACEHOLDER
  M_OWNER_PLACEHOLDER
  M_URL_PLACEHOLDER
  M_CAPTION_PLACEHOLDER
  TIMESTAMP_PLACEHOLDER
</div>
  LIKE_ARRAY_PLACEHOLDER
"



    Public ConvoLinkHTML As String = "<div class='convo-link'><a href='CONVO_INDEX_PLACEHOLDER' target='convo'>CONVO_NAME_PLACEHOLDER</a></div>"

    Public convoListHTML As String = "
<html>
<head>
  <title>TITLE_PLACEHOLDER</title>
  <style>
  .container{
  height: 100%;
  display: flex;
  align-items: stretch;
}
.nav{
  flex: 0.2 auto;
  width: 0%;
  order: 1;
  overflow-y: scroll;
}
.convo-link{
  padding: 10px 0px;
  border-bottom: solid 0px #ccc;
}

.convo-link:hover{
  background-color: #ccf2ff;
}

[name=convo]{
flex: 1;
order: 2;
}
  </style>
</head>
<body>
  <div class='container' width=100% height=100%>
    <nav class='nav'>
CONVO_LIST_PLACEHOLDER
    </nav>
<iframe name='convo' src=''></iframe>
</div>
</body>
</html>
"
End Module
