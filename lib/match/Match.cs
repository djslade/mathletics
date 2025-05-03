namespace mathletics.lib.match
{
    public abstract class Match
    {
        protected int firstOperand;
        protected int secondOperand;
        protected string operation;

        protected int correctAnswer;
        protected int playerAnswer;
        public bool PlayerWon { get => correctAnswer == playerAnswer; }
        public string Question { get => $"{firstOperand} {operation} {secondOperand}"; }



        public Match(string op)
        {
            SetFirstOperand();
            SetSecondOperand();
            SetAnswer();
            operation = op;
        }

        private static int SetRandomOperand()
        {
            var minValue = 1;
            var maxValue = 100;
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

        public void GiveAnswer(int answer)
        {
            playerAnswer = answer;
        }
    }
}

