namespace MathGame.TruthfulUK;

using MathGame.TruthfulUK.Models;
using static MathGame.TruthfulUK.Enums;
using Spectre.Console;


internal class UserInterface
{
    private bool gameExit = false;
    internal void MainMenu()
    {
        while (!gameExit)
        {
            Console.Clear();

            AnsiConsole.MarkupLine("Welcome to the [red]Math Game[/].");

            var mainMenuSelection = AnsiConsole.Prompt(
                new SelectionPrompt<MainMenuSelection>()
                .Title("Please select an option:")
                .AddChoices(Enum.GetValues<MainMenuSelection>()));

            switch (mainMenuSelection)
            {
                case MainMenuSelection.PlayGame:
                    Console.Clear();
                    PlayGameMenu();
                    break;
                case MainMenuSelection.GameHistory:
                    Console.Clear();
                    DisplayHistory();
                    break;
                case MainMenuSelection.Quit:
                    gameExit = true;
                    break;

            }

        }

    }

    private void PlayGameMenu()
    {
        var gameSelection = AnsiConsole.Prompt(
                new SelectionPrompt<GameSelection>()
                .Title("Please select your desired [red]game[/]:")
                .AddChoices(Enum.GetValues<GameSelection>()));

        var gameDifficulty = AnsiConsole.Prompt(
                new SelectionPrompt<GameDifficulty>()
                .Title("Please select your desired [red]difficulty[/]:")
                .AddChoices(Enum.GetValues<GameDifficulty>()));

        Game.Play(gameSelection, gameDifficulty);

    }

    private void DisplayHistory()
    {
        var rule = new Rule();
        AnsiConsole.MarkupLine("[bold black on white]Game\t\t\tScore[/]");
        AnsiConsole.Write(rule);
        foreach (GameRecord game in GameState.GameHistory)
        {
            game.DisplayGame();
        }

        AnsiConsole.Write(rule);
        AnsiConsole.MarkupLine("Press [red]Any Key[/] to return to the main menu.");
        Console.ReadKey();

    }
}
