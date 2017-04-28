using System;
namespace Curs

{

	/*class Program

	{

		static void Main(string[] args)

		{

			//Set up a chain of candidate handlers to handle the

			//request. Chain will be (1st considered -> last):

			//ConcreteHandler1, ConcreteHandler2. 



			HandlerBase chain = new ConcreteHandler3();

			HandlerBase more = new ConcreteHandler2();

			more.Successor = chain;

			chain = new ConcreteHandler1();

			chain.Successor = more;

			// hand the request to the chain

			Console.WriteLine(chain.SayWhen("saturday"));

			Console.ReadKey();

		}

	}*/

	public interface ILibrary

	{

		// properties

		HandlerBase Successor { set; }

	}



// --- Abstract Handler

abstract public class HandlerBase

	{

		// fields

		protected HandlerBase _successor;

		// properties

		public HandlerBase Successor

		{

			set { _successor = value; }

		}

		// methods

		abstract public string SayWhen(string day);

	}

	// --- Concrete handlers

	public class ConcreteHandler1 : HandlerBase
	{

		// methods

		override public string SayWhen(string day)
		{

			if ((day.Equals("monday") == true) || (day.Equals("wednesday") == true)  || (day.Equals("friday") == true))

				return String.Format("On {0} will be work 111 room. You can take the book there ", day);

            else {

				if (_successor != null)
				{
					Console.WriteLine("The room 111 don`t work on these days");
					return _successor.SayWhen(day);

				}

				else

					return "Don`t work";
				}

		}

	}

	public class ConcreteHandler2 : HandlerBase
	{

		// methods

		override public string SayWhen(string day)
		{

			if ( (day.Equals("tuesday") == true)|| (day.Equals("thursday") == true))

				return String.Format("On {0} will be work 222 room. You can take the book there ", day);

			else {

				if (_successor != null)
				{
					Console.WriteLine("The room 222 don`t work on these days");
					return _successor.SayWhen(day);

				}

				else

					return "Don`t work";
				}

		}
	}

	public class ConcreteHandler3 : HandlerBase

	{

		// methods

		override public string SayWhen(string day)
		{

			if ((day.Equals("saturday") == true)|| (day.Equals("sunday") == true))

				return String.Format("On {0} will be work 333 room. You can take the book there ", day);

			else {

				if (_successor != null)
				{
					Console.WriteLine("The room 333 don`t work on these days");
					return _successor.SayWhen(day);

				}

				else

					return "Don`t work";
				}

		}
	}

}
