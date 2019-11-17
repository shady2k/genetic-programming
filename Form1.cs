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
            Population population = new Population(-5.12, 5.12, 100, 0.9, 0.1, 4, fitnessFunction, solutionFunction);

            population.Cross(this);

            if(g1.Count > 0) DrawChart(gViewer1, g1);
            if (g2.Count > 0) DrawChart(gViewer2, g2);
            if (g3.Count > 0) DrawChart(gViewer3, g3);
            if (g4.Count > 0) DrawChart(gViewer4, g4);




            //Expression<Func<double, double>> f = (x) => 1*x + 2 + 3*x;
            //var func = f.Compile(); // this is a Func<double,double,double>

            /*object result = CSharpScript.EvaluateAsync("1 + 2");

            NExpression ex = new NExpression("3*x + Sin(x+4)");
            ex.Parameters["x"] = 0;
            ex.Evaluate();
            var test = ex.ParsedExpression;
            NCalc.Domain.BinaryExpression operation = (NCalc.Domain.BinaryExpression)test;
            Console.WriteLine(operation.LeftExpression.ToString());*/



            /*Expression<Func<double, double, double>> f = (x, y) => Math.Sin(x / y) + (5 * 4*x);
            var func = f.Compile(); // this is a Func<double,double,double>
            Console.WriteLine(func(12, 5));
            Console.WriteLine(func(23, 4));

            //ParameterExpression param = (ParameterExpression)f.Parameters[0];
            BinaryExpression operation = (BinaryExpression)f.Body;
            var left = operation.Left;
            var right = operation.Right;

            var munged = SwapExpressionVisitor.Swap(
                f, // the lambda to rewrite
                f.Parameters[0], // "x"
                Expression.Call(typeof(Math), "Log", null, f.Parameters[0]) // ln(x)
            ); // (x, y) => (Sin((Log(x) / y)) + 5)

            func = munged.Compile();
            Console.WriteLine(func(12, 5));
            Console.WriteLine(func(23, 4));*/
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
