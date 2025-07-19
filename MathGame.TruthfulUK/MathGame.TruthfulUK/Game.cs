using MathGame.TruthfulUK.Models;
using Spectre.Console;
using System.Numerics;
using static MathGame.TruthfulUK.Enums;

namespace MathGame.TruthfulUK;

internal static class Game
{
    internal static bool GameEnd;
    internal static int MaxGameInt;
    internal static int GameScore = 0;
    internal static string GameName = "Default";

    internal static void Play(Enums.GameSelection gameSelection, Enums.GameDifficulty gameDifficulty)
    {
        switch (gameDifficulty)
        {
            case GameDifficulty.Easy:
                MaxGameInt = 25;
                break;
            case GameDifficulty.Medium:
                MaxGameInt = 100;
                break;
            case GameDifficulty.Hard:
                MaxGameInt = 250;
                break;
        }

        Game.GameEnd = false;
        GameName = gameSelection.ToString();
        while(!Game.GameEnd)
        {
            AnsiConsole.MarkupLine($"Game: [red]{gameSelection}[/] | Difficulty: [red]{gameDifficulty}[/] | Score: [red]{GameScore}[/]");
            int calcAnswer = 0;
            int userAnswer = 0;
            int[] validNumbers = Helpers.GenerateNumbers(MaxGameInt, gameSelection);

            switch (gameSelection)
            {
                case GameSelection.Addition:
                    calcAnswer = validNumbers[0] + validNumbers[1];
                    userAnswer = AnsiConsole.Prompt(
                    new TextPrompt<int>($"What is {validNumbers[0]} + {validNumbers[1]}?"));
                    break;
                case GameSelection.Subtraction:
                    calcAnswer = validNumbers[0] - validNumbers[1];
                    userAnswer = AnsiConsole.Prompt(
                    new TextPrompt<int>($"What is {validNumbers[0]} - {validNumbers[1]}?"));
                    break;
                case GameSelection.Multiplication:
                    calcAnswer = validNumbers[0] * validNumbers[1];
                    userAnswer = AnsiConsole.Prompt(
                    new TextPrompt<int>($"What is {validNumbers[0]} * {validNumbers[1]}?"));
                    break;
                case GameSelection.Division:
                    calcAnswer = validNumbers[0] / validNumbers[1];
                    userAnswer = AnsiConsole.Prompt(
                    new TextPrompt<int>($"What is {validNumbers[0]} / {validNumbers[1]}?"));
                    break;
                case GameSelection.Random:
                    break;
            }

            if (Helpers.DetermineOutcome(calcAnswer, userAnswer))
            {
                GameScore += 1;
                Console.Clear();
            }
            else
            {
                Game.End();
            }
        }  
    }

    internal static void End()
    {
        Game.GameEnd = true;
        GameRecord gameResult = new GameRecord(GameName, GameScore);
        GameState.GameHistory.Add(gameResult);
        GameScore = 0;
    }

}
