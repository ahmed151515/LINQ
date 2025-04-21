
# Projection Operations in LINQ

Projection is the process of converting an object into a new form, typically to select specific properties or shape the data for further use. This is a fundamental concept in LINQ (Language Integrated Query) that allows developers to transform data efficiently.

## Table of Contents

1. [Key Concepts](#key-concepts)
2. [Select](#select)
   - [Example01: Projecting a New Property](#example01-projecting-a-new-property)
   - [Example02: Performing Mathematical Operations](#example02-performing-mathematical-operations)
   - [Example03: Constructing a New Type](#example03-constructing-a-new-type)
3. [SelectMany](#selectmany)
   - [Example01: Flattening Sentences](#example01-flattening-sentences)
   - [Example02: Flattening Employee Skills](#example02-flattening-employee-skills)
4. [Zip](#zip)
   - [Example01: Combining Color Names and HEX Codes](#example01-combining-color-names-and-hex-codes)
   - [Example02: Pairing Employees](#example02-pairing-employees)

---

## Key Concepts

Projection operations in LINQ are performed using the following methods:
- **`Select`**: Projects each element of a sequence into a new form.
- **`SelectMany`**: Projects sequences of values and flattens them into one sequence.
- **`Zip`**: Combines elements from two sequences into a single sequence.

---

## Select

The `Select` method is used to project each element of a sequence into a new form. It can be used for transforming data, performing calculations, or constructing new types.

### Example01: Projecting a New Property

This example demonstrates how to project a new property by transforming strings.

```csharp
private static void Example01()
{
    // A list of words
    List<string> words = new() { "i", "love", "asp.net", "core" };

    // Convert all words to uppercase using Select
    var wordsToUpper = words.Select(x => x.ToUpper()); // Transform each word to uppercase
    var wordsToUpperQuerySyntax = from w in words select w.ToUpper(); // Equivalent query syntax

    // Print the results
    wordsToUpper.Print(nameof(wordsToUpper)); // Output: I LOVE ASP.NET CORE
    wordsToUpperQuerySyntax.Print(nameof(wordsToUpperQuerySyntax)); // Output: I LOVE ASP.NET CORE

    // Replace 'o' with '0' in all words
    var wordsReplaceOTo0 = words.Select(x => x.Replace('o', '0')); // Replace 'o' with '0'

    // Print the results
    wordsReplaceOTo0.Print(nameof(wordsReplaceOTo0)); // Output: i l0ve asp.net c0re
}
```

---

### Example02: Performing Mathematical Operations

This example demonstrates how to perform mathematical operations on numbers.

```csharp
private static void Example02()
{
    // A list of integers
    List<int> numbers = new() { 2, 3, 5, 7 };

    // Multiply each number by 2 using Select
    var numProduct2 = numbers.Select(n => n * 2); // Multiply each number by 2
    var numProduct2QuerySyntax = from n in numbers select n * 2; // Equivalent query syntax

    // Print the results
    numProduct2.Print(nameof(numProduct2)); // Output: 4 6 10 14
    numProduct2QuerySyntax.Print(nameof(numProduct2QuerySyntax)); // Output: 4 6 10 14
}
```

---

### Example03: Constructing a New Type

This example demonstrates how to construct a new type (`EmployeeDTO`) from an existing collection.

```csharp
class EmployeeDTO
{
    public string Name { get; set; } // Full name of the employee
    public int TotalSkills { get; set; } // Number of skills the employee has

    public override string ToString()
    {
        return $"Name = {Name} | TotalSkills = {TotalSkills}";
    }
}

private static void Example03()
{
    var employees = Repository.LoadEmployees(); // Load employee data from the repository

    // Create a new DTO for each employee
    var employeeToDto = employees.Select(e => new EmployeeDTO
    {
        Name = $"{e.FirstName} {e.LastName}", // Combine first and last name
        TotalSkills = e.Skills.Count // Count the number of skills
    });

    // Print the results
    employeeToDto.Print(nameof(employeeToDto)); // Output: Name = John Doe | TotalSkills = 5 ...
}
```

---

## SelectMany

The `SelectMany` method projects sequences of values and flattens them into one sequence. It is especially useful when working with nested collections.

### Example01: Flattening Sentences

This example demonstrates how to split sentences into individual words and flatten the result.

```csharp
private static void Example01()
{
    // An array of sentences
    string[] sentences = {
        "I love asp.net core",
        "I like sql server also",
        "in general i love programming"
    };

    // Split sentences into words and flatten the result
    var sentencesToOneArray = sentences.SelectMany(s => s.Split(' ')); // Split each sentence into words

    // Print the results
    sentencesToOneArray.Print(nameof(sentencesToOneArray)); // Output: I love asp.net core ...
}
```

---

### Example02: Flattening Employee Skills

This example demonstrates how to extract and flatten skills from a list of employees.

```csharp
private static void Example02()
{
    var employees = Repository.LoadEmployees(); // Load employee data from the repository

    // Extract all skills from employees and flatten the result
    var AllSkills = employees.SelectMany(e => e.Skills); // Flatten the nested skills collection

    // Print the results
    AllSkills.Print(nameof(AllSkills)); // Output: C# SQL Python ...

    // Query syntax equivalent
    var AllSkillsQuerySyntax = from e in employees from s in e.Skills select s;

    // Print the results
    AllSkillsQuerySyntax.Print(nameof(AllSkillsQuerySyntax)); // Output: C# SQL Python ...

    // Remove duplicates
    var AllSkillsDistinct = AllSkills.Distinct(); // Remove duplicate skills
    var AllSkillsQuerySyntaxDistinct = (from e in employees from s in e.Skills select s).Distinct();

    // Print the results
    AllSkillsDistinct.Print(nameof(AllSkillsDistinct)); // Output: C# SQL Python ...
    AllSkillsQuerySyntaxDistinct.Print(nameof(AllSkillsQuerySyntaxDistinct)); // Output: C# SQL Python ...
}
```

---

## Zip

The `Zip` method combines elements from two sequences into a single sequence. It stops when the shorter sequence ends.

### Example01: Combining Color Names and HEX Codes

This example demonstrates how to combine color names and their corresponding HEX codes.

```csharp
private static void Example01()
{
    // Arrays of color names and HEX codes
    string[] colorName = { "Red", "Green", "Blue" };
    string[] colorHEX = { "FF0000", "00FF00", "0000FF", "extra" };

    // Combine color names and HEX codes using Zip
    var colors = colorName.Zip(colorHEX, (name, hex) => $"{name}: {hex}"); // Pair each name with its HEX code

    // Print the results
    colors.Print(nameof(colors)); // Output: Red: FF0000 Green: 00FF00 Blue: 0000FF
}
```

---

### Example02: Pairing Employees

This example demonstrates how to pair employees from two different groups.

```csharp
private static void Example02()
{
    var employees = Repository.LoadEmployees().ToArray(); // Load employee data from the repository

    // Take the first three and last three employees
    var firstThreeEmp = employees[..3]; // First three employees
    var lastThreeEmp = employees[^3..]; // Last three employees

    // Pair employees from the first and last groups using Zip
    var teams = firstThreeEmp.Zip(lastThreeEmp, (f, s) => $"{f.FirstName} with {s.FirstName}"); // Pair employees

    // Print the results
    teams.Print(nameof(teams)); // Output: John with Alice Jane with Bob ...

    // Query syntax equivalent
    var teamsQuerySyntax = from team in firstThreeEmp.Zip(lastThreeEmp)
                           select $"{team.First.FirstName} with {team.Second.FirstName}";

    // Print the results
    teamsQuerySyntax.Print(nameof(teamsQuerySyntax)); // Output: John with Alice Jane with Bob ...
}
```

---

## Conclusion

Projection operations in LINQ are powerful tools for transforming and shaping data. By understanding `Select`, `SelectMany`, and `Zip`, you can efficiently manipulate collections to meet your application's needs. Each method has its own use cases, and combining them can solve complex data transformation problems.
