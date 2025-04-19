

# README: Functional Programming Concepts in C#

This repository demonstrates fundamental concepts of **functional programming** in C# by comparing procedural and functional approaches to filtering and processing collections of data. The project also highlights the use of **extension methods**, **higher-order functions**, and **lambda expressions** to improve code readability, reusability, and maintainability.

---

## Table of Contents

1. [Overview](#overview)
2. [Key Concepts](#key-concepts)
   - [Procedural Programming](#procedural-programming)
   - [Functional Programming (Version 1)](#functional-programming-version-1)
   - [Functional Programming (Version 2)](#functional-programming-version-2)
3. [Comparison of Approaches](#comparison-of-approaches)
4. [Running the Application](#running-the-application)
5. [Example Output](#example-output)
6. [Conclusion](#conclusion)

---

## Overview

The application revolves around a collection of `Employee` objects. The goal is to filter and display employees based on various criteria, such as their name, department, salary, gender, and other attributes. The project implements three different approaches to achieve this:

1. **Procedural Approach**: Traditional imperative programming with explicit loops and conditions.
2. **Functional Approach (Version 1)**: Uses a helper class (`ExtensionFunctional01`) with a reusable filtering method.
3. **Functional Approach (Version 2)**: Extends the functionality using **extension methods** to make the code more concise and expressive.

---

## Key Concepts

### Procedural Programming

In the **procedural approach**, filtering logic is implemented using explicit loops and conditions. Each filtering operation is encapsulated in a separate method within the `ExtnensionProcedural` class. For example:

```csharp
public static IEnumerable<Employee> GetEmployeesWithFirstNameStartsWith(string value)
{
    var employees = Repository.LoadEmployees();
    foreach (var employee in employees)
    {
        if (employee.FirstName.ToLowerInvariant().StartsWith(value.ToLowerInvariant()))
        {
            yield return employee;
        }
    }
}
```

#### Characteristics:
- **Explicit Loops**: Iterates through the collection manually.
- **Repetitive Code**: Similar logic is repeated for different filtering criteria.
- **Hard to Reuse**: Each method is tightly coupled to a specific filtering condition.

#### Advantages:
- Simple and straightforward for small-scale applications.
- Easy to understand for beginners.

#### Disadvantages:
- Repetitive and verbose for large datasets or multiple filtering criteria.
- Difficult to maintain and extend.

---

### Functional Programming (Version 1)

The **functional approach** abstracts the filtering logic into a reusable method (`Filter`) in the `ExtensionFunctional01` class. This method accepts a collection of employees and a predicate (a function that evaluates a condition). For example:

```csharp
public static IEnumerable<Employee> Filter(IEnumerable<Employee> employees, Predicate<Employee> predicate)
{
    foreach (var item in employees)
    {
        if (predicate(item))
        {
            yield return item;
        }
    }
}
```

Usage:

```csharp
var q1 = ExtensionFunctional01.Filter(list, e => e.FirstName.ToLowerInvariant().StartsWith("ma"));
```

#### Characteristics:
- **Higher-Order Functions**: Functions that take other functions as arguments (e.g., `predicate`).
- **Lambda Expressions**: Concise syntax for defining inline conditions.
- **Reusable Logic**: Centralizes filtering logic, reducing code duplication.

#### Advantages:
- Reduces repetitive code by centralizing filtering logic.
- Encourages the use of **lambda expressions** for concise and expressive conditions.

#### Disadvantages:
- Requires explicitly calling the helper class (`ExtensionFunctional01`).

---

### Functional Programming (Version 2)

The second version of the functional approach uses **extension methods** to make the filtering logic even more intuitive and expressive. The `Filter` method is defined as an extension method for `IEnumerable<Employee>`, allowing it to be called directly on any collection of employees. For example:

```csharp
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
```

Usage:

```csharp
var q1 = list.Filter(e => e.FirstName.ToLowerInvariant() == "ma");
```

Additionally, a `Print` extension method is introduced to simplify displaying results:

```csharp
public static void Print<T>(this IEnumerable<T> source, string title)
{
    if (source == null)
        return;

    Console.WriteLine($"│   {title.PadRight(52, ' ')}│");
    foreach (var item in source)
        Console.WriteLine(item);
}
```

Usage:

```csharp
q1.Print("Employees with first name starts with 'ma'");
```

#### Characteristics:
- **Fluent Syntax**: Methods can be chained for concise and readable code.
- **Extension Methods**: Adds functionality to existing types without modifying them.
- **Higher-Order Functions**: Continues to leverage predicates for flexible filtering.

#### Advantages:
- Fluent and readable syntax.
- Encourages chaining of operations (e.g., filtering and printing in one line).
- Promotes the use of **higher-order functions**, which are fundamental to functional programming.

---

## Comparison of Approaches

| Feature                     | Procedural Approach       | Functional (v1)          | Functional (v2)          |
|-----------------------------|---------------------------|--------------------------|--------------------------|
| Code Reusability            | Low                      | Medium                  | High                    |
| Readability                 | Low                      | Medium                  | High                    |
| Maintainability             | Low                      | Medium                  | High                    |
| Use of Lambda Expressions   | No                       | Yes                     | Yes                     |
| Use of Extension Methods    | No                       | No                      | Yes                     |
| Chaining Operations         | No                       | No                      | Yes                     |

---

## Running the Application

1. Clone the repository and open the project in your preferred IDE (e.g., Visual Studio).
2. Navigate to the `Program.Main` method in the `Program` class.
3. Uncomment the desired method to run:
   - `RunExtensionProcedural()` for the procedural approach.
   - `RunExtensionFunctional01()` for the first functional approach.
   - `RunExtensionFunctional02()` for the second functional approach.
4. Build and run the application.

---

## Example Output

For the query:

```csharp
var q1 = list.Filter(e => e.FirstName.ToLowerInvariant() == "ma");
q1.Print("Employees with first name starts with 'ma'");
```

The output might look like:

```
┌───────────────────────────────────────────────────────┐
│   Employees with first name starts with 'ma'          │
└───────────────────────────────────────────────────────┘

1       Martin, Mary       01/15/2018      Female         HR           True        False       $103200.00
```

---

## Conclusion

This project highlights the evolution from procedural to functional programming paradigms in C#. By leveraging **higher-order functions**, **lambda expressions**, and **extension methods**, the functional approach provides a more concise, reusable, and maintainable solution. These techniques align with modern programming practices and are essential for writing clean and efficient code.

Key takeaways:
- **Procedural Programming**: Best suited for simple tasks but lacks scalability.
- **Functional Programming**: Encourages reusable, modular, and expressive code.
- **Extension Methods**: Enhance readability and enable fluent syntax.
- **Higher-Order Functions**: Enable flexible and powerful abstractions.

Feel free to experiment with the code and explore additional filtering criteria or operations!

