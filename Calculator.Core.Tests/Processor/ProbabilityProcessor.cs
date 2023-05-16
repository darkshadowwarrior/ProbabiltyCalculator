namespace Calculator.Core.Processor
{
    public class ProbabilityProcessor
    {
        public ProbabilityProcessor()
        {
        }

        public double CombinedWith(double p1, double p2)
        {
            ThrowExceptionIfArguementsOutOfRange(p1, p2);

            return p1 * p2;
        }

        private static void ThrowExceptionIfArguementsOutOfRange(double p1, double p2)
        {
            if (p1 is < 0 or > 1 || p2 is < 0 or > 1)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
    }
}