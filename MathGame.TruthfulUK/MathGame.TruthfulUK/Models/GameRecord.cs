using Spectre.Console;

namespace MathGame.TruthfulUK.Models;

internal class GameRecord
{
    public string Game { get; set; }
    public int Score { get; set; }
    public string Time {  get; set; }

    internal GameRecord(string game, int score, string time)
    {
        Game = game;
        Score = score;
        Time = time;
    }
}
