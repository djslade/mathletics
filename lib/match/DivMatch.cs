namespace mathletics.lib.match
{
    public class DivMatch(string difficulty) : Match(difficulty, "/")
    {
        protected override void SetSecondOperand()
        {
            var factors = new List<int>();
            for (int i = minValue; i <= firstOperand; i++)
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