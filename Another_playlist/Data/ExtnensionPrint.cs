namespace Another_playlist.Data
{
	public static class ExtnensionPrint
	{
		public static void Print<T>(this IEnumerable<T> source, string title)
		{
			if (source == null)
				return;
			Console.WriteLine();
			Console.WriteLine("┌───────────────────────────────────────────────────────┐");
			Console.WriteLine($"│   {Separate(title).PadRight(52, ' ')}│");
			Console.WriteLine("└───────────────────────────────────────────────────────┘");
			Console.WriteLine();
			foreach (var item in source)
				Console.WriteLine(item);
		}
		public static void Print<T>(this T obj, string name)
		{

			Console.WriteLine("┌───────────────────────────────────────────────────────┐");
			Console.WriteLine($"│   {Separate(name).PadRight(52, ' ')}│");
			Console.WriteLine("└───────────────────────────────────────────────────────┘");
			Console.WriteLine(obj);
		}

		static string Separate(string s)
		{
			List<string> res = new();

			int first = 0, end = 0;

			while (end <= s.Length)
			{
				if (end == s.Length || isUpperOrDigit(s[end]))
				{
					res.Add(s[first..end]);
					first = end;
				}
				end++;
			}

			return string.Join(" ", res);
		}

		private static bool isUpperOrDigit(char c)
		{
			if (char.IsDigit(c)) return true;
			else if (char.IsUpper(c)) return true;
			else return false;
		}
	}

}
