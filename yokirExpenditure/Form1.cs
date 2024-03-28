
using System.Drawing.Drawing2D;
using System.Text;
using yHR;
using yHR.Common.Data;
using yHR.DataAccess.Desktop;
using yHR.Desktop.Controller;
using BoldReports.Web;
using System.IO;
using ReportDataSource = BoldReports.Web.ReportDataSource;
using Rectangle = System.Drawing.Rectangle;
using Size = System.Drawing.Size;

namespace yokirExpenditure
{
    public partial class Form1 : Form
    {
        private ISetUpController _setUpController;
        private Expenditures _exp;
        private IExpenditureController _expcontroller;
        private CodeExpType _expType;
        private CodeExpSubType _expSubType;
        public readonly ISQL _db;
        public Form1()
        {
            InitializeComponent();
            SetCurvedEdges();
            _setUpController = new SetUpController();
            _exp = new Expenditures();
            _expcontroller = new ExpenditureController();
            _expType = new CodeExpType();
            _expSubType = new CodeExpSubType();

            DateTime currentDate = DateTime.Now; // Get current date and time

            dtpFrom.MinDate = new DateTime(2023, 1, 1);
            dtpTo.MinDate = new DateTime(2024, 1, 1);

            dtpFrom.MaxDate = currentDate; // Set maximum date to current date and time
            dtpTo.MaxDate = currentDate; // Set maximum date to current date and time

            // Set default value to current date and time if it falls within the allowable range
            dtpFrom.Value = currentDate >= dtpFrom.MinDate && currentDate <= dtpFrom.MaxDate ? currentDate : dtpFrom.MinDate;
            dtpTo.Value = currentDate >= dtpTo.MinDate && currentDate <= dtpTo.MaxDate ? currentDate : dtpTo.MinDate;



            ListView_Settings2();
            LoadCodeTable();
            Label titleLabel = new Label();
            titleLabel.Text = "yHR";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.Dock = DockStyle.Top;
            titleLabel.Height = 50;
            this.Controls.Add(titleLabel);

            ClearInputFields();
        }


        private void ClearInputFields()
        {

            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;

            comboBox1.Text = "";
            comboBox2.Text = "";

            textDescription.Text = "";

            comboBox1.Update();
            comboBox2.Update();
            textDescription.Update();



        }

        private void SetCurvedEdges()
        {
            // Define the new width and height for the form (adjust as needed)
            //int newWidth = 1330;
            //int newHeight = 700;

            int newWidth = 1900;
            int newHeight = 1100;

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

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void ListView_Settings2()
        {

            listView1.Items.Clear();
            listView1.Columns.Add("Description", 900, HorizontalAlignment.Left);
            listView1.Columns.Add("Amount", 200, HorizontalAlignment.Left);
            listView1.Columns.Add("ExpType", 260, HorizontalAlignment.Left);
            listView1.Columns.Add("ExpTypeSub", 260, HorizontalAlignment.Left);
            listView1.Columns.Add("DateCreated", 200, HorizontalAlignment.Left);




            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;

        }

        protected void LoadCodeTable()
        {

            List<CodeTypeData> expType = _setUpController.GetCodeTable(Utility.CodeTable.CodeExpType);
            List<CodeTypeData> expType2 = _setUpController.GetCodeTable(Utility.CodeTable.CodeExpType);

            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            comboBox1.Items.Add("");


            if (expType2.Count > 0)
            {
                comboBox1.DataSource = expType;
                comboBox1.ValueMember = "Code";
                comboBox1.DisplayMember = "Descrip";
            }

            List<CodeTypeData> expSub = _setUpController.GetCodeTable(Utility.CodeTable.CodeExpSubType);
            comboBox2.DataSource = null;
            comboBox2.Items.Clear();

            comboBox2.Items.Add("");

            if (expSub.Count > 0)
            {


                comboBox2.DataSource = expSub;
                comboBox2.ValueMember = "Code";
                comboBox2.DisplayMember = "Descrip";

            }

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;

        }



        protected void DisplayMessage(string message, MessageBoxIcon icon, int timeout = 1000)
        {
            MessageBox.Show(message, "Expenditures", MessageBoxButtons.OK, icon);
            Task.Delay(timeout).ContinueWith(t =>
            {
                if (IsHandleCreated)
                {
                    Invoke(new System.Action(() =>
                    {
                        errorProvider1.Clear();
                    }));
                }
            });
        }

        string _strFilter = "";
        string _strSort;
        private void BuildSelect()
        {
            string sub = Convert.ToString(comboBox2.SelectedValue);
            string type = Convert.ToString(comboBox1.SelectedValue);
            string Description = textDescription.Text;

            DateTime dtFrom = this.dtpFrom.Value.Date;
            DateTime dtto = this.dtpTo.Value.Date;

            string strWhere = "";
            _strFilter = "";
            _strSort = "Description,ExpType,ExpTypeSub,DateCreated";

            if (dtFrom != DateTimePicker.MinimumDateTime && dtto != DateTimePicker.MinimumDateTime)
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere += "(";

                _strFilter = string.Format("DateCreated BETWEEN '{0:yyyy-MM-dd}' AND '{1:yyyy-MM-dd}'", dtFrom, dtto);
                strWhere += _strFilter + ")";
            }

            if (!string.IsNullOrEmpty(Description))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter = string.Format("Description LIKE '%{0}%' ", Description);
                strWhere += _strFilter + ")";
            }

