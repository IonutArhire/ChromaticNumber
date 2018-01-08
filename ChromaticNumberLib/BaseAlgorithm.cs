using System;

namespace ChromaticNumberLib
{
    public abstract partial class BaseAlgorithm
    {
        protected readonly Random RandomGenerator;
        protected int NumberOfColors;
        protected int PopSize;
        protected int NumberOfGenerations;
        protected double Pc;

        protected BaseAlgorithm(int numberOfColors, int popSize, int numberOfGenerations, double pc)
        {
            RandomGenerator = new Random();

            NumberOfColors = numberOfColors;
            PopSize = popSize;
            NumberOfGenerations = numberOfGenerations;
            Pc = pc;
        }

        public abstract int Run(bool[,] adjMatrix);
    }
}
