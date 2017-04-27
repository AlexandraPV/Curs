using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Microsoft.Win32.SafeHandles;
using System.Runtime;

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
			Console.WriteLine(name + " " + surname + " Welcome to library!");
			Account(pers);
			//Enter(personMap);    //test (must delete)
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
			Console.WriteLine("\n");
			Command();

		}

		static public void FindBook(string name, string autor)
		{
			
		}


		static public void TakeBook(BookAll book, Person pers)
		{
			pers.Addtolist(book);
			book.setStateTakeBook();
		}

		static public void ReturnBook(BookAll book, Person pers)
		{
			foreach (BookAll book1 in pers.getListBook())
			{
				if (book1.name == book.name && book1.autor == book.autor)
				{
					pers.Removelist(book);
					book.setStateReturnBook();
				}
				else Console.WriteLine("You didn`t take this book");
			}

		}




		static public void Command()
		{
			Console.WriteLine("\n \n If you need help please enter 'h' : ");
			string val = Console.ReadLine();
			ConvertAll convertall = new ConvertAll();
			convertall.Convert(val);
			string val1 = Console.ReadLine();
			convertall.Convert(val1);

		}

		public static Hashtable personMap = new Hashtable();

		static void Main(string[] args)
		{
			
			List<BookAll> listBook1 = new List<BookAll>();
			BookAll book1 = new BookAll("name1", "autor1", "ganre1");
			listBook1.Add(book1);
			//string[] listB = {book1.name};

			Person person = new Person("Name", "Surname", "login", "pass", "01/02/1998", listBook1);
			Person person2 = new Person("Name2", "Surname2", "login2", "pass2", "01/02/1998", listBook1);
			Console.WriteLine("Объект создан");

			List<Person> perslist = new List<Person>();
			perslist.Add(person);
			perslist.Add(person2);
			// передаем в конструктор тип класса
			XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));

			// получаем поток, куда будем записывать сериализованный объект
			using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, perslist);

				Console.WriteLine("Объект сериализован");
			}

			// десериализация
			using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
			{
				List<Person> newPerson = (List<Person>)formatter.Deserialize(fs);

				Console.WriteLine("Объект десериализован");
				Console.WriteLine(newPerson[0].Name + newPerson[0].Surname);
				Console.WriteLine(newPerson[1].Name + newPerson[1].Surname);
			}



			Menu1();
			Console.ReadKey();

		}


	}


}