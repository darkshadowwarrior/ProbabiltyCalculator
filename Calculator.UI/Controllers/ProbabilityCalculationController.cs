using Calculator.UI.Models;
using Calculator.UI.Services;

namespace Calculator.UI.Controllers
{
    public class ProbabilityCalculationController
    {
        private readonly IProbabilityCalculationService _service;

        public ProbabilityCalculationController(IProbabilityCalculationService service)
        {
            _service = service;
        }

        public ProbabilityCalculationResponse CalculateProbability(ProbabilityCalculationRequest request)
        {
            if (request == null) { throw new ArgumentNullException(nameof(request)); }

            return _service.Calculate(request);
        }
    }
}