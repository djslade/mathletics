namespace mathletics.lib.settings
{
    public class Settings
    {
        private string[] _difficultyOptions = ["easy", "normal", "hard"];
        private string _difficulty = "normal";

        public string[] DifficultyOptions { get => _difficultyOptions; }
        public string Difficulty
        {
            get => _difficulty;
            set
            {
                if (!_difficultyOptions.Contains(value)) throw new Exception("not a valid difficulty option");
                _difficulty = value;
            }
        }
    }
}