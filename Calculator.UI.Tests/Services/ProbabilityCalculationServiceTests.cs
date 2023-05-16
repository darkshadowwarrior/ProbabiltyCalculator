namespace Calculator.UI.Services
{
    public class ProbabilityCalculationServiceTests
    {
        [Fact]
        public void WhenCalculateIsCalled_ShouldCallCombinedWith_AndReturnResponse()
        {
            var service = new ProbabilityCalculationService();

            ProbabilityCalculationResponse response = service.Calculate(new ProbabilityCalculationRequest { ProbabilityA = 0.5, ProbabilityB = 0.5, TypeOfCalculation = "CombinedWith" });

            Assert.Equal(0.25, response.Result);
        }
    }
}
