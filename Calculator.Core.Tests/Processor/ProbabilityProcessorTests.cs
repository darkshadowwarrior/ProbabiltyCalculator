namespace Calculator.Core.Processor
{
    public class ProbabilityProcessorTests
    {
        [Theory]
        [InlineData(0.5, 0.5, 0.25)]
        public void ShouldReturnCorrectProbability_WhenCombinedWithIsCalled(double p1, double p2, double expected)
        {
            var processor = new ProbabilityProcessor();

            var result = processor.CombinedWith(p1, p2);

            Assert.Equal(expected, result);

        }
    }
}
