using System;
using System.Diagnostics;
using ChromaticNumber.Algorithms;
using ChromaticNumber.Helpers;
using ChromaticNumberLib;

namespace ChromaticNumber
{
    class Program
    {
        static void PrintResults(string targetGraph, string typeOfAlg, int numberOfColors, int result, long msPassed)
        {
            Console.WriteLine();
            Console.WriteLine($"For {targetGraph} using {typeOfAlg}:");
            Console.WriteLine($"For {numberOfColors} number of colors we have {result} conflicts.");
            Console.WriteLine($"Execution time (ms): {msPassed}");
            Console.WriteLine("...........................");
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            var file                = args[0];
            var numberOfColors      = int.Parse(args[1]);
            var popSize             = int.Parse(args[2]);
            var pc                  = double.Parse(args[3], System.Globalization.CultureInfo.InvariantCulture);
            var numberOfGenerations = int.Parse(args[4]);

            var adjMatrix = InputManager.ConstructAdjacencyMatrix(file);

            var stopwatch = Stopwatch.StartNew();

            BaseAlgorithm currentAlg = new GeneticAlgorithm(numberOfColors, popSize, numberOfGenerations, pc);
            var currentResult = currentAlg.Run(adjMatrix);
            PrintResults(file, "Genetic Algorithm", numberOfColors, currentResult, stopwatch.ElapsedMilliseconds);

            stopwatch.Restart();

            currentAlg = new RandomMutationHillClimbing(numberOfColors, popSize, numberOfGenerations, pc);
            currentResult = currentAlg.Run(adjMatrix);
            PrintResults(file, "RMHC", numberOfColors, currentResult, stopwatch.ElapsedMilliseconds);

            stopwatch.Stop();
        }
    }
}
