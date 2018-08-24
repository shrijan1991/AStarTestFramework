namespace AStarTestFramework
{
    partial class FrameworkGUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.LoadMaps = new System.Windows.Forms.Button();
            this.MapsPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pathText = new System.Windows.Forms.TextBox();
            this.MapLabel = new System.Windows.Forms.Label();
            this.MapListBox = new System.Windows.Forms.CheckedListBox();
            this.AlgorithmsListBox = new System.Windows.Forms.CheckedListBox();
            this.AlgorithmsPanel = new System.Windows.Forms.Panel();
            this.moveDirectionsLabel = new System.Windows.Forms.Label();
            this.heuristicLabel = new System.Windows.Forms.Label();
            this.moveDirectionsCombo = new System.Windows.Forms.ComboBox();
            this.heuristicsCombo = new System.Windows.Forms.ComboBox();
            this.ExperimentsNoPanel = new System.Windows.Forms.Panel();
            this.experimentsCountNumericUD = new System.Windows.Forms.NumericUpDown();
            this.experimentCountLabel = new System.Windows.Forms.Label();
            this.RunExperiments = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.startEndCheckBox = new System.Windows.Forms.CheckBox();
            this.MapsPanel.SuspendLayout();
            this.AlgorithmsPanel.SuspendLayout();
            this.ExperimentsNoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.experimentsCountNumericUD)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadMaps
            // 
            this.LoadMaps.Location = new System.Drawing.Point(626, 12);
            this.LoadMaps.Name = "LoadMaps";
            this.LoadMaps.Size = new System.Drawing.Size(110, 23);
            this.LoadMaps.TabIndex = 0;
            this.LoadMaps.Text = "Load Maps";
            this.LoadMaps.UseVisualStyleBackColor = true;
            this.LoadMaps.Click += new System.EventHandler(this.LoadMaps_Click);
            // 
            // MapsPanel
            // 
            this.MapsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapsPanel.Controls.Add(this.label1);
            this.MapsPanel.Controls.Add(this.pathText);
            this.MapsPanel.Controls.Add(this.LoadMaps);
            this.MapsPanel.Location = new System.Drawing.Point(13, 2);
            this.MapsPanel.Name = "MapsPanel";
            this.MapsPanel.Size = new System.Drawing.Size(775, 49);
            this.MapsPanel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Enter File Path:";
            // 
            // pathText
            // 
            this.pathText.Location = new System.Drawing.Point(107, 14);
            this.pathText.Name = "pathText";
            this.pathText.Size = new System.Drawing.Size(497, 20);
            this.pathText.TabIndex = 1;
            this.pathText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MapLabel
            // 
            this.MapLabel.AutoSize = true;
            this.MapLabel.Location = new System.Drawing.Point(324, 119);
            this.MapLabel.Name = "MapLabel";
            this.MapLabel.Size = new System.Drawing.Size(0, 13);
            this.MapLabel.TabIndex = 3;
            // 
            // MapListBox
            // 
            this.MapListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapListBox.FormattingEnabled = true;
            this.MapListBox.Location = new System.Drawing.Point(13, 57);
            this.MapListBox.Name = "MapListBox";
            this.MapListBox.Size = new System.Drawing.Size(775, 137);
            this.MapListBox.TabIndex = 4;
            // 
            // AlgorithmsListBox
            // 
            this.AlgorithmsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlgorithmsListBox.FormattingEnabled = true;
            this.AlgorithmsListBox.Location = new System.Drawing.Point(13, 216);
            this.AlgorithmsListBox.Name = "AlgorithmsListBox";
            this.AlgorithmsListBox.Size = new System.Drawing.Size(775, 92);
            this.AlgorithmsListBox.TabIndex = 5;
            this.AlgorithmsListBox.SelectedIndexChanged += new System.EventHandler(this.AlgorithmsListBox_SelectedIndexChanged);
            // 
            // AlgorithmsPanel
            // 
            this.AlgorithmsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlgorithmsPanel.Controls.Add(this.moveDirectionsLabel);
            this.AlgorithmsPanel.Controls.Add(this.heuristicLabel);
            this.AlgorithmsPanel.Controls.Add(this.moveDirectionsCombo);
            this.AlgorithmsPanel.Controls.Add(this.heuristicsCombo);
            this.AlgorithmsPanel.Location = new System.Drawing.Point(13, 330);
            this.AlgorithmsPanel.Name = "AlgorithmsPanel";
            this.AlgorithmsPanel.Size = new System.Drawing.Size(775, 99);
            this.AlgorithmsPanel.TabIndex = 6;
            // 
            // moveDirectionsLabel
            // 
            this.moveDirectionsLabel.AutoSize = true;
            this.moveDirectionsLabel.Location = new System.Drawing.Point(13, 21);
            this.moveDirectionsLabel.Name = "moveDirectionsLabel";
            this.moveDirectionsLabel.Size = new System.Drawing.Size(87, 13);
            this.moveDirectionsLabel.TabIndex = 3;
            this.moveDirectionsLabel.Text = "Move Directions:";
            // 
            // heuristicLabel
            // 
            this.heuristicLabel.AutoSize = true;
            this.heuristicLabel.Location = new System.Drawing.Point(13, 62);
            this.heuristicLabel.Name = "heuristicLabel";
            this.heuristicLabel.Size = new System.Drawing.Size(59, 13);
            this.heuristicLabel.TabIndex = 2;
            this.heuristicLabel.Text = "Heuristics: ";
            // 
            // moveDirectionsCombo
            // 
            this.moveDirectionsCombo.FormattingEnabled = true;
            this.moveDirectionsCombo.Location = new System.Drawing.Point(107, 18);
            this.moveDirectionsCombo.Name = "moveDirectionsCombo";
            this.moveDirectionsCombo.Size = new System.Drawing.Size(121, 21);
            this.moveDirectionsCombo.TabIndex = 1;
            // 
            // heuristicsCombo
            // 
            this.heuristicsCombo.FormattingEnabled = true;
            this.heuristicsCombo.Location = new System.Drawing.Point(107, 59);
            this.heuristicsCombo.Name = "heuristicsCombo";
            this.heuristicsCombo.Size = new System.Drawing.Size(121, 21);
            this.heuristicsCombo.TabIndex = 0;
            // 
            // ExperimentsNoPanel
            // 
            this.ExperimentsNoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ExperimentsNoPanel.Controls.Add(this.startEndCheckBox);
            this.ExperimentsNoPanel.Controls.Add(this.experimentsCountNumericUD);
            this.ExperimentsNoPanel.Controls.Add(this.experimentCountLabel);
            this.ExperimentsNoPanel.Location = new System.Drawing.Point(8, 16);
            this.ExperimentsNoPanel.Name = "ExperimentsNoPanel";
            this.ExperimentsNoPanel.Size = new System.Drawing.Size(311, 80);
            this.ExperimentsNoPanel.TabIndex = 7;
            // 
            // experimentsCountNumericUD
            // 
            this.experimentsCountNumericUD.Location = new System.Drawing.Point(142, 13);
            this.experimentsCountNumericUD.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.experimentsCountNumericUD.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.experimentsCountNumericUD.Name = "experimentsCountNumericUD";
            this.experimentsCountNumericUD.Size = new System.Drawing.Size(120, 20);
            this.experimentsCountNumericUD.TabIndex = 2;
            this.experimentsCountNumericUD.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // experimentCountLabel
            // 
            this.experimentCountLabel.AutoSize = true;
            this.experimentCountLabel.Location = new System.Drawing.Point(5, 15);
            this.experimentCountLabel.Name = "experimentCountLabel";
            this.experimentCountLabel.Size = new System.Drawing.Size(102, 13);
            this.experimentCountLabel.TabIndex = 1;
            this.experimentCountLabel.Text = "No. of Experiments: ";
            // 
            // RunExperiments
            // 
            this.RunExperiments.Location = new System.Drawing.Point(529, 16);
            this.RunExperiments.Name = "RunExperiments";
            this.RunExperiments.Size = new System.Drawing.Size(225, 80);
            this.RunExperiments.TabIndex = 8;
            this.RunExperiments.Text = "Run Experiments";
            this.RunExperiments.UseVisualStyleBackColor = true;
            this.RunExperiments.Click += new System.EventHandler(this.RunExperiments_Click);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.ExperimentsNoPanel);
            this.panel1.Controls.Add(this.RunExperiments);
            this.panel1.Location = new System.Drawing.Point(13, 454);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 110);
            this.panel1.TabIndex = 9;
            // 
            // startEndCheckBox
            // 
            this.startEndCheckBox.AutoSize = true;
            this.startEndCheckBox.Location = new System.Drawing.Point(8, 48);
            this.startEndCheckBox.Name = "startEndCheckBox";
            this.startEndCheckBox.Size = new System.Drawing.Size(159, 17);
            this.startEndCheckBox.TabIndex = 4;
            this.startEndCheckBox.Text = "Unique Start and End points";
            this.startEndCheckBox.UseVisualStyleBackColor = true;
            // 
            // FrameworkGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(797, 576);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.AlgorithmsPanel);
            this.Controls.Add(this.AlgorithmsListBox);
            this.Controls.Add(this.MapListBox);
            this.Controls.Add(this.MapLabel);
            this.Controls.Add(this.MapsPanel);
            this.Name = "FrameworkGUI";
            this.Text = " A Star Test Framework";
            this.Load += new System.EventHandler(this.FrameworkGUI_Load);
            this.MapsPanel.ResumeLayout(false);
            this.MapsPanel.PerformLayout();
            this.AlgorithmsPanel.ResumeLayout(false);
            this.AlgorithmsPanel.PerformLayout();
            this.ExperimentsNoPanel.ResumeLayout(false);
            this.ExperimentsNoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.experimentsCountNumericUD)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadMaps;
        private System.Windows.Forms.Panel MapsPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pathText;
        private System.Windows.Forms.Label MapLabel;
        private System.Windows.Forms.CheckedListBox MapListBox;
        private System.Windows.Forms.CheckedListBox AlgorithmsListBox;
        private System.Windows.Forms.Panel AlgorithmsPanel;
        private System.Windows.Forms.Panel ExperimentsNoPanel;
        private System.Windows.Forms.Button RunExperiments;
        private System.Windows.Forms.NumericUpDown experimentsCountNumericUD;
        private System.Windows.Forms.Label experimentCountLabel;
        private System.Windows.Forms.Label moveDirectionsLabel;
        private System.Windows.Forms.Label heuristicLabel;
        private System.Windows.Forms.ComboBox moveDirectionsCombo;
        private System.Windows.Forms.ComboBox heuristicsCombo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox startEndCheckBox;
    }
}

