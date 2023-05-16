namespace Calculator.Core.Wrappers
{
    public class FileWriter : IFileWriter
    {
        private string FilePath = @"\results\probability_results.txt";

        public void SaveToFile(string line)
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath);
            }

            using (var stream = new StreamWriter(FilePath))
            {
                stream.WriteLine(line);
            }
        }
    }
}
