namespace MathGame.TruthfulUK;

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
        var table = new Table();

        AnsiConsole.MarkupLine("[bold black on white]Game History[/]");
        AnsiConsole.Write(rule);

        table.AddColumn("Game");
        table.AddColumn("Score");
        table.AddColumn("Time");

        for (int i = 0; i < GameState.GameHistory.Count; i++)
        {
            table.InsertRow(i, 
                $"{GameState.GameHistory[i].Game}", 
                $"{GameState.GameHistory[i].Score}",
                $"{GameState.GameHistory[i].Time}");
        }

        table.Expand();
        table.Border(TableBorder.Minimal);
        AnsiConsole.Write(table);
        AnsiConsole.Write(rule);
        AnsiConsole.MarkupLine("Press [red]Any Key[/] to return to the main menu.");
        Console.ReadKey();
    }
}
