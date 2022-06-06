using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Cycles_in_a_Graph
{
    public static class Program
    {
        private static Dictionary<char,ICollection<char>> graph = new Dictionary<char, ICollection<char>>();
        private static HashSet<char> visited = new HashSet<char>();

        public static void Main()
        {
            string input;

            while ((input = Console.ReadLine())!= "End")
            {
                char[] edge = input.Split('-').Select(x=>char.Parse(x)).ToArray();

                char fromVertex = edge[0];
                char toVertex = edge[1];

                if (!graph.ContainsKey(fromVertex))
                {
                    graph.Add(fromVertex, new List<char>());
                }

                if (!graph.ContainsKey(toVertex))
                {
                    graph.Add(toVertex, new List<char>());
                }

                graph[fromVertex].Add(toVertex);
            }

            try
            {
                DFS(graph.Keys.FirstOrDefault());
                Console.WriteLine($"Acyclic: Yes");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Acyclic: No"); 
            }
        }

        private static void DFS(char node)
        {
            ICollection<char> children = graph[node];

            if (visited.Contains(node))
            {
                throw new InvalidOperationException("Acyclic graph");
            }

            visited.Add(node);

            foreach (char child in children)
            {
                DFS(child);
            }
        }
    }
}
