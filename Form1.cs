using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using NExpression = NCalc.Expression;
using System.Windows.Forms.DataVisualization.Charting;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace gp
{
    public partial class Form1 : Form
    {
        private Population syncPopulation;
        private int lastBestChromosomeID = -1;
        private static readonly Random getRandom = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        private void lockControls(bool isEnabled)
        {
            if (isEnabled)
            {
                foreach (Control item in splitContainer2.Panel1.Controls)
                {
                    item.Enabled = false;
                }
                txtLog.Text = "Выполняется...";
            }
            else
            {
                foreach (Control item in splitContainer2.Panel1.Controls)
                {
                    item.Enabled = true;
                }
            }
        }
        private void updateUI()
        {
            string log = string.Empty;
            Chromosome currentBestChromosome = syncPopulation.GetBestСhromosome();
            log = "Выполняется, поколение " + syncPopulation.generation.ToString() + "\r\n";
            double t = Math.Round(100 - syncPopulation.GetBestСhromosome().fitness, 2);
            if (t < 0) t = 0;
            log += String.Format("Точность: {0}%\r\n", t);
            log += string.Format("Лучшая хромосома:\r\n" + syncPopulation.GetBestСhromosome().ParsedData);
            if(txtLog.Text != log) txtLog.Text = log;
            if (currentBestChromosome.id != lastBestChromosomeID)
            {
                lastBestChromosomeID = currentBestChromosome.id;
                if (currentBestChromosome.Tree.argumentsList.Length == 1)
                {
                    DrawBestChromosomeChart(chartBestChromosome, syncPopulation);
                }
                DrawBestChromosomeDiagram(gViewer1, syncPopulation);
            }
        }
        private string Start(decimal maxGenerations, decimal maxEqualGenerations, Population population)
        {
            string log = String.Empty;
            double lastValue = 0;
            int lastValueGeneration = 0;
            int equalCount = 0;

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
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
                    if ((i % 2) == 0)
                    {
                        syncPopulation = population;
                        this.BeginInvoke(new MethodInvoker(updateUI));
                    }
                    if (equalCount > maxEqualGenerations)
                    {
                        Console.WriteLine("maxEqualGenerations break");
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                log += String.Format("Возникла ошибка:{0}\r\n", ex.Message);
                log += String.Format("Стек трейс:\r\n{0}\r\n", ex.StackTrace);
            }
            finally
            {
                stopwatch.Stop();
            }

            stopwatch.Stop();
            log += String.Format("Найденная функция: {0}\r\n", population.GetBestСhromosome().ParsedData);
            log += String.Format("Функция: {0}\r\n", population.solutionFunction.ParsedExpression);
            log += String.Format("Прошло поколений: {0}\r\n", population.generation);
            log += String.Format("Прошло времени: {0} секунд\r\n", (int)stopwatch.Elapsed.TotalSeconds);
            log += String.Format("Решение найдно на поколении: {0}\r\n", lastValueGeneration);
            double t = Math.Round(100 - population.GetBestСhromosome().fitness, 2);
            if (t < 0) t = 0;
            log += String.Format("Максимальное количество поколений: {0}\r\n", maxGenerations);
            log += String.Format("Интервал изменений хромосом: [{0}, {1}]\r\n", population.minValue, population.maxValue);
            log += String.Format("Макс. кол-во поколений при постоянном значении: {0}\r\n", maxEqualGenerations);
            log += String.Format("Максимальный размер популяции: {0}\r\n", population.maxPopulationSize);
            log += String.Format("Начальный размер популяции: {0}\r\n", population.initPopulationSize);
            log += String.Format("Вероятность скрещивания: {0}%\r\n", population.crossPossibility * 100);
            log += String.Format("Вероятность мутации: {0}%\r\n", population.mutationPossibility * 100);

            return log;
        }
        public static List<string> ValidatePattern(string pattern, string input)
        {
            Regex regex = new Regex(pattern);
            var matches = regex.Matches(input);

            List<string> results = new List<string>();
            foreach (Match match in matches)
            {
                var group = match.Groups[0];
                results.Add(group.Success ? group.Value : string.Empty);
            }
            return results;
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            string log = string.Empty;

            decimal maxGenerations = nudMaxGenerations.Value;
            decimal maxEqualGenerations = nudMaxEqualGenerations.Value;

            double minValue = decimal.ToDouble(nudMinValue.Value);
            double maxValue = decimal.ToDouble(nudMaxValue.Value);
            int maxPopulationSie = decimal.ToInt32(nudMaxPopulationSize.Value);
            double crossPossibility = decimal.ToDouble(nudCrossPossibility.Value);
            double mutationPossibility = decimal.ToDouble(nudMutationPossibility.Value);
            int initPopulationSie = decimal.ToInt32(nudInitPopulationSize.Value);
            int maxTreeDepth = decimal.ToInt32(nudMaxTreeDepth.Value);
            int checkPoints = decimal.ToInt32(nudCheckPoints.Value);

            lockControls(true);

            NExpression fitnessFunction = new NExpression(tbFitnessFunction.Text);
            NExpression solutionFunction = new NExpression(tbFunction.Text);
            List<string> uv = new List<string>();
            uv = ValidatePattern(@"(x[\d]+?)", tbFunction.Text);
            uv.Insert(0, "x");
            string[] unknownVariables = uv.ToArray();

            Population population = new Population(minValue, maxValue, maxPopulationSie, maxTreeDepth, 
                crossPossibility, mutationPossibility, initPopulationSie, fitnessFunction, solutionFunction, 
                unknownVariables, checkPoints);
            if (unknownVariables.Length == 1)
            {
                drawSolutionFunctionChart(chartFunction, population);
            }

            log = await Task.Run(() => Start(maxGenerations, maxEqualGenerations, population));
            updateUI();
            txtLog.Text = log;
            lockControls(false);
        }

        private void DrawBestChromosomeDiagram(Microsoft.Msagl.GraphViewerGdi.GViewer gViewer, Population population)
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            Chromosome chromosome = population.GetBestСhromosome();
            List<Adjacency> res = chromosome.Tree.GetEdges();

            DrawDiagram(gViewer, res);
        }
        private void DrawDiagram(Microsoft.Msagl.GraphViewerGdi.GViewer gViewer, List<Adjacency> res)
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            foreach (var item in res)
            {
                var node = graph.AddNode(item.sourceId.ToString());
                node.LabelText = item.sourceData;
                var node2 = graph.AddNode(item.targetId.ToString());
                node2.LabelText = item.targetData;
                graph.AddEdge(item.sourceId.ToString(), item.targetId.ToString());
                //graph.LayerConstraints.AddSameLayerNeighbors(node, node2);
            }

            gViewer.Graph = graph;
        }
        private void DrawBestChromosomeChart(Chart chart, Population population)
        {
            try
            {
                chart.Series.Clear();

                Series mySeriesOfPoint = new Series("Series1");
                mySeriesOfPoint.BorderWidth = 2;
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                mySeriesOfPoint.ChartArea = "ChartArea1";
                for (double x = population.minValue; x <= population.maxValue; x += 0.01)
                {
                    NExpression testFunction = new NExpression(population.GetBestСhromosome().ParsedData);
                    testFunction.Parameters["x"] = x;
                    double sfr = Convert.ToDouble(testFunction.Evaluate());
                    mySeriesOfPoint.Points.AddXY(x, sfr);
                }
                //Добавляем созданный набор точек в Chart
                chart.Series.Add(mySeriesOfPoint);
                chart.ChartAreas[0].RecalculateAxesScale();
            }
            catch
            {
                chart.Series.Clear();
                return;
            }
        }
        private void drawSolutionFunctionChart(Chart chart, Population population)
        {
            try
            {
                chart.Series.Clear();

                Series mySeriesOfPoint = new Series("Series1");
                mySeriesOfPoint.BorderWidth = 2;
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                mySeriesOfPoint.ChartArea = "ChartArea1";
                for (double x = population.minValue; x <= population.maxValue; x += 0.01)
                {
                    NExpression solutionFunction = population.solutionFunction;
                    solutionFunction.Parameters["x"] = x;
                    double sfr = Convert.ToDouble(solutionFunction.Evaluate());
                    mySeriesOfPoint.Points.AddXY(x, sfr);
                }
                //Добавляем созданный набор точек в Chart
                chart.Series.Add(mySeriesOfPoint);
                chart.ChartAreas[0].RecalculateAxesScale();
            }
            catch
            {
                chart.Series.Clear();
                return;
            }
        }
        private void drawChart(List<KeyValuePair<int, double>> plotData, Chart chart)
        {
            try
            {
                chart.Series.Clear();
                Series mySeriesOfPoint = new Series("Series1", plotData.Count());
                mySeriesOfPoint.ChartType = SeriesChartType.Line;
                mySeriesOfPoint.ChartArea = "ChartArea1";
                mySeriesOfPoint.BorderWidth = 3;

                ChartArea ca = chart.ChartAreas[0];
                ca.AxisX.IsLabelAutoFit = false;

                double? YAxisMin = null;
                double? YAxisMax = null;
                foreach (KeyValuePair<int, double> data in plotData)
                {
                    if (!YAxisMin.HasValue) YAxisMin = data.Value;
                    if (!YAxisMax.HasValue) YAxisMax = data.Value;

                    var point = mySeriesOfPoint.Points.AddXY(data.Key, data.Value);
                    if (data.Value < YAxisMin) YAxisMin = data.Value;
                    if (data.Value > YAxisMax) YAxisMax = data.Value;
                }
                chart.Series.Add(mySeriesOfPoint);

                if (!YAxisMin.HasValue) YAxisMin = 0;
                if (!YAxisMax.HasValue) YAxisMax = 0;
                if (YAxisMax.Value == YAxisMin.Value) YAxisMax += 1;
                ca.AxisY.Maximum = YAxisMax.Value;
                ca.AxisY.Minimum = YAxisMin.Value;
                ca.RecalculateAxesScale();
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("Возникла ошибка при построении графика ({0})", ex.Message), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

    }
}
