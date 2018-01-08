using System.Collections.Generic;
using System.Linq;
using ChromaticNumberLib.Domain;

namespace ChromaticNumberLib
{
    public abstract partial class BaseAlgorithm
    {
        protected void MutateGene(Chromosome chromosome, int geneIndex, bool[,] adjMatrix)
        {
            var adjacentColors = new HashSet<int>();
            for (var i = 1; i < adjMatrix.GetLength(0); i++)
            {
                if (adjMatrix[geneIndex, i])
                {
                    adjacentColors.Add(chromosome.Genes[i]);
                }
            }

            var allColors = new HashSet<int>();
            for (var i = 0; i < NumberOfColors; i++)
            {
                allColors.Add(i);
            }

            adjacentColors.SymmetricExceptWith(allColors);

            var validColors = adjacentColors.Count != 0 ? adjacentColors : allColors;

            var validColorsArray = validColors.ToArray();

            var randomColor = RandomGenerator.Next(validColorsArray.Count());

            chromosome.Genes[geneIndex] = validColorsArray[randomColor];
        }

        protected void Mutation(List<Chromosome> chromosomes, bool[,] adjMatrix)
        {
            for (var i = 1; i < chromosomes.Count; i++)
            {
                for (var j = 1; j < chromosomes[i].Genes.Count; j++)
                {
                    for (var k = 1; k < adjMatrix.GetLength(0); k++)
                    {
                        if (adjMatrix[j, k])
                        {
                            if (chromosomes[i].Genes[j] == chromosomes[i].Genes[k])
                            {
                                MutateGene(chromosomes[i], j, adjMatrix);
                                break;
                            }
                        }

                    }
                }
            }
        }
    }
}
