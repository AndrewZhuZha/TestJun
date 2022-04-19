<?php
if (@$_SERVER['HTTP_X_REQUESTED_WITH'] == 'XMLHttpRequest') 
{
	include '../CRUD.php';
	$user = new User;
	$user ->CRUD_ADD();
}
else
{
	echo "Это не АЖАкс запрос";
}
?>