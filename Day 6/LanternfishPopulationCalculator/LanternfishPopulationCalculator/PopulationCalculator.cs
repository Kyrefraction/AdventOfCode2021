public static class PopulationCalculator
{
    public static long CalculatePopulation(List<int> lanternFishPopulation, int calculationTime)
    {
        var lanternFishGroups = GetInitialPopulationGroups(lanternFishPopulation);

        for (int day = 0; day < calculationTime; day++)
        {
            TickLanternFishGroups(lanternFishGroups);
        }

        return SumGroups(lanternFishGroups);
    }

    private static void TickLanternFishGroups(long[] lanternFishGroups)
    {
        var numberOfNewSpawns = lanternFishGroups[0];

        for (int group = 0; group < LanternFishProperties.MaxDaysUntilSpawn - 1; group++)
        {
            lanternFishGroups[group] = lanternFishGroups[group + 1];
        }

        AddNewSpawns(lanternFishGroups, numberOfNewSpawns);
        ResetParents(lanternFishGroups, numberOfNewSpawns);
    }

    private static void AddNewSpawns(long[] lanternFishGroups, long numberOfNewSpawns)
    {
        lanternFishGroups[LanternFishProperties.ReproductionInterval + LanternFishProperties.MaturityInterval - 1] = numberOfNewSpawns;
    }

    private static void ResetParents(long[] lanternFishGroups, long numberOfNewSpawns)
    {
        lanternFishGroups[LanternFishProperties.ReproductionInterval - 1] += numberOfNewSpawns;
    }

    private static long[] GetInitialPopulationGroups(List<int> lanternFishPopulation)
    {
        long[] lanternFishGroups = new long[LanternFishProperties.MaxDaysUntilSpawn];

        foreach (var lanternFish in lanternFishPopulation)
        {
            lanternFishGroups[lanternFish]++;
        }

        return lanternFishGroups;
    }

    private static long SumGroups(long[] lanternFishGroups)
    {
        long total = 0;
        foreach (var lanternFishInGroup in lanternFishGroups)
        {
            total += lanternFishInGroup;
        }
        return total;
    }
}
