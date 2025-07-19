using static MathGame.TruthfulUK.Enums;

namespace MathGame.TruthfulUK;

internal static class Helpers
{
    internal static int[] GenerateNumbers(int maxInt, Enums.GameSelection gameSelection)
    {
        Random rand = new Random();
        int numA;
        int numB;
        if (gameSelection == GameSelection.Division)
        {
            numA = rand.Next(1, maxInt);
            numB = rand.Next(3, maxInt);

            while (numA % numB != 0 || numA == numB)
            {
                numA = rand.Next(1, maxInt);
                numB = rand.Next(3, maxInt);
            }
        }
        else if (gameSelection == GameSelection.Subtraction) 
        {      
            numA = rand.Next(1, maxInt);
            numB = rand.Next(1, maxInt);

            while (numB > numA)
            {
                numA = rand.Next(1, maxInt);
                numB = rand.Next(1, maxInt);
            }
        }
        else
        {
            numA = rand.Next(1, maxInt);
            numB = rand.Next(1, maxInt);
        }
        int[] validRandoms = { numA, numB };
        return validRandoms;
    }

    internal static bool DetermineOutcome(int expected, int actual)
    {
        return expected == actual;
    }
}
