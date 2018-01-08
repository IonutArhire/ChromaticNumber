using ChromaticNumberLib;

namespace ChromaticNumber.Algorithms
{
    public class GeneticAlgorithm : BaseAlgorithm
    {
        public GeneticAlgorithm(int numberOfColors, int popSize, int numberOfGenerations, double pc) 
            : base(numberOfColors, popSize, numberOfGenerations, pc)
        {
        }

        public override int Run(bool[,] adjMatrix)
        {
            var numGenes = adjMatrix.GetLength(0);
            var chromosomes = GenerateRandomChromosomes(numGenes);
            var bestFitness = int.MaxValue;

            while (NumberOfGenerations != 0 && bestFitness != 0)
            {
                var fitnesses = GetFitnesses(chromosomes, adjMatrix);
                bestFitness = GetBestFitness(fitnesses, bestFitness);

                chromosomes = Selection(chromosomes, fitnesses);
                CrossOver(chromosomes);
                Mutation(chromosomes, adjMatrix);
                NumberOfGenerations--;
            }

            return bestFitness;
        }
    }
}
