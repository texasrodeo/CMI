namespace ClientExample
{
    partial class FormMain
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PBLeft = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PBRight = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LabelTurn = new System.Windows.Forms.Label();
            this.LabelDamage = new System.Windows.Forms.Label();
            this.NUDBorder = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TimingLabel = new System.Windows.Forms.Label();
            this.ChartForDiff = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.myClientControl = new ClientExample.MyClientControl();
            this.LeftHP = new System.Windows.Forms.Label();
            this.rightHp = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBLeft)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDBorder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartForDiff)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LeftHP);
            this.groupBox1.Controls.Add(this.PBLeft);
            this.groupBox1.Controls.Add(this.LabelTurn);
            this.groupBox1.Location = new System.Drawing.Point(194, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(485, 285);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Player1";
            // 
            // PBLeft
            // 
            this.PBLeft.Location = new System.Drawing.Point(108, 19);
            this.PBLeft.Name = "PBLeft";
            this.PBLeft.Size = new System.Drawing.Size(371, 259);
            this.PBLeft.TabIndex = 0;
            this.PBLeft.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rightHp);
            this.groupBox2.Controls.Add(this.PBRight);
            this.groupBox2.Location = new System.Drawing.Point(685, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(485, 285);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Player2";
            // 
            // PBRight
            // 
            this.PBRight.Location = new System.Drawing.Point(6, 19);
            this.PBRight.Name = "PBRight";
            this.PBRight.Size = new System.Drawing.Size(376, 259);
            this.PBRight.TabIndex = 1;
            this.PBRight.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(662, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ожидаем готовности";
            // 
            // LabelTurn
            // 
            this.LabelTurn.AutoSize = true;
            this.LabelTurn.Location = new System.Drawing.Point(448, 288);
            this.LabelTurn.Name = "LabelTurn";
            this.LabelTurn.Size = new System.Drawing.Size(0, 13);
            this.LabelTurn.TabIndex = 7;
            // 
            // LabelDamage
            // 
            this.LabelDamage.AutoSize = true;
            this.LabelDamage.Location = new System.Drawing.Point(622, 445);
            this.LabelDamage.Name = "LabelDamage";
            this.LabelDamage.Size = new System.Drawing.Size(0, 13);
            this.LabelDamage.TabIndex = 8;
            // 
            // NUDBorder
            // 
            this.NUDBorder.Location = new System.Drawing.Point(243, 12);
            this.NUDBorder.Maximum = new decimal(new int[] {
            228000,
            0,
            0,
            0});
            this.NUDBorder.Name = "NUDBorder";
            this.NUDBorder.Size = new System.Drawing.Size(120, 20);
            this.NUDBorder.TabIndex = 13;
            this.NUDBorder.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.NUDBorder.ValueChanged += new System.EventHandler(this.NUDBorder_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Граница";
            // 
            // TimingLabel
            // 
            this.TimingLabel.AutoSize = true;
            this.TimingLabel.Location = new System.Drawing.Point(1076, 19);
            this.TimingLabel.Name = "TimingLabel";
            this.TimingLabel.Size = new System.Drawing.Size(0, 13);
            this.TimingLabel.TabIndex = 14;
            // 
            // ChartForDiff
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartForDiff.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartForDiff.Legends.Add(legend1);
            this.ChartForDiff.Location = new System.Drawing.Point(226, 358);
            this.ChartForDiff.Name = "ChartForDiff";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series1.Color = System.Drawing.Color.Black;
            series1.LabelBorderDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.NotSet;
            series1.LabelBorderWidth = 3;
            series1.Legend = "Legend1";
            series1.Name = "первый игрок";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series2.Legend = "Legend1";
            series2.Name = "Граница";
            series3.BorderWidth = 3;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.FastLine;
            series3.Legend = "Legend1";
            series3.Name = "второй игрок";
            this.ChartForDiff.Series.Add(series1);
            this.ChartForDiff.Series.Add(series2);
            this.ChartForDiff.Series.Add(series3);
            this.ChartForDiff.Size = new System.Drawing.Size(885, 328);
            this.ChartForDiff.TabIndex = 15;
            this.ChartForDiff.Text = "s";
            // 
            // myClientControl
            // 
            this.myClientControl.ClientName = "Client";
            this.myClientControl.Dock = System.Windows.Forms.DockStyle.Left;
            this.myClientControl.IPServer = ((System.Net.IPAddress)(resources.GetObject("myClientControl.IPServer")));
            this.myClientControl.IsSyncronized = true;
            this.myClientControl.Location = new System.Drawing.Point(0, 0);
            this.myClientControl.Name = "myClientControl";
            this.myClientControl.Port = 8000;
            this.myClientControl.Size = new System.Drawing.Size(188, 749);
            this.myClientControl.TabIndex = 0;
            this.myClientControl.Load += new System.EventHandler(this.myClientControl_Load);
            // 
            // LeftHP
            // 
            this.LeftHP.AutoSize = true;
            this.LeftHP.Location = new System.Drawing.Point(8, 19);
            this.LeftHP.Name = "LeftHP";
            this.LeftHP.Size = new System.Drawing.Size(0, 13);
            this.LeftHP.TabIndex = 1;
            // 
            // rightHp
            // 
            this.rightHp.AutoSize = true;
            this.rightHp.Location = new System.Drawing.Point(388, 19);
            this.rightHp.Name = "rightHp";
            this.rightHp.Size = new System.Drawing.Size(0, 13);
            this.rightHp.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 749);
            this.Controls.Add(this.ChartForDiff);
            this.Controls.Add(this.TimingLabel);
            this.Controls.Add(this.NUDBorder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LabelDamage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.myClientControl);
            this.Name = "FormMain";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBLeft)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PBRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUDBorder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ChartForDiff)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MyClientControl myClientControl;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox PBLeft;
        private System.Windows.Forms.PictureBox PBRight;
        private System.Windows.Forms.Label LabelTurn;
        private System.Windows.Forms.Label LabelDamage;
        private System.Windows.Forms.NumericUpDown NUDBorder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TimingLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart ChartForDiff;
        private System.Windows.Forms.Label LeftHP;
        private System.Windows.Forms.Label rightHp;
    }
}

