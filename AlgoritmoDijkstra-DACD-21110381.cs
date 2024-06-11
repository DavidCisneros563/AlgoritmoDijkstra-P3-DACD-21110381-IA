using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Crear un grafo de ejemplo (representado como una matriz de adyacencia)
        int[,] graph = {
            { 0, 4, 2, 0, 0 },
            { 4, 0, 1, 5, 0 },
            { 2, 1, 0, 8, 10 },
            { 0, 5, 8, 0, 2 },
            { 0, 0, 10, 2, 0 }
        };

        int startVertex = 0; // Nodo de inicio (puedes cambiarlo según tu necesidad)

        Dijkstra(graph, startVertex);
    }

    static void Dijkstra(int[,] graph, int start)
    {
        int n = graph.GetLength(0);
        int[] distance = new int[n];
        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            distance[i] = int.MaxValue;
            visited[i] = false;
        }

        distance[start] = 0;

        for (int count = 0; count < n - 1; count++)
        {
            int u = GetMinDistanceVertex(distance, visited);
            visited[u] = true;

            Console.WriteLine($"Paso {count + 1}: Visitando nodo {u}");

            for (int v = 0; v < n; v++)
            {
                if (!visited[v] && graph[u, v] != 0 && distance[u] != int.MaxValue &&
                    distance[u] + graph[u, v] < distance[v])
                {
                    distance[v] = distance[u] + graph[u, v];
                }
            }
        }

        Console.WriteLine("\nDistancias mínimas desde el nodo de inicio:");
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Nodo {i}: {distance[i]}");
        }
    }

    static int GetMinDistanceVertex(int[] distance, bool[] visited)
    {
        int minDist = int.MaxValue;
        int minVertex = -1;

        for (int v = 0; v < distance.Length; v++)
        {
            if (!visited[v] && distance[v] < minDist)
            {
                minDist = distance[v];
                minVertex = v;
            }
        }

        return minVertex;
    }
}
