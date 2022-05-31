using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _6._Word_Cruncher
{
    public static class Program
    {
        private static string[] parts;
        private static string targetWord;
        private static IDictionary<int, ICollection<string>> indexCandidates = new Dictionary<int, ICollection<string>>();
        private static Stack<string> formedWord = new Stack<string>();

        public static void Main()
        {
            parts = Console.ReadLine().Split(", ");
            targetWord = Console.ReadLine();

            FindCandidatesByIndex(0);
            GenerateWord(0);
        }

        private static void FindCandidatesByIndex(int index)
        {
            if (index>=targetWord.Length)
            {
                return;
            }

            foreach (var part in parts.Where(part=>part.StartsWith(targetWord[index])))
            {
                bool canBePlased = true;
                for (int i = 1; i < part.Length; i++)
                {
                    canBePlased = targetWord[index + i]==part[i];

                    if (!canBePlased)
                    {
                        break;
                    }
                }

                if (!canBePlased)
                {
                    continue;
                }

                if (!indexCandidates.ContainsKey(index))
                {
                    indexCandidates[index] = new HashSet<string>();
                }

                indexCandidates[index].Add(part);
            }

            FindCandidatesByIndex(index + 1);
        }

        private static void GenerateWord(int index)
        {
            if (index >= targetWord.Length)
            {
                Console.WriteLine(string.Join(' ', formedWord.Reverse()));
                return;
            }

            ICollection<string> candidateParts;
            bool contains = indexCandidates.TryGetValue(index, out candidateParts);

            if (!contains)
            {
                return;
            }

            foreach (var candidate in candidateParts)
            {
                int candidateLength = candidate.Length;

                formedWord.Push(candidate);
                GenerateWord(index + candidateLength);
                formedWord.Pop();
            }
        }
    }
}

