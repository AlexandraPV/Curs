using System;
using System.Collections.Generic;
namespace Curs

{
	/*class Program

	{

		static void Main(string[] args)

		{

			ConvertAll convertall = new ConvertAll();
			Console.WriteLine(convertall.Convert(25.7f));
			Console.WriteLine(convertall.Convert(28.4f));
			Console.WriteLine(convertall.Convert(25f));
			Console.ReadKey();

		}

	}*/

	public class ConvertAll
	{
		MenuOne menuOne = new MenuOne();
		MenuTwo menuTwo = new MenuTwo();

		public void Convert(string val)
		{
		   menuTwo.Convert(menuOne.Convert(val));
		}
	}


	public class MenuOne
	{

		public int Convert(string val)
		{
			
                switch (val)
			{
				case "exit": return 0;   
				case "h": return 1;
				//case "a": return 2;      //account
				case "f": return 3;      //found book
				case "p": return 4;      //print book
				case "d": return 5;      //order
				case "t": return 6;      //take book
				case "r": return 7;     //return book	
				default: Console.WriteLine("ERROR"); return -1;

			}
		}
	}


	public class MenuTwo
	{
		static public void ChooseAgen()
		{
			string cover;
			string pages;
			Console.WriteLine("Type of cover (soft or hard): ");
			cover = Console.ReadLine();
			Console.WriteLine("Type of pages (medium or good): ");
			pages = Console.ReadLine();

			Creator c = new Creator();
			IBook book;

			book = c.FactoryMethod(cover, pages);
			Console.WriteLine("New Book " + book.ShipFrom());


		}

		static public void DoOrder()
		{
			string name;
			string autor;

			Console.WriteLine("Name:");
			name = Console.ReadLine();
			Console.WriteLine("Autor:");
			autor = Console.ReadLine();

			BookAll book1 = new BookAll("name1", "autor1", "ganre1");
			BookAll book2 = new BookAll("name2", "autor2", "ganre2");

			List<BookAll> listBookPostach1 = new List<BookAll>();
			listBookPostach1.Add(book1);
			listBookPostach1.Add(book2);

			BookAll book3 = new BookAll("name3", "autor3", "ganre3");
			BookAll book4 = new BookAll("name4", "autor4", "ganre4");

			List<BookAll> listBookPostach2 = new List<BookAll>();
			listBookPostach2.Add(book3);
			listBookPostach2.Add(book4);

			Postach post1 = new Postach("post1", listBookPostach1);
			Postach post2 = new Postach("post2", listBookPostach2);

			AbstractCompany comp = new AbstractCompany();
			comp.Addtolist(post1);
			comp.Addtolist(post2);

			Console.WriteLine("The book "+ comp.ChooseProd(name, autor).name + " " + comp.ChooseProd(name, autor).autor + "was ordered. Please wait" );


		}


		public static void FoundBookAutor()
		{

			string autor;

			Console.WriteLine("Please enter information about book \n");
			Console.WriteLine("Autor of book: ");
			autor = Console.ReadLine();

			List<BookAll> booklist = MainPro.OpenListBooks();
			Console.WriteLine("Books \n");
			foreach (BookAll book in booklist)
			{
				if (book.AutorB == autor)
				{
					Console.WriteLine("Name: " + book.NameB);
					Console.WriteLine("Autor: " + book.AutorB);
					Console.WriteLine("Ganre: " + book.GanreB);
					Console.WriteLine("PersonState: " + book.PersonStateB);
					Console.WriteLine("\n");
				}
			}
		}


		public static void FoundBookGanre()
		{ 
			
			string ganre;

			Console.WriteLine("Please enter information about book \n");
			Console.WriteLine("Ganre of book: ");
			ganre = Console.ReadLine();

			List<BookAll> booklist = MainPro.OpenListBooks();
			Console.WriteLine("Books \n");
			foreach (BookAll book in booklist)
			{
				if (book.GanreB == ganre )
				{
					Console.WriteLine("Name: " + book.NameB);
					Console.WriteLine("Autor: " + book.AutorB);
					Console.WriteLine("Ganre: " + book.GanreB);
					Console.WriteLine("PersonState: " + book.PersonStateB);
					Console.WriteLine("\n");
				}
			}
		}

		public static void FoundBookMenu()
		{ 
			Console.WriteLine(" na - name and autor \n a - autor \n g - ganre \n");
			string val = Console.ReadLine();

			if (val == "na")
			{
				FoundBook();
			}
			else if (val == "a")
			{
				FoundBookAutor();
			}
			else if (val == "g")
			{
				FoundBookGanre();
			}
			else {
				Console.WriteLine("Wrong symbol \n");
				FoundBookMenu();
			}
		}

