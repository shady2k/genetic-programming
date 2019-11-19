namespace gp
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation1 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.button1 = new System.Windows.Forms.Button();
            this.cbCheckWithFunctionValue = new System.Windows.Forms.CheckBox();
            this.nudCheckFunctionValue = new System.Windows.Forms.NumericUpDown();
            this.cbExtremum = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbFunction = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nudInitPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudMutationPossibility = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudCrossPossibility = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.nudMaxPopulationSize = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nudMaxValue = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudMinValue = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMaxEqualGenerations = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nudMaxGenerations = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.chartBestChromosome = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartFunction = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckFunctionValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInitPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMutationPossibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrossPossibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPopulationSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxEqualGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGenerations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartBestChromosome)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1213, 626);
            this.splitContainer1.SplitterDistance = 317;
            this.splitContainer1.TabIndex = 4;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.button1);
            this.splitContainer2.Panel1.Controls.Add(this.cbCheckWithFunctionValue);
            this.splitContainer2.Panel1.Controls.Add(this.nudCheckFunctionValue);
            this.splitContainer2.Panel1.Controls.Add(this.cbExtremum);
            this.splitContainer2.Panel1.Controls.Add(this.label10);
            this.splitContainer2.Panel1.Controls.Add(this.tbFunction);
            this.splitContainer2.Panel1.Controls.Add(this.label9);
            this.splitContainer2.Panel1.Controls.Add(this.nudInitPopulationSize);
            this.splitContainer2.Panel1.Controls.Add(this.label8);
            this.splitContainer2.Panel1.Controls.Add(this.nudMutationPossibility);
            this.splitContainer2.Panel1.Controls.Add(this.label7);
            this.splitContainer2.Panel1.Controls.Add(this.nudCrossPossibility);
            this.splitContainer2.Panel1.Controls.Add(this.label6);
            this.splitContainer2.Panel1.Controls.Add(this.nudMaxPopulationSize);
            this.splitContainer2.Panel1.Controls.Add(this.label5);
            this.splitContainer2.Panel1.Controls.Add(this.nudMaxValue);
            this.splitContainer2.Panel1.Controls.Add(this.label4);
            this.splitContainer2.Panel1.Controls.Add(this.nudMinValue);
            this.splitContainer2.Panel1.Controls.Add(this.label3);
            this.splitContainer2.Panel1.Controls.Add(this.nudMaxEqualGenerations);
            this.splitContainer2.Panel1.Controls.Add(this.label2);
            this.splitContainer2.Panel1.Controls.Add(this.nudMaxGenerations);
            this.splitContainer2.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtLog);
            this.splitContainer2.Size = new System.Drawing.Size(317, 626);
            this.splitContainer2.SplitterDistance = 494;
            this.splitContainer2.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 464);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 70;
            this.button1.Text = "Старт";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbCheckWithFunctionValue
            // 
            this.cbCheckWithFunctionValue.AutoSize = true;
            this.cbCheckWithFunctionValue.Location = new System.Drawing.Point(15, 415);
            this.cbCheckWithFunctionValue.Name = "cbCheckWithFunctionValue";
            this.cbCheckWithFunctionValue.Size = new System.Drawing.Size(212, 17);
            this.cbCheckWithFunctionValue.TabIndex = 69;
            this.cbCheckWithFunctionValue.Text = "Сверять с известным значение ЦФ:";
            this.cbCheckWithFunctionValue.UseVisualStyleBackColor = true;
            // 
            // nudCheckFunctionValue
            // 
            this.nudCheckFunctionValue.DecimalPlaces = 3;
            this.nudCheckFunctionValue.Location = new System.Drawing.Point(15, 438);
            this.nudCheckFunctionValue.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudCheckFunctionValue.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudCheckFunctionValue.Name = "nudCheckFunctionValue";
            this.nudCheckFunctionValue.Size = new System.Drawing.Size(120, 20);
            this.nudCheckFunctionValue.TabIndex = 68;
            this.nudCheckFunctionValue.Value = new decimal(new int[] {
            6285,
            0,
            0,
            196608});
            // 
            // cbExtremum
            // 
            this.cbExtremum.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbExtremum.FormattingEnabled = true;
            this.cbExtremum.Items.AddRange(new object[] {
            "Максимум",
            "Минимум"});
            this.cbExtremum.Location = new System.Drawing.Point(15, 388);
            this.cbExtremum.Name = "cbExtremum";
            this.cbExtremum.Size = new System.Drawing.Size(144, 21);
            this.cbExtremum.TabIndex = 67;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 372);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 66;
            this.label10.Text = "Экстремум:";
            // 
            // tbFunction
            // 
            this.tbFunction.Location = new System.Drawing.Point(15, 349);
            this.tbFunction.Name = "tbFunction";
            this.tbFunction.Size = new System.Drawing.Size(287, 20);
            this.tbFunction.TabIndex = 65;
            this.tbFunction.Text = "Cos(x) / (1 + Exp(-x))";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 333);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 13);
            this.label9.TabIndex = 64;
            this.label9.Text = "Функция:";
            // 
            // nudInitPopulationSize
            // 
            this.nudInitPopulationSize.Location = new System.Drawing.Point(15, 232);
            this.nudInitPopulationSize.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudInitPopulationSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudInitPopulationSize.Name = "nudInitPopulationSize";
            this.nudInitPopulationSize.Size = new System.Drawing.Size(120, 20);
            this.nudInitPopulationSize.TabIndex = 63;
            this.nudInitPopulationSize.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 13);
            this.label8.TabIndex = 62;
            this.label8.Text = "Начальный размер популяции:";
            // 
            // nudMutationPossibility
            // 
            this.nudMutationPossibility.DecimalPlaces = 2;
            this.nudMutationPossibility.Location = new System.Drawing.Point(15, 310);
            this.nudMutationPossibility.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMutationPossibility.Name = "nudMutationPossibility";
            this.nudMutationPossibility.Size = new System.Drawing.Size(120, 20);
            this.nudMutationPossibility.TabIndex = 61;
            this.nudMutationPossibility.Value = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(120, 13);
            this.label7.TabIndex = 60;
            this.label7.Text = "Вероятность мутации:";
            // 
            // nudCrossPossibility
            // 
            this.nudCrossPossibility.DecimalPlaces = 2;
            this.nudCrossPossibility.Location = new System.Drawing.Point(15, 271);
            this.nudCrossPossibility.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCrossPossibility.Name = "nudCrossPossibility";
            this.nudCrossPossibility.Size = new System.Drawing.Size(120, 20);
            this.nudCrossPossibility.TabIndex = 59;
            this.nudCrossPossibility.Value = new decimal(new int[] {
            9,
            0,
            0,
            65536});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 255);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(147, 13);
            this.label6.TabIndex = 58;
            this.label6.Text = "Вероятность скрещивания:";
            // 
            // nudMaxPopulationSize
            // 
            this.nudMaxPopulationSize.Location = new System.Drawing.Point(15, 189);
            this.nudMaxPopulationSize.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMaxPopulationSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nudMaxPopulationSize.Name = "nudMaxPopulationSize";
            this.nudMaxPopulationSize.Size = new System.Drawing.Size(120, 20);
            this.nudMaxPopulationSize.TabIndex = 57;
            this.nudMaxPopulationSize.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 173);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 13);
            this.label5.TabIndex = 56;
            this.label5.Text = "Максимальный размер популяции:";
            // 
            // nudMaxValue
            // 
            this.nudMaxValue.DecimalPlaces = 2;
            this.nudMaxValue.Location = new System.Drawing.Point(15, 148);
            this.nudMaxValue.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudMaxValue.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudMaxValue.Name = "nudMaxValue";
            this.nudMaxValue.Size = new System.Drawing.Size(120, 20);
            this.nudMaxValue.TabIndex = 55;
            this.nudMaxValue.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(231, 13);
            this.label4.TabIndex = 54;
            this.label4.Text = "Интервал изменений хромосом, максимум:";
            // 
            // nudMinValue
            // 
            this.nudMinValue.DecimalPlaces = 2;
            this.nudMinValue.Location = new System.Drawing.Point(15, 109);
            this.nudMinValue.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudMinValue.Minimum = new decimal(new int[] {
            10000000,
            0,
            0,
            -2147483648});
            this.nudMinValue.Name = "nudMinValue";
            this.nudMinValue.Size = new System.Drawing.Size(120, 20);
            this.nudMinValue.TabIndex = 53;
            this.nudMinValue.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(225, 13);
            this.label3.TabIndex = 52;
            this.label3.Text = "Интервал изменений хромосом, минимум:";
            // 
            // nudMaxEqualGenerations
            // 
            this.nudMaxEqualGenerations.Location = new System.Drawing.Point(15, 64);
            this.nudMaxEqualGenerations.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.nudMaxEqualGenerations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxEqualGenerations.Name = "nudMaxEqualGenerations";
            this.nudMaxEqualGenerations.Size = new System.Drawing.Size(120, 20);
            this.nudMaxEqualGenerations.TabIndex = 51;
            this.nudMaxEqualGenerations.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(290, 13);
            this.label2.TabIndex = 50;
            this.label2.Text = "Макс. кол-во поколений при постоянном значении ЦФ:";
            // 
            // nudMaxGenerations
            // 
            this.nudMaxGenerations.Location = new System.Drawing.Point(15, 25);
            this.nudMaxGenerations.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.nudMaxGenerations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMaxGenerations.Name = "nudMaxGenerations";
            this.nudMaxGenerations.Size = new System.Drawing.Size(120, 20);
            this.nudMaxGenerations.TabIndex = 49;
            this.nudMaxGenerations.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(205, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Максимальное количество поколений:";
            // 
            // txtLog
            // 
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(317, 128);
            this.txtLog.TabIndex = 0;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.gViewer1);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.splitContainer4);
            this.splitContainer3.Size = new System.Drawing.Size(892, 626);
            this.splitContainer3.SplitterDistance = 400;
            this.splitContainer3.TabIndex = 0;
            // 
            // gViewer1
            // 
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(0, 0);
            this.gViewer1.LooseOffsetForRouting = 0.25D;
            this.gViewer1.MouseHitDistance = 0.05D;
            this.gViewer1.Name = "gViewer1";
            this.gViewer1.NavigationVisible = true;
            this.gViewer1.NeedToCalculateLayout = true;
            this.gViewer1.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer1.PaddingForEdgeRouting = 8D;
            this.gViewer1.PanButtonPressed = false;
            this.gViewer1.SaveAsImageEnabled = true;
            this.gViewer1.SaveAsMsaglEnabled = true;
            this.gViewer1.SaveButtonVisible = true;
            this.gViewer1.SaveGraphButtonVisible = true;
            this.gViewer1.SaveInVectorFormatEnabled = true;
            this.gViewer1.Size = new System.Drawing.Size(400, 626);
            this.gViewer1.TabIndex = 2;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = true;
            this.gViewer1.Transform = planeTransformation1;
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.chartBestChromosome);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.chartFunction);
            this.splitContainer4.Size = new System.Drawing.Size(488, 626);
            this.splitContainer4.SplitterDistance = 314;
            this.splitContainer4.TabIndex = 0;
            // 
            // chartBestChromosome
            // 
            chartArea1.Name = "ChartArea1";
            this.chartBestChromosome.ChartAreas.Add(chartArea1);
            this.chartBestChromosome.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartBestChromosome.Location = new System.Drawing.Point(0, 0);
            this.chartBestChromosome.Name = "chartBestChromosome";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Name = "Series1";
            this.chartBestChromosome.Series.Add(series1);
            this.chartBestChromosome.Size = new System.Drawing.Size(488, 314);
            this.chartBestChromosome.TabIndex = 3;
            // 
            // chartFunction
            // 
            chartArea2.Name = "ChartArea1";
            this.chartFunction.ChartAreas.Add(chartArea2);
            this.chartFunction.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartFunction.Location = new System.Drawing.Point(0, 0);
            this.chartFunction.Name = "chartFunction";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Name = "Series1";
            this.chartFunction.Series.Add(series2);
            this.chartFunction.Size = new System.Drawing.Size(488, 308);
            this.chartFunction.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1213, 626);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nudCheckFunctionValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudInitPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMutationPossibility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCrossPossibility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxPopulationSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxEqualGenerations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaxGenerations)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartBestChromosome)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartFunction)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartBestChromosome;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFunction;
        private System.Windows.Forms.CheckBox cbCheckWithFunctionValue;
        private System.Windows.Forms.NumericUpDown nudCheckFunctionValue;
        private System.Windows.Forms.ComboBox cbExtremum;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbFunction;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudInitPopulationSize;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudMutationPossibility;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudCrossPossibility;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown nudMaxPopulationSize;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudMaxValue;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudMinValue;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMaxEqualGenerations;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudMaxGenerations;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtLog;
    }
}

