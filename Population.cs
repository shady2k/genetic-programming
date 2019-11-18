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
        public int maxTreeDepth { get; private set; }
        public double crossPossibility { get; private set; }
        public double mutationPossibility { get; private set; }
        public int roundVal { get; private set; } = 3;
        private NCalc.Expression fitnessFunction;
        private NCalc.Expression solutionFunction;
        public string txtFunction { get; private set; }
        public int initPopulationSize { get; private set; }
        public int generation { get; private set; } = 1;
        private int lastChromosomeID = 0;
        public Population(double minValue, double maxValue, int maxPopulationSize, int maxTreeDepth, double crossPossibility, double mutationPossibility,
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
            this.maxTreeDepth = maxTreeDepth;
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
            target.Tree.ChangeLastNodeID(source.Tree.GetLastNodeID());
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
            double ffr = Double.NaN;

            try
            {
                double x = Math.Round(StaticRandom.NextDouble(minValue, maxValue), 3);

                NExpression mf = new NExpression(chromosome.ParsedData);
                mf.Parameters["x"] = x;
                double mfr = Convert.ToDouble(mf.Evaluate());

                solutionFunction.Parameters["x"] = x;
                double sfr = Convert.ToDouble(solutionFunction.Evaluate());

                if (Double.IsInfinity(mfr))
                {
                    ffr = Double.MaxValue;
                    chromosome.isDead = true;
                }
                else
                {
                    fitnessFunction.Parameters["y"] = mfr;
                    fitnessFunction.Parameters["d"] = sfr;
                    ffr = Convert.ToDouble(fitnessFunction.Evaluate());
                }
            } catch(Exception ex)
            {
                chromosome.isDead = true;
            }

            return ffr;
        }
        public Chromosome GenerateRandomChromosome()
        {
            Chromosome chromosome = new Chromosome(GenerateNewChromosomeID());
            chromosome.Tree.GenerateRandomTree(chromosome, maxTreeDepth);
            chromosome.ParsedData = chromosome.Tree.ParseData();
            /*chromosome.fitness = CalcFitness(chromosome);*/
            return chromosome;
        }
        public void Cross()
        {
            var chromosomesSnapshot = chromosomes.ToList();
            foreach (var chromosome in chromosomesSnapshot)
            {
                if (StaticRandom.NextDouble() <= crossPossibility)
                {
                    int rn = StaticRandom.Next(chromosomesSnapshot.Count - 1);
                    Cross(chromosome, chromosomesSnapshot[rn]);
                }
            }
        }
        public void Cross(Chromosome x, Chromosome y)
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

            AddChromosome(xy);
            AddChromosome(yx);
        }
        public void Mutation()
        {
            var chromosomesSnapshot = chromosomes.ToList();
            foreach (var chromosome in chromosomesSnapshot)
            {
                if (StaticRandom.NextDouble() <= mutationPossibility)
                {
                    int rn = StaticRandom.Next(chromosomesSnapshot.Count - 1);
                    Mutation(chromosome);
                }
            }
        }
        public void Mutation(Chromosome x)
        {
            Console.WriteLine("x: " + x.ParsedData);

            Chromosome xx = CopyChromosome(x);
            Chromosome y = GenerateRandomChromosome();
            Node rnx = xx.Tree.GetRandomNode();

            Console.WriteLine("y: " + y.ParsedData);

            xx.Tree.ReplaceNode(y.Tree.Root, rnx);
            xx.Tree.ParseData();

            Console.WriteLine("-----");
            Console.WriteLine("x: " + x.Tree.ParseData());
            Console.WriteLine("y: " + y.Tree.ParseData());
            Console.WriteLine("new xx: " + xx.Tree.ParseData());
            Console.WriteLine("===============================");

            AddChromosome(xx);
        }
        public void TestChromosomes()
        {
            /*foreach (Chromosome chromosome in chromosomes)
            {
                if (chromosome.value < minValue || chromosome.value > maxValue)
                {
                    chromosome.isDead = true;
                }
            }*/
        }
        public void Selection()
        {
            TestChromosomes();
            List<Chromosome> sorted = new List<Chromosome>();
            sorted = chromosomes.OrderBy(o => o.isDead).ThenBy(o => o.fitness).Take(maxPopulationSize).ToList();
            chromosomes = sorted;
            generation++;
        }
    }
}

