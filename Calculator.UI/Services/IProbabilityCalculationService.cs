using Calculator.UI.Models;

namespace Calculator.UI.Services
{
    public interface IProbabilityCalculationService
    {
        ProbabilityCalculationResponse Calculate(ProbabilityCalculationRequest probabilityCalculationRequest);
    }
}