<?php
header('Content-type: application/json');
if (@$_SERVER['HTTP_X_REQUESTED_WITH'] == 'XMLHttpRequest') // проерка ajax запрос или нет
{
	if ($_POST["Exit"]==="Exit")							// если нажал кнопка "назад"
	{
		$Exit = array("Info" =>"Yes");
		echo json_encode($Exit);
	}
	else
	{
	include '../../CRUD.php';								// подключение CRUD
	$user = new User;
	$user ->Update();										// изменение данных юзера
}
}
else
{	
	$Exit["Info"]="Это не АЖАкс запрос";
	echo $Exit;
}

?>