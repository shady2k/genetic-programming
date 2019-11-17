using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NExpression = NCalc.Expression;

namespace gp
{
    class Population
    {
        private List<Chromosome> chromosomes;

        public double minValue { get; private set; }
        public double maxValue { get; private set; }
        public int maxPopulationSize { get; private set; }
        public double crossPossibility { get; private set; }
        public double mutationPossibility { get; private set; }
        public int roundVal { get; private set; } = 3;
        private NCalc.Expression fitnessFunction;
        private NCalc.Expression solutionFunction;
        public string txtFunction { get; private set; }
        public int initPopulationSize { get; private set; }
        public int generation { get; private set; } = 1;
        private int lastChromosomeID = 0;
        public Population(double minValue, double maxValue, int maxPopulationSize, double crossPossibility, double mutationPossibility,
                          int initPopulationSize, NCalc.Expression fitnessFunction, NCalc.Expression solutionFunction)
        {
            chromosomes = new List<Chromosome>();
            this.minValue = minValue;
            this.maxValue = maxValue;
            this.crossPossibility = crossPossibility;
            this.mutationPossibility = mutationPossibility;
            this.fitnessFunction = fitnessFunction;
            this.solutionFunction = solutionFunction;
            this.initPopulationSize = initPopulationSize;
            this.maxPopulationSize = maxPopulationSize;
            this.generation = 1;
            Init(initPopulationSize);
        }
        public List<Chromosome> GetChromosomes()
        {
            return chromosomes;
        }
        public int GenerateNewChromosomeID()
        {
            lastChromosomeID++;
            return lastChromosomeID;
        }
        private Chromosome CopyChromosome(Chromosome source)
        {
            Chromosome target = new Chromosome(GenerateNewChromosomeID());
            target.Tree.CopyNode(source, target);
            return target;
        }
        public void AddChromosome(Chromosome chromosome)
        {
            chromosome.ParsedData = chromosome.Tree.ParseData();
            chromosome.fitness = CalcFitness(chromosome);

            bool isChromosomeExists = chromosomes.Any(item => item.ParsedData == chromosome.ParsedData);
            if (!isChromosomeExists)
            {
                chromosomes.Add(chromosome);
            }
        }
        /*public void Add(double val)
        {
            double roundedVal = Math.Round(val, roundVal);
            double fitnessValue = fitnessFunction(txtFunction, val);
            if (!Double.IsNaN(fitnessValue))
            {
                Chromosome nc = new Chromosome(roundedVal, fitnessValue);

                bool alreadyExists = population.Any(x => x.value.Equals(roundedVal));
                if (!alreadyExists)
                {
                    population.Add(new Chromosome(roundedVal, fitnessValue));
                }
            }
        }*/
        public void Init(int populationSize)
        {
            if (populationSize < 2)
            {
                throw new Exception("Too small population!");
            }

            for (int i = 0; i < populationSize; i++)
            {
                AddChromosome(GenerateRandomChromosome());
                //double randomNumber = Util.NextDouble(minValue, maxValue);
                //Add(randomNumber);
            }
        }
        public double CalcFitness(Chromosome chromosome)
        {
            double x = Math.Round(StaticRandom.NextDouble(minValue, maxValue), 3);

            NExpression mf = new NExpression(chromosome.ParsedData);
            mf.Parameters["x"] = x;
            double mfr = Convert.ToDouble(mf.Evaluate());

            solutionFunction.Parameters["x"] = x;
            double sfr = Convert.ToDouble(solutionFunction.Evaluate());

            double ffr = Double.NaN;
            if (Double.IsInfinity(mfr))
            {
                ffr = Double.MaxValue;
            }
            else
            {
                fitnessFunction.Parameters["y"] = mfr;
                fitnessFunction.Parameters["d"] = sfr;
                ffr = Convert.ToDouble(fitnessFunction.Evaluate());
            }

            return ffr;
        }
        public Chromosome GenerateRandomChromosome()
        {
            Chromosome chromosome = new Chromosome(GenerateNewChromosomeID());
            chromosome.Tree.GenerateRandomTree(chromosome, 10);
            /*chromosome.ParsedData = chromosome.Tree.ParseData();
            chromosome.fitness = CalcFitness(chromosome);*/
            return chromosome;
        }
        public void Cross(Form1 t)
        {
            var chromosomesSnapshot = chromosomes.ToList();
            foreach (var chromosome in chromosomesSnapshot)
            {
                if (StaticRandom.NextDouble() <= crossPossibility)
                {
                    int rn = StaticRandom.Next(chromosomesSnapshot.Count - 1);
                    Cross(chromosome, chromosomesSnapshot[rn], t);
                }
            }
        }
        private void Cross(Chromosome x, Chromosome y, Form1 t)
        {
            Console.WriteLine("x: " + x.ParsedData);
            Console.WriteLine("y: " + y.ParsedData);

            Chromosome yx = CopyChromosome(x);
            Chromosome xy = CopyChromosome(y);
            
            Node rnx = x.Tree.GetRandomNode();
            Node rny = y.Tree.GetRandomNode();

            Node rnxy = xy.Tree.FindNode(rny.id);
            xy.Tree.ReplaceNode(rnx, rnxy);
            xy.Tree.ParseData();

            Node rnyx = yx.Tree.FindNode(rnx.id);
            yx.Tree.ReplaceNode(rny, rnyx);
            yx.Tree.ParseData();

            Console.WriteLine("-----");
            Console.WriteLine("x: " + x.Tree.ParseData());
            Console.WriteLine("y: " + y.Tree.ParseData());
            Console.WriteLine("new x: " + yx.Tree.ParseData());
            Console.WriteLine("new y: " + xy.Tree.ParseData());
            Console.WriteLine("===============================");

            t.g1 = x.Tree.GetEdges();
            t.g2 = y.Tree.GetEdges();
            t.g3 = xy.Tree.GetEdges();
            t.g4 = yx.Tree.GetEdges();

            AddChromosome(xy);
            AddChromosome(yx);
        }




