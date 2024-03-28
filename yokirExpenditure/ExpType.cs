using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using yHR.Common.Data;
using yHR.DataAccess.Desktop;
using yHR.Desktop.Controller;
using yokirExpenditure;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ListView = System.Windows.Forms.ListView;

namespace yHR
{
    public partial class ExpType : Form
    {

        private ISetUpController _setUpController;
        private Expenditures _exp;
        private IExpenditureController _expcontroller;
        private CodeExpType _expType;
        private CodeExpSubType _expSubType;
        public readonly ISQL _db;
        public ExpType()
        {
            InitializeComponent();
            SetCurvedEdges();
            _setUpController = new SetUpController();
            _exp = new Expenditures();
            _expcontroller = new ExpenditureController();
            _expType = new CodeExpType();
            _expSubType = new CodeExpSubType();
            LoadCodeTable();


            LoadListView(listView1, Utility.CodeTable.CodeExpType);
            LoadListView(listView2, Utility.CodeTable.CodeExpSubType);


            listView1.SelectedIndexChanged += ListView_SelectedIndexChanged;
            listView2.SelectedIndexChanged += ListView_SelectedIndexChanged;


            Label titleLabel = new Label();
            titleLabel.Text = "yHR";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 50;
            this.Controls.Add(titleLabel);

            ClearInputFields();


        }

        private void LoadListView(System.Windows.Forms.ListView listView, Utility.CodeTable codeTable)
        {
            // Get the data for the specified CodeTable
            List<CodeTypeData> data = _setUpController.GetCodeTable(codeTable);

            // Clear existing items in the ListView
            listView.Items.Clear();

            // Add columns to the ListView
            listView.Columns.Add("Code", 180, HorizontalAlignment.Left);
            listView.Columns.Add("Description", 212, HorizontalAlignment.Left);
            listView.View = View.Details;
            listView.GridLines = true;
            listView.FullRowSelect = true;

            // Populate the ListView with data
            foreach (CodeTypeData item in data)
            {
                ListViewItem listViewItem = new ListViewItem(item.Code);
                listViewItem.SubItems.Add(item.Descrip);
                listView.Items.Add(listViewItem);
            }

        }


        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView.SelectedItems[0];

