namespace WindowSync
{
    partial class MainForm
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
            label7 = new Label();
            label6 = new Label();
            btnIgroneClear = new Button();
            btnAddIgrone = new Button();
            btnStart = new Button();
            btnClear = new Button();
            lstWindows = new ListView();
            colHandle = new ColumnHeader();
            colTitle = new ColumnHeader();
            colOperation = new ColumnHeader();
            btnGetHandle = new Button();
            txtIgroneKeys = new TextBox();
            checkBox1 = new CheckBox();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            checkBox4 = new CheckBox();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            btnSetFrom = new Button();
            textLog = new TextBox();
            groupBoxLog = new GroupBox();
            trackBar1 = new TrackBar();
            groupBox2 = new GroupBox();
            groupBox1 = new GroupBox();
            label1 = new Label();
            groupBoxLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).BeginInit();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label7.AutoSize = true;
            label7.Location = new Point(12, 160);
            label7.Name = "label7";
            label7.Size = new Size(83, 17);
            label7.TabIndex = 38;
            label7.Text = "鼠标点击同步:";
            label7.Visible = false;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Location = new Point(5, 55);
            label6.Name = "label6";
            label6.Size = new Size(59, 17);
            label6.TabIndex = 37;
            label6.Text = "忽略按键:";
            // 
            // btnIgroneClear
            // 
            btnIgroneClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnIgroneClear.Location = new Point(186, 50);
            btnIgroneClear.Name = "btnIgroneClear";
            btnIgroneClear.Size = new Size(64, 25);
            btnIgroneClear.TabIndex = 30;
            btnIgroneClear.Text = "清除";
            btnIgroneClear.UseVisualStyleBackColor = true;
            btnIgroneClear.Click += btnIgroneClear_Click;
            // 
            // btnAddIgrone
            // 
            btnAddIgrone.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddIgrone.Location = new Point(116, 51);
            btnAddIgrone.Name = "btnAddIgrone";
            btnAddIgrone.Size = new Size(64, 25);
            btnAddIgrone.TabIndex = 29;
            btnAddIgrone.Text = "添加";
            btnAddIgrone.UseVisualStyleBackColor = true;
            btnAddIgrone.Click += btnAddIgrone_Click;
            // 
            // btnStart
            // 
            btnStart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnStart.Location = new Point(107, 22);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(64, 25);
            btnStart.TabIndex = 27;
            btnStart.Text = "运行";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(177, 22);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(52, 25);
            btnClear.TabIndex = 26;
            btnClear.Text = "清除";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // lstWindows
            // 
            lstWindows.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstWindows.Columns.AddRange(new ColumnHeader[] { colHandle, colTitle, colOperation });
            lstWindows.FullRowSelect = true;
            lstWindows.GridLines = true;
            lstWindows.Location = new Point(9, 22);
            lstWindows.MultiSelect = false;
            lstWindows.Name = "lstWindows";
            lstWindows.Size = new Size(242, 108);
            lstWindows.TabIndex = 25;
            lstWindows.UseCompatibleStateImageBehavior = false;
            lstWindows.View = View.Details;
            lstWindows.DoubleClick += lstWindows_DoubleClick;
            // 
            // colHandle
            // 
            colHandle.Text = "句柄";
            colHandle.Width = 80;
            // 
            // colTitle
            // 
            colTitle.Text = "标题";
            colTitle.Width = 80;
            // 
            // colOperation
            // 
            colOperation.Text = "主控";
            colOperation.TextAlign = HorizontalAlignment.Center;
            colOperation.Width = 40;
            // 
            // btnGetHandle
            // 
            btnGetHandle.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnGetHandle.Location = new Point(15, 22);
            btnGetHandle.Name = "btnGetHandle";
            btnGetHandle.Size = new Size(86, 25);
            btnGetHandle.TabIndex = 24;
            btnGetHandle.Text = "拖动到窗口";
            btnGetHandle.UseVisualStyleBackColor = true;
            btnGetHandle.MouseDown += btnGetHandle_MouseDown;
            btnGetHandle.MouseUp += btnGetHandle_MouseUp;
            // 
            // txtIgroneKeys
            // 
            txtIgroneKeys.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtIgroneKeys.Location = new Point(68, 52);
            txtIgroneKeys.Name = "txtIgroneKeys";
            txtIgroneKeys.ReadOnly = true;
            txtIgroneKeys.Size = new Size(45, 23);
            txtIgroneKeys.TabIndex = 41;
            // 
            // checkBox1
            // 
            checkBox1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(101, 159);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(51, 21);
            checkBox1.TabIndex = 42;
            checkBox1.Text = "左键";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.Visible = false;
            // 
            // checkBox2
            // 
            checkBox2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(158, 159);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(51, 21);
            checkBox2.TabIndex = 43;
            checkBox2.Text = "中键";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.Visible = false;
            // 
            // checkBox3
            // 
            checkBox3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(215, 159);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(51, 21);
            checkBox3.TabIndex = 44;
            checkBox3.Text = "右键";
            checkBox3.UseVisualStyleBackColor = true;
            checkBox3.Visible = false;
            // 
            // checkBox4
            // 
            checkBox4.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(272, 159);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(58, 21);
            checkBox4.TabIndex = 45;
            checkBox4.Text = "第4键";
            checkBox4.UseVisualStyleBackColor = true;
            checkBox4.Visible = false;
            // 
            // checkBox5
            // 
            checkBox5.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(336, 159);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(58, 21);
            checkBox5.TabIndex = 46;
            checkBox5.Text = "第5键";
            checkBox5.UseVisualStyleBackColor = true;
            checkBox5.Visible = false;
            // 
            // checkBox6
            // 
            checkBox6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(400, 159);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(58, 21);
            checkBox6.TabIndex = 47;
            checkBox6.Text = "第6键";
            checkBox6.UseVisualStyleBackColor = true;
            checkBox6.Visible = false;
            // 
            // btnSetFrom
            // 
            btnSetFrom.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSetFrom.Location = new Point(172, 16);
            btnSetFrom.Name = "btnSetFrom";
            btnSetFrom.Size = new Size(70, 25);
            btnSetFrom.TabIndex = 48;
            btnSetFrom.Text = "迷你";
            btnSetFrom.UseVisualStyleBackColor = true;
            btnSetFrom.Click += btnSetFrom_Click;
            // 
            // textLog
            // 
            textLog.Location = new Point(6, 17);
            textLog.Multiline = true;
            textLog.Name = "textLog";
            textLog.Size = new Size(160, 70);
            textLog.TabIndex = 49;
            // 
            // groupBoxLog
            // 
            groupBoxLog.Controls.Add(trackBar1);
            groupBoxLog.Controls.Add(btnSetFrom);
            groupBoxLog.Controls.Add(textLog);
            groupBoxLog.Location = new Point(12, 186);
            groupBoxLog.Name = "groupBoxLog";
            groupBoxLog.Size = new Size(248, 144);
            groupBoxLog.TabIndex = 50;
            groupBoxLog.TabStop = false;
            groupBoxLog.Text = "日志";
            // 
            // trackBar1
            // 
            trackBar1.Location = new Point(6, 93);
            trackBar1.Maximum = 255;
            trackBar1.Name = "trackBar1";
            trackBar1.Size = new Size(236, 45);
            trackBar1.TabIndex = 50;
            trackBar1.Value = 255;
            trackBar1.Scroll += trackBar1_Scroll;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(lstWindows);
            groupBox2.Location = new Point(9, 12);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(257, 136);
            groupBox2.TabIndex = 51;
            groupBox2.TabStop = false;
            groupBox2.Text = "同步窗口";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(btnGetHandle);
            groupBox1.Controls.Add(txtIgroneKeys);
            groupBox1.Controls.Add(btnClear);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnStart);
            groupBox1.Controls.Add(btnIgroneClear);
            groupBox1.Controls.Add(btnAddIgrone);
            groupBox1.Location = new Point(273, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(270, 136);
            groupBox1.TabIndex = 52;
            groupBox1.TabStop = false;
            groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label1.AutoSize = true;
            label1.Location = new Point(273, 202);
            label1.Name = "label1";
            label1.Size = new Size(158, 34);
            label1.TabIndex = 53;
            label1.Text = "F5：启动同步/关闭同步\r\nF6：启动修工事/关闭修工事";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(571, 342);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Controls.Add(groupBox2);
            Controls.Add(groupBoxLog);
            Controls.Add(checkBox6);
            Controls.Add(checkBox5);
            Controls.Add(checkBox4);
            Controls.Add(checkBox3);
            Controls.Add(checkBox2);
            Controls.Add(checkBox1);
            Controls.Add(label7);
            Name = "MainForm";
            Text = "GreatMingCtu | 自我克隆体肉欲的交织与狂欢";
            //Load += MainForm_Load;
            groupBoxLog.ResumeLayout(false);
            groupBoxLog.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBar1).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label7;
        private Label label6;
        private Button btnIgroneClear;
        private Button btnAddIgrone;
        private Button btnStart;
        private Button btnClear;
        private ListView lstWindows;
        private ColumnHeader colHandle;
        private ColumnHeader colTitle;
        private ColumnHeader colOperation;
        private Button btnGetHandle;
        private TextBox txtIgroneKeys;
        private CheckBox checkBox1;
        private CheckBox checkBox2;
        private CheckBox checkBox3;
        private CheckBox checkBox4;
        private CheckBox checkBox5;
        private CheckBox checkBox6;
        private Button btnSetFrom;
        private TextBox textLog;
        private GroupBox groupBoxLog;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private TrackBar trackBar1;
        private Label label1;
    }
}
