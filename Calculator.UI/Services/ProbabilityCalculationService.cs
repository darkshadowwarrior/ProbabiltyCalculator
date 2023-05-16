using Calculator.Core.Processor;

namespace Calculator.UI.Services
{
    public class ProbabilityCalculationService
    {
        private readonly IProbabilityProcessor _processor;

        public ProbabilityCalculationService(IProbabilityProcessor processor)
        {
            _processor = processor;
        }

        public ProbabilityCalculationResponse Calculate(ProbabilityCalculationRequest probabilityCalculationRequest)
        {
            var response = new ProbabilityCalculationResponse();
            if (probabilityCalculationRequest.TypeOfCalculation.Equals("CombinedWith")) { 
                response.Result = _processor.CombinedWith(probabilityCalculationRequest.ProbabilityA, probabilityCalculationRequest.ProbabilityB);
            } else
            {
                response.Result = _processor.Either(probabilityCalculationRequest.ProbabilityA, probabilityCalculationRequest.ProbabilityB);
            }

            return response;
        }
    }
}