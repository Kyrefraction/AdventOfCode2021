using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DepthMeasurementService
{
    public class DepthMeasurementService
    {
        public static void Main(string[] args)
        {
            var depthMeasurements = FileReader.ReadFileIntList("input.txt");
            var numberOfMeasurementsGreaterThanPrevious = DepthMeasurementCalculator.GetIncreasingDepthMeasurements(depthMeasurements);
            var numberOfSpreadMeasurementsGreaterThanPrevious = DepthMeasurementCalculator.GetIncreasingDepthMeasurementsWithSpread(depthMeasurements, 3);

            Console.WriteLine($"Number of measurements greater than previous: {numberOfMeasurementsGreaterThanPrevious}");
            Console.WriteLine($"Number of measurements greater than previous with spread: {numberOfSpreadMeasurementsGreaterThanPrevious}");
            Console.ReadKey();
        }
    }

    public static class DepthMeasurementCalculator
    {
        public static int GetIncreasingDepthMeasurements(IReadOnlyList<int> depthMeasurements) => depthMeasurements.Where((depthMeasurement, index) => index != 0 && depthMeasurement > depthMeasurements[index - 1]).Count();

        public static int GetIncreasingDepthMeasurementsWithSpread(IReadOnlyList<int> depthMeasurements, int spread)
        {
            var count = 0;
            for (var index = 0; index < depthMeasurements.Count - spread + 1; index++)
            {
                if (index == 0) continue;

                var depthMeasurementSpread = GetSpread(depthMeasurements, index, spread);
                var previousDepthMeasurementSpread = GetSpread(depthMeasurements, index - 1, spread);

                if (depthMeasurementSpread > previousDepthMeasurementSpread)
                    count++;

            }

            return count;
        }

        private static int GetSpread(IReadOnlyList<int> depthMeasurements, int index, int spread)
        {
            var currentValue = depthMeasurements[index];
            for (var i = 1; i < spread; i++)
            {
                currentValue += depthMeasurements[index + i];
            }

            return currentValue;
        }

    }

    public static class FileReader
    {
        public static List<int> ReadFileIntList(string filePath)
        {
            var stringList = ReadFileStringList(filePath);
            return stringList.Select(int.Parse).ToList();
        }

        private static IEnumerable<string> ReadFileStringList(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            return lines.ToList();
        }
    }
}