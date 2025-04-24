

# Sorting Data in LINQ

Sorting data is a fundamental operation in LINQ (Language Integrated Query) that allows developers to organize collections based on specific criteria. This document explores various sorting techniques, including `OrderBy`, `ThenBy`, custom comparers (`OrderByCustom`), and reversing sequences using `Reverse`.

## Table of Contents

1. [Key Concepts](#key-concepts)
2. [OrderBy](#orderby)
   - [Ascending and Descending Order](#ascending-and-descending-order)
   - [Sorting by Length](#sorting-by-length)
3. [ThenBy](#thenby)
   - [Chaining Multiple Sorting Criteria](#chaining-multiple-sorting-criteria)
4. [OrderByCustom](#orderbycustom)
   - [Custom Comparer Implementation](#custom-comparer-implementation)
5. [Reverse](#reverse)

---

## Key Concepts

LINQ provides several methods for sorting data:
- **`OrderBy`**: Sorts elements in ascending order.
- **`OrderByDescending`**: Sorts elements in descending order.
- **`ThenBy`**: Applies secondary sorting criteria after `OrderBy`.
- **`Reverse`**: Reverses the order of elements in a sequence.
- **Custom Comparers**: Allows sorting based on custom logic using `IComparer<T>`.

---

## OrderBy

The `OrderBy` method sorts elements in ascending or descending order based on a key.

### Ascending and Descending Order

This example demonstrates sorting strings in both ascending and descending order.

```csharp
public static void main()
{
    string[] fruits = { "apricot", "orange", "banana", "mango", "apple", "grape", "strawberry" };

    // Sort fruits in ascending order
    var fruitOrederbyAsc = fruits.OrderBy(f => f); 
    // Uses natural string comparison to sort alphabetically.
    fruitOrederbyAsc.Print(nameof(fruitOrederbyAsc));

    // Equivalent query syntax
    var fruitOrederbyAscQuerySyntax = from f in fruits orderby f select f;
    // Query syntax achieves the same result as method syntax.
    fruitOrederbyAscQuerySyntax.Print(nameof(fruitOrederbyAscQuerySyntax));

    // Sort fruits in descending order
    var fruitOrederbyDesc = fruits.OrderByDescending(f => f);
    // Reverses the sort order compared to OrderBy.
    fruitOrederbyDesc.Print(nameof(fruitOrederbyDesc));

    // Equivalent query syntax
    var fruitOrederbyDescQuerySyntax = from f in fruits orderby f descending select f;
    // The 'descending' keyword reverses the order in query syntax.
    fruitOrederbyDescQuerySyntax.Print(nameof(fruitOrederbyDescQuerySyntax));
}
```

---

### Sorting by Length

This example demonstrates sorting strings by their length.

```csharp
var fruitOrederbyAscLength = fruits.OrderBy(f => f.Length); 
// Sorts strings based on their character count.
fruitOrederbyAscLength.Print(nameof(fruitOrederbyAscLength));
```

---

## ThenBy

The `ThenBy` method applies secondary sorting criteria after an initial `OrderBy`.

### Chaining Multiple Sorting Criteria

This example demonstrates sorting employees by name and then by salary.

```csharp
public static void main()
{
    var employees = Repository.LoadEmployees();

    // Sort employees by name, then by salary
    var employeesOrderbyNameAndSalary = employees
        .OrderBy(e => e.Name) // Primary sort: Name
        .ThenBy(e => e.Salary); // Secondary sort: Salary
    // Combines multiple sorting criteria for refined results.
    employeesOrderbyNameAndSalary.Print(nameof(employeesOrderbyNameAndSalary));

    // Equivalent query syntax
    var employeesOrderbyNameAndSalaryQuerySyntax = from e in employees
                                                   orderby e.Name, e.Salary
                                                   select e;
    // Query syntax supports chaining with commas (e.g., orderby e.Name, e.Salary).
    employeesOrderbyNameAndSalaryQuerySyntax.Print(nameof(employeesOrderbyNameAndSalaryQuerySyntax));

    // Sort employees by entry year (extracted from EmployeeNo)
    var employeesOrderbyEntryYear = employees.OrderBy(e => e.EmployeeNo[0..4]); 
    // Extracts the first 4 characters (year) from EmployeeNo for sorting.
    employeesOrderbyEntryYear.Print(nameof(employeesOrderbyEntryYear));
}
```

---

## OrderByCustom

The `OrderByCustom` class demonstrates sorting using a custom comparer (`IComparer<T>`).

### Custom Comparer Implementation

This example implements a custom comparer to sort employees based on their `EmployeeNo`.

```csharp
public static void main()
{
    IEnumerable<Employee> emps = Repository.LoadEmployees();

    // Sort employees using a custom comparer
    IOrderedEnumerable<Employee> sortedEmps = emps.OrderBy(e => e, new EmployeeComparer());
    // Query syntax does not support custom comparers (IComparer). 
    // If the data is large, using custom comparers in sorting operations could negatively affect performance.
    sortedEmps.Print("sorted employees");
}

class EmployeeComparer : IComparer<Employee>
{
    public int Compare(Employee? e1, Employee? e2)
    {
        // Split EmployeeNo into parts: "2017-FI-1343" => ["2017", "FI", "1343"]
        var e1No = e1.EmployeeNo.Split('-');
        var e2No = e2.EmployeeNo.Split('-');

        int e1Year = Convert.ToInt32(e1No[0]); // Entry year
        int e2Year = Convert.ToInt32(e2No[0]);

        string e1Dep = e1No[1]; // Department code
        string e2Dep = e2No[1];

        int e1Id = Convert.ToInt32(e1No[2]); // Employee ID
        int e2Id = Convert.ToInt32(e2No[2]);

        // Compare department codes first
        if (e1Dep == e2Dep)
        {
            // If departments match, compare years
            if (e1Year == e2Year)
            {
                return e1Id.CompareTo(e2Id); // Compare IDs if years match
            }
            else
            {
                return e1Year.CompareTo(e2Year); // Compare years
            }
        }
        else
        {
            return e1Dep.CompareTo(e2Dep); // Compare department codes
        }
    }
}
// Custom comparers allow complex sorting logic but may impact performance for large datasets.
```

---

## Reverse

The `Reverse` method reverses the order of elements in a sequence.

### Reversing a Sequence

This example demonstrates reversing the order of strings.

```csharp
public static void main()
{
    string[] fruits = { "apricot", "orange", "banana", "mango", "apple", "grape", "strawberry" };

    // Reverse the order of fruits
    var fruitsReverse = fruits.Reverse(); 
    // Reverse() returns an IEnumerable<T> and must be assigned to a variable for further use.
    fruitsReverse.Print(nameof(fruitsReverse));
}
```

---

## Conclusion

Sorting data in LINQ is a versatile operation that can be customized to meet specific needs. By leveraging `OrderBy`, `ThenBy`, custom comparers, and `Reverse`, you can efficiently organize and manipulate collections. Each method has its own use cases, and combining them can solve complex sorting problems.
