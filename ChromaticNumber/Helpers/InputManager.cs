using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace ChromaticNumber.Helpers
{
    public static class InputManager
    {
        private static int GetNumberOfNodes(string text)
        {
            var regex = new Regex(@"p\s+\w+\s+(\d+)");
            var match = regex.Match(text);

            return int.Parse(match.Groups[1].Value);
        }

        private static List<(int, int)> GetEdges(string text)
        {
            var results = new List<(int, int)>();
            var regex = new Regex(@"\be\s+(\d+)\s+(\d+)");
            foreach (Match match in regex.Matches(text))
            {
                var fst = int.Parse(match.Groups[1].Value);
                var snd = int.Parse(match.Groups[2].Value);
                results.Add((fst, snd));
            }
            return results;
        }

        public static bool[,] ConstructAdjacencyMatrix(string file)
        {
            var pathToFile = Path.Combine("Graphs", file);
            using (var streamReader = new StreamReader(pathToFile))
            {
                var text = streamReader.ReadToEnd();

                var numNodes = GetNumberOfNodes(text);
                var adjMatrix = new bool[numNodes + 1, numNodes + 1]; //+1 because the first node has the index 1

                foreach (var edge in GetEdges(text))
                {
                    adjMatrix[edge.Item1, edge.Item2] = true;
                }

                return adjMatrix;
            }
        }
    }
}
