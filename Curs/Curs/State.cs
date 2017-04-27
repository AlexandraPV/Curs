using System;
namespace Curs

{

	public abstract class State

	{

		public string strStatename;

		abstract public void TakeBook();

	}


	public class BookInLibraryState : State

	{

		public BookInLibraryState()

		{
			strStatename = "BookInLibraryState";

		}

		override public void TakeBook()

		{
			Console.WriteLine("You can take a book");

		}

	}


	public class BookTakenState : State

	{
		public BookTakenState()

		{
			strStatename = "BookTakenState";
		}

		override public void TakeBook()

		{

			Console.WriteLine("The book is taken");

		}

	}


	public class BookTakenLongTimeState : State

	{

		public BookTakenLongTimeState()

		{
			strStatename = "BookTakenLongTimeState";
		}

		override public void TakeBook()

		{

			Console.WriteLine("The book is taken for a long time");

		}

	}

	public class BookLostState : State

	{

		public BookLostState()

		{
			strStatename = "BookLostState";
		}

		override public void TakeBook()

		{

			Console.WriteLine("The book is lost");

		}

	}



}
