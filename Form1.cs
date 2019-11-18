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
            NExpression fitnessFunction = new NExpression("Abs(y-d)");
            NExpression solutionFunction = new NExpression("Pow(x, 2)");
            Population population = new Population(-5.12, 5.12, 100, 10, 0.9, 0.1, 4, fitnessFunction, solutionFunction);

            for (var i = 0; i <= 10; i++)
            {
                population.Cross();
                population.Mutation();
                population.Selection();
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

    class SwapExpressionVisitor : ExpressionVisitor
    {
        public static Expression<T> Swap<T>(Expression<T> lambda,
            Expression from, Expression to)
        {
            return Expression.Lambda<T>(
                Swap(lambda.Body, from, to), lambda.Parameters);
        }
        public static Expression Swap(
            Expression body, Expression from, Expression to)
        {
            return new SwapExpressionVisitor(from, to).Visit(body);
        }
        private readonly Expression from, to;
        public SwapExpressionVisitor(Expression from, Expression to)
        {
            this.from = from;
            this.to = to;
        }
        public override Expression Visit(Expression node)
        {
            return node == from ? to : base.Visit(node);
        }
    }
}
