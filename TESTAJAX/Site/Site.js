document.getElementById('Update').disabled=false;					//
document.getElementById('Delete').disabled=false;					// если js будет включён кнопки будут актины
document.getElementById('Exit').disabled=false;						//
document.addEventListener("DOMContentLoaded", ready);				// готовность загрузки страницы
const form = document.getElementById('form');						// получение формы 
var Hello = 'Hello';												// переменная для получения имени
function ready(){													// если страница загружена отпраляем запрос на серер
$.ajax({
 		method: "POST",
  		url: "/Site/Site.php",
  		dataType: 'json',
		data: { 
				Hello,
		}
	}).done (function(msg)
		{ 
			var a = msg["Info"];									// получение имени пользователя от сервера
			document.getElementById("Hello").innerHTML = a;			// изменяет текст на "привет "имя""
		})
}

var info;															// переменная для отпраки информации на сервер
		
$('button.Delete').click(function(e)								
	{
		e.preventDefault();
		info='DeleteYes';
	})
$('button.Exit').click(function(e)
	{
		e.preventDefault();
		info='ExitYes';
	})
$('button.Update').click(function(e)
	{
		e.preventDefault();
		info='UpdateYes';
	})
$('button').click(function()										// отслеживание нажатия по любой кнопке на форме 
{																	// => отпрака запроса на сервер
$.ajax({
 		method: "POST",
  		url: "/Site/Site.php",
  		dataType: 'json',
		data: { 
				info,
		}
	})
		.done (function(msg)										// получение ответа от серера и переход по страницам 
		{
		if (msg["Info"]==="UpdateYes")
		{
			document.location.href='/Site/Update/Update.html';
		}
		else if (msg["Info"]==="ExitYes") 
		{
			document.location.href='Autorise.html';
		}
		else if (msg["Info"]==="DeleteYes")
		{
			document.location.href='Autorise.html';
		}
		else if (msg["Info"]==="DeleteNo")
		{
			alert("ОШИБКА!");
		}
	})
})