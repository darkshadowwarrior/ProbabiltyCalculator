using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using Moq;

namespace Calculator.Core.Processor
{
    public class ProbabilityProcessorTests
    {
        private Mock<IProbabilityRepository> _probabilityRepositoryMock;
        private ProbabilityProcessor _processor;

        public ProbabilityProcessorTests()
        {
            _probabilityRepositoryMock = new Mock<IProbabilityRepository>();

            _processor = new ProbabilityProcessor(_probabilityRepositoryMock.Object);
        }

        [Theory]
        [InlineData(0.5, 0.5, 0.25)]
        [InlineData(0.3, 0.7, 0.21)]
        public void ShouldReturnCorrectProbability_WhenCombinedWithIsCalled(double p1, double p2, double expected)
        {
            var result = _processor.CombinedWith(p1, p2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-0.1, 0.5)]
        [InlineData(1, -0.5)]
        public void ShouldThrowsArgumentOutOfRangeExceptionIfArgumentIsNullWhenCallingCombinedWith(double p1, double p2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _processor.CombinedWith(p1, p2));
        }

        [Theory]
        [InlineData(0.5, 0.5, 0.75)]
        [InlineData(0.3, 0.7, 0.79)]
        public void ShouldReturnCorrectProbability_WhenEitherIsCalled(double p1, double p2, double expected)
        {
            var result = _processor.Either(p1, p2);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(-0.1, 0.5)]
        [InlineData(1, -0.5)]
        public void ShouldThrowsArgumentOutOfRangeExceptionIfArgumentIsNullWhenCallingEither(double p1, double p2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _processor.Either(p1, p2));
        }

        [Theory]
        [InlineData(0.5, 0.5, 0.25)]
        [InlineData(0.3, 0.7, 0.21)]
        public void ShouldSaveCombinedWithResultToFile(double p1, double p2, double expected)
        {

            Probability savedProbability = null;

            _probabilityRepositoryMock.Setup(x => x.Save(It.IsAny<Probability>()))
                .Callback<Probability>(probabilty =>
                {
                    savedProbability = probabilty;
                });

            _processor.CombinedWith(p1, p2);

            _probabilityRepositoryMock.Verify(x => x.Save(It.IsAny<Probability>()), Times.Once());

            Assert.NotNull(savedProbability);
            Assert.Equal(expected, savedProbability.Value);

        }

    }
}
