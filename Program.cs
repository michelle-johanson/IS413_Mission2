namespace Mission2
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Initialize instance of RollSimulator class
            RollSimulator sr = new RollSimulator();
            
            // INITIALIZE VARIABLES
            int numberOfRolls = 0;
            string userInput = "";
            double percentage = 0.0;
            int numAsterisks = 0;
            
            // Collect number of rolls
            Console.WriteLine("Welcome to the dice throwing simulator!");
            Console.Write("How many dice rolls would you like to simulate? ");
            userInput =  Console.ReadLine();
            numberOfRolls = int.Parse(userInput);

            // Run SimulateRolls method from RollSimulator class
            int[] results = sr.SimulateRolls(numberOfRolls);

            // Print Results
            Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
            Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
            Console.WriteLine($"Total number of rolls = {numberOfRolls}.\n");

            // Loop through the possible sums (2 through 12)
            for (int i = 2; i <= 12; i++)
            {
                // Calculate percentage: (count / total) * 100
                percentage = ((double)results[i] / numberOfRolls) * 100;
                
                // Round to the nearest whole number for the asterisks
                numAsterisks = (int)Math.Round(percentage);

                // Create the string of asterisks
                string asterisks = new string('*', numAsterisks);

                // Print the row
                Console.WriteLine($"{i}: {asterisks}");
            }

            Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");
        }
    }
}