namespace Calculator.Core.Wrappers
{
    public class FileWriter : IFileWriter
    {
        private readonly string _filePath = @"probability_results.csv";
        private readonly char _delimiter = ';';

        public void SaveToFile(string line)
        {

            if (!File.Exists(_filePath))
            {
                string header = $"Date, Calculation Used, Result, Input A, Input B {_delimiter}" + Environment.NewLine;

                File.WriteAllText(_filePath, header);
            }


            File.AppendAllText(_filePath, line + _delimiter + Environment.NewLine);
        }
    }
}
