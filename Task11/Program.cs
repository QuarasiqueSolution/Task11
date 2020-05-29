using System;
using System.Linq;
using Task11Library;

namespace Task11
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Connecting to database...");

                var lastResults = GetLastResults.GetRows();
                Console.WriteLine("Last {0} result(s) (#\'Id\': \'value\'): ", lastResults.Count());
                foreach (var row in lastResults)
                {
                    Console.WriteLine("#{0}: {1}", row.Id, row.Result);
                }

                while (true)
                {
                    Console.WriteLine();
                    Console.WriteLine("Input number of intervals to get sum of the lengths of these intervals.");
                    Console.WriteLine("Example: input of \"1 2 3 4\" would be [1, 2], [3, 4]).");
                    Console.WriteLine("Note: Incorrect input would be a \"0\".");
                    string intervalsString = Console.ReadLine();
                    int[] intervalsArray = intervalsString.Split(' ').Select(s => int.TryParse(s, out int n) ? n : 0).ToArray();
                    if (intervalsArray.Length <= 1)
                    {
                        Console.WriteLine("Array is empty or not filled!");
                        continue;
                    }
                    if (intervalsArray.Length % 2 != 0)
                    {
                        Console.WriteLine("Warning: Last interval contains only one number. Erasing last interval...");
                        intervalsArray = intervalsArray.Take(intervalsArray.Length - 1).ToArray();
                    }
                    int intervalsLength = intervalsArray.Length / 2;
                    ValueTuple<int, int>[] intervals = new ValueTuple<int, int>[intervalsLength];
                    for (int i = 0; i < intervalsLength; i++)
                    {
                        intervals[i].Item1 = intervalsArray[i + i];
                        intervals[i].Item2 = intervalsArray[i + i + 1];
                    }
                    Console.WriteLine("Intervals: ");
                    foreach (var e in intervals)
                    {
                        Console.WriteLine("[" + e.Item1 + ", " + e.Item2 + "]");
                    }
                    int result = SumIntervals.GetSumInterval(intervals);
                    Console.WriteLine("Sum of these intervals: " + result);
                    SaveResult.Save(new SumInterval { Result = result });
                    Console.WriteLine("Result was inserted into database.");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadKey();
            }
        }
    }
}