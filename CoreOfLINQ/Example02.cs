using System.Collections;

namespace CoreOfLINQ
{
	public static class Example02
	{
		public static void main()
		{
			var numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

			var collection = new ArrayList() { 1, 1.5m, "d", 'c', true, DateTime.Now };

			// Using LINQ to get even numbers (deferred execution using yield)
			var evenNums = numbers.Where(n => n % 2 == 0);

			// Custom method using yield return (deferred execution)
			var evenNumsFilterIntYield = numbers.FilterIntYield(n => n % 2 == 0);

			// Custom method that returns a new list (immediate execution)
			var evenNumsFilterIntNewList = numbers.FilterIntNewList(n => n % 2 == 0);

			// LINQ methods like 'Where' require the collection to implement IEnumerable<T>,
			// which means it must be a generic type. 'ArrayList' is not generic, so LINQ doesn't work on it directly.
			numbers.Add(10);
			numbers.Add(12);
			numbers.Remove(4);

			// Deferred execution: any changes to 'numbers' (like Add/Remove) before iteration
			// will affect the result when 'evenNums' is finally iterated
			evenNums.Print(nameof(evenNums));
			// Output: 2 6 8 10 12

			// Also uses yield, so affected by changes in 'numbers'
			evenNumsFilterIntYield.Print(nameof(evenNumsFilterIntYield));
			// Output: 2 6 8 10 12

			// Immediate execution: result was fixed when the method was called
			evenNumsFilterIntNewList.Print(nameof(evenNumsFilterIntNewList));
			// Output: 2 4 6 8
		}


	}

}

