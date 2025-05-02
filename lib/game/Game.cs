using mathletics.lib.match;

namespace mathletics.lib.game
{
    public class Game
    {
        private string[] _operators = ["+", "-", "*", "/"];
        private int _streak;
        public int Streak { get => _streak; }
        private int _longestStreak;
        public int LongestStreak { get => _longestStreak; }

        private static Match GetMatch(string op)
        {
            Match match = op switch
            {
                "-" => new SubMatch(),
                "+" => new AddMatch(),
                "*" => new MultMatch(),
                "/" => new DivMatch(),
                _ => throw new Exception("op not one of expected values"),
            };
            return match;
        }

        private string GetOpFromUser()
        {
            try
            {
                string? op = "";
                Console.WriteLine("Enter an operator (+, i, * or /)");
                while (op == "")
                {
                    var input = Console.ReadLine();
                    if (!_operators.Contains(input))
                    {
                        Console.WriteLine("Please enter a valid operator");
                        continue;
                    }
                    if (input == null) throw new Exception("user input is null");
                    op = input.Trim();
                }
                return op;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return _operators[0];
            }

        }
        public void PlayRound()
        {
            string op = GetOpFromUser();
            Match match = GetMatch(op);
            Console.WriteLine($"What is {match.Question()}?");
            
        }
    }
}