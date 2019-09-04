namespace dev.jerry_h.pc_tools.TestApplication
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeviceListRefresh = new System.Windows.Forms.Button();
            this.cmbDeviceList = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblResolution = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.txtCmdTest = new System.Windows.Forms.TextBox();
            this.txtCmdParsedOutput = new System.Windows.Forms.TextBox();
            this.btnCmdCompiler = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 96);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(257, 52);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LongClick";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(122, 19);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(52, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "2000";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(64, 19);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(52, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.Text = "580";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(52, 20);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "300";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnDeviceListRefresh);
            this.groupBox2.Controls.Add(this.cmbDeviceList);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(460, 55);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Android device";
            // 
            // btnDeviceListRefresh
            // 
            this.btnDeviceListRefresh.Location = new System.Drawing.Point(386, 22);
            this.btnDeviceListRefresh.Name = "btnDeviceListRefresh";
            this.btnDeviceListRefresh.Size = new System.Drawing.Size(60, 23);
            this.btnDeviceListRefresh.TabIndex = 4;
            this.btnDeviceListRefresh.Text = "Refresh";
            this.btnDeviceListRefresh.UseVisualStyleBackColor = true;
            this.btnDeviceListRefresh.Click += new System.EventHandler(this.btnDeviceListRefresh_Click);
            // 
            // cmbDeviceList
            // 
            this.cmbDeviceList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeviceList.FormattingEnabled = true;
            this.cmbDeviceList.Location = new System.Drawing.Point(31, 22);
            this.cmbDeviceList.Name = "cmbDeviceList";
            this.cmbDeviceList.Size = new System.Drawing.Size(349, 23);
            this.cmbDeviceList.TabIndex = 0;
            this.cmbDeviceList.SelectedIndexChanged += new System.EventHandler(this.cmbDeviceList_SelectedIndexChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.textBox6);
            this.groupBox3.Controls.Add(this.button2);
            this.groupBox3.Location = new System.Drawing.Point(275, 96);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 52);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Click";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(64, 19);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(53, 20);
            this.textBox5.TabIndex = 3;
            this.textBox5.Text = "580";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(6, 19);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(52, 20);
            this.textBox6.TabIndex = 2;
            this.textBox6.Text = "300";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(122, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblResolution);
            this.groupBox4.Location = new System.Drawing.Point(478, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(72, 52);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Resolution";
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(15, 24);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(0, 13);
            this.lblResolution.TabIndex = 0;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(496, 96);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(210, 229);
            this.treeView1.TabIndex = 5;
            // 
            // txtCmdTest
            // 
            this.txtCmdTest.Location = new System.Drawing.Point(18, 154);
            this.txtCmdTest.Multiline = true;
            this.txtCmdTest.Name = "txtCmdTest";
            this.txtCmdTest.Size = new System.Drawing.Size(374, 49);
            this.txtCmdTest.TabIndex = 6;
            this.txtCmdTest.Text = "VAR a1 = DEV1.Actions.Swip(345,123) //Test Remark\r\nVAR a2 = (1+2)*3-4*((5+90/10)-" +
    "1)+1";
            this.txtCmdTest.TextChanged += new System.EventHandler(this.txtCmdTest_TextChanged);
            // 
            // txtCmdParsedOutput
            // 
            this.txtCmdParsedOutput.Location = new System.Drawing.Point(18, 209);
            this.txtCmdParsedOutput.Multiline = true;
            this.txtCmdParsedOutput.Name = "txtCmdParsedOutput";
            this.txtCmdParsedOutput.ReadOnly = true;
            this.txtCmdParsedOutput.Size = new System.Drawing.Size(374, 79);
            this.txtCmdParsedOutput.TabIndex = 8;
            // 
            // btnCmdCompiler
            // 
            this.btnCmdCompiler.Location = new System.Drawing.Point(398, 154);
            this.btnCmdCompiler.Name = "btnCmdCompiler";
            this.btnCmdCompiler.Size = new System.Drawing.Size(60, 23);
            this.btnCmdCompiler.TabIndex = 9;
            this.btnCmdCompiler.Text = "Compiler";
            this.btnCmdCompiler.UseVisualStyleBackColor = true;
            this.btnCmdCompiler.Click += new System.EventHandler(this.btnCmdCompiler_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(397, 180);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "Run";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 392);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnCmdCompiler);
            this.Controls.Add(this.txtCmdParsedOutput);
            this.Controls.Add(this.txtCmdTest);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmbDeviceList;
        private System.Windows.Forms.Button btnDeviceListRefresh;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.TextBox txtCmdTest;
        private System.Windows.Forms.TextBox txtCmdParsedOutput;
        private System.Windows.Forms.Button btnCmdCompiler;
        private System.Windows.Forms.Button button3;
    }
}

