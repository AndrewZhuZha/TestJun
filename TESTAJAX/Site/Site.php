<?php
header('Content-type: application/json');
if (@$_SERVER['HTTP_X_REQUESTED_WITH'] == 'XMLHttpRequest') // проерка на запрос ajax
{
session_start();

if ($_POST['Hello']=='Hello')								// привет "имя"
{
	$hello = "Привет ";
	$info = array("Info"=>$hello.$_SESSION['name']);
	echo json_encode($info);				
}
if ($_POST['info'] == 'UpdateYes')							// переход на страницу обноления учётной записи
{
	$info["Info"]='UpdateYes';
	echo json_encode($info);
}
else if ($_POST['info']=='DeleteYes')						// удаление учётной записи
{
	include '../CRUD.php';
	$user = new User;
	$user ->Delete();
}
else if ($_POST['info']=='ExitYes')							// выход из учётной записи
{
	$info["Info"]='ExitYes';
	echo json_encode($info);
	session_unset();
}
}
else
{
	$info["Info"]="Это не АЖАкс запрос";
	echo $info;												// ответ, если запрос был не ajax
}
?>