namespace IEnumerableVsIQueryable
{
	internal class Program
	{
		// only C# understands LINQ
		static void Main(string[] args)
		{
			Console.WriteLine("=============exampleIEnumerable=============");
			exampleIEnumerable();
			Console.WriteLine("=============exampleIQueryable=============");
			exampleIQueryable();


		}

		static void exampleIEnumerable()
		{
			var db = new BookContext();

			var booksPriceAbove500 = db.Books.Where(b => b.Price > 500);

			// This query executes in memory
			// Because `IEnumerable<T>` forces fetching *all* records from the database first,
			// and then filters them in application memory
			IEnumerable<Book> books = db.Books;

			var booksOver50 = books.Where(b => b.Price > 50);

			foreach (var item in booksOver50)
			{
				Console.WriteLine(item);
			}
		}
		static void exampleIQueryable()
		{
			var db = new BookContext();

			// This query executes in the database
			// Because `IQueryable<T>` builds an expression tree that EF Core translates to SQL
			// allowing filtering to happen at the database level
			IQueryable<Book> books = db.Books;

			var booksOver50 = books.Where(b => b.Price > 50);

			foreach (var item in booksOver50)
			{
				Console.WriteLine(item);
			}

		}
	}
}

