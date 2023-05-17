using Calculator.Core.Domain;

namespace Calculator.Core.Data
{
    public interface IProbabilityRepository
    {
        void Save(Probability probability);
    }
}