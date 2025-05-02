namespace mathletics.lib.match
{
    public class AddMatch : Match
    {
        protected override void SetAnswer()
        {
            correctAnswer = firstOperand + secondOperand;
        }

        public override string Question()
        {
            return $"{firstOperand} + {secondOperand}";
        }   
    }
}