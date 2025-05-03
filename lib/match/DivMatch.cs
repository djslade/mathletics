namespace mathletics.lib.match
{
    public class DivMatch : Match
    {
        public DivMatch() : base("/") { }


        protected override void SetSecondOperand()
        {
            var factors = new List<int>();
            for (int i = 1; i <= firstOperand; i++)
            {
                if (firstOperand % i != 0) continue;
                factors.Add(i);
            }
            var rand = new Random();
            var choice = rand.Next(factors.Count);
            secondOperand = factors[choice];
        }
        protected override void SetAnswer()
        {
            correctAnswer = firstOperand / secondOperand;
        }
    }
}