

# README: Exploring Functional Programming in C#

This repository provides a practical demonstration of **functional programming (FP)** concepts within the C# language. It contrasts a traditional **procedural approach** with two evolving **functional approaches** for filtering and processing collections of `Employee` data.

The core goal is to illustrate how FP principles, facilitated by C# features like **extension methods**, **higher-order functions**, and **lambda expressions**, lead to code that is more **declarative, reusable, readable, and maintainable**.

> **Core Philosophy (from code comments):** Strive for *Pure Functions* to build robust and testable code. Prefer *declarative* ("what to do") over *imperative* ("how to do it") coding styles. Functional programming is a paradigm centered around using functions, emphasizing *immutability* and *higher-order functions*.

---

## Table of Contents

1.  [Introduction](#introduction)
2.  [Core Concepts Explained](#core-concepts-explained)
    *   [Functional Programming (FP)](#functional-programming-fp)
    *   [Pure Functions](#pure-functions)
    *   [Higher-Order Functions](#higher-order-functions)
    *   [Lambda Expressions](#lambda-expressions)
    *   [Extension Methods](#extension-methods)
    *   [Declarative vs. Imperative](#declarative-vs-imperative)
3.  [The Approaches](#the-approaches)
    *   [Approach 1: Procedural](#approach-1-procedural)
    *   [Approach 2: Basic Functional (Helper Class)](#approach-2-basic-functional-helper-class)
    *   [Approach 3: Functional with Extension Methods](#approach-3-functional-with-extension-methods)
4.  [Comparison Summary](#comparison-summary)
5.  [Running the Application](#running-the-application)
6.  [Example Output](#example-output)
7.  [Conclusion](#conclusion)

---

## Introduction

We start with a common task: querying a list of `Employee` objects based on different criteria (name, department, salary, etc.). This repository showcases three distinct methods to achieve this, highlighting the evolution from imperative to functional styles in C#.

1.  **Procedural Approach**: Uses traditional loops and conditional statements.
2.  **Basic Functional Approach**: Introduces a reusable filtering function using a helper class and predicates.
3.  **Functional with Extension Methods**: Refines the functional approach using extension methods for a more fluent and integrated syntax, closely resembling LINQ.

---

## Core Concepts Explained

Understanding these concepts is key to appreciating the functional approaches demonstrated:

### Functional Programming (FP)

A programming paradigm that treats computation as the evaluation of mathematical functions. It emphasizes:
*   **Immutability**: Data structures are typically not changed after creation.
*   **Avoiding Side Effects**: Functions aim to only compute and return results without altering external state.
*   **First-Class and Higher-Order Functions**: Functions can be treated as values (passed as arguments, returned from other functions).
*   **Declarative Style**: Focuses on *what* the code should accomplish rather than *how*.

### Pure Functions

A function is pure if:
1.  Its return value is solely determined by its input values.
2.  Its evaluation has no side effects (e.g., no modification of external variables, no I/O operations).
*Benefit*: Pure functions are predictable, easy to test, and less prone to bugs.*

### Higher-Order Functions

Functions that operate on other functions, either by taking them as arguments or by returning them.
*Example*: The `Filter` methods in the functional approaches are higher-order functions because they accept a `predicate` function as an argument.
*Benefit*: Enables abstraction and composition of behavior.*

> **From Code Comments**: Almost all LINQ extension methods (`Where`, `Select`, `OrderBy`, etc.) are higher-order functions.

### Lambda Expressions

A concise syntax for creating anonymous functions inline.
*Example*: `e => e.Salary > 50000` is a lambda expression representing a function that takes an employee `e` and returns `true` if their salary exceeds 50000.
*Benefit*: Reduces boilerplate code for simple functions, improving readability when used with higher-order functions.*

### Extension Methods

A C# feature allowing you to add new methods to existing types without modifying their original source code.
*Example*: Defining `Filter` as an extension method for `IEnumerable<Employee>` allows calling `.Filter(...)` directly on the employee list.
*Benefit*: Improves code readability and enables fluent APIs (method chaining).*

### Declarative vs. Imperative

*   **Imperative**: Describes *how* to achieve a result using step-by-step instructions (loops, assignments, conditions). The procedural approach is imperative.
*   **Declarative**: Describes *what* result is desired, leaving the *how* to underlying abstractions. The functional approaches, especially with LINQ-like syntax, lean heavily declarative.
*Benefit*: Declarative code is often more concise and easier to reason about.*

---

## The Approaches

### Approach 1: Procedural

This approach uses dedicated methods for each filtering criterion, implementing the logic with explicit `foreach` loops and `if` conditions.

```csharp
// Example: Filtering by First Name Prefix
public static IEnumerable<Employee> GetEmployeesWithFirstNameStartsWith(string value)
{
    var employees = Repository.LoadEmployees(); // Assume this loads the data
    foreach (var employee in employees)
    {
        if (employee.FirstName.ToLowerInvariant().StartsWith(value.ToLowerInvariant()))
        {
            // 'yield return' makes this method an iterator block - efficient memory usage
            yield return employee;
        }
    }
}
```

**Characteristics:**
*   **Style**: Imperative.
*   **Logic**: Explicit loops and conditions.
*   **Reusability**: Low; filtering logic is duplicated/adapted for each criterion.
*   **Maintainability**: Can become cumbersome as filtering requirements grow.

---

### Approach 2: Basic Functional (Helper Class)

This version introduces a generic `Filter` method within a static helper class (`ExtensionFunctional01`). This method accepts the collection and a `Predicate<Employee>` (a function that returns `true` or `false` for an employee) to define the filtering condition.

```csharp
// Reusable Filter method
public static IEnumerable<Employee> Filter(IEnumerable<Employee> employees, Predicate<Employee> predicate)
{
    foreach (var item in employees)
    {
        if (predicate(item)) // The predicate function decides inclusion
        {
            yield return item;
        }
    }
}

// Usage
var list = Repository.LoadEmployees();
var q1 = ExtensionFunctional01.Filter(list, e => e.FirstName.ToLowerInvariant().StartsWith("ma"));
```

**Characteristics:**
*   **Style**: More declarative (the *what* is defined by the lambda).
*   **Key Concepts**: Uses Higher-Order Functions (`Filter` taking `predicate`) and Lambda Expressions.
*   **Reusability**: High; the `Filter` method works for any condition expressible as a predicate.
*   **Readability**: Improved, logic is more focused.
*   **Drawback**: Still requires explicitly calling the static helper class method.

---

### Approach 3: Functional with Extension Methods

This approach refines Version 1 by defining `Filter` as an **extension method** on `IEnumerable<Employee>`. This allows calling `Filter` directly on the collection, leading to a more fluent and natural syntax, similar to LINQ. A `Print` extension method is also added for convenience.

```csharp
// Filter as an Extension Method
public static IEnumerable<Employee> Filter(this IEnumerable<Employee> employees, Predicate<Employee> predicate)
// 'this' keyword marks it as an extension method for IEnumerable<Employee>
{
    foreach (var item in employees)
    {
        if (predicate(item))
        {
            yield return item;
        }
    }
}

// Print Extension Method
public static void Print<T>(this IEnumerable<T> source, string title) // Extends any IEnumerable<T>
{
    // ... (implementation for printing) ...
}

// Usage
var list = Repository.LoadEmployees();
var q1 = list.Filter(e => e.FirstName.ToLowerInvariant().StartsWith("ma")); // Fluent syntax!
q1.Print("Employees with first name starts with 'ma'");

// Chaining example
list.Filter(e => e.Department == "IT")
    .Filter(e => e.Salary > 60000)
    .Print("IT Employees earning > $60,000");
```

**Characteristics:**
*   **Style**: Highly declarative and fluent.
*   **Key Concepts**: Leverages Extension Methods, Higher-Order Functions, and Lambda Expressions.
*   **Reusability**: Very high.
*   **Readability**: Excellent, closely mimics natural language and standard LINQ operations.
*   **Maintainability**: High; easy to add new filters or chain operations.

---

## Comparison Summary

| Feature                 | Procedural                | Functional (v1 - Helper) | Functional (v2 - Extension) |
| :---------------------- | :------------------------ | :----------------------- | :-------------------------- |
| **Style**               | Imperative                | Becoming Declarative     | Highly Declarative / Fluent |
| **Code Reusability**    | Low                       | Medium                   | High                        |
| **Readability**         | Low (for complex logic)   | Medium                   | High                        |
| **Maintainability**     | Low                       | Medium                   | High                        |
| **Use of HOFs**         | No                        | Yes (`Filter` method)    | Yes (`Filter` method)       |
| **Use of Lambdas**      | No                        | Yes (for predicates)     | Yes (for predicates)        |
| **Use of Extensions**   | No                        | No                       | Yes (`Filter`, `Print`)     |
| **Method Chaining**     | No                        | Difficult                | Yes (Fluent API)            |
| **Testability**         | Lower (logic embedded)    | Higher (predicates testable)| Highest (pure functions)    |

---

## Running the Application

1.  **Prerequisites**: Ensure you have the .NET SDK installed.
2.  Clone this repository.
3.  Open the solution in your preferred IDE (e.g., Visual Studio, VS Code) or use the command line.
4.  Navigate to the `Program.cs` file.
5.  In the `Main` method, uncomment the specific `Run...` method corresponding to the approach you want to execute:
    *   `RunExtensionProcedural()`
    *   `RunExtensionFunctional01()`
    *   `RunExtensionFunctional02()`
6.  Build and run the project (e.g., using `dotnet run` from the terminal in the project directory).

The console output will display the results of the filtering operations performed by the selected approach.

---

## Example Output

When running the query from Approach 3:

```csharp
var q1 = list.Filter(e => e.FirstName.ToLowerInvariant().StartsWith("ma"));
q1.Print("Employees with first name starts with 'ma'");
```

The console output will resemble this (data may vary):

```
┌───────────────────────────────────────────────────────┐
│   Employees with first name starts with 'ma'          │
└───────────────────────────────────────────────────────┘
 Id   FullName           HireDate        Gender         Department   HasPension  HasHealthInsurance Salary
───────────────────────────────────────────────────────────────────────────────────────────────────────────
 1    Martin, Mary       01/15/2018      Female         HR           True        False              $103,200.00
 15   Mason, Matthew     07/20/2019      Male           Sales        False       True               $78,500.00
```

---

## Conclusion

This project demonstrates the practical benefits of adopting functional programming techniques in C#. Moving from a basic procedural style to functional approaches using **higher-order functions**, **lambda expressions**, and finally **extension methods**, we achieve significant improvements:

*   **Reduced Boilerplate**: Less repetitive code for common tasks like iteration and conditional checks.
*   **Increased Reusability**: Abstracted logic (like `Filter`) can be applied across various scenarios.
*   **Enhanced Readability**: Declarative style and fluent syntax make the code's intent clearer.
*   **Improved Maintainability**: Changes are often localized to lambda expressions or specific chained methods.

These functional constructs are not just theoretical; they are the foundation of powerful C# features like LINQ (Language Integrated Query) and are essential tools for writing modern, effective C# code.
