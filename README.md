# Mission 2

Write a .NET console application using C# that simulates the rolling of _**two** 6-sided dice._
Use an array to keep track of the number of times that each combination is thrown.
(Track how many times the combination of the two simulated dice is 2, 
how many times the combination is 3, and so on, all the way up through 12.)

### Steps:
1. Allow the user to choose how many times the “dice” will be thrown. 
2. Once you have that number of rolls, pass that number to a second class **RollSimulator**
3. The **RollSimulator** class has a **SimulateRolls** method that simulates the roll of the dice for the number of times that the user specified. 
4. Store the results in array **RollCounts**. 
5. The **SimulateRolls** method should return the **RollCounts** array to the first class. 
6. In the first class, use the **RollCounts** array to print a histogram using asterisks.
7. Show the total percentage each number was rolled with each * representing 1% of the total rolls.

### Sample session:
```bash
Welcome to the dice throwing simulator!

How many dice rolls would you like to simulate? 1000

DICE ROLLING SIMULATION RESULTS
Each "*" represents 1% of the total number of rolls.
Total number of rolls = 1000.

2: ***
3: ***
4: ***********
5: ***********
6: ********
7: ******************
8: ****************
9: **********
10: *************
11: *****
12: **

Thank you for using the dice throwing simulator. Goodbye!
```
NOTE: Due to rounding issues and the fact that you cannot print a partial asterisk, your total
number of asterisks printed may not be exactly 100

# Video Notes

## Data Types in C#

We can choose different data types based on the size of the data, required precision,
and how much memory we want to use.

For example, decimal numbers can be stored as:
- `float` (4 bytes) – less precise
- `double` (8 bytes) – default for decimals
- `decimal` (16 bytes) – high precision, often used for money

In this class:
- A `int` stores a whole number
- A `double` stores a number with decimals
- A `bool` stores a true or a false
- A `char` stores one character
- A `string` stores many characters

## The Main Method
```csharp
internal class Program
    // A class is just an organizational unit - should match the file name
    // Program.cs is where the program goes to start
{
    private static void Main(string[] args) 
        // Can be public or private depending on if we want other classes 
        // to see and access the methods in this class.
        // Main can be public or private. The runtime can find Main regardless of access modifier.

        
        // Static means the method belongs to the class itself, not to instances of the class.
        
        // Return types - Main can't return anything so it will be void
        
        // Parameters - a string array called "args"
        // If you wanted to pass strings into the args array in the Main function, you can 
        // Do so in the command line when running the program
    {
        Console.WriteLine("Hello, World!");
        // Needs to add "System." before running in command line 
    }
}
```

## Run in Terminal
Run the project from the command line; args get passed into Main.
```bash
cd /Users/michellejohanson/VScode/IS_413/Mission2
dotnet build
dotnet run -- Spencer 2
```
Any variable you pass through will be a string, which you can convert into a number with data parsing.

```csharp
internal class Program
{
    private static void Main(string[] args)
    {
        string my_name = args[0];
        int my_num = int.Parse(args[1]);

        Console.WriteLine($"Hello, {my_name}! My number is {my_num}.");
    }
}
```

## User Input
```csharp
internal class Program
{
    private static void Main(string[] args)
    {
        // Initialize the variable
        string name = "";
        
        // Take user input
        Console.WriteLine("Please enter your name: ");
        name = Console.ReadLine();

        // Print user input
        Console.WriteLine($"Hello, {name}!");
    }
}
```

## Methods

Methods help organize code and avoid repetition.  
Instead of rewriting the same logic multiple times (or copy/pasting),
we can put that logic into a method and call it whenever we need it.

```csharp
internal class Program
{
    private static void Main(string[] args)
    {
        string name = "";
        
        Console.WriteLine("Please enter your name: ");
        name = Console.ReadLine();

        Console.WriteLine(PrintName(name));
        // name variable exists locally, and doesn't roll over unless I pass it through a parameter
    }
    
    // Method
    private static string PrintName(string n)
        // Returns the output as a string
        // n is the local parameter / variable for this method
    {
        string output = "";
        output = $"Hello, {n}!";
        return output;
    }
}
```

## Method in a Separate Class
Best practice has us putting separate classes in separate folders. 
For this example, imagine we created a separate folder called **PrintStuff.cs**.
```csharp
// Separate class to hold printing logic
public class PrintStuff
{
    public void PrintName(string n)
        // Public so it can be accessed from Program
    {
        Console.WriteLine($"Hello, {n}!");
    }
}
```
```csharp
internal class Program
{
    private static void Main(string[] args)
    {
        // Get user input
        Console.WriteLine("Please enter your name:");
        string name = Console.ReadLine();

        // Create an instance of the PrintStuff class
        PrintStuff ps = new PrintStuff();

        // Call the method using the instance
        ps.PrintName(name);
    }
}
```

## Class with Constructor and Instance Method

When a method lives in another class, it must be accessed through that class.
This can be done either by calling a static method or by creating an instance
of the class. Creating instances allows multiple objects to exist separately
in memory, each with its own settings.

Constructors are special methods that run once when an object is created.
They are often used to initialize settings for that instance.

```csharp
public class PrintStuff
{
    // Class-level variable
    // Scope: accessible by all methods in this class
    private string language;

    // Constructor
    public PrintStuff(string temp)
        // Runs once when a PrintStuff object is created
        // Requires a language to be passed in (ex: "en" or "pt")
    {
        language = temp;
    }

    // Instance method
    public void PrintName(string name)
    {
        // Use double == to compare values
        if (language == "en")
        {
            Console.WriteLine("Hello, " + name + "!");
        }
        else if (language == "pt")
        {
            Console.WriteLine("Oi, " + name + "!");
        }
    }
}
```
**Using this class from Main:**
```csharp
internal class Program
{
    private static void Main(string[] args)
    {
        // Ask user for language
        Console.WriteLine("Enter language (en or pt):");
        string lang = Console.ReadLine();

        // Ask user for name
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();

        // Create an instance of PrintStuff
        // Constructor runs here
        PrintStuff ps = new PrintStuff(lang);

        // Call method using the instance
        ps.PrintName(name);
    }
}
```
