using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Distance_Between_Vertices
{
    public static class Program
    {
        private static IDictionary<int, ICollection<int>> graph;
        private static IDictionary<int, int> clues;

        public static void Main()
        {
            int verticesCount = int.Parse(Console.ReadLine());
            int pathsCount = int.Parse(Console.ReadLine());

            graph = new Dictionary<int, ICollection<int>>();
            int[,] paths = new int[pathsCount, 2];

            CreateGraph(verticesCount);
            ReadDestinationTasks(pathsCount, paths);

            for (int i = 0; i < paths.GetLength(0); i++)
            {
                int fromNode = paths[i, 0];
                int toNode = paths[i, 1];

                int distance = BFS(fromNode, toNode);
                Console.WriteLine($"{{{fromNode}, {toNode}}} -> {distance}");
            }
        }

        private static void ReadDestinationTasks(int pathsCount, int[,] paths)
        {
            for (int i = 0; i < pathsCount; i++)
            {
                int[] input = Console.ReadLine().Split('-').Select(x => int.Parse(x)).ToArray();
                int fromNode = input[0];
                int toNode = input[1];
                paths[i, 0] = fromNode;
                paths[i, 1] = toNode;
            }
        }

        private static void CreateGraph(int verticesCount)
        {
            for (int i = 0; i < verticesCount; i++)
            {
                string[] input = Console.ReadLine().Split(':', StringSplitOptions.RemoveEmptyEntries);
                int node = int.Parse(input[0]);
                ICollection<int> childer = input.Length == 2 ? input[1].Split(' ').Select(x => int.Parse(x)).ToArray() : new List<int>();

                graph.Add(node, childer);
            }
        }

        private static int BFS(int fromNode, int toNode)
        {
            Queue<int> nodes = new Queue<int>();
            nodes.Enqueue(fromNode);

            ICollection<int> visited = new HashSet<int>();
            clues = new Dictionary<int, int>();

            while (nodes.Any())
            {

                fromNode = nodes.Dequeue();
                visited.Add(fromNode);

                foreach (int child in graph[fromNode].Where(child=> !visited.Contains(child)))
                {
                    nodes.Enqueue(child);
                    clues.TryAdd(child, fromNode);

                    if (child == toNode)
                    {
                        return CalculateDistance(toNode);
                    }
                }
            }

            return -1;
        }

        private static int CalculateDistance(int toNode)
        {
            if (!clues.ContainsKey(toNode))
            {
                return 0;
            }

            return 1 + CalculateDistance(clues[toNode]);
        }
    }
}
