using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gp
{
    class Chromosome
    {
        public int id { get; set; }
        public BinaryTree Tree { get; set; }
        public string ParsedData { get; set; }
        public bool isDead { get; set; }
        public double fitness { get; set; }
        public Chromosome(int id, string[] unknownVariables)
        {
            this.id = id;
            this.Tree = new BinaryTree(unknownVariables);
            this.fitness = Double.NaN;
            this.isDead = false;
            this.ParsedData = string.Empty;
        }
    }
}
