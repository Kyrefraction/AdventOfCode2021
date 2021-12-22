namespace LanternfishPopulationCalculator
{
    public static class FileReader
    {
        public static List<int> ReadNumbers(string fileName)
        {
            var file = File.ReadAllText(fileName);
            var numbers = file.Split(',');
            return numbers.Select(int.Parse).ToList();
        }
    }
}
