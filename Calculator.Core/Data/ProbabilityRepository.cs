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
            throw new NotImplementedException();
        }
    }
}