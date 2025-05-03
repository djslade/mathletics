using mathletics.lib.match;

namespace mathletics.lib.game
{
    public class Game
    {
        private string[] _operators = ["+", "-", "*", "/"];
        private int _streak = 0;
        public int Streak { get => _streak; }
        private int _longestStreak = 0;
        public int LongestStreak { get => _longestStreak; }
        private List<Match> _matchHistory = [];
        public List<Match> MatchHistory { get => _matchHistory; }

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

        private static int GetAnswerFromUser(string question)
        {
            Console.WriteLine($"What is {question}?");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out int answer)) return answer;
                Console.WriteLine("Please enter a valid integer");
            }
        }

        public void PlayRound()
        {
            string op = GetOpFromUser();
            Match match = GetMatch(op);
            int answer = GetAnswerFromUser(match.Question);
            match.GiveAnswer(answer);
            if (match.PlayerWon)
            {
                Console.WriteLine("You win!");
                _streak += 1;
            }
            else
            {
                Console.WriteLine("You lose!");
                _streak = 0;
            }
            if (_streak > _longestStreak)
            {
                _longestStreak = _streak;
            }
            _matchHistory.Add(match);
        }
    }
}