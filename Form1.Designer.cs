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
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation2 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation3 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation planeTransformation4 = new Microsoft.Msagl.Core.Geometry.Curves.PlaneTransformation();
            this.button1 = new System.Windows.Forms.Button();
            this.gViewer1 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.gViewer2 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.gViewer3 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.gViewer4 = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(58, 378);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // gViewer1
            // 
            this.gViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gViewer1.ArrowheadLength = 10D;
            this.gViewer1.AsyncLayout = false;
            this.gViewer1.AutoScroll = true;
            this.gViewer1.BackwardEnabled = false;
            this.gViewer1.BuildHitTree = true;
            this.gViewer1.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer1.EdgeInsertButtonVisible = true;
            this.gViewer1.FileName = "";
            this.gViewer1.ForwardEnabled = false;
            this.gViewer1.Graph = null;
            this.gViewer1.InsertingEdge = false;
            this.gViewer1.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer1.LayoutEditingEnabled = true;
            this.gViewer1.Location = new System.Drawing.Point(279, 10);
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
            this.gViewer1.Size = new System.Drawing.Size(336, 288);
            this.gViewer1.TabIndex = 1;
            this.gViewer1.TightOffsetForRouting = 0.125D;
            this.gViewer1.ToolBarIsVisible = true;
            this.gViewer1.Transform = planeTransformation1;
            this.gViewer1.UndoRedoButtonsVisible = true;
            this.gViewer1.WindowZoomButtonPressed = false;
            this.gViewer1.ZoomF = 1D;
            this.gViewer1.ZoomWindowThreshold = 0.05D;
            // 
            // gViewer2
            // 
            this.gViewer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gViewer2.ArrowheadLength = 10D;
            this.gViewer2.AsyncLayout = false;
            this.gViewer2.AutoScroll = true;
            this.gViewer2.BackwardEnabled = false;
            this.gViewer2.BuildHitTree = true;
            this.gViewer2.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer2.EdgeInsertButtonVisible = true;
            this.gViewer2.FileName = "";
            this.gViewer2.ForwardEnabled = false;
            this.gViewer2.Graph = null;
            this.gViewer2.InsertingEdge = false;
            this.gViewer2.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer2.LayoutEditingEnabled = true;
            this.gViewer2.Location = new System.Drawing.Point(660, 12);
            this.gViewer2.LooseOffsetForRouting = 0.25D;
            this.gViewer2.MouseHitDistance = 0.05D;
            this.gViewer2.Name = "gViewer2";
            this.gViewer2.NavigationVisible = true;
            this.gViewer2.NeedToCalculateLayout = true;
            this.gViewer2.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer2.PaddingForEdgeRouting = 8D;
            this.gViewer2.PanButtonPressed = false;
            this.gViewer2.SaveAsImageEnabled = true;
            this.gViewer2.SaveAsMsaglEnabled = true;
            this.gViewer2.SaveButtonVisible = true;
            this.gViewer2.SaveGraphButtonVisible = true;
            this.gViewer2.SaveInVectorFormatEnabled = true;
            this.gViewer2.Size = new System.Drawing.Size(336, 288);
            this.gViewer2.TabIndex = 2;
            this.gViewer2.TightOffsetForRouting = 0.125D;
            this.gViewer2.ToolBarIsVisible = true;
            this.gViewer2.Transform = planeTransformation2;
            this.gViewer2.UndoRedoButtonsVisible = true;
            this.gViewer2.WindowZoomButtonPressed = false;
            this.gViewer2.ZoomF = 1D;
            this.gViewer2.ZoomWindowThreshold = 0.05D;
            // 
            // gViewer3
            // 
            this.gViewer3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gViewer3.ArrowheadLength = 10D;
            this.gViewer3.AsyncLayout = false;
            this.gViewer3.AutoScroll = true;
            this.gViewer3.BackwardEnabled = false;
            this.gViewer3.BuildHitTree = true;
            this.gViewer3.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer3.EdgeInsertButtonVisible = true;
            this.gViewer3.FileName = "";
            this.gViewer3.ForwardEnabled = false;
            this.gViewer3.Graph = null;
            this.gViewer3.InsertingEdge = false;
            this.gViewer3.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer3.LayoutEditingEnabled = true;
            this.gViewer3.Location = new System.Drawing.Point(279, 298);
            this.gViewer3.LooseOffsetForRouting = 0.25D;
            this.gViewer3.MouseHitDistance = 0.05D;
            this.gViewer3.Name = "gViewer3";
            this.gViewer3.NavigationVisible = true;
            this.gViewer3.NeedToCalculateLayout = true;
            this.gViewer3.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer3.PaddingForEdgeRouting = 8D;
            this.gViewer3.PanButtonPressed = false;
            this.gViewer3.SaveAsImageEnabled = true;
            this.gViewer3.SaveAsMsaglEnabled = true;
            this.gViewer3.SaveButtonVisible = true;
            this.gViewer3.SaveGraphButtonVisible = true;
            this.gViewer3.SaveInVectorFormatEnabled = true;
            this.gViewer3.Size = new System.Drawing.Size(336, 288);
            this.gViewer3.TabIndex = 3;
            this.gViewer3.TightOffsetForRouting = 0.125D;
            this.gViewer3.ToolBarIsVisible = true;
            this.gViewer3.Transform = planeTransformation3;
            this.gViewer3.UndoRedoButtonsVisible = true;
            this.gViewer3.WindowZoomButtonPressed = false;
            this.gViewer3.ZoomF = 1D;
            this.gViewer3.ZoomWindowThreshold = 0.05D;
            // 
            // gViewer4
            // 
            this.gViewer4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gViewer4.ArrowheadLength = 10D;
            this.gViewer4.AsyncLayout = false;
            this.gViewer4.AutoScroll = true;
            this.gViewer4.BackwardEnabled = false;
            this.gViewer4.BuildHitTree = true;
            this.gViewer4.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;
            this.gViewer4.EdgeInsertButtonVisible = true;
            this.gViewer4.FileName = "";
            this.gViewer4.ForwardEnabled = false;
            this.gViewer4.Graph = null;
            this.gViewer4.InsertingEdge = false;
            this.gViewer4.LayoutAlgorithmSettingsButtonVisible = true;
            this.gViewer4.LayoutEditingEnabled = true;
            this.gViewer4.Location = new System.Drawing.Point(660, 298);
            this.gViewer4.LooseOffsetForRouting = 0.25D;
            this.gViewer4.MouseHitDistance = 0.05D;
            this.gViewer4.Name = "gViewer4";
            this.gViewer4.NavigationVisible = true;
            this.gViewer4.NeedToCalculateLayout = true;
            this.gViewer4.OffsetForRelaxingInRouting = 0.6D;
            this.gViewer4.PaddingForEdgeRouting = 8D;
            this.gViewer4.PanButtonPressed = false;
            this.gViewer4.SaveAsImageEnabled = true;
            this.gViewer4.SaveAsMsaglEnabled = true;
            this.gViewer4.SaveButtonVisible = true;
            this.gViewer4.SaveGraphButtonVisible = true;
            this.gViewer4.SaveInVectorFormatEnabled = true;
            this.gViewer4.Size = new System.Drawing.Size(336, 288);
            this.gViewer4.TabIndex = 4;
            this.gViewer4.TightOffsetForRouting = 0.125D;
            this.gViewer4.ToolBarIsVisible = true;
            this.gViewer4.Transform = planeTransformation4;
            this.gViewer4.UndoRedoButtonsVisible = true;
            this.gViewer4.WindowZoomButtonPressed = false;
            this.gViewer4.ZoomF = 1D;
            this.gViewer4.ZoomWindowThreshold = 0.05D;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 598);
            this.Controls.Add(this.gViewer4);
            this.Controls.Add(this.gViewer3);
            this.Controls.Add(this.gViewer2);
            this.Controls.Add(this.gViewer1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer1;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer2;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer3;
        private Microsoft.Msagl.GraphViewerGdi.GViewer gViewer4;
    }
}

