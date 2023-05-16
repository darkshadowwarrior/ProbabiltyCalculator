using Calculator.Core.Data;
using Calculator.Core.Processor;
using Calculator.Core.Wrappers;

namespace Calculator.Core.Repository
{
    public class ProbabilityRepository : IProbabilityRepository
    {
        private IFileWriter _fileWriter;

        public ProbabilityRepository(IFileWriter fileWriter)
        {
            _fileWriter = fileWriter;
        }

        public void Save(Probability probability)
        {
            var line = $"{probability.Date}, {probability.TypeOfCalculation}, {probability.Value}, {probability.Inputs[0]}, {probability.Inputs[1]}";

            _fileWriter.SaveToFile(line);
        }
    }
}