const form = document.getElementById('form');			//
const login = document.getElementById('login');			// получение формы и её элементов
const password = document.getElementById('password');	//
document.getElementById('enter').disabled=false;		// если джс вкл. кнопка будет активна
function setErrorFor (input,message)					// сообщение об ошибке
{
	const formControl = input.parentElement;
	const small = formControl.querySelector('small');
	small.innerText=message;
	formControl.className = 'form-control error'
}
function setSuccessFor (input)							// сообщение о том, что всё хорошо
{
	const formControl = input.parentElement;
	formControl.className = 'form-control success';
}
$('button.enter').click(function(e)						// валидация и отправка данных на сервер
	{
	e.preventDefault();
	const loginValue = login.value.trim();
	const passwordValue = password.value.trim();
	if (loginValue==='')
	{
	setErrorFor(login, 'Введите логин');
	}
	else if (passwordValue==='')
	{
	setSuccessFor(login);
	setErrorFor(password, 'Введите пароль');
	}
	else
	{
		setSuccessFor(login);
		setSuccessFor(password);
		$.ajax({
 		method: "POST",
  		url: "/Login/Login.php",
  		dataType: 'json',
		data: { 
			login:loginValue,
			password:passwordValue,
		}
	})
		.done (function(msg)
		{
		if (msg["Info"] === "Да")
		{
			document.location.href = "Site.html";
		}
		else
		{
			setErrorFor(login, 'Непраильно введён логин или пароль');
			setErrorFor(password,'');
			$('input.login').val('');
			$('input.password').val('');
		}
		})
	}
})