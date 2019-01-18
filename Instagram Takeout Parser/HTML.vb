Module HTML

    Public startPageHTML As String = "
<html>
<head>
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
"

    Public TableHTML As String = "
<html>
<head>
<title>TABLE_PAGE_PLACEHOLDER</title>
<style>
TABLECSS_PLACEHOLDER
</style>
</head>
<boby>
PAGE_CONTENT_PLACEHOLDER
</body>
"

End Module
