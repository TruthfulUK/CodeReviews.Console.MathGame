using MathGame.TruthfulUK.Models;
using Spectre.Console;
using System.Diagnostics;
using System.Numerics;
using static MathGame.TruthfulUK.Enums;

namespace MathGame.TruthfulUK;

internal static class Game
{
    internal static bool GameEnd;
    internal static int MaxGameInt;
    internal static int GameScore = 0;
    internal static string GameName = "Default";
    internal static readonly Random random = new Random();
    internal static Stopwatch GameTimer = new Stopwatch();

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

        var allGames = new[]
        {
            GameSelection.Addition,
            GameSelection.Subtraction,
            GameSelection.Multiplication,
            GameSelection.Division
        };

        var stopwatch = Stopwatch.StartNew();

        while (!Game.GameEnd)
        {
            var effectiveGame = gameSelection == GameSelection.Random
                ? allGames[random.Next(allGames.Length)]
                : gameSelection;

            AnsiConsole.MarkupLine(
                    $"Game: [red]{gameSelection}[/] | " +
                    $"Difficulty: [red]{gameDifficulty}[/] | " +
                    $"Score: [green]{GameScore}[/]");


            int calcAnswer = 0;
            int userAnswer = 0;
            string gameOperator = "";
            int[] validNumbers = Helpers.GenerateNumbers(MaxGameInt, effectiveGame);

            switch (effectiveGame)
            {
                case GameSelection.Addition:
                    calcAnswer = validNumbers[0] + validNumbers[1];
                    gameOperator = "+";
                    break;
                case GameSelection.Subtraction:
                    calcAnswer = validNumbers[0] - validNumbers[1];
                    gameOperator = "-";
                    break;
                case GameSelection.Multiplication:
                    calcAnswer = validNumbers[0] * validNumbers[1];
                    gameOperator = "X";
                    break;
                case GameSelection.Division:
                    calcAnswer = validNumbers[0] / validNumbers[1];
                    gameOperator = "/";
                    break;
            }

            userAnswer = AnsiConsole.Prompt(
                    new TextPrompt<int>($"What is {validNumbers[0]} {gameOperator} {validNumbers[1]}?"));

            if (Helpers.DetermineOutcome(calcAnswer, userAnswer))
            {
                GameScore += 1;
                Console.Clear();
            }
            else
            {
                stopwatch.Stop();
                TimeSpan elapsed = stopwatch.Elapsed;
                string formattedElapsed = elapsed.ToString(@"mm\:ss");
                Game.End(formattedElapsed);
            }
        }  
    }

    internal static void End(string roundTimer)
    {
        Game.GameEnd = true;
        GameRecord gameResult = new GameRecord(GameName, GameScore, roundTimer);
        GameState.GameHistory.Add(gameResult);
        GameScore = 0;
    }

}
