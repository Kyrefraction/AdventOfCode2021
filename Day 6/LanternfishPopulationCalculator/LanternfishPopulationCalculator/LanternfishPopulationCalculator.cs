using LanternfishPopulationCalculator;

var calculationTimes = new List<int> { 80, 256 };

var initialLanternFishPopulation = FileReader.ReadNumbers("input.txt");
foreach (var calculationTime in calculationTimes)
{
    var calculatedLanternFishPopulation = PopulationCalculator.CalculatePopulation(initialLanternFishPopulation, calculationTime);
    Console.WriteLine($"After {calculationTime} days the population will be {calculatedLanternFishPopulation}");
}