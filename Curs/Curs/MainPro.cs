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
				Console.WriteLine("enter");
			}
			else if (com.Equals("r") == true)
			{
				Registration(personMap);
			}
			else Console.WriteLine("Wrong command");
		}

		static public void Registration(Hashtable personMap)
		{
			
			BookAll book1 = new BookAll("name1", "autor1", "ganre1");
			List<BookAll> listBook1 = new List<BookAll>();
			listBook1.Add(book1);

			Person pers = new Person("name", "surname", "login", "pass", "02/01/1998", listBook1);
				
			Console.WriteLine(pers.name);
		}

		public static Hashtable personMap = new Hashtable();

		static void Main(string[] args)
		{
			

			Menu1();
			Console.ReadKey();

		}
	}
}
