namespace SortingData
{
	public class Reverse
	{
		public static void main()
		{
			string[] fruits =
				{ "apricot", "orange", "banana", "mango",
				"apple", "grape", "strawberry" };

			var fruitsReverse = fruits.Reverse();
			// Reverse() returns an IEnumerable<T> and must be assigned to a variable for further use.

			fruitsReverse.Print(nameof(fruitsReverse));
		}
	}

}
