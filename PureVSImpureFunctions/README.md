# C# Code Examples: Core Programming Concepts

This repository contains simple C# code examples illustrating fundamental programming concepts, particularly focusing on aspects relevant to functional programming paradigms alongside basic C# constructs.

## Pure vs. Impure Functions (`PureVsImpureFunctions` namespace)

This section illustrates the core difference between pure and impure functions using examples that interact with a shared list (`ints`).

*   **Pure Function (`AddInteger4`)**:
    *   **Deterministic**: Given the same input (`ints`, `num`), it always returns the same output.
    *   **No Side Effects**: It does *not* modify any external state (like the global `ints` list). It creates and returns a *new* list (`res`).
*   **Impure Functions (`AddInteger1`, `AddInteger2`, `AddInteger3`, `Print`)**:
    *   **`AddInteger1`**: Impure because it modifies the global `ints` list (a side effect).
    *   **`AddInteger2`**: Impure because it modifies the input parameter `num` (passed by `ref`) and modifies the global `ints` list (side effects).
    *   **`AddInteger3`**: Impure because it interacts with the outside world (`new Random().Next()`, which is non-deterministic) and modifies the global `ints` list (side effect).
    *   **`Print`**: Impure because it performs I/O (`Console.Write`/`WriteLine`), which is an interaction with the outside world (a side effect).

The default execution of this project runs the `main` method within this namespace. The output shows how the global `ints` list changes after calls to the impure functions but remains unaffected by the conceptual use of the pure function (though the example *prints* the result of the pure function, demonstrating it doesn't alter the original `ints`).

## Expressions vs. Statements (`ExpressionVsStatement` namespace)

This namespace provides comments and examples clarifying these fundamental C# elements:

*   **Statement**: A complete unit of execution. Often ends with a semicolon (`;`). Examples include declarations (`int counter;`), assignments (`counter = 1;`), control flow (`if`, `for`, `foreach`), method calls (`Console.WriteLine(...)`).
*   **Expression**: A sequence of operators and operands that evaluates to a single value, object, method, or namespace. Examples include literals (`10`, `3.14`), arithmetic operations (`radius * radius`), method calls that return a value (`new Random().Next()`), object creation (`new string[] { ... }`).

The key takeaway is that statements *perform actions* (and can contain expressions), while expressions *produce values*. This namespace contains a `main` method demonstrating these, but it is *not* called by the default project entry point.

## Imperative vs. Declarative Programming (`ImparativeVsDeclarative` namespace)

This section contrasts two fundamental programming paradigms using the task of filtering a list of `Person` objects:

*   **Imperative Approach (`FilterPeopleWithAgeLessThan`, `FilterPeopleWithAgeEqual`)**:
    *   Focuses on *how* to achieve the result step-by-step.
    *   Uses explicit loops (`foreach`) and conditional checks (`if`).
    *   Less reusable – separate methods are needed for slightly different filtering logic (e.g., `<` vs `==`).
*   **Declarative Approach (`Filter` method with `Func<Person, bool> predicate`)**:
    *   Focuses on *what* result is desired.
    *   Abstracts the iteration and filtering mechanism.
    *   Uses a higher-order function (`Filter`) that accepts another function (`predicate`) as an argument. The `predicate` defines the filtering condition.
    *   More reusable – the `Filter` method can be used with *any* boolean condition defined by the `Func` delegate (`p => p.Age >= 32`, `p => p.Name.StartsWith("A")`, etc.).
    *   This style is heavily used in LINQ (Language Integrated Query) in C#.

The example demonstrates creating a `Func<Person, bool>` delegate (`predicate = p => p.Age >= 32;`) and passing it to the generic `Filter` method. It also includes examples of passing a method as an argument using `Action` (`Method2(Method1)`). This namespace contains a `main` method demonstrating these, but it is *not* called by the default project entry point.

## Exploring Other Examples

By default, the project runs the `PureVsImpureFunctions` example. To run the examples in the `ExpressionVsStatement` or `ImparativeVsDeclarative` namespaces, you need to modify the main application entry point:

1.  Open `PureVSImpureFunctions/Program.cs`.
2.  In the `static void Main(string[] args)` method, change the line:
    ```csharp
    PureVsImpureFunctions.PureVsImpureFunctions.main();
    ```
    to call the desired example's `main` method:
    *   For Expression vs. Statement:
        ```csharp
        ExpressionVsStatement.ExpressionVsStatement.main();
        ```
    *   For Imperative vs. Declarative:
        ```csharp
        ImparativeVsDeclarative.ImparativeVsDeclarative.main(args);
        ```
        *(Note: This specific `main` method signature includes `string[] args`, although they aren't used in this example).*
3.  Rebuild and run the application using your preferred .NET tools (e.g., `dotnet build` then `dotnet run` in the terminal, or using the build/run commands in your IDE).