using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DepthMeasurementService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var depthMeasurements = ReadFileIntList("input.txt");
            var numberOfMeasurementsGreaterThanPrevious = GetDepthMeasurementsGreaterThanPrevious(depthMeasurements);

            Console.WriteLine(numberOfMeasurementsGreaterThanPrevious);
            Console.ReadKey();
        }

        private static int GetDepthMeasurementsGreaterThanPrevious(IReadOnlyList<int> depthMeasurements) => depthMeasurements.Where((t, index) => index != 0 && t > depthMeasurements[index - 1]).Count();

        private static List<int> ReadFileIntList(string filePath)
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