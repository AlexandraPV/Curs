using System;
namespace Curs

{

	class Program

	{
		
		static void Main(string[] args)

		{

			InventoryItem itm = new InventoryItem();

			Medium mediumComp = new Medium();
			Cheap cheapComp = new Cheap();
			Expensive expensiveComp = new Expensive();

			string cost = "Cheap";
			string cover = "Soft";
			string pages = "Medium";

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







			Console.ReadKey();

		}

	}



	public abstract class IPrintStrategy

	{
		public string cost;
		public string cover;
		public string pages;
		public int quantity;

		public abstract int CalculateCostOnePages(int costC);
		public abstract void Paid(int costC);

	}

	public class Cheap : IPrintStrategy
	{
		public Cheap()
		{
			cost = "Cheap";
			cover = "Soft";
			pages = "Medium";

		}

		public override int CalculateCostOnePages(int costC)
		{
			return 10;
		}

		public override void Paid(int costC)
		{
			Console.WriteLine("You buy and print book. Price:" + costC);
		}

	}

	public class Medium : IPrintStrategy
	{
		public Medium()
		{
			cost = "Medium";
			cover = "Soft";
			pages = "Good";

		}

		public override int CalculateCostOnePages(int costC)
		{
			return 25;
		}

		public override void Paid(int costC)
		{
			Console.WriteLine("You buy and print book. Price:" + costC);
		}

	}

	public class Expensive : IPrintStrategy
	{
		public Expensive()
		{
			cost = "Expensive";
			cover = "Hard";
			pages = "Good";

		}

		public override int CalculateCostOnePages(int costC)
		{
			return 50;
		}

		public override void Paid(int costC)
		{
			Console.WriteLine("You buy and print book. Price:" + costC);
		}

	}

	public class InventoryItem

	{

		private IPrintStrategy _ItemStrat;

		private int _ItemCost;

		public InventoryItem()
		{
		}

		public void SetCost(IPrintStrategy strat)

		{
			_ItemStrat = strat;

		}

		public int ItemCost
		{
			get { return _ItemCost; }

			set { _ItemCost = value; }

		}

		public void ItemWithStrat()

		{
			Console.WriteLine("Price is " + _ItemStrat.CalculateCostOnePages(_ItemCost));

			_ItemStrat.Paid(_ItemStrat.CalculateCostOnePages(_ItemCost));


		}

	}

}

