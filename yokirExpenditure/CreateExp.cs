using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yHR.Common.Data;
using yHR.DataAccess.Desktop;
using yHR.Desktop.Controller;

namespace yHR
{
    public partial class CreateExp : Form
    {
        private ISetUpController _setUpController;
        private Expenditures _exp;
        private IExpenditureController _expcontroller;
        private CodeExpType _expType;
        private CodeExpSubType _expSubType;
        public readonly ISQL _db;
        public CreateExp()
        {
            InitializeComponent();
            SetCurvedEdges();
            _setUpController = new SetUpController();
            _exp = new Expenditures();
            _expcontroller = new ExpenditureController();
            _expType = new CodeExpType();
            _expSubType = new CodeExpSubType();
            LoadCodeTable();
            ClearInputFields();


           
          


            dateTimePicker2.Value = DateTime.Now;
            

        }


        protected void LoadCodeTable()
        {
            List<CodeTypeData> expType = _setUpController.GetCodeTable(Utility.CodeTable.CodeExpType);

            cmbExTyp.DataSource = null;
            cmbExTyp.Items.Clear();

            cmbExTyp.Items.Add("");
            if (expType.Count > 0)
            {
                cmbExTyp.DataSource = expType;
                cmbExTyp.ValueMember = "Code";
                cmbExTyp.DisplayMember = "Descrip";
            }
            cmbExTyp.DropDownStyle = ComboBoxStyle.DropDownList;



           

            List<CodeTypeData> expSub = _setUpController.GetCodeTable(Utility.CodeTable.CodeExpSubType);
            cmbExpSub.DataSource = null;
            cmbExpSub.Items.Clear();

            cmbExpSub.Items.Add("");

            if (expSub.Count > 0)
            {


                cmbExpSub.DataSource = expSub;
                cmbExpSub.ValueMember = "Code";
                cmbExpSub.DisplayMember = "Descrip";

            }
            cmbExpSub.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void SetCurvedEdges()
        {
            // Define the new width and height for the form (adjust as needed)
            int newWidth = 730;
            int newHeight = 900;

            // Define the radius of the curves (adjust as needed)
            int radius = 20;

            // Create a GraphicsPath to define the shape
            GraphicsPath path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius * 2, radius * 2), 180, 90);
            path.AddArc(new Rectangle(newWidth - radius * 2, 0, radius * 2, radius * 2), -90, 90);
            path.AddArc(new Rectangle(newWidth - radius * 2, newHeight - radius * 2, radius * 2, radius * 2), 0, 90);
            path.AddArc(new Rectangle(0, newHeight - radius * 2, radius * 2, radius * 2), 90, 90);
            path.CloseFigure();

            // Set the form's region to the defined shape
            this.Region = new Region(path);

            // Set the new size of the form
            this.Size = new Size(newWidth, newHeight);
        }
        protected void DisplayMessage(string message, MessageBoxIcon icon, int timeout = 1000)
        {
            MessageBox.Show(message, "Expenditures", MessageBoxButtons.OK, icon);
            Task.Delay(timeout).ContinueWith(t =>
            {
                if (IsHandleCreated)
                {
                    Invoke(new Action(() =>
                    {
                        errorProvider1.Clear();
                    }));
                }
            });
        }

        private void ClearInputFields()
        {
            // Clear input fields
            txtDescrip.Text = "";
            txtAmount.Text = "";

            cmbExTyp.SelectedIndex = -1;
            cmbExpSub.SelectedIndex = -1;

            cmbExTyp.Text = "";
            cmbExpSub.Text = "";




            cmbExTyp.Update();
            cmbExpSub.Update();


        }

        private void btnAddExp_Click_1(object sender, EventArgs e)
        {
            {
              
                Control ctlr = this;
                string strError = null;

                _exp.Description = txtDescrip.Text;
                _exp.ExpType = cmbExTyp.Text;
                _exp.ExpTypeSub = cmbExpSub.Text;



                if (string.IsNullOrWhiteSpace(_exp.Description))
                {
                    ctlr = txtDescrip;
                    strError = "Please enter Description";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }



                if (cmbExTyp.SelectedIndex != -1)
                {
                    _exp.ExpType = cmbExTyp.SelectedValue.ToString();

                }

                else
                {
                    ctlr = cmbExTyp;
                    strError = "Please enter Expenditure Type";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;

                }


                if (cmbExpSub.SelectedIndex != -1)
                {
                    _exp.ExpTypeSub = cmbExpSub.SelectedValue?.ToString();

                }


                if (decimal.TryParse(txtAmount.Text.Replace(",",""), out decimal amount))
                {
                    _exp.Amount = amount;
                    txtAmount.Text = string.Format(CultureInfo.InvariantCulture,"{0:N}", amount);
                }
                else
                {
                    ctlr = txtAmount;
                    strError = "Please input Amount";
                    errorProvider1.SetError(ctlr, strError);
                    DisplayMessage(strError, MessageBoxIcon.Error);
                    return;
                }


                _exp.DateCreated = dateTimePicker2.Value.Date;
                bool saveResult = _expcontroller.Save(_exp);

                if (saveResult)
                {
                    
                    DisplayMessage("Expenditure added successfully!", MessageBoxIcon.Information);
                    ClearInputFields();
                    //LoadCodeTable();
                }

                else
                {
                    DisplayMessage("Error occured while saving!", MessageBoxIcon.Information);
                    ClearInputFields();
                }
            }
        }
    }
}



//dateTimePicker2.Value = DateTimePicker.MinimumDateTime;
//dateTimePicker2.ValueChanged += dateTimePicker2_ValueChanged;
//private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
//{
//    _exp.DateCreated = dateTimePicker2.Value;
//}