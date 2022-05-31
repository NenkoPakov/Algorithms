using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._School_Teams
{
    public static class Program
    {
        private const int GIRLS_IN_TEAM = 3;
        private const int BOYS_IN_TEAM = 2;

        private static string[] girls;
        private static string[] boys;
        private static Dictionary<string, (string[] members, int size, List<string[]> combinations, string[] skeleton)> teams;

        private static string[] girlsCombination = new string[GIRLS_IN_TEAM];
        private static string[] boysCombination = new string[BOYS_IN_TEAM];
        private static List<string[]> boysCombinations = new List<string[]>();
        private static List<string[]> girlsCombinations = new List<string[]>();

        static void Main()
        {
            girls = Console.ReadLine().Split(", ");
            boys = Console.ReadLine().Split(", ");

            teams = new Dictionary<string, (string[] members, int size, List<string[]> combinations, string[] skeleton)>
            {
                { "girls",( girls ,GIRLS_IN_TEAM,  girlsCombinations, girlsCombination)},
                { "boys", ( boys, BOYS_IN_TEAM,  boysCombinations, boysCombination) }
            };

            foreach (var gender in teams.Keys)
            {
                GenerateTeams(gender, 0, 0);
            }

            
            PrintCombinations();
        }

        private static void PrintCombinations()
        {
            foreach (var girlCombination in girlsCombinations)
            {
                string girlsTeam = string.Join(", ", girlCombination);

                foreach (var boyCombination in boysCombinations)
                {
                    string boysTeam = string.Join(", ", boyCombination);

                    Console.WriteLine($"{girlsTeam}, {boysTeam}");
                }
            }
        }

        private static void GenerateTeams(string gender, int currentIndex, int startElementIndex)
        {
            var currentTeam = teams[gender].skeleton;

            if (currentIndex >= teams[gender].size)
            {
                teams[gender].combinations.Add(currentTeam.ToArray());
                return;
            }

            for (int i = startElementIndex; i < teams[gender].members.Length; i++)
            {
                currentTeam[currentIndex] = teams[gender].members[i];
                GenerateTeams(gender, currentIndex + 1, i + 1);
            }
        }
    }
}
