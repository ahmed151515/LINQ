

# Core of LINQ: Exploring LINQ Concepts in C#

This document provides an overview of LINQ (Language Integrated Query) concepts in C#. It includes examples demonstrating the use of LINQ methods, extension methods, and query syntax. The examples are organized into separate classes (`Example01`, `Example02`, `Example03`, `Example04`) for clarity.

---

## Table of Contents

1. [Extension Methods](#extension-methods)
2. [Example01: Filtering Employees](#example01-filtering-employees)
3. [Example02: Filtering Numbers](#example02-filtering-numbers)
4. [Example03: LINQ Syntax Variations](#example03-linq-syntax-variations)
5. [Example04: Combining Filters](#example04-combining-filters)

---

## Extension Methods

The `ExtensionFunctional` class contains utility extension methods that enhance the functionality of collections. These methods are designed to work with any collection implementing `IEnumerable<T>`.

### Key Methods in `ExtensionFunctional`

1. **`Filter` Method**:
   - **Purpose**: Filters a collection of `Employee` objects based on a condition.
   - **How It Works**:
     - Uses `yield return` to implement deferred execution.
     - Iterates through the source collection and applies the predicate (a function that returns `true` or `false`) to each item.
     - If the predicate returns `true`, the item is included in the result.
   - **Deferred Execution**: The filtering logic is not executed until the result is iterated.

   ```csharp
   public static IEnumerable<Employee> Filter(this IEnumerable<Employee> source, Func<Employee, bool> predicate)
   {
       foreach (var employee in source)
       {
           if (predicate(employee))
           {
               yield return employee;
           }
       }
   }
   ```

2. **`FilterIntYield` Method**:
   - Similar to `Filter`, but works with integers.
   - Demonstrates how `yield return` can be used to create custom filtering logic.

3. **`FilterIntNewList` Method**:
   - **Purpose**: Filters integers and returns a new list.
   - **Immediate Execution**: Unlike `FilterIntYield`, this method creates and returns a new list immediately when called.
   - **Use Case**: Useful when you need to capture the state of the collection at a specific point in time.

   ```csharp
   public static IEnumerable<int> FilterIntNewList(this IEnumerable<int> source, Func<int, bool> predicate)
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
   ```

4. **`Print` Method**:
   - **Purpose**: Prints the contents of a collection with an optional title.
   - **Details**:
     - Checks if the collection is `null` before proceeding.
     - Formats the output with a title and separators for readability.
     - Handles both value types (e.g., integers) and reference types (e.g., objects).

   ```csharp
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
   ```

---

## Example01: Filtering Employees

This example demonstrates filtering employees using custom extension methods, LINQ's `Where`, and query syntax.

### Explanation

1. **Custom `Filter` Method**:
   - Filters employees whose gender is "female" and whose first name starts with "S".
   - Uses the `Filter` extension method defined earlier.

   ```csharp
   var femaleWithSartsSFilter = employees.Filter(e => e.Gender == "female" && e.FirstName.ToLower().StartsWith("s"));
   ```

2. **LINQ `Where` Method**:
   - Achieves the same result as the custom `Filter` method but uses LINQ's built-in `Where` method.

   ```csharp
   var femaleWithSartsSWhere = employees.Where(e => e.Gender == "female" && e.FirstName.ToLower().StartsWith("s"));
   ```

3. **Query Syntax**:
   - Provides a more readable alternative to method syntax, especially for complex queries.
   - Internally, the compiler converts query syntax into method calls like `Where`.

   ```csharp
   var femaleWithSartsSQuery =
       from e in employees where e.Gender == "female" && e.FirstName.ToLower().StartsWith("s") select e;
   ```

4. **Output**:
   - All three approaches produce the same result, demonstrating that they are functionally equivalent.

---

## Example02: Filtering Numbers

This example explores filtering numbers using LINQ's `Where`, custom extension methods, and deferred vs. immediate execution.

### Explanation

1. **Deferred Execution**:
   - Both `evenNums` and `evenNumsFilterIntYield` use deferred execution.
   - Changes to the `numbers` collection (e.g., adding or removing elements) affect the results when the collection is iterated.

   ```csharp
   var evenNums = numbers.Where(n => n % 2 == 0);
   var evenNumsFilterIntYield = numbers.FilterIntYield(n => n % 2 == 0);
   ```

2. **Immediate Execution**:
   - `evenNumsFilterIntNewList` captures the state of the `numbers` collection at the time of invocation.
   - Subsequent changes to `numbers` do not affect the result.

   ```csharp
   var evenNumsFilterIntNewList = numbers.FilterIntNewList(n => n % 2 == 0);
   ```

3. **Modifying the Collection**:
   - After defining the filters, the `numbers` collection is modified by adding and removing elements.
   - Deferred execution methods (`evenNums` and `evenNumsFilterIntYield`) reflect these changes, while immediate execution (`evenNumsFilterIntNewList`) does not.

---

## Example03: LINQ Syntax Variations

This example compares different ways to write LINQ queries: extension method syntax, `Enumerable.Where`, and query syntax.

### Explanation

1. **Extension Method Syntax**:
   - The most common way to write LINQ queries in C#.
   - Concise and easy to read for simple queries.

   ```csharp
   var evenNumsUsingExtensionWhere = numbers.Where(n => n % 2 == 0);
   ```

2. **`Enumerable.Where`**:
   - Explicitly calls the `Where` method from the `Enumerable` class.
   - Functionally identical to extension method syntax but less commonly used.

   ```csharp
   var evenNumsUsingEnumerableWhere = Enumerable.Where(numbers, n => n % 2 == 0);
   ```

3. **Query Syntax**:
   - Provides a declarative style, which is often more readable for complex queries.
   - Internally, the compiler converts query syntax into method calls.

   ```csharp
   var evenNumsUsingQuerySyntax = from n in numbers where n % 2 == 0 select n;
   ```

---

## Example04: Combining Filters

This example demonstrates combining multiple filters to refine results.

### Explanation

1. **Filter Male Employees**:
   - Filters employees whose gender is "male".

   ```csharp
   var empMale = employees.Where(x => x.Gender == "male");
   ```

2. **Filter Employees with Salary >= 300K**:
   - Filters employees whose salary is greater than or equal to 300,000.

   ```csharp
   var empsSalaryOver300K = employees.Where(x => x.Salary >= 300_000);
   ```

3. **Combine Filters**:
   - Filters male employees who belong to the "HR" department.
   - Demonstrates chaining filters to refine results further.

   ```csharp
   var empMaleInHRDepartment = empMale.Where(x => x.Department.ToLowerInvariant() == "hr");
   ```

4. **Output**:
   - Each filtered result is printed using the `Print` extension method.

---

## Key Takeaways

1. **Deferred Execution**: Methods like `Where` and custom methods using `yield return` evaluate lazily, meaning changes to the source collection affect the result until iteration.
2. **Immediate Execution**: Methods that create a new collection (e.g., `ToList`, `ToArray`) evaluate eagerly, capturing the state of the collection at the time of invocation.
3. **LINQ Syntax**: Extension methods, `Enumerable` methods, and query syntax are functionally equivalent but offer different readability and flexibility.

