namespace mathletics.lib.match
{
    public class AddMatch(string difficulty) : Match(difficulty, "+")
    {
        protected override void SetAnswer()
        {
            correctAnswer = firstOperand + secondOperand;
        }
    }
}