        /*public List<Chromosome> GetBestСhromosome()
        {
            return (GetBestСhromosome(1));
        }
        public List<Chromosome> GetBestСhromosome(int cnt)
        {
            List<Chromosome> sorted = new List<Chromosome>();
            if (isMaxExtremum)
            {
                sorted = population.Where(x => x.isDead == false).OrderByDescending(o => o.fitness).Take(cnt).ToList();
            }
            else
            {
                sorted = population.Where(x => x.isDead == false).OrderBy(o => o.fitness).Take(cnt).ToList();
            }
            return sorted;
        }
        public List<Chromosome> GetRandomСhromosome()
        {
            return (GetRandomСhromosome(1));
        }
        public List<Chromosome> GetRandomСhromosome(int cnt)
        {
            List<Chromosome> rnd = new List<Chromosome>();
            List<Chromosome> sorted = population.Where(x => x.isDead == false).ToList();

            for (int i = 0; i < cnt; i++)
            {
                int rn = Util.Next(sorted.Count - 1);
                rnd.Add(sorted[rn]);
            }
            return rnd;
        }
        public void Cross()
        {
            var populationSnapshot = population.ToList();
            foreach (var chromosome in populationSnapshot)
            {
                if (Util.NextDouble() <= crossPossibility)
                {
                    int rn = Util.Next(populationSnapshot.Count - 1);
                    Cross(chromosome, populationSnapshot[rn]);
                }
            }
        }
        private void Cross(Chromosome x, Chromosome y)
        {
            double xy = Cross(x.value, y.value);
            Add(xy);
        }
        public void TestChromosomes()
        {
            foreach (Chromosome Сhromosome in population)
            {
                if (Сhromosome.value < minValue || Сhromosome.value > maxValue)
                {
                    Сhromosome.isDead = true;
                }
            }
        }
        public void Selection()
        {
            List<Chromosome> sorted = new List<Chromosome>();
            if (isMaxExtremum)
            {
                sorted = population.OrderBy(o => o.isDead).ThenByDescending(o => o.fitness).Take(maxPopulationSize).ToList();
            }
            else
            {
                sorted = population.OrderBy(o => o.isDead).ThenBy(o => o.fitness).Take(maxPopulationSize).ToList();
            }
            population = sorted;
            generation++;
        }
        static protected Int64 BitCross(Int64 x, Int64 y)
        {
            int Count = Util.Next(62) + 1;
            Int64 mask = ~0;

            mask = mask << (64 - Count);

            return (x & mask) | (y & ~mask);
        }
        static protected Int64 Cross(Int64 x, Int64 y)
        {
            Int64 res = BitCross(x, y);
            if (Util.Next() % 2 == 0)
            {
                if (x * res < 0)
                {
                    res = -res;
                }
            }
            else
            {
                if (y * res < 0)
                {
                    res = -res;
                }
            }

            return res;
        }
        static protected double Cross(double x, double y)
        {
            Int64 ix = BitConverter.DoubleToInt64Bits(x);
            Int64 iy = BitConverter.DoubleToInt64Bits(y);

            double res = BitConverter.Int64BitsToDouble(BitCross(ix, iy));

            if (Util.Next() % 2 == 0)
            {
                if (x * res < 0)
                {
                    res = -res;
                }
            }
            else
            {
                if (y * res < 0)
                {
                    res = -res;
                }
            }

            return res;
        }
        public void Mutation()
        {
            var populationSnapshot = population.ToList();
            foreach (var chromosome in populationSnapshot)
            {
                if (Util.NextDouble() <= mutationPossibility)
                {
                    int rn = Util.Next(populationSnapshot.Count - 1);
                    Mutation(populationSnapshot[rn]);
                }
            }
        }
        private void Mutation(Сhromosome x)
        {
            double z = Mutation(x.value);
            Add(z);
        }
        static protected double Mutation(double val)
        {
            UInt64 x = BitConverter.ToUInt64(BitConverter.GetBytes(val), 0);

            UInt64 mask = 1;
            mask <<= Util.Next(63);
            x ^= mask;

            double res = BitConverter.ToDouble(BitConverter.GetBytes(x), 0);

            return res;
        }
        static protected Int64 Mutation(Int64 val)
        {
            Int64 mask = 1;
            mask <<= Util.Next(63);

            return val ^ mask;
        }*/
    }
}

