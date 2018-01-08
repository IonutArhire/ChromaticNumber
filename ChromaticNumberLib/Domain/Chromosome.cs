using System.Collections.Generic;

namespace ChromaticNumberLib.Domain
{
    public class Chromosome
    {
        public List<int> Genes { get; }

        public Chromosome()
        {
            Genes = new List<int>();
        }

        public void Add(int gene)
        {
            Genes.Add(gene);
        }
    }
}
