
//NO
/*using System;
namespace Curs

{
	class Program

	{

		static void Main(string[] args)

		{

			ConvertAll convertall = new ConvertAll();
			Console.WriteLine(convertall.Convert(25.7f));
			Console.WriteLine(convertall.Convert(28.4f));
			Console.WriteLine(convertall.Convert(25f));
			Console.ReadKey();

		}

	}

	public class ConvertAll
	{
		ConvertFootUkr convertFootUkr = new ConvertFootUkr();
		ConvertUkrEngl convertUkrEngl = new ConvertUkrEngl();

		public float Convert(float val)
		{
			return convertUkrEngl.Convert(convertFootUkr.Convert(val));
		}
	}


	public class MenuOne
	{

		public int Convert(string val)
		{
                switch (val)
			{
				case "enter": return 4;
				case 38: return 5;
				case 39: return 6;
				case 40: return 6.5f;
				case 41: return 7.5f;
				case 42: return 8;
				case 43: return 9;
				case 44: return 9.5f;
				case 45: return 10.5f;
				case 46: return 11.5f;
				default: Console.WriteLine("ERROR"); return -1;

			}
		}
	}


	public class MenuTwo
	{
		public float Convert(int val)
		{
			switch (val)
			{
				case 37: return 4;
				case 38: return 5;
				case 39: return 6;
				case 40: return 6.5f;
				case 41: return 7.5f;
				case 42: return 8;
				case 43: return 9;
				case 44: return 9.5f;
				case 45: return 10.5f;
				case 46: return 11.5f;
				default: Console.WriteLine("ERROR"); return -1;

			}
		}
	}

}

*/