using Spectre.Console;

namespace MathGame.TruthfulUK.Models;

internal class GameRecord
{
    public string Game { get; set; }
    public int Score { get; set; }

    internal GameRecord(string game, int score)
    {
        Game = game;
        Score = score;
    }

    internal void DisplayGame()
    {
        AnsiConsole.MarkupLine($"[bold white on red]{Game}[/] \t\t {Score}");
    }
}
