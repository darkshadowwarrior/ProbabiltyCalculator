namespace Calculator.Core.Processor
{
    public class ProbabilityProcessorTests
    {
        [Theory]
        [InlineData(0.5, 0.5, 0.25)]
        [InlineData(0.3, 0.7, 0.21)]
        public void ShouldReturnCorrectProbability_WhenCombinedWithIsCalled(double p1, double p2, double expected)
        {
            var processor = new ProbabilityProcessor();

            var result = processor.CombinedWith(p1, p2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-0.1, 0.5)]
        [InlineData(1, -0.5)]
        public void ShouldThrowsArgumentOutOfRangeExceptionIfArgumentIsNullWhenCallingCombinedWith(double p1, double p2)
        {
            
        }
}
