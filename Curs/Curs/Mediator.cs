using System;
using System.Collections.Generic;
namespace Curs

{

	/*class MainApp

	{

		static void Main()
		{
			BookAll book1 = new BookAll("name1", "autor1", "ganre1");
			BookAll book2 = new BookAll("name2", "autor2", "ganre2");

			List<BookAll> listBookPostach1 = new List<BookAll>();
			listBookPostach1.Add(book1);
			listBookPostach1.Add(book2);

			BookAll book3 = new BookAll("name3", "autor3", "ganre3");
			BookAll book4 = new BookAll("name4", "autor4", "ganre4");

			List<BookAll> listBookPostach2 = new List<BookAll>();
			listBookPostach2.Add(book3);
			listBookPostach2.Add(book4);

			Postach post1 = new Postach("post1", listBookPostach1);
			Postach post2 = new Postach("post2", listBookPostach2);

			AbstractCompany comp = new AbstractCompany();
			comp.Addtolist(post1);
			comp.Addtolist(post2);

			Console.WriteLine(comp.ChooseProd("name2", "autor2").name);
			Console.WriteLine(comp.ChooseProd("name3", "autor3").name);
			Console.WriteLine(comp.ChooseProd("name4", "autor1").name);
			Console.ReadKey();

		}

	}
*/


	class AbstractCompany

	{
		List<Postach> list = new List<Postach>();

		public void Addtolist(Postach post)
		{
			list.Add(post);
		}

		public BookAll ChooseProd(string nameB, string autorB)
		{
			foreach (Postach post in list)
			{
				if (post.CheckParams(nameB, autorB) == true)
				{
					return post.FindBookPostach(nameB, autorB);
				}

			}
			return new BookAll("no", "no", "no");
		}

	}


	class Postach
	{
		public string name;
		List<BookAll> listBookPostach = new List<BookAll>();


		public Postach(string name, List<BookAll> listBookPostach)
		{
			this.name = name;
			this.listBookPostach = listBookPostach;

		}

		public void AddtolistPostach(BookAll book)
		{
			listBookPostach.Add(book);
		}

		public BookAll FindBookPostach(string nameB, string autorB)
		{
			foreach (BookAll book in listBookPostach)
			{
				if (book.name == nameB && book.autor == autorB)
				{
					return book;
				}

			}
			throw new ApplicationException("Can`t find");
		}


		public bool CheckParams(string nameB, string autorB)
		{

			foreach (BookAll book in listBookPostach)
			{
				if (book.name == nameB && book.autor == autorB)
				{
					return true;
				}

			}
			return false;
		}
	}
}

