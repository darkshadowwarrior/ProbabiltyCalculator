﻿using Calculator.Core.Data;
using Calculator.Core.Domain;
using Moq;

namespace Calculator.Core.Processor
{
    public class ProbabilityProcessorTests
    {
        private readonly Mock<IProbabilityRepository> _probabilityRepositoryMock;
        private readonly ProbabilityProcessor _processor;

        public ProbabilityProcessorTests()
        {
            _probabilityRepositoryMock = new Mock<IProbabilityRepository>();

            _processor = new ProbabilityProcessor(_probabilityRepositoryMock.Object);
        }

        [Theory]
        [InlineData(-0.1, 0.5)]
        [InlineData(1, -0.5)]
        public void WhenCombinedWithIsCalled_IfArgumentIsOutOfRange_ShouldThrowArgumentOutOfRangeException(double p1, double p2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _processor.CombinedWith(p1, p2));
        }

        [Theory]
        [InlineData(-0.1, 0.5)]
        [InlineData(1, -0.5)]
        public void WhenEitherIsCalled_IfArgumentIsOutOfRange_ShouldThrowArgumentOutOfRangeException(double p1, double p2)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _processor.Either(p1, p2));
        }

        [Fact]
        public void WhenCombinedWithIsCalledWithValidArguments_ShouldSaveCombinedWithResultToFile_AndShouldReturnExpectedProbability()
        {
            var expected = 0.25;
            var result = _processor.CombinedWith(0.5, 0.5);

            _probabilityRepositoryMock.Verify(x => x.Save(It.IsAny<Probability>()), Times.Once());

            Assert.Equal(expected, result);
        }

        [Fact]
        public void WhenEitherIsCalledWithValidArguments_ShouldSaveEitherResultToFile_AndShouldReturnExpectedProbability()
        {
            var expected = 0.75;
            var result = _processor.Either(0.5, 0.5);

            _probabilityRepositoryMock.Verify(x => x.Save(It.IsAny<Probability>()), Times.Once());

            Assert.Equal(expected, result);
        }

    }
}
