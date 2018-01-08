using System.Collections.Generic;
using System.Linq;
using ChromaticNumberLib.Domain;

namespace ChromaticNumberLib
{
    public abstract partial class BaseAlgorithm
    {
        protected int GetFitness(Chromosome chromosome, bool[,] adjMatrix)
        {
            var fitness = 0;
            for (var i = 1; i < chromosome.Genes.Count; i++)
            {
                for (var j = 1; j < adjMatrix.GetLength(0); j++)
                {
                    if (adjMatrix[i, j])
                    {
                        if (chromosome.Genes[i] == chromosome.Genes[j])
                        {
                            fitness++;
                        }
                    }
                }
            }
            return fitness;
        }

        protected int GetBestFitness(List<int> fitnesses, int bestCurrentFitness)
        {
            var bestFitness = fitnesses.Min();
            if (bestFitness > bestCurrentFitness)
            {
                bestFitness = bestCurrentFitness;
            }
            return bestFitness;
        }

        protected List<int> GetFitnesses(List<Chromosome> chromosomes, bool[,] adjMatrix)
        {
            var fitnesses = new List<int>();

            foreach (var chromosome in chromosomes)
            {
                fitnesses.Add(GetFitness(chromosome, adjMatrix));
            }

            return fitnesses;
        }

        protected List<Chromosome> Selection(List<Chromosome> chromosomes, List<int> fitnesses)
        {
            var nextPopulation = new List<Chromosome>();

            for (var i = 0; i < PopSize; i++)
            {
                var randomIndex1 = RandomGenerator.Next(chromosomes.Count);
                var randomIndex2 = RandomGenerator.Next(chromosomes.Count);

                if (fitnesses[randomIndex1] < fitnesses[randomIndex2])
                {
                    nextPopulation.Add(chromosomes[randomIndex1]);
                }
                else
                {
                    nextPopulation.Add(chromosomes[randomIndex2]);
                }
            }

            return nextPopulation;
        }
    }
}