		public static void FoundBook()
		{
			string name;
			string autor;

			Console.WriteLine("Please enter information about book \n");
			Console.WriteLine("Name of book: ");
			name = Console.ReadLine();
			Console.WriteLine("Autor of book: ");
			autor = Console.ReadLine();
			List<BookAll> booklist = MainPro.OpenListBooks();
			Console.WriteLine("Information about this book \n");
			foreach (BookAll book in booklist)
			{
				if (book.NameB == name && book.AutorB == autor)
				{
					Console.WriteLine("Name: " + book.NameB);
					Console.WriteLine("Autor: " + book.AutorB);
					Console.WriteLine("Ganre: " + book.GanreB);
					Console.WriteLine("PersonState: " + book.PersonStateB);
					Console.WriteLine("\n");
				}
			}
		}

		static public void PrintBook()
		{
			InventoryItem itm = new InventoryItem();
			Medium mediumComp = new Medium();
			Cheap cheapComp = new Cheap();
			Expensive expensiveComp = new Expensive();

			string cost;
			string cover;
			string pages;

			Console.WriteLine("Type of cover (Soft or Hard): ");
			cover = Console.ReadLine();
			Console.WriteLine("Type of pages (Medium or Good): ");
			pages = Console.ReadLine();
			Console.WriteLine("Type of cost (Cheap, Medium or Expensive): ");
			cost = Console.ReadLine();

			if ((cover.Equals("Soft") == true) && (cost.Equals("Cheap") == true) && (pages.Equals("Medium") == true))
			{
				itm.SetCost(cheapComp);
				itm.ItemWithStrat();
			}
			else
				if ((cover.Equals("Soft") == true) && (cost.Equals("Medium") == true) && (pages.Equals("Good") == true))
			{
				itm.SetCost(mediumComp);
				itm.ItemWithStrat();
			}
			else
				if ((cover.Equals("Hard") == true) && (cost.Equals("Expensive") == true) && (pages.Equals("Good") == true))
			{
				itm.SetCost(expensiveComp);
				itm.ItemWithStrat();
			}
			else Console.WriteLine("Can`t print your book");
		}

		public void Convert(int val)
		{
			if (val == 1)
				Console.WriteLine(" h - help \n a - account \n f - found book \n p - print book \n d - do order \n t - take a book \n r - return book \n");
			else if (val == 3)
				FoundBookMenu();
			else if (val == 4)
			{
				ChooseAgen();
				PrintBook();
			}
			else if (val == 5)
			{
				DoOrder();
			}
			else if (val == 6)
			{
				string name;
				string autor;

				Console.WriteLine("Please enter information about book \n");
				Console.WriteLine("Name of book: ");
				name = Console.ReadLine();
				Console.WriteLine("Autor of book: ");
				autor = Console.ReadLine();

				String loginP;
				string passwordP;
				Console.WriteLine("Login: ");
				loginP = Console.ReadLine();
				Console.WriteLine("Password: ");
				passwordP = Console.ReadLine();

				List<Person> listpers = MainPro.OpenListPerson();
				ValidationPerson Prime_Facecontrol = new ValidationPerson();

				foreach (Person pers in listpers)
				{
					
					if (pers.Login == loginP)
					{
						if (Prime_Facecontrol.Enter_Lib(pers, passwordP) == true)
						{
							MainPro.AddBookToPerson(name, autor, pers);
						}

						else {
							Console.WriteLine("Try again");
						}
					}


				}

			}
			else if (val == 7)
			{
				string name;
				string autor;

				Console.WriteLine("Please enter information about book \n");
				Console.WriteLine("Name of book: ");
				name = Console.ReadLine();
				Console.WriteLine("Autor of book: ");
				autor = Console.ReadLine();

				String loginP;
				string passwordP;
				Console.WriteLine("Login: ");
				loginP = Console.ReadLine();
				Console.WriteLine("Password: ");
				passwordP = Console.ReadLine();

				List<Person> listpers = MainPro.OpenListPerson();
				ValidationPerson Prime_Facecontrol = new ValidationPerson();

				foreach (Person pers in listpers)
				{

					if (pers.Login == loginP)
					{
						if (Prime_Facecontrol.Enter_Lib(pers, passwordP) == true)
						{
							MainPro.ReturnBookPerson(name, autor, pers);
						}

						else {
							Console.WriteLine("Try again");
						}
					}


				}

			}

			else Console.WriteLine("ERROR");
					

		}
	}

}
