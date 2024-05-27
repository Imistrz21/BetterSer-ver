namespace RobloxLauncher
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startBTN = new System.Windows.Forms.Button();
            this.stopBTN = new System.Windows.Forms.Button();
            this.restartBTN = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comBTN = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.loadingBAR = new System.Windows.Forms.ToolStripProgressBar();
            this.upTimeLABEL = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Console = new System.Windows.Forms.TabPage();
            this.ProcessAllocation = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
            this.ramALLmax = new System.Windows.Forms.NumericUpDown();
            this.ramALLmin = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cpuALL = new System.Windows.Forms.DomainUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.Files = new System.Windows.Forms.TabPage();
            this.label7 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.Console.SuspendLayout();
            this.ProcessAllocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramALLmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramALLmin)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.Files.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.txtOutput.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.HideSelection = false;
            this.txtOutput.Location = new System.Drawing.Point(6, 6);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ShortcutsEnabled = false;
            this.txtOutput.Size = new System.Drawing.Size(705, 367);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            this.txtOutput.UseWaitCursor = true;
            this.txtOutput.WordWrap = false;
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // txtInput
            // 
            this.txtInput.Location = new System.Drawing.Point(12, 418);
            this.txtInput.Name = "txtInput";
            this.txtInput.Size = new System.Drawing.Size(725, 20);
            this.txtInput.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(744, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Private ip:";
            // 
            // startBTN
            // 
            this.startBTN.Location = new System.Drawing.Point(743, 51);
            this.startBTN.Name = "startBTN";
            this.startBTN.Size = new System.Drawing.Size(133, 23);
            this.startBTN.TabIndex = 3;
            this.startBTN.Text = "Start";
            this.startBTN.UseVisualStyleBackColor = true;
            this.startBTN.Click += new System.EventHandler(this.button1_Click);
            // 
            // stopBTN
            // 
            this.stopBTN.Enabled = false;
            this.stopBTN.Location = new System.Drawing.Point(744, 80);
            this.stopBTN.Name = "stopBTN";
            this.stopBTN.Size = new System.Drawing.Size(133, 23);
            this.stopBTN.TabIndex = 4;
            this.stopBTN.Text = "Stop";
            this.stopBTN.UseVisualStyleBackColor = true;
            this.stopBTN.Click += new System.EventHandler(this.button2_Click);
            // 
            // restartBTN
            // 
            this.restartBTN.Enabled = false;
            this.restartBTN.Location = new System.Drawing.Point(743, 386);
            this.restartBTN.Name = "restartBTN";
            this.restartBTN.Size = new System.Drawing.Size(141, 23);
            this.restartBTN.TabIndex = 5;
            this.restartBTN.Text = "Restart";
            this.restartBTN.UseVisualStyleBackColor = true;
            this.restartBTN.Visible = false;
            this.restartBTN.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(744, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Public ip:";
            // 
            // comBTN
            // 
            this.comBTN.Location = new System.Drawing.Point(743, 415);
            this.comBTN.Name = "comBTN";
            this.comBTN.Size = new System.Drawing.Size(141, 23);
            this.comBTN.TabIndex = 7;
            this.comBTN.Text = "Send an command";
            this.comBTN.UseVisualStyleBackColor = true;
            this.comBTN.Click += new System.EventHandler(this.comBTN_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadingBAR,
            this.upTimeLABEL});
            this.statusStrip1.Location = new System.Drawing.Point(0, 444);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(888, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // loadingBAR
            // 
            this.loadingBAR.Enabled = false;
            this.loadingBAR.Name = "loadingBAR";
            this.loadingBAR.Size = new System.Drawing.Size(100, 16);
            this.loadingBAR.Visible = false;
            // 
            // upTimeLABEL
            // 
            this.upTimeLABEL.Name = "upTimeLABEL";
            this.upTimeLABEL.Size = new System.Drawing.Size(52, 17);
            this.upTimeLABEL.Text = "Uptime: ";
            // 
            // tabControl1
            // 
            this.tabControl1.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.tabControl1.Controls.Add(this.Console);
            this.tabControl1.Controls.Add(this.ProcessAllocation);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.Files);
            this.tabControl1.Location = new System.Drawing.Point(12, 4);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(725, 405);
            this.tabControl1.TabIndex = 9;
            // 
            // Console
            // 
            this.Console.BackColor = System.Drawing.Color.Transparent;
            this.Console.Controls.Add(this.txtOutput);
            this.Console.Location = new System.Drawing.Point(4, 4);
            this.Console.Name = "Console";
            this.Console.Padding = new System.Windows.Forms.Padding(3);
            this.Console.Size = new System.Drawing.Size(698, 397);
            this.Console.TabIndex = 0;
            this.Console.Text = "Console";
            // 
            // ProcessAllocation
            // 
            this.ProcessAllocation.CausesValidation = false;
            this.ProcessAllocation.Controls.Add(this.label8);
            this.ProcessAllocation.Controls.Add(this.ramALLmax);
            this.ProcessAllocation.Controls.Add(this.ramALLmin);
            this.ProcessAllocation.Controls.Add(this.label6);
            this.ProcessAllocation.Controls.Add(this.label5);
            this.ProcessAllocation.Controls.Add(this.label4);
            this.ProcessAllocation.Controls.Add(this.cpuALL);
            this.ProcessAllocation.Controls.Add(this.label3);
            this.ProcessAllocation.Location = new System.Drawing.Point(4, 4);
            this.ProcessAllocation.Name = "ProcessAllocation";
            this.ProcessAllocation.Padding = new System.Windows.Forms.Padding(3);
            this.ProcessAllocation.Size = new System.Drawing.Size(698, 397);
            this.ProcessAllocation.TabIndex = 1;
            this.ProcessAllocation.Text = "Process allocation";
            this.ProcessAllocation.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(294, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Resource allocation is disabled...";
            // 
            // ramALLmax
            // 
            this.ramALLmax.Location = new System.Drawing.Point(41, 62);
            this.ramALLmax.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.ramALLmax.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ramALLmax.Name = "ramALLmax";
            this.ramALLmax.Size = new System.Drawing.Size(120, 20);
            this.ramALLmax.TabIndex = 10;
            this.ramALLmax.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ramALLmax.ValueChanged += new System.EventHandler(this.ramALLmax_ValueChanged);
            // 
            // ramALLmin
            // 
            this.ramALLmin.Location = new System.Drawing.Point(167, 62);
            this.ramALLmin.Maximum = new decimal(new int[] {
            250000,
            0,
            0,
            0});
            this.ramALLmin.Minimum = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ramALLmin.Name = "ramALLmin";
            this.ramALLmin.Size = new System.Drawing.Size(120, 20);
            this.ramALLmin.TabIndex = 9;
            this.ramALLmin.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            this.ramALLmin.ValueChanged += new System.EventHandler(this.ramALLmin_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(198, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Maximum";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(74, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Minimum";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cpu:";
            // 
            // cpuALL
            // 
            this.cpuALL.Items.Add("1");
            this.cpuALL.Items.Add("2");
            this.cpuALL.Items.Add("3");
            this.cpuALL.Items.Add("4");
            this.cpuALL.Items.Add("5");
            this.cpuALL.Items.Add("6");
            this.cpuALL.Items.Add("7");
            this.cpuALL.Items.Add("8");
            this.cpuALL.Items.Add("9");
            this.cpuALL.Items.Add("10");
            this.cpuALL.Items.Add("12");
            this.cpuALL.Items.Add("13");
            this.cpuALL.Items.Add("14");
            this.cpuALL.Items.Add("15");
            this.cpuALL.Items.Add("16");
            this.cpuALL.Items.Add("17");
            this.cpuALL.Items.Add("18");
            this.cpuALL.Items.Add("19");
            this.cpuALL.Items.Add("20");
            this.cpuALL.Items.Add("21");
            this.cpuALL.Items.Add("22");
            this.cpuALL.Items.Add("23");
            this.cpuALL.Items.Add("24");
            this.cpuALL.Location = new System.Drawing.Point(41, 9);
            this.cpuALL.Name = "cpuALL";
            this.cpuALL.ReadOnly = true;
            this.cpuALL.Size = new System.Drawing.Size(120, 20);
            this.cpuALL.TabIndex = 3;
            this.cpuALL.Text = "Cpu:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ram:";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.richTextBox1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Location = new System.Drawing.Point(4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(698, 397);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Server Download";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(303, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 13);
            this.label13.TabIndex = 7;
            this.label13.Text = "Download is disabled...";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(581, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 6;
            this.label12.Text = "Java 22";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(512, 25);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(183, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Install java";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(3, 280);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(711, 96);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(42, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "1.20.4";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Download Server";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Files
            // 
            this.Files.Controls.Add(this.label7);
            this.Files.Controls.Add(this.webBrowser1);
            this.Files.Location = new System.Drawing.Point(4, 4);
            this.Files.Name = "Files";
            this.Files.Size = new System.Drawing.Size(698, 397);
            this.Files.TabIndex = 2;
            this.Files.Text = "Files";
            this.Files.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(299, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "File explorer is disabled...";
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(698, 397);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("file://c:/", System.UriKind.Absolute);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(739, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(162, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Resource allocation is disabled...";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(739, 119);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(124, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "File explorer is disabled...";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(888, 466);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.comBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.restartBTN);
            this.Controls.Add(this.stopBTN);
            this.Controls.Add(this.startBTN);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtInput);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Minecraft Server Launcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.Console.ResumeLayout(false);
            this.ProcessAllocation.ResumeLayout(false);
            this.ProcessAllocation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ramALLmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ramALLmin)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.Files.ResumeLayout(false);
            this.Files.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startBTN;
        private System.Windows.Forms.Button stopBTN;
        private System.Windows.Forms.Button restartBTN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button comBTN;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar loadingBAR;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage Console;
        private System.Windows.Forms.TabPage ProcessAllocation;
        private System.Windows.Forms.TabPage Files;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DomainUpDown cpuALL;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown ramALLmin;
        private System.Windows.Forms.NumericUpDown ramALLmax;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripStatusLabel upTimeLABEL;
    }
}

