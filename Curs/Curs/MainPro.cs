using System;
using System.Collections.Generic;
using System.Collections;

namespace Curs
{
	public class MainPro
	{
		static public void Menu1()
		{
			Console.WriteLine("Menu \n Enter - e \n Registration - r \n ");
			string com = Console.ReadLine();

			if (com.Equals("e") == true)
			{
				Enter(personMap);
			}
			else if (com.Equals("r") == true)
			{
				Registration(personMap);
			}
			else Console.WriteLine("Wrong command");
		}


		static public void Enter(Hashtable personMap)
		{
			
			String loginP;
			string passwordP;
			Console.WriteLine("Login: ");
			loginP = Console.ReadLine();
			Console.WriteLine("Password: ");
			passwordP = Console.ReadLine();

			Person pers = (Person)personMap[loginP];
			ValidationPerson Prime_Facecontrol = new ValidationPerson();

			if (Prime_Facecontrol.Enter_Lib(pers, passwordP) == true)
			{
				Account(pers);
			}
			else {
				Console.WriteLine("Try again");
				Enter(personMap);
			}


		}


		static public void Registration(Hashtable personMap)
		{
			BookAll book1 = new BookAll("name1", "autor1", "ganre1");
			String name;
			String surname;
			String login;
			string password;
			String dateBirth;
			List<BookAll> listBook1 = new List<BookAll>();
			listBook1.Add(book1);

			Console.WriteLine("Name:");
			name = Console.ReadLine();
			Console.WriteLine("Surname:");
			surname = Console.ReadLine();
			Console.WriteLine("Login:");
			login = Console.ReadLine();
			Console.WriteLine("Date of birth:");
			dateBirth = Console.ReadLine();
			Console.WriteLine("Password:");
			password = Console.ReadLine();

			Person pers = new Person(name, surname, login, password, dateBirth, listBook1);
			personMap[pers.login] = pers;	
			Console.WriteLine(name +" "+ surname +" Welcome to library!");
			Account(pers);
			Enter(personMap);    //test (must delete)
		}

		static public void Account(Person pers)
		{
			Console.WriteLine("Name: " + pers.name);
			Console.WriteLine("Surname: " + pers.surname);
			Console.WriteLine("Date of birth: " + pers.dateBirth);
			Console.WriteLine("Books: ");
			foreach (BookAll book in pers.getListBook())
			{
				Console.WriteLine(book.name + " " + book.autor + "\n");
			}


		}


		public static Hashtable personMap = new Hashtable();

		static void Main(string[] args)
		{
			

			Menu1();
			Console.ReadKey();

		}
	}
}
