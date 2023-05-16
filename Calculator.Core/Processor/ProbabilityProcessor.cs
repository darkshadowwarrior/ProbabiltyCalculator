namespace Calculator.Core.Processor
{
    public class ProbabilityProcessor
    {
        private readonly IProbabilityRepository _repository;

        public ProbabilityProcessor(IProbabilityRepository repository)
        {
            _repository = repository;
        }

        public double CombinedWith(double p1, double p2)
        {
            ThrowExceptionIfArguementsOutOfRange(p1, p2);

            var result = p1 * p2;

            _repository.Save(new Probability { Value = result });

            return result;
        }

        public double Either(double p1, double p2)
        {
            ThrowExceptionIfArguementsOutOfRange(p1, p2);

            var a = p1 + p2;
            var b = p2 * p1;

            return a - b;
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