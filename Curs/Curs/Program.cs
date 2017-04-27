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

	[Serializable]
	public  class Person

	{
		[XmlIgnore]
		public String name;
		[XmlIgnore]
		public String surname;
		[XmlIgnore]
		public String login;
		[XmlIgnore]
		public string password;
		[XmlIgnore]
		public String dateBirth;
		[XmlIgnore]
		List<BookAll> listBook = new List<BookAll>();







		/*public Person(String name,String surname, String login, string password, String dateBirth, List<BookAll> listBook)
		{
			this.name = name;
			this.surname = surname;
			this.login = login;
			this.password = password;
			this.dateBirth = dateBirth;
			this.listBook = listBook;
		}*/

		[XmlElement("name")]
		public string Name { get; set; }
		[XmlElement("surname")]
		public string Surname { get; set; }
		[XmlElement("login")]
		public string Login { get; set; }
		[XmlElement("password")]
		public string Password { get; set; }
		[XmlElement("dateBirth")]
		public string DateBirth { get; set; }

		[XmlArray("listBook")]
		public List<BookAll> ListBook { get; set; }

		public Person(){ }

		public Person(string name, string surname, string login, string password, string dateBirth, List<BookAll> listBook)
		{
			Name = name;
			Surname = surname;
			Login = login;
			Password = password;
			DateBirth = dateBirth;
			ListBook = listBook;
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
		public State personState;

		BookInLibraryState bookInLibraryState = new BookInLibraryState();
		BookTakenState bookTakenState = new BookTakenState();
		BookTakenLongTimeState bookTakenLongTimeState = new BookTakenLongTimeState();
		BookLostState bookLostState = new BookLostState();

		[XmlElement("nameB")]
		public string NameB { get; set; }
		[XmlElement("autorB")]
		public string AutorB { get; set; }
		[XmlElement("ganreB")]
		public string GanreB { get; set; }

		public BookAll() { }

		public BookAll(string name, string autor, string ganre)
		{
			NameB = name;
			AutorB = autor;
			GanreB = ganre;
		}




		/*public BookAll(string name, string autor, string ganre)
		{
			this.name = name;
			this.autor = autor;
			this.ganre = ganre;
			this.personState = bookInLibraryState;
		}*/

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


		public int getId()
		{
			return id;
		}

		public State getStatePerson()
		{
			return personState;
		}

		public void setStatePersonLongTime()
		{
			if (personState == bookTakenState)
				personState = bookTakenLongTimeState;
			else Console.WriteLine("NO1");
		}

		public void setStatePersonLostBook()
		{
			if (personState == bookTakenState || personState == bookTakenLongTimeState)
				personState = bookLostState;
			else Console.WriteLine("NO2");
		}

		public void setStateTakeBook()
		{
			personState = bookTakenState;
		}

		public void setStateReturnBook()
		{
			if(personState == bookTakenState || personState == bookTakenLongTimeState)
			personState = bookInLibraryState;
		}

	}





}
