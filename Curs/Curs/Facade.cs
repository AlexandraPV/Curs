using System;
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
				Console.WriteLine(" h - help \n a - account \n f - found book \n p - print book \n");
			else if (val == 3)
				Console.WriteLine("Found book");
			else if (val == 4)
			{
				ChooseAgen();
				PrintBook();
			}
			else Console.WriteLine("ERROR");
					

		}
	}

}
