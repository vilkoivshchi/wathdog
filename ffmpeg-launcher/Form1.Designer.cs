
namespace ffmpeg_launcher
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpen = new System.Windows.Forms.Button();
            this.AppTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ArgsTextBox = new System.Windows.Forms.TextBox();
            this.btnRunStop = new System.Windows.Forms.Button();
            this.StatusTextBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripLabelApp = new System.Windows.Forms.ToolStripStatusLabel();
            this.UpDownTimeout = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.labelSeconds = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.RunMinimized = new System.Windows.Forms.CheckBox();
            this.chkAutostartProc = new System.Windows.Forms.CheckBox();
            this.runWithWindows = new System.Windows.Forms.CheckBox();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(17, 16);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(100, 28);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // AppTextBox
            // 
            this.AppTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AppTextBox.Location = new System.Drawing.Point(222, 19);
            this.AppTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.AppTextBox.Name = "AppTextBox";
            this.AppTextBox.Size = new System.Drawing.Size(373, 22);
            this.AppTextBox.TabIndex = 1;
            this.AppTextBox.TextChanged += new System.EventHandler(this.AppTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Приложение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 58);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "Аргументы";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // ArgsTextBox
            // 
            this.ArgsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ArgsTextBox.Location = new System.Drawing.Point(222, 55);
            this.ArgsTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ArgsTextBox.Name = "ArgsTextBox";
            this.ArgsTextBox.Size = new System.Drawing.Size(373, 22);
            this.ArgsTextBox.TabIndex = 4;
            this.ArgsTextBox.TextChanged += new System.EventHandler(this.ArgsTextBox_TextChanged);
            // 
            // btnRunStop
            // 
            this.btnRunStop.Location = new System.Drawing.Point(17, 52);
            this.btnRunStop.Margin = new System.Windows.Forms.Padding(4);
            this.btnRunStop.Name = "btnRunStop";
            this.btnRunStop.Size = new System.Drawing.Size(100, 28);
            this.btnRunStop.TabIndex = 5;
            this.btnRunStop.Text = "Запустить";
            this.btnRunStop.UseVisualStyleBackColor = true;
            this.btnRunStop.Click += new System.EventHandler(this.btnRunStop_Click);
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.StatusTextBox.Location = new System.Drawing.Point(17, 217);
            this.StatusTextBox.Multiline = true;
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.ReadOnly = true;
            this.StatusTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.StatusTextBox.Size = new System.Drawing.Size(578, 291);
            this.StatusTextBox.TabIndex = 7;
            this.StatusTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabelApp});
            this.statusStrip1.Location = new System.Drawing.Point(0, 511);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(607, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripLabelApp
            // 
            this.toolStripLabelApp.Name = "toolStripLabelApp";
            this.toolStripLabelApp.Size = new System.Drawing.Size(118, 17);
            this.toolStripLabelApp.Text = "toolStripStatusLabel1";
            // 
            // UpDownTimeout
            // 
            this.UpDownTimeout.Location = new System.Drawing.Point(269, 92);
            this.UpDownTimeout.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.UpDownTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownTimeout.Name = "UpDownTimeout";
            this.UpDownTimeout.Size = new System.Drawing.Size(53, 22);
            this.UpDownTimeout.TabIndex = 9;
            this.UpDownTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.UpDownTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.UpDownTimeout.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 94);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Проверять через:";
            // 
            // labelSeconds
            // 
            this.labelSeconds.AutoSize = true;
            this.labelSeconds.Location = new System.Drawing.Point(329, 94);
            this.labelSeconds.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSeconds.Name = "labelSeconds";
            this.labelSeconds.Size = new System.Drawing.Size(62, 16);
            this.labelSeconds.TabIndex = 11;
            this.labelSeconds.Text = "секунду";
            this.labelSeconds.Click += new System.EventHandler(this.labelSeconds_Click);
            // 
            // btnClearLog
            // 
            this.btnClearLog.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClearLog.Location = new System.Drawing.Point(17, 88);
            this.btnClearLog.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.Size = new System.Drawing.Size(100, 28);
            this.btnClearLog.TabIndex = 12;
            this.btnClearLog.Text = "Очистить";
            this.btnClearLog.UseVisualStyleBackColor = true;
            // 
            // RunMinimized
            // 
            this.RunMinimized.AutoSize = true;
            this.RunMinimized.Location = new System.Drawing.Point(17, 123);
            this.RunMinimized.Name = "RunMinimized";
            this.RunMinimized.Size = new System.Drawing.Size(343, 20);
            this.RunMinimized.TabIndex = 13;
            this.RunMinimized.Text = "Запускать контролируемый процесс свернутым";
            this.RunMinimized.UseVisualStyleBackColor = true;
            this.RunMinimized.CheckedChanged += new System.EventHandler(this.RunMinimized_CheckedChanged);
            // 
            // chkAutostartProc
            // 
            this.chkAutostartProc.AutoSize = true;
            this.chkAutostartProc.Location = new System.Drawing.Point(17, 149);
            this.chkAutostartProc.Name = "chkAutostartProc";
            this.chkAutostartProc.Size = new System.Drawing.Size(320, 20);
            this.chkAutostartProc.TabIndex = 14;
            this.chkAutostartProc.Text = "Запускать процесс при запуске приложения";
            this.chkAutostartProc.UseVisualStyleBackColor = true;
            this.chkAutostartProc.CheckedChanged += new System.EventHandler(this.chkAutostartProc_CheckedChanged);
            // 
            // runWithWindows
            // 
            this.runWithWindows.AutoSize = true;
            this.runWithWindows.Location = new System.Drawing.Point(17, 175);
            this.runWithWindows.Name = "runWithWindows";
            this.runWithWindows.Size = new System.Drawing.Size(321, 20);
            this.runWithWindows.TabIndex = 15;
            this.runWithWindows.Text = "Автозапуск приложения при старте Windows";
            this.runWithWindows.UseVisualStyleBackColor = true;
            this.runWithWindows.CheckedChanged += new System.EventHandler(this.runWithWindows_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 533);
            this.Controls.Add(this.runWithWindows);
            this.Controls.Add(this.chkAutostartProc);
            this.Controls.Add(this.RunMinimized);
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.labelSeconds);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.UpDownTimeout);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.StatusTextBox);
            this.Controls.Add(this.btnRunStop);
            this.Controls.Add(this.ArgsTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AppTextBox);
            this.Controls.Add(this.btnOpen);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FFmpeg watchdog";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UpDownTimeout)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox AppTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ArgsTextBox;
        private System.Windows.Forms.Button btnRunStop;
        private System.Windows.Forms.TextBox StatusTextBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripLabelApp;
        private System.Windows.Forms.NumericUpDown UpDownTimeout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelSeconds;
        private System.Windows.Forms.Button btnClearLog;
        private System.Windows.Forms.CheckBox RunMinimized;
        private System.Windows.Forms.CheckBox chkAutostartProc;
        private System.Windows.Forms.CheckBox runWithWindows;
    }
}

