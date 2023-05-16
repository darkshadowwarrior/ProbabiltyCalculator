using Calculator.Core.Processor;
using Calculator.Core.Wrappers;
using Moq;

namespace Calculator.Core.Repository
{
    public class ProbabilityRepositoryTests
    {
        private Mock<IFileWriter> _fileMock;

        public ProbabilityRepositoryTests()
        {
            _fileMock = new Mock<IFileWriter>();
        }

        [Fact]
        public void WhenSaveIsCalled_ShouldGenerateALineInTheCorrectFormat_AndSaveToFile()
        {
            var repository = new ProbabilityRepository(_fileMock.Object);

            var probabilityToSave = new Probability { Value = 0.25, Date = new DateTime(2023, 5, 16), TypeOfCalculation = "CombinedWith", Inputs = new double[] { 0.5, 0.5 } };
            var expectedLineToSave = $"Date calculation processed is: {probabilityToSave.Date}, Type of calculation: {probabilityToSave.TypeOfCalculation}, Result of calculation: {probabilityToSave.Value}, Inputs used are: P1 = {probabilityToSave.Inputs[0]} and P2 = {probabilityToSave.Inputs[1]}";

            repository.Save(probabilityToSave);

            _fileMock.Verify(x => x.SaveToFile(expectedLineToSave), Times.Once());
        }
    }
}
