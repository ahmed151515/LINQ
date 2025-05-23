namespace CustomLINQExtensionMethod
{
	public static class Extensions
	{
		public static void Print<T>(this IEnumerable<T> source, string title)
		{
			if (source == null)
				return;
			Console.WriteLine();
			Console.WriteLine("┌───────────────────────────────────────────────────────┐");
			Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
			Console.WriteLine("└───────────────────────────────────────────────────────┘");
			Console.WriteLine();
			foreach (var item in source)
			{
				if (typeof(T).IsValueType)
					Console.Write($" {item} "); // 1, 2, 3
				else
					Console.WriteLine(item);
			}
		}

		public static IEnumerable<TSource> Paginante<TSource>(this IEnumerable<TSource> source
			, int page = 1, int pagesSize = 10)
		{
			return source.Skip((page - 1) * pagesSize).Take(pagesSize);
		}
		public static IEnumerable<TSource> Paginante<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predict
			, int page = 1, int pagesSize = 10)
		{
			var res = source.Where(predict);
			return res.Paginante(page, pagesSize);
		}
	}
}
