using System;
using System.Collections.Generic;

namespace WriteLineUniqueValues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstList = new List<int>();
            var secondList = new List<int>();
            var random = new Random();
            for (var i = 0; i < 100; i++) // lists random filling
            {
                firstList.Add(random.Next(100));
                secondList.Add(random.Next(100));
            } // lists random filling
            WriteLineUniqueValues(firstList, secondList);
        }
        static void WriteLineUniqueValues(List<int> firstList, List<int> secondList)
        {
            var uniqueValues = new Dictionary<int, int>();
            var copyValues = new Dictionary<int, int>();
            var runCounter = 0;
            foreach (var value in firstList) // get first list values
            {
                try
                {
                    uniqueValues.Add(value, value);
                }
                catch
                {
                    runCounter++;
                    try
                    {
                        copyValues.Add(value, value);
                    }
                    catch
                    {
                        runCounter++;
                    }
                }
            } // get first list values
            foreach (var value in secondList) // get second list values
            {
                try
                {
                    uniqueValues.Add(value, value);
                }
                catch
                {
                    runCounter++;
                    try
                    {
                        copyValues.Add(value, value);
                    }
                    catch
                    {
                        runCounter++;
                    }
                }
            } // get second list values
            foreach (var value in copyValues.Keys) // double check
            {
                runCounter++;
                uniqueValues.Remove(value);
            } // double check
            foreach (var value in uniqueValues.Keys)
            {
                Console.Write($"{value}; ");
            }
            Console.WriteLine();
            Console.WriteLine($"Run counter: {runCounter}");
            Console.WriteLine();
        }
    }
}