namespace mathletics.lib.match
{
    public class AddMatch : Match
    {
        public AddMatch() : base("+") { }

        protected override void SetAnswer()
        {
            correctAnswer = firstOperand + secondOperand;
        }
    }
}