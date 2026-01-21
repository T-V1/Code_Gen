# .NET 6+ Single GET API Example (MVC Architecture)

## Structure

- Controllers/ValuesController.cs : Contains a single GET endpoint at `api/values`.
- Program.cs : Entry point and minimal setup for .NET 6+.
- README.md : This file.

## How to Run

1. Ensure you have [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0) installed.
2. Place the files in a directory structure as shown above.
3. Open a terminal in the root directory and run:

    ```
    dotnet new webapi -n GET_API
    (Replace the generated Controllers/ValuesController.cs and Program.cs with the provided ones)
    dotnet run --project GET_API
    ```

4. Access the GET endpoint at:  
   `http://localhost:5000/api/values`  
   (or the port shown in your terminal)

## Output

The endpoint returns:
```json
["value1", "value2", "value3"]
```
