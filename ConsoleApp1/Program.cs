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
            for (var i = 0; i < 100; i++) // lists filling
            {
                firstList.Add(random.Next(100));
                secondList.Add(random.Next(100));
            } // lists filling
            WriteLineUniqueValues(firstList, secondList);
            Console.WriteLine();
        }
        static void WriteLineUniqueValues(List<int> firstList, List<int> secondList)
        {
            var tempList = new List<int>();
            tempList.AddRange(firstList);
            tempList.AddRange(secondList);
            var i = 0;
            while (i < tempList.Count) // primary loop
            {
                var toKill = false;
                for (var j = i + 1; j < tempList.Count; j++) // sub loop
                {
                    if (tempList[j] == tempList[i])
                    {
                        tempList.RemoveAt(j); // sub copy killing
                        toKill = true;
                    }
                }
                if (toKill == true)
                {
                    tempList.RemoveAt(i); // primary copy killing
                }
                else
                {
                    Console.Write($"{tempList[i]}; "); // unique value printing
                    i++; // go next primary index
                }
            }
            Console.WriteLine();
        }
    }
}