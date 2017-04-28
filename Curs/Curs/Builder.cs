using System;
namespace Curs

{

	// Client invoking class
	/*
	public class Client

	{

		public static void Main()

		{

			// Create a PDF report

			PubBuilder bookBuilder = new BookBuilder();

			Director dir = new Director();

			BookPub bookReport = dir.GenerateReport(bookBuilder);

			// Print content

			Console.WriteLine(bookReport.Header);

			Console.WriteLine(bookReport.Content);

			Console.WriteLine(bookReport.Image);

			// Create a Excel report

			PubBuilder magazineBuilder = new MagazineBuilder();

			BookPub magazineReport = dir.GenerateReport(magazineBuilder);

			// Print content

			Console.WriteLine(magazineReport.Header);

			Console.WriteLine(magazineReport.Content);

			Console.WriteLine(magazineReport.Image);

			Console.ReadLine();

		}

	}
	*/
// Report or Product

public class BookPub

	{

		public string PubType;

		public string Header;

		public string Image;

		public string Content;

	}

	// Report Builder - Builder is responsible for defining

	// the construction process for individual parts. Builder

	// has those individual processes to initialize and

	// configure the report.

	public abstract class PubBuilder

	{

		public BookPub report;

		public void CreateReport()

		{

			report = new BookPub();

		}

		public abstract void SetPubType();

		public abstract void SetHeader(string header);

		public abstract void SetImage(string img);

		public abstract void SetContent(string content);

		public BookPub DispatchReport()

		{

			return report;

		}

	}

	// PDF Report class

	public class BookBuilder : PubBuilder

	{

		public override void SetPubType()

		{

			report.PubType = "Book";

		}

		public override void SetHeader(string header)

		{

			report.Header = header;

		}

		public override void SetImage(string img)

		{

			report.Image = img;

		}

		public override void SetContent(string content)

		{

			report.Content = content;

		}

	}

	// Excel Report class

	public class MagazineBuilder : PubBuilder

	{

		public override void SetPubType()

		{

			report.PubType = "Magazine";

		}

		public override void SetHeader(string header)

		{

			report.Header = header;

		}

		public override void SetImage(string img)

		{

			report.Image = img;

		}

		public override void SetContent(string content)

		{

			report.Content = content;

		}

	}


/// Director takes those individual processes from the builder

/// and defines the sequence to build the report.

public class Director

	{

		public BookPub GenerateReport(PubBuilder pubBuilder,string header, string img, string content)

		{

			pubBuilder.CreateReport();

			pubBuilder.SetPubType();

			pubBuilder.SetHeader(header);

			pubBuilder.SetContent(content);

			pubBuilder.SetImage(img);

			return pubBuilder.DispatchReport();

		}

	}

}
