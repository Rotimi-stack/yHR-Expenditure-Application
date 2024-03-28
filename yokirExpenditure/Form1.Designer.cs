namespace yokirExpenditure
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            errorProvider1 = new ErrorProvider(components);
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            lblTotal = new Label();
            button1 = new Button();
            lblReport = new Label();
            panel11 = new Panel();
            listView1 = new ListView();
            panel10 = new Panel();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            btnExpAdd = new Button();
            dtpTo = new DateTimePicker();
            label20 = new Label();
            dtpFrom = new DateTimePicker();
            label19 = new Label();
            btnPrint = new Button();
            btnSearch = new Button();
            textDescription = new TextBox();
            label18 = new Label();
            label17 = new Label();
            label15 = new Label();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel11.SuspendLayout();
            panel10.SuspendLayout();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Margin = new Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1332, 741);
            tabControl1.TabIndex = 3;
            // 
            // tabPage2
            // 
            tabPage2.BorderStyle = BorderStyle.Fixed3D;
            tabPage2.Controls.Add(lblTotal);
            tabPage2.Controls.Add(button1);
            tabPage2.Controls.Add(lblReport);
            tabPage2.Controls.Add(panel11);
            tabPage2.Controls.Add(panel10);
            tabPage2.Location = new Point(4, 28);
            tabPage2.Margin = new Padding(4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4);
            tabPage2.Size = new Size(1324, 709);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Exp OP";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(373, 640);
            lblTotal.Margin = new Padding(4, 0, 4, 0);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(63, 19);
            lblTotal.TabIndex = 9;
            lblTotal.Text = "Total:";
            // 
            // button1
            // 
            button1.Location = new Point(8, 640);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(67, 29);
            button1.TabIndex = 8;
            button1.Text = "Setup";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // lblReport
            // 
            lblReport.AutoSize = true;
            lblReport.Location = new Point(534, 209);
            lblReport.Margin = new Padding(4, 0, 4, 0);
            lblReport.Name = "lblReport";
            lblReport.Size = new Size(63, 19);
            lblReport.TabIndex = 2;
            lblReport.Text = "Report";
            // 
            // panel11
            // 
            panel11.BorderStyle = BorderStyle.Fixed3D;
            panel11.Controls.Add(listView1);
            panel11.Location = new Point(8, 236);
            panel11.Margin = new Padding(4);
            panel11.Name = "panel11";
            panel11.Size = new Size(1307, 400);
            panel11.TabIndex = 1;
            // 
            // listView1
            // 
            listView1.Location = new Point(4, 4);
            listView1.Margin = new Padding(4);
            listView1.Name = "listView1";
            listView1.Size = new Size(1295, 388);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // panel10
            // 
            panel10.BackColor = Color.FromArgb(255, 255, 128);
            panel10.BorderStyle = BorderStyle.Fixed3D;
            panel10.Controls.Add(comboBox2);
            panel10.Controls.Add(comboBox1);
            panel10.Controls.Add(btnExpAdd);
            panel10.Controls.Add(dtpTo);
            panel10.Controls.Add(label20);
            panel10.Controls.Add(dtpFrom);
            panel10.Controls.Add(label19);
            panel10.Controls.Add(btnPrint);
            panel10.Controls.Add(btnSearch);
            panel10.Controls.Add(textDescription);
            panel10.Controls.Add(label18);
            panel10.Controls.Add(label17);
            panel10.Controls.Add(label15);
            panel10.Location = new Point(8, 8);
            panel10.Margin = new Padding(4);
            panel10.Name = "panel10";
            panel10.Size = new Size(1307, 191);
            panel10.TabIndex = 0;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(576, 42);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(227, 27);
            comboBox2.TabIndex = 14;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(187, 38);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(227, 27);
            comboBox1.TabIndex = 13;
            // 
            // btnExpAdd
            // 
            btnExpAdd.Location = new Point(1174, 147);
            btnExpAdd.Margin = new Padding(4);
            btnExpAdd.Name = "btnExpAdd";
            btnExpAdd.Size = new Size(66, 29);
            btnExpAdd.TabIndex = 12;
            btnExpAdd.Text = "Add";
            btnExpAdd.UseVisualStyleBackColor = true;
            btnExpAdd.Click += btnExpAdd_Click;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(842, 107);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(286, 26);
            dtpTo.TabIndex = 11;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label20.Location = new Point(803, 108);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(32, 18);
            label20.TabIndex = 10;
            label20.Text = "To:";
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(504, 107);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(292, 26);
            dtpFrom.TabIndex = 9;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label19.Location = new Point(456, 109);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(48, 18);
            label19.TabIndex = 8;
            label19.Text = "From:";
            // 
            // btnPrint
            // 
            btnPrint.Location = new Point(1096, 147);
            btnPrint.Margin = new Padding(4);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(70, 29);
            btnPrint.TabIndex = 7;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = true;
            btnPrint.Click += btnPrint_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1013, 147);
            btnSearch.Margin = new Padding(4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 29);
            btnSearch.TabIndex = 6;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // textDescription
            // 
            textDescription.Location = new Point(188, 109);
            textDescription.Margin = new Padding(4);
            textDescription.Name = "textDescription";
            textDescription.Size = new Size(226, 26);
            textDescription.TabIndex = 4;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label18.Location = new Point(76, 113);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(104, 18);
            label18.TabIndex = 2;
            label18.Text = "Description:";
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label17.Location = new Point(457, 51);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(112, 18);
            label17.TabIndex = 1;
            label17.Text = "Exp Type Sub:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label15.Location = new Point(100, 47);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(80, 18);
            label15.TabIndex = 0;
            label15.Text = "Exp Type:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.DarkMagenta;
            ClientSize = new Size(1337, 754);
            Controls.Add(tabControl1);
            Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "yHR";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            panel11.ResumeLayout(false);
            panel10.ResumeLayout(false);
            panel10.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private ErrorProvider errorProvider1;
        private TabControl tabControl1;
        private TabPage tabPage2;
        private Panel panel10;
        private Label label18;
        private Label label17;
        private Label label15;
        private Label lblReport;
        private Panel panel11;
        private ListView listView1;
        private Button btnPrint;
        private Button btnSearch;
        private TextBox textDescription;
        private DateTimePicker dtpTo;
        private Label label20;
        private DateTimePicker dtpFrom;
        private Label label19;
        private Button button1;
        private Button btnExpAdd;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Label lblTotal;
    }
}
