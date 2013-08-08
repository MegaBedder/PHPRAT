<?php
$id = sha1(uniqid());

$uploaddir = 'screenshots/';
if (is_uploaded_file($_FILES['file']['tmp_name'])) {
	$uploadfile = $uploaddir . $id . '.png';
	if (move_uploaded_file($_FILES['file']['tmp_name'], $uploadfile)) {
		echo $id;
	}
}
?>