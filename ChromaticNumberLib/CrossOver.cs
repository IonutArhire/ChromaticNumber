using System.Collections.Generic;
using ChromaticNumberLib.Domain;

namespace ChromaticNumberLib
{
    public abstract partial class BaseAlgorithm
    {
        protected List<Chromosome> SelectForCrossOver(List<Chromosome> chromosomes)
        {
            var selectedChromosomes = new List<Chromosome>();

            for (var i = 0; i < chromosomes.Count; i++)
            {
                if (RandomGenerator.NextDouble() < Pc)
                {
                    selectedChromosomes.Add(chromosomes[i]);
                }
            }

            if (selectedChromosomes.Count % 2 != 0)
            {
                selectedChromosomes.RemoveAt(RandomGenerator.Next(selectedChromosomes.Count));
            }

            return selectedChromosomes;
        }

        protected void CrossOver(List<Chromosome> chromosomes)
        {
            var selectedChromosomes = SelectForCrossOver(chromosomes);
            
            while (selectedChromosomes.Count != 0)
            {
                var numSelectedChromosomes = selectedChromosomes.Count;

                var randomIndex1 = RandomGenerator.Next(numSelectedChromosomes);
                var randomIndex2 = RandomGenerator.Next(numSelectedChromosomes);

                while (randomIndex1 == randomIndex2)
                {
                    randomIndex2 = RandomGenerator.Next(numSelectedChromosomes);
                }

                var chromosome1 = selectedChromosomes[randomIndex1];
                var chromosome2 = selectedChromosomes[randomIndex2];

                var crosspoint = RandomGenerator.Next(chromosomes[0].Genes.Count - 2) + 2; //we need to use +2 instead of +1 because we need to avoid node 0.

                for (var geneIndex = crosspoint; geneIndex < chromosomes[0].Genes.Count; geneIndex++)
                {
                    var aux = chromosome1.Genes[geneIndex];
                    chromosome1.Genes[geneIndex] = chromosome2.Genes[geneIndex];
                    chromosome2.Genes[geneIndex] = aux;
                }

                selectedChromosomes.RemoveAt(randomIndex1);
                if (randomIndex2 > randomIndex1)
                {
                    randomIndex2--;
                }
                selectedChromosomes.RemoveAt(randomIndex2);
            }
        }
    }
}
