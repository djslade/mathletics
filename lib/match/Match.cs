namespace mathletics.lib.match
{
    public abstract class Match
    {
        protected int firstOperand;
        protected int secondOperand;

        protected int correctAnswer;
        protected int playerAnswer;



        public Match()
        {
            SetFirstOperand();
            SetSecondOperand();
            SetAnswer();
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

        public abstract string Question();

    }
}

