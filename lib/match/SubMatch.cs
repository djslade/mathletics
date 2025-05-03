namespace mathletics.lib.match
{
    public class SubMatch : Match
    {
        public SubMatch() : base("-") { }
        protected override void SetAnswer()
        {
            correctAnswer = firstOperand - secondOperand;
        }
    }
}