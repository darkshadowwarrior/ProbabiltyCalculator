using Calculator.Core.Processor;
using Moq;

namespace Calculator.UI.Services
{
    public class ProbabilityCalculationServiceTests
    {
        private Mock<IProbabilityProcessor> _processorMock;

        public ProbabilityCalculationServiceTests()
        {
            _processorMock = new Mock<IProbabilityProcessor>();
        }

        [Fact]
        public void WhenCalculateIsCalled_ShouldCallCombinedWith_AndReturnResponse()
        {
            var service = new ProbabilityCalculationService(_processorMock.Object);
            _processorMock.Setup(x => x.CombinedWith(It.IsAny<double>(), It.IsAny<double>())).Returns(0.25);

            ProbabilityCalculationResponse response = service.Calculate(new ProbabilityCalculationRequest { ProbabilityA = 0.5, ProbabilityB = 0.5, TypeOfCalculation = "CombinedWith" });

            _processorMock.Verify(x => x.CombinedWith(It.IsAny<double>(), It.IsAny<double>()));

            Assert.Equal(0.25, response.Result);
        }
    }
}
