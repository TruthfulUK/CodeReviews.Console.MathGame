using static MathGame.TruthfulUK.Enums;

namespace MathGame.TruthfulUK;

internal static class Helpers
{
    internal static int[] GenerateNumbers(int maxInt, Enums.GameSelection effectiveSelection)
    {
        Random rand = new Random();
        int numA;
        int numB;
        if (effectiveSelection == GameSelection.Division)
        {
            numA = rand.Next(1, maxInt);
            numB = rand.Next(3, maxInt);

            while (numA % numB != 0 || numA == numB)
            {
                numA = rand.Next(1, maxInt);
                numB = rand.Next(3, maxInt);
            }
        }
        else if (effectiveSelection == GameSelection.Subtraction) 
        {      
            numA = rand.Next(1, maxInt);
            numB = rand.Next(1, maxInt);

            while (numB > numA)
            {
                numA = rand.Next(1, maxInt);
                numB = rand.Next(1, maxInt);
            }
        }
        else if (effectiveSelection == GameSelection.Multiplication)
        {
            numA = rand.Next(1, maxInt);
            numB = rand.Next(1, 12);
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
