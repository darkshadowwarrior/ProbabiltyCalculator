namespace Calculator.Core.Domain
{
    public class Probability
    {
        public double Value { get; init; }
        public DateTime Date { get; init; }
        public string? TypeOfCalculation { get; init; }
        public double[]? Inputs { get; init; }

    }
}