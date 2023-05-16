namespace Calculator.Core.Wrappers
{
    public class FileWriter : IFileWriter
    {
        private string FilePath = @"probability_results.txt";

        public void SaveToFile(string line)
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }

            File.AppendAllText(FilePath, line);
        }
    }
}
