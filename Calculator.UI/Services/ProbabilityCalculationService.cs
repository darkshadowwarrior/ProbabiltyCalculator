using Calculator.Core.Processor;

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
            var p1 = double.Parse(probabilityCalculationRequest.ProbabilityA);
            var p2 = double.Parse(probabilityCalculationRequest.ProbabilityB);

            if (probabilityCalculationRequest.TypeOfCalculation.Equals("CombinedWith")) { 
                response.Result = _processor.CombinedWith(p1, p2);
            } 
            else
            {
                response.Result = _processor.Either(p1, p2);
            }

            return response;
        }
    }
}