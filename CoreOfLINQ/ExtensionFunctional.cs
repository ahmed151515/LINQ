namespace CoreOfLINQ
{
	public static class ExtensionFunctional
	{

		public static IEnumerable<Employee> Filter
			(this IEnumerable<Employee> source, Func<Employee, bool> predicate)
		{

			foreach (var employee in source)
			{
				if (predicate(employee))
				{
					yield return employee;
				}
			}
		}
		public static IEnumerable<int> FilterIntYield
			(this IEnumerable<int> source, Func<int, bool> predicate)
		{

			foreach (var employee in source)
			{
				if (predicate(employee))
				{
					yield return employee;
				}
			}

		}
		public static IEnumerable<int> FilterIntNewList
			(this IEnumerable<int> source, Func<int, bool> predicate)
		{
			var res = new List<int>();
			foreach (var n in source)
			{
				if (predicate(n))
				{
					res.Add(n);
				}
			}
			return res;
		}

		public static void Print<T>(this IEnumerable<T> source, string title = "")
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
			Console.WriteLine();


		}
	}

}

