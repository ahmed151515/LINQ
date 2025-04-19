namespace FunctionalProgramming
{
	static class ExtensionFunctional02
	{

		public static IEnumerable<Employee> Filter(this IEnumerable<Employee> employees, Predicate<Employee> predicate)
		{
			foreach (var item in employees)
			{
				if (predicate(item))
				{
					yield return item;
				}
			}
		}
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
				Console.WriteLine(item);
		}
	}
}
