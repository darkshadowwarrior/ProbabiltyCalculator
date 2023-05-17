using Calculator.Core.Data;
using Calculator.Core.Domain;
using Calculator.Core.Wrappers;
using Moq;

namespace Calculator.Core.Repository
{
    public class ProbabilityRepositoryTests
    {
        private readonly Mock<IFileWriter> _fileMock;

        public ProbabilityRepositoryTests()
        {
            _fileMock = new Mock<IFileWriter>();
        }

        [Fact]
        public void WhenSaveIsCalled_ShouldGenerateALineInTheCorrectFormat_AndSaveToFile()
        {
            var repository = new ProbabilityRepository(_fileMock.Object);

            var probabilityToSave = new Probability { Value = 0.25, Date = new DateTime(2023, 5, 16), TypeOfCalculation = "CombinedWith", Inputs = new[] { 0.5, 0.5 } };
            var expectedLineToSave = $"{probabilityToSave.Date}, {probabilityToSave.TypeOfCalculation}, {probabilityToSave.Value}, {probabilityToSave.Inputs[0]}, {probabilityToSave.Inputs[1]}";

            repository.Save(probabilityToSave);

            _fileMock.Verify(x => x.SaveToFile(expectedLineToSave), Times.Once());
        }
    }
}