                if (listView == listView1)
                {
                    txtCode.Text = selectedItem.SubItems[0].Text;
                    txtDescription.Text = selectedItem.SubItems[1].Text;
                }
                else if (listView == listView2)
                {
                    txtSubTypeCode.Text = selectedItem.SubItems[0].Text;
                    txtSubDescrip.Text = selectedItem.SubItems[1].Text;
                }
            }




        }

        private void SetCurvedEdges()
        {
            // Define the new width and height for the form (adjust as needed)
            int newWidth = 1400;
            int newHeight = 1000;

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
        protected void LoadCodeTable()
        {

            List<CodeTypeData> expType2 = _setUpController.GetCodeTable(Utility.CodeTable.CodeExpType);

            cmbExpTyp2.DataSource = null;
            cmbExpTyp2.Items.Clear();
            cmbExpTyp2.Items.Add("");


            if (expType2.Count > 0)
            {
                cmbExpTyp2.DataSource = expType2;
                cmbExpTyp2.ValueMember = "Code";
                cmbExpTyp2.DisplayMember = "Descrip";
            }

            cmbExpTyp2.DropDownStyle = ComboBoxStyle.DropDownList;


        }

        private void ClearInputFields()
        {
            // Clear input fields
            txtCode.Text = "";
            txtDescription.Text = "";

            txtSubTypeCode.Text = "";
            txtSubDescrip.Text = "";

            cmbExpTyp2.SelectedIndex = -1;
            cmbExpTyp2.Text = "";


            cmbExpTyp2.Update();




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

        private void btnExpSubAdd_Click(object sender, EventArgs e)
        {

            Control ctlr = this;
            string strError = null;


            _expSubType.Code = txtSubTypeCode.Text;
            _expSubType.Descrip = txtSubDescrip.Text;
            _expSubType.ExpType = cmbExpTyp2.Text;


            if (string.IsNullOrWhiteSpace(_expSubType.Code) || _expSubType.Code.Length > 4)
            {
                ctlr = txtSubTypeCode;
                strError = "Please enter a valid Code with a maximum length of Four characters";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);

                return;
            }
            if (string.IsNullOrWhiteSpace(_expSubType.Descrip))
            {
                ctlr = txtSubDescrip;
                strError = "Please enter Description";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            if (cmbExpTyp2.SelectedItem != null)
            {
                _expSubType.ExpType = cmbExpTyp2.SelectedValue.ToString();

            }
            else
            {
                ctlr = cmbExpTyp2;
                strError = "Please enter Expenditure Type";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }


            bool saveResult = _expcontroller.SaveExpSubType(_expSubType);
            LoadListView(listView2, Utility.CodeTable.CodeExpSubType);

            if (saveResult)
            {

                DisplayMessage("Expenditure Sub Type added successfully!", MessageBoxIcon.Information);
                ClearInputFields();

            }

            else
            {
                DisplayMessage("Error occured while saving! Expenditure Sub Type", MessageBoxIcon.Information);
                ClearInputFields();
            }
        }

        private void btnAddExpType_Click(object sender, EventArgs e)
        {

            Control ctlr = this;
            string strError = null;


            _expType.Code = txtCode.Text;
            _expType.Descrip = txtDescription.Text;

            if (string.IsNullOrWhiteSpace(_expType.Code) || _expType.Code.Length > 3)
            {
                ctlr = txtCode;
                strError = "Please enter a valid Code with a maximum length of three characters";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);

                return;
            }
            if (string.IsNullOrWhiteSpace(_expType.Descrip))
            {
                ctlr = txtDescription;
                strError = "Please enter Description";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            bool saveResult = _expcontroller.SaveExpType(_expType);
            LoadListView(listView1, Utility.CodeTable.CodeExpType);
            LoadCodeTable();

            if (saveResult)
            {

                DisplayMessage("Expenditure Type added successfully!", MessageBoxIcon.Information);
                ClearInputFields();
            }

            else
            {
                DisplayMessage("Error occured while saving! Expenditure Type", MessageBoxIcon.Information);
                ClearInputFields();
            }

        }

        private void btnEditExpTyp_Click(object sender, EventArgs e)
        {
            Control ctlr = this;
            string strError = null;


            _expType.Code = txtCode.Text;
            _expType.Descrip = txtDescription.Text;

            if (string.IsNullOrWhiteSpace(_expType.Code) || _expType.Code.Length > 3)
            {
                ctlr = txtCode;
                strError = "Please enter a valid Code with a maximum length of three characters";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);

                return;
            }
            if (string.IsNullOrWhiteSpace(_expType.Descrip))
            {
                ctlr = txtDescription;
                strError = "Please enter Description";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            bool saveResult = _expcontroller.UpdateExpType(_expType);
            LoadListView(listView1, Utility.CodeTable.CodeExpType);

            if (saveResult)
            {

                DisplayMessage("Expenditure Type Updated successfully!", MessageBoxIcon.Information);
                ClearInputFields();
            }

            else
            {
                DisplayMessage("Error occured while Updating! Expenditure Type", MessageBoxIcon.Information);
                ClearInputFields();
            }
        }

        private void btnExpSubTypUpdate_Click(object sender, EventArgs e)
        {
            Control ctlr = this;
            string strError = null;


            _expSubType.Code = txtSubTypeCode.Text;
            _expSubType.Descrip = txtSubDescrip.Text;

            if (string.IsNullOrWhiteSpace(_expSubType.Code) || _expSubType.Code.Length > 3)
            {
                ctlr = txtSubTypeCode;
                strError = "Please enter a valid Code with a maximum length of three characters";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);

                return;
            }
            if (string.IsNullOrWhiteSpace(_expSubType.Descrip))
            {
                ctlr = txtSubDescrip;
                strError = "Please enter Description";
                errorProvider1.SetError(ctlr, strError);
                DisplayMessage(strError, MessageBoxIcon.Error);
                return;
            }

            bool saveResult = _expcontroller.UpdateExpSubType(_expSubType);
            LoadListView(listView2, Utility.CodeTable.CodeExpSubType);

            if (saveResult)
            {

                DisplayMessage("Expenditure Sub Type Updated successfully!", MessageBoxIcon.Information);
            }

            else
            {
                DisplayMessage("Error occured while Updating! Expenditure Type", MessageBoxIcon.Information);
            }
        }
    }
}
