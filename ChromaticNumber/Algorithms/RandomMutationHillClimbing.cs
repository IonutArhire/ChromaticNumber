using ChromaticNumberLib;
using ChromaticNumberLib.Domain;

namespace ChromaticNumber.Algorithms
{
    public class RandomMutationHillClimbing : BaseAlgorithm
    {
        public RandomMutationHillClimbing(int numberOfColors, int popSize, int numberOfGenerations, double pc)
            : base(numberOfColors, popSize, numberOfGenerations, pc)
        {
        }

        private Chromosome CopyChromosome(Chromosome toCopy)
        {
            var result = new Chromosome();

            for (int i = 0; i < toCopy.Genes.Count; i++)
            {
                result.Add(toCopy.Genes[i]);
            }

            return result;
        }

        public override int Run(bool[,] adjMatrix)
        {
            var bestChromosome = GenerateRandomChromosome(adjMatrix.GetLength(0));
            var bestFitness = GetFitness(bestChromosome, adjMatrix);

            while (NumberOfGenerations != 0 && bestFitness != 0)
            {
                var candidate = CopyChromosome(bestChromosome);

                var randomGeneIndex = RandomGenerator.Next(candidate.Genes.Count);
                MutateGene(candidate, randomGeneIndex, adjMatrix);

                var candidateFitness = GetFitness(candidate, adjMatrix);

                if (bestFitness > candidateFitness)
                {
                    bestChromosome = CopyChromosome(candidate);
                    bestFitness = candidateFitness;
                }
                NumberOfGenerations--;
            }

            return bestFitness;
        }
    }
}
