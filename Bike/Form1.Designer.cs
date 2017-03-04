namespace Bike
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.DateLabel = new System.Windows.Forms.Label();
            this.Date = new System.Windows.Forms.Label();
            this.StartTime = new System.Windows.Forms.Label();
            this.startTimeLabel = new System.Windows.Forms.Label();
            this.Interval = new System.Windows.Forms.Label();
            this.intervalLabel = new System.Windows.Forms.Label();
            this.HeartRate = new System.Windows.Forms.Label();
            this.HeartRateLabel = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exit = new System.Windows.Forms.ToolStripMenuItem();
            this.minHR = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.maxHR = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MaxSpeed = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.AverageSpeed = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.MaxPower = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.AveragePower = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.MaxAltitude = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.AverageAltitude = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.milesRadioButton = new System.Windows.Forms.RadioButton();
            this.KilometersRadioButton = new System.Windows.Forms.RadioButton();
            this.TotalDistance = new System.Windows.Forms.Label();
            this.TotalDistanceLabel = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Heart_Rate_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Speed_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cadence_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Altitude_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Power_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Power_Balance_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(3, 0);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(30, 13);
            this.DateLabel.TabIndex = 2;
            this.DateLabel.Text = "Date";
            // 
            // Date
            // 
            this.Date.AutoSize = true;
            this.Date.Location = new System.Drawing.Point(104, 0);
            this.Date.Name = "Date";
            this.Date.Size = new System.Drawing.Size(35, 13);
            this.Date.TabIndex = 3;
            this.Date.Text = "label2";
            // 
            // StartTime
            // 
            this.StartTime.AutoSize = true;
            this.StartTime.Location = new System.Drawing.Point(104, 22);
            this.StartTime.Name = "StartTime";
            this.StartTime.Size = new System.Drawing.Size(35, 13);
            this.StartTime.TabIndex = 5;
            this.StartTime.Text = "label2";
            // 
            // startTimeLabel
            // 
            this.startTimeLabel.AutoSize = true;
            this.startTimeLabel.Location = new System.Drawing.Point(3, 22);
            this.startTimeLabel.Name = "startTimeLabel";
            this.startTimeLabel.Size = new System.Drawing.Size(55, 13);
            this.startTimeLabel.TabIndex = 4;
            this.startTimeLabel.Text = "Start Time";
            // 
            // Interval
            // 
            this.Interval.AutoSize = true;
            this.Interval.Location = new System.Drawing.Point(104, 44);
            this.Interval.Name = "Interval";
            this.Interval.Size = new System.Drawing.Size(35, 13);
            this.Interval.TabIndex = 7;
            this.Interval.Text = "label2";
            // 
            // intervalLabel
            // 
            this.intervalLabel.AutoSize = true;
            this.intervalLabel.Location = new System.Drawing.Point(3, 44);
            this.intervalLabel.Name = "intervalLabel";
            this.intervalLabel.Size = new System.Drawing.Size(42, 13);
            this.intervalLabel.TabIndex = 6;
            this.intervalLabel.Text = "Interval";
            // 
            // HeartRate
            // 
            this.HeartRate.AutoSize = true;
            this.HeartRate.Location = new System.Drawing.Point(104, 144);
            this.HeartRate.Name = "HeartRate";
            this.HeartRate.Size = new System.Drawing.Size(35, 13);
            this.HeartRate.TabIndex = 9;
            this.HeartRate.Text = "label2";
            // 
            // HeartRateLabel
            // 
            this.HeartRateLabel.AutoSize = true;
            this.HeartRateLabel.Location = new System.Drawing.Point(3, 144);
            this.HeartRateLabel.Name = "HeartRateLabel";
            this.HeartRateLabel.Size = new System.Drawing.Size(59, 13);
            this.HeartRateLabel.TabIndex = 8;
            this.HeartRateLabel.Text = "Heart Rate";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1668, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exit
            // 
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(103, 22);
            this.exit.Text = "Exit";
            this.exit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // minHR
            // 
            this.minHR.AutoSize = true;
            this.minHR.Location = new System.Drawing.Point(104, 164);
            this.minHR.Name = "minHR";
            this.minHR.Size = new System.Drawing.Size(35, 13);
            this.minHR.TabIndex = 16;
            this.minHR.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Min Heart Rate";
            // 
            // maxHR
            // 
            this.maxHR.AutoSize = true;
            this.maxHR.Location = new System.Drawing.Point(104, 184);
            this.maxHR.Name = "maxHR";
            this.maxHR.Size = new System.Drawing.Size(35, 13);
            this.maxHR.TabIndex = 18;
            this.maxHR.Text = "label2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Max Heart Rate";
            // 
            // MaxSpeed
            // 
            this.MaxSpeed.AutoSize = true;
            this.MaxSpeed.Location = new System.Drawing.Point(104, 224);
            this.MaxSpeed.Name = "MaxSpeed";
            this.MaxSpeed.Size = new System.Drawing.Size(35, 13);
            this.MaxSpeed.TabIndex = 22;
            this.MaxSpeed.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Max Speed";
            // 
            // AverageSpeed
            // 
            this.AverageSpeed.AutoSize = true;
            this.AverageSpeed.Location = new System.Drawing.Point(104, 204);
            this.AverageSpeed.Name = "AverageSpeed";
            this.AverageSpeed.Size = new System.Drawing.Size(35, 13);
            this.AverageSpeed.TabIndex = 20;
            this.AverageSpeed.Text = "label2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 204);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Average Speed";
            // 
            // MaxPower
            // 
            this.MaxPower.AutoSize = true;
            this.MaxPower.Location = new System.Drawing.Point(104, 124);
            this.MaxPower.Name = "MaxPower";
            this.MaxPower.Size = new System.Drawing.Size(35, 13);
            this.MaxPower.TabIndex = 26;
            this.MaxPower.Text = "label2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "Max Power";
            // 
            // AveragePower
            // 
            this.AveragePower.AutoSize = true;
            this.AveragePower.Location = new System.Drawing.Point(104, 104);
            this.AveragePower.Name = "AveragePower";
            this.AveragePower.Size = new System.Drawing.Size(35, 13);
            this.AveragePower.TabIndex = 24;
            this.AveragePower.Text = "label2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 104);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(80, 13);
            this.label8.TabIndex = 23;
            this.label8.Text = "Average Power";
            // 
            // MaxAltitude
            // 
            this.MaxAltitude.AutoSize = true;
            this.MaxAltitude.Location = new System.Drawing.Point(104, 84);
            this.MaxAltitude.Name = "MaxAltitude";
            this.MaxAltitude.Size = new System.Drawing.Size(35, 13);
            this.MaxAltitude.TabIndex = 30;
            this.MaxAltitude.Text = "label2";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Max Altitude";
            // 
            // AverageAltitude
            // 
            this.AverageAltitude.AutoSize = true;
            this.AverageAltitude.Location = new System.Drawing.Point(104, 64);
            this.AverageAltitude.Name = "AverageAltitude";
            this.AverageAltitude.Size = new System.Drawing.Size(35, 13);
            this.AverageAltitude.TabIndex = 28;
            this.AverageAltitude.Text = "label2";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 64);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Average Altitude";
            // 
            // milesRadioButton
            // 
            this.milesRadioButton.AutoSize = true;
            this.milesRadioButton.Location = new System.Drawing.Point(21, 184);
            this.milesRadioButton.Name = "milesRadioButton";
            this.milesRadioButton.Size = new System.Drawing.Size(49, 17);
            this.milesRadioButton.TabIndex = 31;
            this.milesRadioButton.TabStop = true;
            this.milesRadioButton.Text = "Miles";
            this.milesRadioButton.UseVisualStyleBackColor = true;
            this.milesRadioButton.CheckedChanged += new System.EventHandler(this.milesRadioButton_CheckedChanged);
            // 
            // KilometersRadioButton
            // 
            this.KilometersRadioButton.AutoSize = true;
            this.KilometersRadioButton.Location = new System.Drawing.Point(86, 184);
            this.KilometersRadioButton.Name = "KilometersRadioButton";
            this.KilometersRadioButton.Size = new System.Drawing.Size(73, 17);
            this.KilometersRadioButton.TabIndex = 32;
            this.KilometersRadioButton.TabStop = true;
            this.KilometersRadioButton.Text = "Kilometers";
            this.KilometersRadioButton.UseVisualStyleBackColor = true;
            this.KilometersRadioButton.CheckedChanged += new System.EventHandler(this.KilometersRadioButton_CheckedChanged);
            // 
            // TotalDistance
            // 
            this.TotalDistance.AutoSize = true;
            this.TotalDistance.Location = new System.Drawing.Point(104, 244);
            this.TotalDistance.Name = "TotalDistance";
            this.TotalDistance.Size = new System.Drawing.Size(35, 13);
            this.TotalDistance.TabIndex = 34;
            this.TotalDistance.Text = "label2";
            // 
            // TotalDistanceLabel
            // 
            this.TotalDistanceLabel.AutoSize = true;
            this.TotalDistanceLabel.Location = new System.Drawing.Point(3, 244);
            this.TotalDistanceLabel.Name = "TotalDistanceLabel";
            this.TotalDistanceLabel.Size = new System.Drawing.Size(76, 13);
            this.TotalDistanceLabel.TabIndex = 33;
            this.TotalDistanceLabel.Text = "Total Distance";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Heart_Rate_Column,
            this.Speed_Column,
            this.Cadence_Column,
            this.Altitude_Column,
            this.Power_Column,
            this.Power_Balance_Column});
            this.dataGridView1.Location = new System.Drawing.Point(584, 686);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1028, 175);
            this.dataGridView1.TabIndex = 35;
            // 
            // Heart_Rate_Column
            // 
            this.Heart_Rate_Column.HeaderText = "Heart Rate (bpm)";
            this.Heart_Rate_Column.Name = "Heart_Rate_Column";
            // 
            // Speed_Column
            // 
            this.Speed_Column.HeaderText = "Speed (mph/kph)";
            this.Speed_Column.Name = "Speed_Column";
            // 
            // Cadence_Column
            // 
            this.Cadence_Column.HeaderText = "Cadence (rpm)";
            this.Cadence_Column.Name = "Cadence_Column";
            // 
            // Altitude_Column
            // 
            this.Altitude_Column.HeaderText = "Altitude (m/ft)";
            this.Altitude_Column.Name = "Altitude_Column";
            // 
            // Power_Column
            // 
            this.Power_Column.HeaderText = "Power (Watts)";
            this.Power_Column.Name = "Power_Column";
            // 
            // Power_Balance_Column
            // 
            this.Power_Balance_Column.HeaderText = "Power Balance And Pedalling Index";
            this.Power_Balance_Column.Name = "Power_Balance_Column";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 29.13669F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 254);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.02118F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 26.97882F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(418, 670);
            this.tableLayoutPanel1.TabIndex = 36;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Location = new System.Drawing.Point(497, 109);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(1028, 483);
            this.zedGraphControl1.TabIndex = 37;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.DateLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.TotalDistance, 1, 12);
            this.tableLayoutPanel3.Controls.Add(this.TotalDistanceLabel, 0, 12);
            this.tableLayoutPanel3.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.MaxSpeed, 1, 11);
            this.tableLayoutPanel3.Controls.Add(this.MaxPower, 1, 6);
            this.tableLayoutPanel3.Controls.Add(this.AverageAltitude, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.label3, 0, 11);
            this.tableLayoutPanel3.Controls.Add(this.AveragePower, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.AverageSpeed, 1, 10);
            this.tableLayoutPanel3.Controls.Add(this.label8, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.label6, 0, 10);
            this.tableLayoutPanel3.Controls.Add(this.Date, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.maxHR, 1, 9);
            this.tableLayoutPanel3.Controls.Add(this.startTimeLabel, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.minHR, 1, 8);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 9);
            this.tableLayoutPanel3.Controls.Add(this.MaxAltitude, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.label7, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 8);
            this.tableLayoutPanel3.Controls.Add(this.label10, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.HeartRate, 1, 7);
            this.tableLayoutPanel3.Controls.Add(this.StartTime, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.HeartRateLabel, 0, 7);
            this.tableLayoutPanel3.Controls.Add(this.intervalLabel, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.Interval, 1, 2);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 18;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(203, 364);
            this.tableLayoutPanel3.TabIndex = 37;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1668, 922);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.KilometersRadioButton);
            this.Controls.Add(this.milesRadioButton);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.Label Date;
        private System.Windows.Forms.Label StartTime;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.Label Interval;
        private System.Windows.Forms.Label intervalLabel;
        private System.Windows.Forms.Label HeartRate;
        private System.Windows.Forms.Label HeartRateLabel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.Label minHR;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label maxHR;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label MaxSpeed;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AverageSpeed;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label MaxPower;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label AveragePower;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label MaxAltitude;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label AverageAltitude;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem exit;
        private System.Windows.Forms.RadioButton milesRadioButton;
        private System.Windows.Forms.RadioButton KilometersRadioButton;
        private System.Windows.Forms.Label TotalDistance;
        private System.Windows.Forms.Label TotalDistanceLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Heart_Rate_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Speed_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cadence_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Altitude_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Power_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Power_Balance_Column;
        private ZedGraph.ZedGraphControl zedGraphControl1;
    }
}

