namespace mathletics.lib.match
{
    public class MultMatch : Match
    {
        public MultMatch() : base("*") { }
        protected override void SetAnswer()
        {
            correctAnswer = firstOperand * secondOperand;
        }
    }
}