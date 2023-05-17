using Calculator.Core.Processor;
using Calculator.UI.Models;

namespace Calculator.UI.Services
{
    public class ProbabilityCalculationService : IProbabilityCalculationService
    {
        private readonly IProbabilityProcessor _processor;

        public ProbabilityCalculationService(IProbabilityProcessor processor)
        {
            _processor = processor;
        }

        public ProbabilityCalculationResponse Calculate(ProbabilityCalculationRequest probabilityCalculationRequest)
        {
            var response = new ProbabilityCalculationResponse();
            var p1 = double.Parse(probabilityCalculationRequest.ProbabilityA ?? string.Empty);
            var p2 = double.Parse(probabilityCalculationRequest.ProbabilityB ?? string.Empty);

            response.Result = probabilityCalculationRequest.TypeOfCalculation is "CombinedWith" ? _processor.CombinedWith(p1, p2) : _processor.Either(p1, p2);

            return response;
        }
    }
}