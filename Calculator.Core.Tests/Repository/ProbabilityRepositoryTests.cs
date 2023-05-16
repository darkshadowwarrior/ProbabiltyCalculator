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

        [Theory]
        [InlineData(0.25, "CombinedWith", new double[] { 0.5, 0.5 })]
        [InlineData(0.79, "Either", new double[] { 0.3, 0.7 })]
        public void ShouldSaveToFileWhenSaveIsCalled(double itemToSave, string typeOfCalculation, double[] Inputs)
        {
            var repository = new ProbabilityRepository(_fileMock.Object);
            string lineToSave = "";
            var probabilityToSave = new Probability { Value = itemToSave, Date = new DateTime(2023, 5, 16), TypeOfCalculation = typeOfCalculation, Inputs = Inputs };
            var expectedLineToSave = $"Date calculation processed is: {probabilityToSave.Date}, Type of calculation: {probabilityToSave.TypeOfCalculation}, Result of calculation: {probabilityToSave.Value}, Inputs used are: P1 = {probabilityToSave.Inputs[0]} and P2 = {probabilityToSave.Inputs[1]}";
            
            _fileMock.Setup(x => x.SaveToFile(It.IsAny<string>()))
            .Callback<string>(value =>
            {
                lineToSave = value;
            });

            repository.Save(probabilityToSave);

            Assert.NotEmpty(lineToSave);
            Assert.Equal(lineToSave, expectedLineToSave);
        }
    }
}
