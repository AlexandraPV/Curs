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
			Console.WriteLine("Menu \n Enter - e \n Registration - r \n Add book - b \n ");
			string com = Console.ReadLine();

			if (com.Equals("e") == true)
			{
				Enter();
			}
			else if (com.Equals("r") == true)
			{
				Registration();
			}
			else if(com.Equals("b") == true)
			{
				AddBook();
			}

			else Console.WriteLine("Wrong command");
		}


		static public void Enter()
		{

			String loginP;
			string passwordP;
			Console.WriteLine("Login: ");
			loginP = Console.ReadLine();
			Console.WriteLine("Password: ");
			passwordP = Console.ReadLine();

			List<Person> listpers = OpenListPerson();
			ValidationPerson Prime_Facecontrol = new ValidationPerson();
			foreach (Person pers in listpers)
			{

				if (pers.Login == loginP)
				{
					if (Prime_Facecontrol.Enter_Lib(pers, passwordP) == true)
					{
						Account(pers);
					}

					else {
						Console.WriteLine("Try again");
						Enter();

					}
				}


			}

		}


		static public void Registration()
		{
			BookAll book1 = new BookAll("name1", "autor1", "ganre1",1);
			string name;
			string surname;
			string login;
			string password;
			string dateBirth;
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
			//List<Person> listpers = OpenListPerson();
			Console.WriteLine(name + " " + surname + " Welcome to library!");
			WriteInListPerson(pers);
			Account(pers);
			//Enter(personMap);    //test (must delete)
		}



		static public void AddBook()
		{
			
		    string name;
		    string autor;
			string ganre;

			Console.WriteLine("Name:");
			name = Console.ReadLine();
			Console.WriteLine("Autor:");
			autor = Console.ReadLine();
			Console.WriteLine("Ganre:");
			ganre = Console.ReadLine();

			BookAll book = new BookAll(name, autor, ganre, 1);
			Console.WriteLine(name + "  " + autor + " New Book");
			WriteInListBooks(book);

		}



		static public void Account(Person pers)
		{
			Console.WriteLine("Name: " + pers.Name);
			Console.WriteLine("Surname: " + pers.Surname);
			Console.WriteLine("Date of birth: " + pers.DateBirth);
			Console.WriteLine("Books: ");
			foreach (BookAll book in pers.ListBook)
			{
				Console.WriteLine(book.NameB + " " + book.AutorB + "\n");
			}
			Console.WriteLine("\n");
			Command();

		}

		static public int GetIDPerson(Person pers)
		{
			List<Person> perslist = OpenListPerson();
			for (int i = 0; i <= perslist.ToArray().Length; i++)
			{
				if (perslist[i].Login == pers.Login)
					return i;
				else return -1;
			}
			return 10;
		}

		static public int GetIDBookPerson(int id, string name, string autor)
		{
			List<Person> perslist = OpenListPerson();
			List<BookAll> listbook = new List<BookAll>();
			listbook = perslist[id].ListBook;
			for (int i = 0; i <= listbook.ToArray().Length; i++)
			{
				if (listbook[i].NameB == name && listbook[i].AutorB == autor)
					return i;
			}
			return 10;
		}





		static public void AddBookToPerson(string name, string autor, Person pers)
		{
			XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
			List<Person> perslist = OpenListPerson();
			int id = GetIDPerson(pers);
			Console.WriteLine(id);
			// получаем поток, куда будем записывать сериализованный объект

		
			List<BookAll> booklist = OpenListBooks();

			foreach (BookAll book in booklist)
			{
				if (book.NameB == name && book.AutorB == autor)
				{
					//book.setStateTakeBook();
					book.PersonStateB = "bookTakenState";
					//newP.ListBook.Add(book);
					perslist[id].ListBook.Add(book);
					//perslist.Remove(pers);
					//perslist.Add(newP);
					using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
					{

						formatter.Serialize(fs, perslist);
						Console.WriteLine("AddBookToPerson");
					}


				}
			}
		}


		static public void ReturnBookPerson(string name, string autor, Person pers)
		{
			XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
			List<Person> perslist = OpenListPerson();
			int id = GetIDPerson(pers);
			int idB = GetIDBookPerson(id, name, autor);
			Console.WriteLine(id);
			Console.WriteLine(idB);
			// получаем поток, куда будем записывать сериализованный объект
			List<BookAll> booklist = OpenListBooks();

			foreach (BookAll book in booklist)
			{
				if (book.NameB == name && book.AutorB == autor)
				{
					//book.setStateTakeBook();
					book.PersonStateB = "bookInLibraryState";

					perslist[id].ListBook.RemoveAt(idB);

					using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
					{

						formatter.Serialize(fs, perslist);
						Console.WriteLine("AddBookToPerson");
					}


				}
			}
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

		public static List<Person> OpenListPerson()
		{
			XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
			using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
			{
				List<Person> newPerson = (List<Person>)formatter.Deserialize(fs);

				Console.WriteLine("Объект десериализован");
				return newPerson;
			}
		}

		public static void WriteInListPerson(Person pers)
		{
			XmlSerializer formatter = new XmlSerializer(typeof(List<Person>));
			List<Person> perslist = OpenListPerson();
			Console.WriteLine(pers.Login);
			perslist.Add(pers);

			// получаем поток, куда будем записывать сериализованный объект
			using (FileStream fs = new FileStream("persons.xml", FileMode.OpenOrCreate))
			{
				
				formatter.Serialize(fs, perslist);
				Console.WriteLine("WriteInListPerson");
			}
		}





		public static List<BookAll> OpenListBooks()
		{
			XmlSerializer formatter = new XmlSerializer(typeof(List<BookAll>));
			using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
			{
				List<BookAll> newBooks = (List<BookAll>)formatter.Deserialize(fs);

				Console.WriteLine("Объект десериализован");

				return newBooks;
			}
		}

		public static void WriteInListBooks(BookAll book)
		{
			XmlSerializer formatter = new XmlSerializer(typeof(List<BookAll>));
			//List<BookAll> booklist = new List<BookAll>();
			List<BookAll> booklist = OpenListBooks();
			Console.WriteLine(book.NameB);
			booklist.Add(book);

			// получаем поток, куда будем записывать сериализованный объект
			using (FileStream fs = new FileStream("books.xml", FileMode.OpenOrCreate))
			{

				formatter.Serialize(fs, booklist);
				Console.WriteLine("WriteInListBooks");
			}
		}


		static public void Command()
		{
			while (true)
			{
				Console.WriteLine("\n \n If you need help please enter 'h' : ");
				string val = Console.ReadLine();
				ConvertAll convertall = new ConvertAll();
				convertall.Convert(val);
				string val1 = Console.ReadLine();
				convertall.Convert(val1);
			}

		}



		static void Main(string[] args)
		{


			//BookAll book = new BookAll("Taras Bulba", "Gogol", "povest");
			//WriteInListBooks(book);
			//Person pers = new Person();
			//pers = OpenListPerson()[0];
			//AddBookToPerson("Taras Bulba", "Gogol",pers);

			Menu1();
			Console.ReadKey();

		}


	}


}