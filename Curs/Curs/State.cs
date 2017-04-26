using System;
namespace Curs

{

	abstract class State

	{

		public string strStatename;

		abstract public void TakeBook();

	}


	class BookInLibraryState : State

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


	class BookTakenState : State

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


	class BookTakenLongTimeState : State

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

	class BookLostState : State

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

	/*

	class LibraryBook
	{
		private State CurrentState;

		BookInLibraryState bookInLibraryState = new BookInLibraryState();
		BookTakenState bookTakenState = new BookTakenState();
		BookTakenLongTimeState bookTakenLongTimeState = new BookTakenLongTimeState();
		BookLostState bookLostState = new BookLostState();


		public LibraryBook()
		{
			CurrentState = firstState;
		}

		public void InstallProgramFirst()
		{
			if (CurrentState == firstState)
			{
				CurrentState.Install();
				CurrentState = secondState;
			}
			else Console.WriteLine("Programm already is installed");
		}



		public void InstallProgramSecond()
		{
			if (CurrentState == secondState)
			{
				CurrentState.Install();
				CurrentState = thirdState;
			}
			else if (CurrentState == firstState)
			{
				Console.WriteLine("You should install First program");
			}
			else Console.WriteLine("Programm already is installed");
		}

		public void InstallProgramThird()
		{


			if (CurrentState == thirdState)
			{
				CurrentState.Install();
				CurrentState = endState;

			}
			else if (CurrentState == firstState)
			{
				Console.WriteLine("You should install First and Second program");
			}
			else if (CurrentState == secondState)
			{
				Console.WriteLine("You should install Second program");
			}

			else if (CurrentState == endState)
			{
				Console.WriteLine("Programm already is installed");
			}

		}

	}




	public class Client

	{

		public static int Main(string[] args)

		{

			Computer computer = new Computer();

			computer.InstallProgramSecond();
			computer.InstallProgramFirst();
			computer.InstallProgramSecond();
			computer.InstallProgramThird();
			computer.InstallProgramThird();



			Console.ReadKey();

			return 0;

		}

	}
*/
}
