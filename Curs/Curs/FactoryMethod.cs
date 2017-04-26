using System;

namespace Curs

{
	interface IBook
	{
		string ShipFrom();
	}

	class BookA : IBook
	{
		public String ShipFrom()
		{
			return "PublishingHouse1";
		}
	}

	class BookB : IBook
	{
		public String ShipFrom()
		{
			return "PublishingHouse2";
		}
	}

	class DefaultProduct : IBook
	{
		public String ShipFrom()
		{
			return "Can`t publishing";
		}
	}

	class Creator

	{

		public IBook FactoryMethod(string cover, string pages )         
		{

			if ((cover.Equals("soft")==true) && (pages.Equals("medium")==true))

				return new BookA();

			else

			if ((cover.Equals("hard") == true) && (pages.Equals("good") == true))

				return new BookB();

			else return new DefaultProduct();
		}
	}





/*class Program

	{

		static void Main()
		{
			Creator c = new Creator();
			IBook book;

				book = c.FactoryMethod("soft", "medium");
				Console.WriteLine("New Book " + book.ShipFrom());


			Console.ReadKey();

		}

	}
	*/
}

