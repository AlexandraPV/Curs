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


	public  class Person

	{

		public String name;
		public String surname;
		public int id;
		public DateTime dateBirth;
		List<BookAll> listBook = new List<BookAll>();

		public Object Clone()
		{
			Object clone = null;
			try
			{
				clone = this.MemberwiseClone();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return clone;
		}

		public int getId()
		{
			return id;
		}


		public String getSurname()
		{
			return this.surname;
		}

		public String getName()
		{
			return this.name;
		}

		public DateTime getDateBirth()
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

	public abstract class BookAll

	{
		public int id;
		public String name;
		public String autor;
		public String ganre;
		public String type;
		public int state;
		public bool personState;


		public Object Clone()
		{
			Object clone = null;
			try
			{
				clone = this.MemberwiseClone();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			return clone;
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

		public bool getStatePerson()
		{
			return personState;
		}

		public void setState(int stateNew)
		{
			state = stateNew;
		}

		public void setStatePerson(bool stateNew)
		{
			personState = stateNew;
		}


	}

}
