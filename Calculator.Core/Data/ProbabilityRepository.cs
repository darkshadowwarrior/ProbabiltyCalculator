using Calculator.Core.Domain;
using Calculator.Core.Wrappers;

namespace Calculator.Core.Data
{
    public class ProbabilityRepository : IProbabilityRepository
    {
        private readonly IFileWriter _fileWriter;

        public ProbabilityRepository(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public void Save(Probability probability)
        {
            if (probability.Inputs != null)
            {
                var line = $"{probability.Date}, {probability.TypeOfCalculation}, {probability.Value}, {probability.Inputs[0]}, {probability.Inputs[1]}";

                _fileWriter.SaveToFile(line);
            }
        }
    }
}