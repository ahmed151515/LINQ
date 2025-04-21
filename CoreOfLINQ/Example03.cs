namespace CoreOfLINQ
{
	public static class Example03
	{
		public static void main()
		{

			var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			// Using extension method syntax (most common in C#)
			// Note: The compiler internally converts  this to Enumerable.Where
			var evenNumsUsingExtensionWhere = numbers.Where(n => n % 2 == 0);


			// Using Enumerable.Where explicitly (equivalent to the above)
			var evenNumsUsingEnumerableWhere = Enumerable.Where(numbers, n => n % 2 == 0);

			// Using LINQ query syntax (more readable for complex queries like joins or working with databases)
			// Note: The compiler internally converts this to Enumerable.Where
			var evenNumsUsingQuerySyntax = from n in numbers where n % 2 == 0 select n;


			evenNumsUsingExtensionWhere.Print(nameof(evenNumsUsingExtensionWhere));
			evenNumsUsingEnumerableWhere.Print(nameof(evenNumsUsingEnumerableWhere));
			evenNumsUsingQuerySyntax.Print(nameof(evenNumsUsingQuerySyntax));
		}
	}

}

