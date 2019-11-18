using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NCalcExpression = NCalc.Expression;
using org.mariuszgromada.math.mxparser;
using MExpression = org.mariuszgromada.math.mxparser.Expression;
using NExpression = NCalc.Expression;
using Expression = System.Linq.Expressions.Expression;
using Microsoft.CodeAnalysis.CSharp.Scripting;

namespace gp
{
    public partial class Form1 : Form
    {
        public List<Adjacency> g1 = new List<Adjacency>();
        public List<Adjacency> g2 = new List<Adjacency>();
        public List<Adjacency> g3 = new List<Adjacency>();
        public List<Adjacency> g4 = new List<Adjacency>();
        private static readonly Random getRandom = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal maxGenerations = 1000;
            decimal maxEqualGenerations = 20;
            double lastValue = Double.NaN;
            int equalCount = 0;
            int lastValueGeneration = 0;

            NExpression fitnessFunction = new NExpression("Abs(y-d)");
            NExpression solutionFunction = new NExpression("3*Pow(x, 2)");
            Population population = new Population(-5.12, 5.12, 100, 10, 0.9, 0.1, 4, fitnessFunction, solutionFunction);

            for (var i = 0; i <= maxGenerations; i++)
            {
                population.Cross();
                population.Mutation();
                population.Selection();
                Chromosome chromosome = population.GetBestСhromosome();

                if (i == 0)
                {
                    lastValue = chromosome.fitness;
                }
                else
                {
                    if (lastValue.Equals(chromosome.fitness))
                    {
                        equalCount++;
                    }
                    else
                    {
                        equalCount = 0;
                        lastValueGeneration = population.generation;
                    }
                    lastValue = chromosome.fitness;
                }
                if (equalCount > maxEqualGenerations)
                {
                    Console.WriteLine("maxEqualGenerations break");
                    break;
                }
            }

            if (g1.Count > 0) DrawChart(gViewer1, g1);
            if (g2.Count > 0) DrawChart(gViewer2, g2);
            if (g3.Count > 0) DrawChart(gViewer3, g3);
            if (g4.Count > 0) DrawChart(gViewer4, g4);
        }

        private void DrawChart(Microsoft.Msagl.GraphViewerGdi.GViewer gViewer, Population population)
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            Chromosome chromosome = population.GetChromosomes()[0];
            List<Adjacency> res = chromosome.Tree.GetEdges();

            DrawChart(gViewer, res);
        }
        private void DrawChart(Microsoft.Msagl.GraphViewerGdi.GViewer gViewer, List<Adjacency> res)
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            foreach (var item in res)
            {
                var node = graph.AddNode(item.sourceId.ToString());
                node.LabelText = item.sourceData;
                var node2 = graph.AddNode(item.targetId.ToString());
                node2.LabelText = item.targetData;
                graph.AddEdge(item.sourceId.ToString(), item.targetId.ToString());
            }

            gViewer.Graph = graph;
        }
    }
}
