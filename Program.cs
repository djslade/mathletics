using mathletics.lib.game;

var programRunning = true;

Console.WriteLine("Welcome to the incredible game Mathletics!");
var game = new Game();
while (programRunning)
{
    game.PlayRound();
}