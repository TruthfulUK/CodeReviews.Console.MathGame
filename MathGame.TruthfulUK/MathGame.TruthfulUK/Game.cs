using static MathGame.TruthfulUK.Enums;

namespace MathGame.TruthfulUK;

internal static class Game
{
    internal static int MaxGameInt;
    internal static int GameScore;

    internal static void Play(Enums.GameSelection gameSelection, Enums.GameDifficulty gameDifficulty)
    {
        Console.WriteLine($"Selected Game: {gameSelection} - Selected Difficulty: {gameDifficulty}");
        Console.ReadKey();

        switch (gameDifficulty)
        {
            case GameDifficulty.Easy:
                GameScore = 0;
                MaxGameInt = 50;
                break;
            case GameDifficulty.Medium:
                GameScore = 0;
                MaxGameInt = 250;
                break;
            case GameDifficulty.Hard:
                GameScore = 0;
                MaxGameInt = 1000;
                break;
        }


        switch (gameSelection)
        {
            case GameSelection.Addition:
                Console.WriteLine("Addition Game");
                Console.WriteLine($"MaxInt: {MaxGameInt}");
                Console.ReadKey();
                break;
            case GameSelection.Subtraction:
                Console.WriteLine("Subtraction Game");
                Console.WriteLine($"MaxInt: {MaxGameInt}");
                Console.ReadKey();
                break;
            case GameSelection.Multiplication:
                break;
            case GameSelection.Division:
                break;
            case GameSelection.Random:
                break;
        }
    }

}
