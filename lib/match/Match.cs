namespace mathletics.lib.match
{
    public abstract class Match
    {
        protected int firstOperand;
        protected int secondOperand;
        protected string operation;
        protected int minValue = 1;
        protected int maxValue;

        protected int correctAnswer;
        protected int playerAnswer;

        public int CorrectAnswer { get => correctAnswer; }
        public int PlayerAnswer { get => playerAnswer; }
        public bool PlayerWon { get => correctAnswer == playerAnswer; }
        public string Question { get => $"{firstOperand} {operation} {secondOperand}"; }



        public Match(string difficulty, string op)
        {
            SetDifficulty(difficulty);
            SetFirstOperand();
            SetSecondOperand();
            SetAnswer();
            operation = op;
        }

        private int SetRandomOperand()
        {
            var rand = new Random();
            return rand.Next(minValue, maxValue + 1);
        }
        protected virtual void SetFirstOperand()
        {
            firstOperand = SetRandomOperand();
        }

        protected virtual void SetSecondOperand()
        {
            secondOperand = SetRandomOperand();
        }

        protected abstract void SetAnswer();

        protected virtual void SetDifficulty(string difficulty)
        {
            switch (difficulty)
            {
                case "easy":
                    maxValue = 10;
                    break;
                case "normal":
                    maxValue = 100;
                    break;
                case "hard":
                    maxValue = 1000;
                    break;
            }
        }

        public void GiveAnswer(int answer)
        {
            playerAnswer = answer;
        }
    }
}

