using System.Collections;

namespace CoreOfLINQ
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Example01.main();
			//Example02.main();
			//Example03.main();
			Example04.main();
		}

	}
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


	public static class Example01
	{
		public static void main()
		{
			var employees = Repository.LoadEmployees();

			var femaleWithSartsSFilter = employees.Filter(e => e.Gender == "female" && e.FirstName.ToLower().StartsWith("s"));
			femaleWithSartsSFilter.Print("female With Sarts S Filter");

			var femaleWithSartsSWhere = employees.Where(e => e.Gender == "female" && e.FirstName.ToLower().StartsWith("s"));
			femaleWithSartsSWhere.Print("female With Sarts S Where");
			var femaleWithSartsSQuery =
				from e in employees where e.Gender == "female" && e.FirstName.ToLower().StartsWith("s") select e;
			femaleWithSartsSQuery.Print("female With Sarts S Query");
		}
	}
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
	public static class Example04
	{
		public static void main()
		{
			var employees = Repository.LoadEmployees();

			var empMale = employees.Where(x => x.Gender == "male");

			var empsSalaryOver300K = employees.Where(x => x.Salary >= 300_000);

			empMale.Print("Male Employees");

			empsSalaryOver300K.Print("Employees with Salary >= 300K");

			var empMaleInHRDepartment =
				empMale.Where(x => x.Department.ToLowerInvariant() == "hr");
			empMaleInHRDepartment.Print("Male Employees In HR");
			Console.ReadKey();
		}
	}

}

