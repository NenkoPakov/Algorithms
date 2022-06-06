using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Break_Cycles
{
    public static class Program
    {
        private static IDictionary<string, ICollection<string>> graph = new Dictionary<string, ICollection<string>>();
        private static HashSet<string> visited;
        private static ICollection<Edge> edges = new List<Edge>();
        private static ICollection<string> removed = new List<string>();

        public static void Main()
        {
            int nodesCount = int.Parse(Console.ReadLine());

            ReadData(nodesCount);

            edges = edges.OrderBy(node => node.StartNode)
                         .ThenBy(node => node.DestinationNode)
                         .ToList();

            foreach (Edge edge in edges)
            {
                visited = new HashSet<string>();
                graph[edge.StartNode].Remove(edge.DestinationNode);

                if (removed.Contains(new Edge(edge.DestinationNode, edge.StartNode).ToString()))
                {
                    continue;
                }

                DFS(edge.StartNode, edge.DestinationNode);

                if (visited.Contains(edge.DestinationNode))
                {
                    removed.Add(edge.ToString());
                    graph[edge.DestinationNode].Remove(edge.StartNode);
                }
                else
                {
                    graph[edge.StartNode].Add(edge.DestinationNode);
                }
            }

            PrintOutput();
        }

        private static void PrintOutput()
        {
            Console.WriteLine($"Edges to remove: {removed.Count}");
            foreach (string edge in removed)
            {
                Console.WriteLine(edge);
            }
        }

        private static void ReadData(int nodesCount)
        {
            for (int nodeIndex = 0; nodeIndex < nodesCount; nodeIndex++)
            {
                string[] nodeData = Console.ReadLine().Split(" -> ");
                string node = nodeData[0];
                IEnumerable<string> children = nodeData[1].Split(' ');

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                foreach (string child in children)
                {
                    edges.Add(new Edge(node, child));
                }

                graph[node] = graph[node].Concat(children).ToList();
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
    }
}
