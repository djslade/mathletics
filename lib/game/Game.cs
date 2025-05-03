using mathletics.lib.match;
using mathletics.lib.history;
using mathletics.lib.settings;
using mathletics.lib.stats;

namespace mathletics.lib.game
{
    public class Game
    {
        private string[] _operators = ["+", "-", "*", "/"];
        private readonly History _history = new();
        private readonly Settings _settings = new();
        private readonly Stats _stats = new();
        private bool _running = true;


        private Match GetMatch(string op)
        {
            Match match = op switch
            {
                "-" => new SubMatch(_settings.Difficulty),
                "+" => new AddMatch(_settings.Difficulty),
                "*" => new MultMatch(_settings.Difficulty),
                "/" => new DivMatch(_settings.Difficulty),
                _ => throw new Exception("op not one of expected values"),
            };
            return match;
        }

        private string GetOpFromUser()
        {
            string? op = "";
            Console.WriteLine($"Enter an operator or 'random' for a random game, options are {string.Join(", ", _operators)}");
            while (op == "")
            {
                var input = Console.ReadLine();
                if (!_operators.Contains(input))
                {
                    if (input == "random")
                    {
                        var random = new Random();
                        input = _operators[random.Next(_operators.Length)];
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid operator");
                        continue;
                    }

                }
                if (input == null) throw new Exception("user input is null");
                op = input.Trim();
            }
            return op;
        }

        private static int GetAnswerFromUser(string question)
        {
            var cancellationToken = new CancellationTokenSource();
            Task<int> inputTask = Task.Run(() =>
            {
                Console.WriteLine($"What is {question}?");
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int answer))
                    {
                        cancellationToken.Cancel();
                        return answer;
                    }
                    Console.WriteLine("Please enter a valid integer");
                }
            });

            Task countdownTask = Task.Run(async () =>
            {
                for (int i = 15; i > 0; i--)
                {
                    if (cancellationToken.Token.IsCancellationRequested) return;
                    Console.Write($"\r{i} seconds left");
                    await Task.Delay(1000);
                }
                Console.WriteLine("\n");
                cancellationToken.Cancel();
            });

            if (inputTask.Wait(TimeSpan.FromSeconds(15)))
            {
                return inputTask.Result;
            }
            Console.WriteLine("Time's up!");
            return 0;
        }

        private void Play()
        {
            string op = GetOpFromUser();
            Match match = GetMatch(op);
            int answer = GetAnswerFromUser(match.Question);
            match.GiveAnswer(answer);
            if (match.PlayerWon)
            {
                Console.WriteLine("You win!");
                _stats.IncreaseStreak();
            }
            else
            {
                Console.WriteLine("You lose!");
                _stats.ResetStreak();
            }
            _stats.IncreaseTotalMatches();
            _history.AddMatch(match);
        }

        private static void ShowMenu()
        {
            Console.WriteLine("Select an option (without quotes)");
            Console.WriteLine("'play'");
            Console.WriteLine("'difficulty");
            Console.WriteLine("'stats'");
            Console.WriteLine("'history");
            Console.WriteLine("'quit");
        }

        private void SetDifficulty()
        {
            try
            {
                Console.WriteLine($"Difficulty is currently set to {_settings.Difficulty}");
                Console.WriteLine($"Choose a difficulty. Options are {string.Join(",", _settings.DifficultyOptions)}");
                string? difficulty = Console.ReadLine() ?? throw new Exception("could not read input");
                _settings.Difficulty = difficulty;
            }
            catch (Exception)
            {
                Console.WriteLine("Not a valid difficulty option");
            }
        }

        private void ShowStats()
        {
            Console.WriteLine($"Your current streak is {_stats.Streak}");
            Console.WriteLine($"Your longest streak is {_stats.LongestStreak}");
            Console.WriteLine($"Your total games played is {_stats.TotalMatches}");
        }

        private void ShowHistory()
        {
            foreach (Match match in _history.Matches)
            {
                Console.WriteLine($"Question: {match.Question}");
                Console.WriteLine($"Your answer: {match.PlayerAnswer}");
                Console.WriteLine($"Correct answer: {match.CorrectAnswer}");
                Console.WriteLine($"Outcome: {(match.PlayerWon ? "win" : "loss")}");
                Console.WriteLine("\n");
            }
        }

        private void Quit()
        {
            _running = false;
            Console.WriteLine("Thanks for playing!");
        }

        public void Start()
        {
            Console.WriteLine("Welcome to the incredible game Mathletics!");
            while (_running)
            {
                ShowMenu();
                var input = Console.ReadLine();
                if (input == null) continue;
                switch (input)
                {
                    case "play":
                        Play();
                        break;
                    case "difficulty":
                        SetDifficulty();
                        break;
                    case "stats":
                        ShowStats();
                        break;
                    case "history":
                        ShowHistory();
                        break;
                    case "quit":
                        Quit();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid command");
                        break;
                }
            }
        }
    }
}