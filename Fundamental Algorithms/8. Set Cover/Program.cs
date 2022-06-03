using System;
using System.Collections.Generic;
using System.Linq;

namespace _8._Set_Cover
{
    public static class Program
    {
        public static void Main()
        {
            List<int> universe = Console.ReadLine()
                                        .Split(", ")
                                        .Select(x => int.Parse(x))
                                        .ToList();

            int subSetCount = int.Parse(Console.ReadLine());
            int[][] subSets = new int[subSetCount][];

            ICollection<int[]> usedSets = new List<int[]>();

            for (int set = 0; set < subSetCount; set++)
            {
                subSets[set] = Console.ReadLine()
                                    .Split(", ")
                                    .Select(x => int.Parse(x))
                                    .ToArray();
            }

            GetCoverSets(universe, subSets, usedSets);

            PrintTheResult(universe, usedSets);
        }

        private static void GetCoverSets(List<int> universe, int[][] subSets, ICollection<int[]> usedSets)
        {
            int[] currentSet = subSets
                                                .OrderByDescending(set => set.Count(elem => universe.Contains(elem)))
                                                .FirstOrDefault(set => set.Any(elem => universe.Contains(elem)));

            while (universe.Any() && currentSet != null)
            {
                usedSets.Add(currentSet);

                foreach (var elem in from int elem in currentSet
                                     where universe.Contains(elem)
                                     select elem)
                {
                    universe.Remove(elem);
                }

                currentSet = subSets
                                         .OrderByDescending(set => set.Count(elem => universe.Contains(elem)))
                                         .FirstOrDefault(set => set.Any(elem => universe.Contains(elem)));
            }
        }

        private static void PrintTheResult(List<int> universe, ICollection<int[]> usedSets)
        {
            if (universe.Any())
            {
                Console.WriteLine("Error");
            }
            else
            {
                Console.WriteLine($"Sets to take ({usedSets.Count}):");

                foreach (int[] set in usedSets)
                {
                    Console.WriteLine(string.Join(", ", set));
                }
            }
        }
    }
}
