namespace Mission2
{
    public class RollSimulator
    {
        public int[] SimulateRolls(int numRolls)
        {
            // We need an array to store results for sums 2 through 12.
            // An array of size 13 allows us to use indices 0-12 directly.
            // Indices 0 and 1 will simply remain 0 as those sums are impossible with two dice.
            int[] rollCounts = new int[13];

            Random rnd = new Random();

            for (int i = 0; i < numRolls; i++)
            {
                // Simulate two dice rolls (1-6)
                // rnd.Next(1, 7) returns a number >= 1 and < 7
                int die1 = rnd.Next(1, 7); 
                int die2 = rnd.Next(1, 7);
                
                int sum = die1 + die2;

                // Increment the position in the array corresponding to the sum
                // Example: if sum is 7, we increment rollCounts[7]
                rollCounts[sum]++;
            }

            return rollCounts;
        }
    }
}