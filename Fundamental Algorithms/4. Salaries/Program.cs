using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Salaries
{
    public static class Program
    {
        private static char[][] graph;
        private static int[] salary;

        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            graph = new char[size][];
            salary = new int[size];

            for (int nodeIndex = 0; nodeIndex < size; nodeIndex++)
            {
                char[] children = Console.ReadLine().ToCharArray();
                graph[nodeIndex] = children;
            }

            for (int node = 0; node < size; node++)
            {

                salary[node] = DFS(node);
            }

            Console.WriteLine(salary.Sum(x=>x));
        }

        private static int DFS(int node)
        {
            char[] children = graph[node];

            if (salary[node] != 0)
            {
                return salary[node];
            }

            bool isEndNode = true;
            int sum = 0;

            for (int childIndex = 0; childIndex < children.Length; childIndex++)
            {
                if (children[childIndex] == 'N')
                {
                    continue;
                }

                isEndNode = false;
                sum += DFS(childIndex);
            }

            return isEndNode ? 1 : sum;
        }
    }
}
