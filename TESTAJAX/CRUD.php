<?php
header('Content-type: application/json');
class User
{
	public $data;
	public function Connect()										// метод чтения файла
	{
		$data = file_get_contents(__DIR__ . '/Register/user.json'); // чтение файла
		$this->data = json_decode($data, true);						// декодирование данных json формата
	}

	public function Write()											//метод записи в файл
	{ 
		$data = json_encode($this->data, JSON_PRETTY_PRINT);		// кодирование в json
		file_put_contents(__DIR__ . '/Register/user.json',$data);	// запись данных в файл
	}

	public function Update()
	{
		$infono = array("Info"=>"No");
		$this->Connect();											// Соединение с бд
		$salt = '1b34r7q5';											// соль пароля
		session_start();											// запуск сессии
		if(!file_get_contents(__DIR__ . '/Register/user.json')) 	// проерка на пустоту файла
		{
				echo json_encode($infono);							// ответ от сервера 
		}		
		else{																
		foreach ($this->data as $key => $value) 					// Поиск записи пользователя в бд
		{			
			if($_SESSION['login']==$value['login'])					// проерка на существующую запись 
			{
				$updatearr = array(									// перезапись
				'login' => $value['login'],							// данных
				'email' => $value['email'],
				'password' => md5($salt.$_POST['password']),
				'name' => $_POST['name']);	
				$_SESSION['name']=$_POST['name'];					// обноление данных сессии
				$this->data[$key] = $updatearr;						// обноление записи пользователя пользователя
				$this -> Write();									// запись обновлённых данныъ в бд
				$infoyes = array("Info"=>"Yes");					// создание массиа для ответа в json 
				echo json_encode($infoyes);							// кодирование в json и отпрака ответа клиенту
				$found = true;										
				break;
			}
		}
	}
	if($found === false)											// выполнена перезпись или нет
			{
				echo json_encode($infono);
			}	
}

	public function Delete()										// метод удаления пользоателя
	{
		$delete= array ("Info"=>"DeleteYes");						// переменная для ответа
		session_start();											// запуск сессии
		$this->Connect();											// конект с файлом
		if(!file_get_contents(__DIR__ . '/Register/user.json'))		// проерка на пустой файл 
		{
			$delete["Info"]="DeleteNo";								// если файл пустой - ошибка
			echo json_encode($delete);
		}
		else
		{
		foreach ($this->data as $key => $value)						// поиск записи в файле
		{
		if ($_SESSION['login']==$value['login'])					// если запись найдена - удалить 
		{
			unset($this->data[$key]);								// удаление
		}	
		$this -> Write();											// перезапись файла
		echo json_encode($delete);									// ответ сервера
		session_unset();											// удаление сессии
		break;
		}
	}
}

	public function ValidLog()										// метод проерки логина на сущестующий
	{
		$this-> Connect();											// конекст с файлом
		if(!file_get_contents(__DIR__ . '/Register/user.json'))		// проерка на пустой файл 
		{
			$GLOBALS['log']=0;
		}
		else
		{
		foreach ($this->data as $value)								// поиск нужной информации
		{
			if ($value['login'] == $_POST['login'])					// сравнение водимого и сущестующего логина
			{
				$GLOBALS['log']=1;									// если есть совпадение
				break;
			}
			else
			{
				$GLOBALS['log']=0;									// если нет совпадений
			}
		}
	}
}


	public function EmailLog()										// метод проерки маила на существующий
	{
		$this -> Connect();											// чтение файла
		if(!file_get_contents(__DIR__ . '/Register/user.json'))		// проерка на пустой файл 
		{
			$GLOBALS['maillog']=0;
		}
		else
		{
		foreach ($this->data as $value)
		{
			if ($value['email'] == $_POST['email'])					//поиск совпадений
			{
				$GLOBALS['maillog']=1;								//если совпадения есть
					break;
			}
			else
			{
				$GLOBALS['maillog']=0;								// если совпадений нет 
			}
		}
	}
	}
	public function CRUD_ADD()										// метод создания нового юзера
		{	
		$user = new User;											// подключение класса
		$user -> ValidLog();										// проверка на регистрируемый логин
		$user -> EmailLog();										// проверка на регистрируемый емаил
		
		if ($GLOBALS['log']== 1)									// условие на проерку существующего логина
		{
			$info = array('Info'=>'Этот логин уже занят');		
			echo json_encode($info);							
		}
			elseif($GLOBALS['maillog']==1)							// условие на проерку существующего маила
			{
				$info['Info'] ='Этот адрес уже занят';
				echo json_encode($info);
			}
		else
		{
			$salt = '1b34r7q5';										// соль пароля
			$this -> Connect();										// конект с файлом
			$add_arr = array(										//создание нового юзера
			"login" => $_POST['login'],
			"password" => md5($salt.$_POST['password']),
			"email" => $_POST['email'],
			"name" => $_POST['name']
		);
		$this->data[] = $add_arr;
		$this -> Write();											// зпись нового юзера в файл
		$info['Info']='Вы успешно зарегестрировались!';
		echo json_encode($info);
		}
		}

		public function pasLog()									// метод сверки логина и пароля юзера
		{
		$this->Connect();											// конект с файлом 
		$salt = '1b34r7q5';											// соль пароля
		$GLOBALS['result']=false;									// переменная для результата
		if(!file_get_contents(__DIR__ . '/Register/user.json'))		// проерка на пустой файл 
		{
			$errpass = json_encode('Нет');
		}
		else
		{
				foreach ($this->data as $data) 						// поиск нужной записи
				{
					if ($data['login']===$_POST['login'])			// поиск логина
				{   
					if ($data['password'] === md5($salt.$_POST['password']))	// поиск пароля
				{
					$GLOBALS['name']=$data['name'];					// переменная для передачи имени в сессию
					$GLOBALS['login']=$_POST['login'];				// переменная для передачи логина в сессию
					$GLOBALS['result'] = true;						// переменная для передачи результата в метод login
					break;	
				}
			}
			}
		}
	}

		public function login()										// метод авторизации пользоателя
		{
		$user = new User;											
		$user->pasLog();											// проверка на существующую запись
		if (false!=$GLOBALS['result'])
		{
			session_start();										// старт сессии
			setcookie("visit", $_POST['login'], strtotime("+30 days")); // старт куки
			$_SESSION['login'] = $_POST['login'];					// запись в сессию логина
			$_SESSION['name'] = $GLOBALS['name'];					// запись в сессию имени
			$errpass = array("Info"=>'Да');
			echo json_encode($errpass);								// ответ сервера
			
		}
		else
		{
			$errpass = array("Info"=>'Нет');
			echo json_encode($errpass);
		}
	}
}
?>