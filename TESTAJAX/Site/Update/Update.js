const form = document.getElementById('form');					//
const password1 = document.getElementById('password1');			// получение элементов
const password2 = document.getElementById('password2');			// формы
const name = document.getElementById('name');					//
document.getElementById('Update').disabled=false;				// если js будет включён кнопки будут актины
document.getElementById('Exit').disabled=false;					// 

function setErrorFor (input,message)							// сообщение об ошибке
{
	const formControl = input.parentElement;
	const small = formControl.querySelector('small');			// обращение к элементу "small" на форме
	small.innerText=message;
	formControl.className = 'form-control error'
}

function setSuccessFor (input)									// правильно заполненные поля
{
	const formControl = input.parentElement;
	formControl.className = 'form-control success';
}

function regName(name)											// регулярное выражение для поля имени
{
	return /^[А-Яа-яЁё]{2,16}$/.test(name);
}

function regPas(password1)										// регулярное ыражение для поля пароля
{
	return /^(?=.*[A-Z].*[A-Z])(?=.*[0-9].*[0-9])(?=.*[a-z].*[a-z].*[a-z]).{8,32}$/.test(password1);
}

$('button.Exit').click(function(e)								// запрос для кнопки выйти на странице update
	{
		e.preventDefault();
		var Exit = "Exit";
		$.ajax({
 		method: "POST",
  		url: "/Site/Update/Update.php",
  		dataType: 'json',
		data: { 
			Exit:Exit,
		}
	})
		.done (function(msg)
		{
		if (msg["Info"]=== "Yes")
		{
			document.location.href = "/Site.html";
		}
		else
		{
			alert("ERROR");
		}
	})
	})

$('button.Update').click(function(e)							// запрос и проерка вводимых данных
	{
	e.preventDefault();
	const pass1Val = password1.value;
	const pass2Val = password2.value;
	const nameVal = name.value;
	if (pass1Val==='')
	{
		setErrorFor(password1, 'Введите пароль');
	}
	else if (!regPas(pass1Val))
	{
		setErrorFor(password1, 'Введите пароль корректно');
	}
	else if (pass2Val==='')
	{
		setSuccessFor(password1);
		setErrorFor(password2, 'Введите пароль повторно');
	}
	else if (pass1Val != pass2Val)
	{	
		setSuccessFor(password1);
		setErrorFor(password2, 'Повторный пароль не верен');
	}
	else if (nameVal==='')
	{
		setSuccessFor(password1);
		setSuccessFor(password2);
		setErrorFor(name, 'Введите имя');
	}
	else if (!regName(nameVal))
	{
		setErrorFor(name, 'Введите имя корректно');
	}
	else
	{
		setSuccessFor(name);
		$.ajax({
 		method: "POST",
  		url: "/Site/Update/Update.php",
  		dataType: 'json',
		data: { 
			password:pass1Val,
			name:nameVal,
		}
	})
		.done (function(msg)
		{
		if (msg["Info"]=== "Yes")
		{
			alert("Ваши данные успешно изменены");
			document.location.href = "/Site.html";
		}
		else
		{
			alert("ERROR");
		}
		})
	}
})