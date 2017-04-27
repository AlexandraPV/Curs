using System;
namespace Curs

{

	/*class Program

	{

		static void Main(string[] args)

		{

			ValidationPerson Prime_Facecontrol = new ValidationPerson();

			Person m1 = new Person() { name = "John", password = "pass" };

			Prime_Facecontrol.Enter_Lib(m1, "pass");
			Prime_Facecontrol.Enter_Lib(m1, "pass1");

		

			Console.ReadKey();

		}

	}
*/

	abstract class Abst_Lib
	{
		public abstract bool Enter_Lib(Person pers, string pass);

	}

	//realsubject

	class Lib : Abst_Lib

	{

		public override bool Enter_Lib(Person pers, string pass)

		{

			Console.WriteLine("Welcome to library, {0}", pers.name);
			return true;
		}

	}

	//proxy

	class ValidationPerson : Abst_Lib

	{

		Lib lib = new Lib();

		public override bool Enter_Lib(Person pers, string pass)

		{
			if (pers.Password.Equals(pass) == true)

				return true;

			else {
				Console.WriteLine("Repead enter");
				return false;
			}
		}

	}

}
