/*
 * Menu Loop
 * - Play a Game
 * -- Addition, Subtraction, Multiplication, Division
 * -- Random
 * - Game History
 * - 
 * 
 * 4 operation games (addition, subtraction, multiply, division)
 * Record previous games - visualize history
 * Levels of difficulty
 * Random mode
 * Game timer
 * 
 */

using MathGame.TruthfulUK;
using MathGame.TruthfulUK.Models;


//// Create test gamestate data
//Random rand = new Random();
//for (int i = 0; i < 10; i++)
//{
//    string[] games = { "Addition", "Subtraction", "Multiplication", "Division" };
//    int randGame = rand.Next(games.Length);
//    int randScore = rand.Next(100, 250);
//    GameRecord testGameData = new GameRecord($"{i} {games[randGame]}", randScore);
//    GameState.GameHistory.Add(testGameData);
//}

UserInterface game = new UserInterface();
game.MainMenu();