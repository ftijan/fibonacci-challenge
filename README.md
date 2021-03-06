# Fibonacci Challenge App Notes

The Fibonacci challenge app solution contains the following:
- The `Fibonacci.csproj` project that compiles as a console app
- The `Fibonacci.Tests.csproj` MS Test unit test project with various test cases proving the correctness of the algorithms

# Running the Console App

Run the console app as `Fibonacci <positive_integer_here>` - example: `Fibonacci 123`

If the app is run without the parameters, or with a bad parameter input, a helper message will be printed to guide the user.

Assumes a non-zero element order, so the first element is `1` and the app should be run as `Fibonacci 1` for that particular use case.

# Architectural Overview

- Runs on .Net 5.0
- The console app uses the `IHostBuilder` to construct the app dependencies through configuration and dependency injection
- Uses one of two algorithms to calculate the fibonacci values:
  - The algorithm is chosen and injected at runtime based on the `appsettings.json` -> `Algorithm` property value
  - The algorithm options are: `Recursive` (recursive, slower performance) and `Iterative` (iterative, better performance)
  - If a config value is not found, the fallback algorithm is the `Recursive` algorithm
- The test framework is `MS Test`
  - `DataTestMethod` and `DataRow` data attributes are used to test a variety of use cases through a single test method as applicable
  - The invalid inputs are also tested to make sure that exceptions are thrown as expected

# Possible Enhancements
- For what is does, the application is over-engineered:
  - `IHostBuilder` pattern can be removed to simplify the logic and increase performance
  - Only a single calculation algorithm could also be used (preferrably the iterative one as it is more performant)
  - Alternatively, a second input parameter could be used to enable the user to pick which calculation algorithm should be used at runtime
    - If this is desirable, then the validation for that parameter should be implemented alongside a helper message to guide the user in selection
- Alternatively, the application could be expanded to showcase the usage of other common algorithms, like sort, search, etc.
  - If going this route, possible enhancements could be:
    - A menu system for the user to choose which algorithm to showcase
    - Reading input and input validation for the selected algorithm
    - Adding useful error messages when the user makes a selection or an input mistake
