namespace yHR
{
    partial class GenerateExpTotal
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
            panel1 = new Panel();
            label1 = new Label();
            label2 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label3 = new Label();
            dateTimePicker2 = new DateTimePicker();
            comboBox1 = new ComboBox();
            panel2 = new Panel();
            button1 = new Button();
            label4 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            listView1 = new ListView();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(listView1);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(3, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(518, 487);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(3, 112);
            label1.Name = "label1";
            label1.Size = new Size(80, 18);
            label1.TabIndex = 0;
            label1.Text = "Exp Type:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(3, 67);
            label2.Name = "label2";
            label2.Size = new Size(48, 18);
            label2.TabIndex = 2;
            label2.Text = "From:";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(57, 62);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(212, 23);
            dateTimePicker1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(281, 66);
            label3.Name = "label3";
            label3.Size = new Size(32, 18);
            label3.TabIndex = 4;
            label3.Text = "To:";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(310, 61);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(190, 23);
            dateTimePicker2.TabIndex = 5;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(78, 107);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(169, 23);
            comboBox1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(button1);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(dateTimePicker1);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(dateTimePicker2);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(508, 214);
            panel2.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(425, 184);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 7;
            button1.Text = "Generate";
            button1.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label4.Location = new Point(208, 7);
            label4.Name = "label4";
            label4.Size = new Size(80, 22);
            label4.TabIndex = 8;
            label4.Text = "Expense";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(218, 225);
            label5.Name = "label5";
            label5.Size = new Size(56, 18);
            label5.TabIndex = 1;
            label5.Text = "Report";
            // 
            // panel3
            // 
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(label4);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(497, 42);
            panel3.TabIndex = 8;
            // 
            // listView1
            // 
            listView1.Location = new Point(3, 246);
            listView1.Name = "listView1";
            listView1.Size = new Size(508, 231);
            listView1.TabIndex = 2;
            listView1.UseCompatibleStateImageBehavior = false;
            // 
            // GenerateExpTotal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(897, 496);
            Controls.Add(panel1);
            Name = "GenerateExpTotal";
            Text = "GenerateExpTotal";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label2;
        private Label label1;
        private Panel panel2;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private Label label3;
        private ComboBox comboBox1;
        private Label label5;
        private Label label4;
        private Button button1;
        private Panel panel3;
        private ListView listView1;
    }
}