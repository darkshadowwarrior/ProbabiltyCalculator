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
            var line = $"Date calculation processed is: {probability.Date} , Type of calculation: {probability.TypeOfCalculation}, Result of calculation: {probability.Value}, Inputs used are: P1 = {probability.Inputs[0]} and P2 = {probability.Inputs[0]}";

            _fileWriter.SaveToFile(line);
        }
    }
}