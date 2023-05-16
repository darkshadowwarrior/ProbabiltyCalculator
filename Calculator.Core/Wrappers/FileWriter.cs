namespace Calculator.Core.Wrappers
{
    public class FileWriter : IFileWriter
    {
        private string FilePath = @"probability_results.csv";
        private char Delimiter = ';';

        public void SaveToFile(string line)
        {

            if (!File.Exists(FilePath))
            {
                string header = $"Date, Calculation Used, Result, Input A, Input B {Delimiter}" + Environment.NewLine;

                File.WriteAllText(FilePath, header);
            }


            File.AppendAllText(FilePath, line + Delimiter + Environment.NewLine);
        }
    }
}
