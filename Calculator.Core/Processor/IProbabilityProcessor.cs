namespace Calculator.Core.Processor
{
    public interface IProbabilityProcessor
    {
        double CombinedWith(double p1, double p2);
        double Either(double p1, double p2);
    }
}