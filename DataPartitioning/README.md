
# Data Partitioning Examples using LINQ

This C# code demonstrates common LINQ methods used for partitioning data collections. It includes examples using `Skip`, `Take`, `Chunk`, and custom extension methods for pagination.



## Program Entry Point

The `Program` class contains the `Main` method, acting as the application's starting point. It allows you to easily switch between different partitioning examples by commenting/uncommenting the calls.

```csharp
namespace DataPartitioning
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Uncomment one of these to run the specific example
			//Skip.main();
			//Take.main();
			//Chunck.main(); // Available in net6.0 and above
			PaginationExample.main();
		}
	}
    // ... other classes below
}
```

## Skip Methods

The `Skip` class illustrates how to use LINQ methods that discard elements from a sequence, either by a fixed count or based on a condition.

```csharp
// Inside the DataPartitioning namespace

/// <summary>
/// Examples of LINQ Skip methods
/// </summary>
class Skip
{
	/*
	 * Skip: Skips a specified number of elements from the start.
	 * SkipWhile: Skips elements from the start as long as a condition is true.
	 * SkipLast: Skips a specified number of elements from the end (.NET Core/.NET).
	 */

	public static void main()
	{
		var employees = Repository.LoadEmployees(); // Loads data (external dependency)

		// Skips the first 10 elements
		var empsSkipFirst10 = employees.Skip(10);
		empsSkipFirst10.Print(nameof(empsSkipFirst10)); // Prints the result (external dependency)

		// Skips elements until an employee with Index 20 is found
		var empsSkipWhileIndexNot20 = employees.SkipWhile(e => e.Index != 20);
		empsSkipWhileIndexNot20.Print(nameof(empsSkipWhileIndexNot20));

		// Skips the last 10 elements
		var empsSkipLast10 = employees.SkipLast(10);
		empsSkipLast10.Print(nameof(empsSkipLast10));
	}
}
```

## Take Methods

The `Take` class demonstrates LINQ methods for selecting elements from the beginning or end of a sequence, or taking elements while a condition holds true.

```csharp
// Inside the DataPartitioning namespace

/// <summary>
/// Examples of LINQ Take methods
/// </summary>
class Take
{
	/*
	 * Take: Takes a specified number of elements from the start.
	 * TakeWhile: Takes elements from the start as long as a condition is true.
	 * TakeLast: Takes a specified number of elements from the end (.NET Core/.NET).
	 */
	public static void main()
	{
		var employees = Repository.LoadEmployees(); // Loads data (external dependency)

		// Takes the first 10 elements
		var empsTakeFirst10 = employees.Take(10);
		empsTakeFirst10.Print(nameof(empsTakeFirst10)); // Prints the result (external dependency)

		// Takes elements until an employee with Index 20 is found
		var empsTakeWhileIndexNot20 = employees.TakeWhile(e => e.Index != 20);
		empsTakeWhileIndexNot20.Print(nameof(empsTakeWhileIndexNot20));

		// Takes the last 10 elements
		var empsTakeLast10 = employees.TakeLast(10);
		empsTakeLast10.Print(nameof(empsTakeLast10));
	}
}
```

## Chunk Method

The `Chunk` class demonstrates the `Chunk` method, which is used to divide a sequence into fixed-size partitions. This is useful for processing data in batches.

```csharp
// Inside the DataPartitioning namespace

/// <summary>
/// Example of LINQ Chunk method
/// </summary>
class Chunck
{
	// Chunk: Splits the elements of a sequence into chunks of a specified size.
	// Available in .NET 6.0 and above
	public static void main()
	{
		var employees = Repository.LoadEmployees(); // Loads data (external dependency)

		// Splits the sequence into chunks of 10 elements
		var chunks = employees.Chunk(10);
		int i = 1;
		foreach (var item in chunks)
		{
			item.Print($"chunk {i}"); // Prints each chunk (external dependency)
			i++;
		}
	}
}
```

## Pagination Examples and Extension Methods

This section presents how to create custom pagination logic using LINQ's `Skip` and `Take`, implemented as extension methods.

The `PaginationExample` class uses these custom extension methods.

```csharp
// Inside the DataPartitioning namespace

/// <summary>
/// Examples of custom pagination extensions
/// </summary>
class PaginationExample
{
	public static void main()
	{
		var employees = Repository.LoadEmployees(); // Loads data (external dependency)

		// Gets the 2nd page, with 30 items per page
		var p1 = employees.Paginate(2, 30);
		p1.Print(nameof(p1)); // Prints the page (external dependency)

		// Gets the first page using default size (10)
		var p2 = employees.Paginate2();
		p2.Print(nameof(p2)); // Prints the page (external dependency)
	}
}
```

The `EctensionPagination` (note the name, possibly a typo) static class provides the `Paginate` extension methods. These methods calculate which elements to return based on the requested page number and size, handling potential invalid inputs.

```csharp
// Inside the DataPartitioning namespace

/// <summary>
/// Extension methods for custom pagination
/// </summary>
static class ExtensionPagination 
{
	/// <summary>
	/// Paginate a sequence by skipping elements for previous pages and taking the current page's elements.
	/// Handles invalid page/size inputs by defaulting them.
	/// </summary>
	/// <typeparam name="T">Type of elements in the sequence.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="page">The page number (1-based). Defaults to 1.</param>
	/// <param name="size">The number of items per page. Defaults to 10.</param>
	/// <returns>An IEnumerable<T> containing the elements for the specified page.</returns>
	public static IEnumerable<T> Paginate<T>(this IEnumerable<T> source, int page = 1, int size = 10)
		where T : class
	{
				// this is not a Side effect the  The parameter is a wrong value 

		// Ensure page and size are valid, default to 1 and 10 if not.
		if (page <= 0) page = 1;
		if (size <= 0) size = 10;

		// Calculate the number of items to skip (items on previous pages)
		int skipCount = (page - 1) * size;

		// Skip the calculated number of items and take the specified size for the current page
		return source.Skip(skipCount).Take(size);
	}

	/// <summary>
	/// Another pagination method, similar to Paginate, also calculating total pages internally
	/// (though not returning the total page count in this method signature).
	/// Handles invalid page/size inputs by defaulting them.
	/// </summary>
	/// <typeparam name="T">Type of elements in the sequence.</typeparam>
	/// <param name="source">The source sequence.</param>
	/// <param name="page">The page number (1-based). Defaults to 1.</param>
	/// <param name="size">The number of items per page. Defaults to 10.</param>
	/// <returns>An IEnumerable<T> containing the elements for the specified page.</returns>
	public static IEnumerable<T> Paginate2<T>(this IEnumerable<T> source,
		int page = 1, int size = 10) where T : class
	{
		if (page <= 0)
		{
			page = 1;
		}

		if (size <= 0)
		{
			size = 10;
		}

		// Calculate total items and total pages (internal calculation, not returned)
		var total = source.Count();
		var pages = (int)Math.Ceiling((decimal)total / size);

		// Calculate skip count and take elements for the current page
		int skipCount = (page - 1) * size;
		var result = source.Skip(skipCount).Take(size);

		return result;
	}
}
```