
//NO

/*
using System;
namespace Curs

{

	abstract class State

	{

		protected string strStatename;

		abstract public void TakeBook();

	}


	class FirstState : State

	{

		public FirstState()

		{
			strStatename = "FirstState";
		}

		override public void TakeBook()
		{
			Console.WriteLine("Left 2 books");

		}

	}

	class SecondState : State

	{

		public SecondState()

		{
			strStatename = "SecondState";
		}

		override public void TakeBook()
		{
			Console.WriteLine("Left 1 books");

		}

	}

	class EndState : State

	{

		public EndState()

		{
			strStatename = "EndState";
		}

		override public void TakeBook()
		{
			Console.WriteLine("No! You can`t take a book");

		}

	}


	class TakeBook
	{

		private State CurrentState;

		FirstState firstState = new FirstState();
		SecondState secondState = new SecondState();
		EndState endState = new EndState();

		public TakeBook()
		{

			CurrentState = firstState;
		}

		public void TakeBookFirst()
		{
			if (CurrentState == firstState)
			{
				CurrentState.TakeBook();
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

}

*/