            if (!string.IsNullOrEmpty(type))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter = string.Format("ExpType = '{0}' ", type); // Append to the existing filter
                strWhere += _strFilter + ")";
            }

            if (!string.IsNullOrEmpty(sub))
            {
                if (strWhere.Length > 0)
                    strWhere += " AND (";
                else
                    strWhere = " (";

                _strFilter = string.Format("ExpTypeSub = '{0}' ", sub); // Append to the existing filter
                strWhere += _strFilter + ")";
            }

            if (strWhere.Length > 0)
                _strFilter = strWhere;
        }



        ExpenditureController _expCont = new ExpenditureController();
        private bool DisplayExpenditureSearchResult(List<Expenditures> searchList)
        {
            if (searchList == null || searchList.Count == 0)
            {
                return false; // No items to display
            }

            foreach (Expenditures expenditure in searchList)
            {
                //Note the items here must be arranged accordingly to how it is coming from the db, so that it does not take a value of a column and put it in another column
                ListViewItem listViewItem = new ListViewItem(expenditure.Description);
                listViewItem.SubItems.Add(expenditure.Amount.ToString()); // Assuming Amount is a decimal
                listViewItem.SubItems.Add(expenditure.ExpTypeDescrip);
                listViewItem.SubItems.Add(expenditure.ExpSubTypeDescrip);
                listViewItem.SubItems.Add(expenditure.DateCreated.ToString("yyyy-MM-dd")); // Adjust the format as needed

                listView1.Items.Add(listViewItem);
            }

            return true;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            listView1.Items.Clear();
            BuildSelect();
            List<Expenditures> searchList = _expCont.Search(_strFilter, _strSort);
            if (searchList.Count > 0)
            {
                DisplayExpenditureSearchResult(searchList);
                decimal totalAmount = searchList.Sum(item => item.Amount);


                lblTotal.Text = $"Total Amount is:{totalAmount.ToString("N")}";
                lblReport.Text = $"number of Expenditures found is: {searchList.Count}";
                ClearInputFields();


            }
            else
            {
                lblReport.Text = "No Expenditures matching specified criterion found!";

                lblTotal.Text = "Total Amount is:0.00";
                ClearInputFields();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExpType expTypeForm = new ExpType();
            expTypeForm.ShowDialog();
        }

        private void btnExpAdd_Click(object sender, EventArgs e)
        {
            CreateExp exp = new CreateExp();
            exp.ShowDialog();

        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            BuildSelect();

            List<Expenditures> searchList = _expCont.Search(_strFilter, _strSort);
            if (searchList.Count > 0)
            {
                // Create an instance of PdfGenerator
                PdfGenerator pdfGenerator = new PdfGenerator();

                // Specify a common file name for the PDF
                string fileName = "ExpenditureReport.pdf";

                // Call the PrintToPdf method with the list of items
                pdfGenerator.PrintToPdf(fileName, listView1);

                lblReport.Text = "PDF Report generated successfully!";

            }
            else
            {
                lblReport.Text = "No items matching specified criterion found!";
            }
        }

      






    }
}
