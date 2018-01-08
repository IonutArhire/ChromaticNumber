using System.Collections.Generic;
using ChromaticNumberLib.Domain;

namespace ChromaticNumberLib
{
    public abstract partial class BaseAlgorithm
    {
        protected Chromosome GenerateRandomChromosome(int size)
        {
            var chromosome = new Chromosome();

            for (var i = 0; i < size; i++)
            {
                var gene = RandomGenerator.Next(NumberOfColors);
                chromosome.Add(gene);
            }

            return chromosome;
        }

        protected List<Chromosome> GenerateRandomChromosomes(int numGenes)
        {
            var chromosomes = new List<Chromosome>();

            for (var i = 0; i < PopSize; i++)
            {
                chromosomes.Add(GenerateRandomChromosome(numGenes));
            }

            return chromosomes;
        }
    }
}
