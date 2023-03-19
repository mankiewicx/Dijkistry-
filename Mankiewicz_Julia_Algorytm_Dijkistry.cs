using System;
using System.Collections.Generic;

namespace Dijkistry
{
    class Program
    {
        static int[,] graph = {
        {0, 4, 0, 0, 0, 0, 0, 8, 0},
        {4, 0, 8, 0, 0, 0, 0, 11, 0},
        {0, 8, 0, 7, 0, 4, 4, 0, 2},
        {0, 0, 7, 0, 9, 14, 0, 0, 0},
        {0, 0, 0, 9, 0, 10, 0, 0, 0},
        {0, 0, 4, 0, 10, 0, 2, 0, 0},
        {0, 0, 0, 14, 0, 2, 0, 1, 6},
        {8, 11, 0, 0, 0, 0, 1, 0, 7},
        {0, 0, 2, 0, 0, 6, 7, 0, 0}
    };
        static int[] dist = new int[graph.GetLength(0)];
        static bool[] visited = new bool[graph.GetLength(0)];

        static void Dijkstra(int source)
        {
            for (int i = 0; i < graph.GetLength(0); i++)
            {
                dist[i] = int.MaxValue;
                visited[i] = false;
            }

            dist[source] = 0;

            for (int i = 0; i < graph.GetLength(0) - 1; i++)
            {
                int min = int.MaxValue;
                int minIndex = -1;

                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    if (!visited[j] && dist[j] <= min)
                    {
                        min = dist[j];
                        minIndex = j;
                    }
                }

                visited[minIndex] = true;

                for (int j = 0; j < graph.GetLength(0); j++)
                {
                    if (!visited[j] && graph[minIndex, j] != 0 && dist[minIndex] != int.MaxValue && dist[minIndex] + graph[minIndex, j] < dist[j])
                    {
                        dist[j] = dist[minIndex] + graph[minIndex, j];
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Dijkstra(0);

            Console.WriteLine("Wartości najkrótszych odległości od wierzchołka 0:");
            for (int i = 0; i < dist.Length; i++)
            {
                Console.WriteLine(i + " - " + dist[i]);
            }
            Console.WriteLine("\nNaciśnij dowolny klawisz by zakonczyc.");
            Console.ReadKey();
        }
    }

}