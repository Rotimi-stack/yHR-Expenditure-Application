namespace yHR
{
    partial class CreateExp
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
            components = new System.ComponentModel.Container();
            panel1 = new Panel();
            panel2 = new Panel();
            panel3 = new Panel();
            dateTimePicker2 = new DateTimePicker();
            cmbExpSub = new ComboBox();
            label7 = new Label();
            cmbExTyp = new ComboBox();
            label6 = new Label();
            btnAddExp = new Button();
            txtAmount = new TextBox();
            label5 = new Label();
            label3 = new Label();
            txtDescrip = new TextBox();
            label2 = new Label();
            panel4 = new Panel();
            label1 = new Label();
            errorProvider1 = new ErrorProvider(components);
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkMagenta;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(panel2);
            panel1.Location = new Point(3, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(491, 537);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.Fixed3D;
            panel2.Controls.Add(panel3);
            panel2.Controls.Add(panel4);
            panel2.Location = new Point(8, 4);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(475, 516);
            panel2.TabIndex = 1;
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.BorderStyle = BorderStyle.Fixed3D;
            panel3.Controls.Add(dateTimePicker2);
            panel3.Controls.Add(cmbExpSub);
            panel3.Controls.Add(label7);
            panel3.Controls.Add(cmbExTyp);
            panel3.Controls.Add(label6);
            panel3.Controls.Add(btnAddExp);
            panel3.Controls.Add(txtAmount);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(txtDescrip);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(5, 62);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(462, 421);
            panel3.TabIndex = 0;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(115, 197);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(278, 23);
            dateTimePicker2.TabIndex = 22;
            // 
            // cmbExpSub
            // 
            cmbExpSub.FormattingEnabled = true;
            cmbExpSub.Location = new Point(203, 58);
            cmbExpSub.Margin = new Padding(4);
            cmbExpSub.Name = "cmbExpSub";
            cmbExpSub.Size = new Size(190, 23);
            cmbExpSub.TabIndex = 21;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.Location = new Point(4, 63);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(176, 18);
            label7.TabIndex = 20;
            label7.Text = "Expenditure Sub Type:";
            // 
            // cmbExTyp
            // 
            cmbExTyp.FormattingEnabled = true;
            cmbExTyp.Location = new Point(174, 13);
            cmbExTyp.Margin = new Padding(4);
            cmbExTyp.Name = "cmbExTyp";
            cmbExTyp.Size = new Size(219, 23);
            cmbExTyp.TabIndex = 19;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label6.Location = new Point(4, 18);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(144, 18);
            label6.TabIndex = 18;
            label6.Text = "Expenditure Type:";
            // 
            // btnAddExp
            // 
            btnAddExp.BackColor = Color.FromArgb(255, 255, 128);
            btnAddExp.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            btnAddExp.Location = new Point(310, 274);
            btnAddExp.Margin = new Padding(4);
            btnAddExp.Name = "btnAddExp";
            btnAddExp.Size = new Size(83, 39);
            btnAddExp.TabIndex = 17;
            btnAddExp.Text = "Add";
            btnAddExp.UseVisualStyleBackColor = false;
            btnAddExp.Click += btnAddExp_Click_1;
            // 
            // txtAmount
            // 
            txtAmount.Location = new Point(115, 144);
            txtAmount.Margin = new Padding(4);
            txtAmount.Name = "txtAmount";
            txtAmount.Size = new Size(278, 23);
            txtAmount.TabIndex = 8;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(4, 149);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(64, 18);
            label5.TabIndex = 4;
            label5.Text = "Amount:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(4, 202);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(48, 18);
            label3.TabIndex = 2;
            label3.Text = "Date:";
            // 
            // txtDescrip
            // 
            txtDescrip.Location = new Point(165, 98);
            txtDescrip.Margin = new Padding(4);
            txtDescrip.Name = "txtDescrip";
            txtDescrip.Size = new Size(228, 23);
            txtDescrip.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Consolas", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(4, 103);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(104, 18);
            label2.TabIndex = 0;
            label2.Text = "Description:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(255, 255, 128);
            panel4.BorderStyle = BorderStyle.Fixed3D;
            panel4.Controls.Add(label1);
            panel4.Location = new Point(3, 3);
            panel4.Margin = new Padding(4);
            panel4.Name = "panel4";
            panel4.Size = new Size(464, 51);
            panel4.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Consolas", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(167, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(117, 19);
            label1.TabIndex = 0;
            label1.Text = "Expenditures";
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // CreateExp
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(506, 546);
            Controls.Add(panel1);
            Name = "CreateExp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CreateExp";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private ComboBox cmbExpSub;
        private Label label7;
        private ComboBox cmbExTyp;
        private Label label6;
        private Button btnAddExp;
        private TextBox txtAmount;
        private Label label5;
        private Label label3;
        private TextBox txtDescrip;
        private Label label2;
        private Panel panel4;
        private Label label1;
        private ErrorProvider errorProvider1;
        private DateTimePicker dateTimePicker2;
    }
}