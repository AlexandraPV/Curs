using System;
using System.Collections.Generic;
using System.Collections;
namespace Curs
{
	/*class MainClass
	{
		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");
		}
	}
*/
	public class PersonCache
	{

		private static Hashtable personMap = new Hashtable();

		public static Person getPerson(String personCode)
		{

			Person cachedPerson = (Person)personMap[personCode];

			return cachedPerson;

		}
	}

	public  class Person

	{

		public String name;
		public String surname;
		public String login;
		public string password;
		public String dateBirth;
		List<BookAll> listBook = new List<BookAll>();


		public Person(String name,String surname, String login, string password, String dateBirth, List<BookAll> listBook)
		{
			this.name = name;
			this.surname = surname;
			this.login = login;
			this.password = password;
			this.dateBirth = dateBirth;
			this.listBook = listBook;
		}


		public String getLogin()
		{
			return login;
		}


		public String getSurname()
		{
			return this.surname;
		}

		public String getPass()
		{
			return password;
		}

		public String getName()
		{
			return this.name;
		}

		public String getDateBirth()
		{
			return this.dateBirth;
		}

		public List<BookAll> getListBook()
		{
			return listBook;
		}

		public void Addtolist(BookAll book)
		{
			listBook.Add(book);
		}

		public void Removelist(BookAll book)
		{
			listBook.Remove(book);
		}

	}

	public class BookAll

	{


		public int id;
		public string name;
		public string autor;
		public string ganre;
		public string type;
		public int state;
		private State personState;


		public BookAll(string name, string autor, string ganre)
		{
			this.name = name;
			this.autor = autor;
			this.ganre = ganre;
		}

		public String getAutor()
		{
			return autor;
		}


		public String getGanre()
		{
			return ganre;
		}

		public String getType()
		{
			return this.type;
		}

		public String getName()
		{
			return name;
		}

		public int getState()
		{
			return state;
		}

		public int getId()
		{
			return id;
		}

		private State getStatePerson()
		{
			return personState;
		}

		public void setState(int stateNew)
		{
			state = stateNew;
		}

		private void setStatePerson(State stateNew)
		{
			personState = stateNew;
		}


	}





}
