namespace SubmarineConsumptionCalculatorService
{
    public static class FileReader
    {
        public static List<string> ReadFile(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            return lines.ToList();
        }
    }
}
