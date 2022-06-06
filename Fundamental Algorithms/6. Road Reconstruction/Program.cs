using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Road_Reconstruction
{
    public static class Program
    {
        private static IDictionary<string, ICollection<string>> graph = new Dictionary<string, ICollection<string>>();
        private static HashSet<string> visited;
        private static ICollection<Edge> edges = new List<Edge>();
        private static ICollection<string> importantStreets = new List<string>();

        public static void Main()
        {
            int buildingsCount = int.Parse(Console.ReadLine());
            int streetsCount = int.Parse(Console.ReadLine());

            ReadData(streetsCount);

            edges = edges.OrderBy(node => node.StartNode)
                         .ThenBy(node => node.DestinationNode)
                         .ToList();

            foreach (Edge edge in edges)
            {
                visited = new HashSet<string>();
                graph[edge.StartNode].Remove(edge.DestinationNode);

                if (importantStreets.Contains(new Edge(edge.DestinationNode, edge.StartNode).ToString()))
                {
                    continue;
                }

                //DFS(edge.StartNode, edge.DestinationNode);
                BFS(edge.StartNode, edge.DestinationNode);

                if (!visited.Contains(edge.DestinationNode))
                {
                    importantStreets.Add(edge.ToString());
                }

                graph[edge.StartNode].Add(edge.DestinationNode);
            }

            PrintOutput();
        }

        private static void PrintOutput()
        {
            Console.WriteLine("Important streets:");
            foreach (string edge in importantStreets)
            {
                Console.WriteLine(edge);
            }
        }

        private static void ReadData(int streetsCount)
        {
            for (int nodeIndex = 0; nodeIndex < streetsCount; nodeIndex++)
            {
                string[] nodeData = Console.ReadLine().Split(" - ");
                string firstBuilding = nodeData[0];
                string secondBuilding = nodeData[1];

                if (!graph.ContainsKey(firstBuilding))
                {
                    graph.Add(firstBuilding, new List<string>());
                }

                if (!graph.ContainsKey(secondBuilding))
                {
                    graph.Add(secondBuilding, new List<string>());
                }

                graph[firstBuilding].Add(secondBuilding);
                graph[secondBuilding].Add(firstBuilding);
                edges.Add(new Edge(firstBuilding, secondBuilding));
            }
        }

        private static void DFS(string startNode, string destinationNode)
        {
            visited.Add(startNode);

            if (startNode == destinationNode)
            {
                return;
            }

            ICollection<string> children = graph[startNode];

            foreach (string child in children)
            {
                if (visited.Contains(child))
                {
                    continue;
                }

                DFS(child, destinationNode);
            }
        }

        private static void BFS(string startNode, string destinationNode)
        {
            var queue = new Queue<string>();

            queue.Enqueue(startNode);

            while (queue.Any())
            {
                string currentNode = queue.Dequeue();
                visited.Add(currentNode);

                if (currentNode == destinationNode)
                {
                    return;
                }

                foreach (string child in graph[currentNode])
                {
                    if (visited.Contains(child))
                    {
                        continue;
                    }

                    queue.Enqueue(child);
                }
            }
        }
    }
}