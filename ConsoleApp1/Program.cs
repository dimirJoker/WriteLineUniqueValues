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
            WriteLineUniqueValuesByDictionary(firstList, secondList);
            WriteLineUniqueValuesByList(firstList, secondList);
        }
        static void WriteLineUniqueValuesByDictionary(List<int> firstList, List<int> secondList)
        {
            var uniqueValues = new Dictionary<int, int>();
            var copyValues = new Dictionary<int, int>();
            var stepsCounter = 0;
            foreach (var value in firstList) // getting first list values
            {
                try
                {
                    uniqueValues.Add(value, value);
                }
                catch
                {
                    stepsCounter++;
                    try
                    {
                        copyValues.Add(value, value);
                    }
                    catch
                    {
                        stepsCounter++;
                    }
                }
            } // getting first list values
            foreach (var value in secondList) // getting second list values
            {
                try
                {
                    uniqueValues.Add(value, value);
                }
                catch
                {
                    stepsCounter++;
                    try
                    {
                        copyValues.Add(value, value);
                    }
                    catch
                    {
                        stepsCounter++;
                    }
                }
            } // getting second list values
            foreach (var value in copyValues.Keys) // making double check
            {
                stepsCounter++;
                uniqueValues.Remove(value);
            } // making double check
            Console.WriteLine("WriteLine unique values by dictionary:");
            foreach (var value in uniqueValues.Keys)
            {
                Console.Write($"{value}; ");
            }
            Console.WriteLine();
            Console.WriteLine($"Steps: {stepsCounter}");
            Console.WriteLine();
        }
        static void WriteLineUniqueValuesByList(List<int> firstList, List<int> secondList)
        {
            var tempList = new List<int>();
            tempList.AddRange(firstList);
            tempList.AddRange(secondList);
            var stepsCounter = 0;
            Console.WriteLine("WriteLine unique values by list:");
            for (var i = 0; i < tempList.Count;) // primary value
            {
                var isUnique = true;
                for (var j = i + 1; j < tempList.Count; ) // looking for it copies
                {
                    stepsCounter++;
                    if (tempList[j] == tempList[i])
                    {
                        isUnique = false;
                        tempList.RemoveAt(j); // and killing them
                    }
                    else
                    {
                        j++;
                    }
                }
                if (!isUnique)
                {
                    tempList.RemoveAt(i); // but then it killed itself because of remorse
                }
                else
                {
                    Console.Write($"{tempList[i]}; "); // or not =)
                    i++;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"Steps done: {stepsCounter}");
            Console.WriteLine();
        }
    }
}