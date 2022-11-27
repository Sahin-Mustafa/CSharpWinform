using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Expenses
{
    public partial class Home : Form
    {
        private List<Expense> expensesList = new List<Expense>();
        private List<Expense> employeeExpenses=new List<Expense>();
        private Employee employee;
        private Expense expense;
        private DataGridViewCellEventArgs mouseLocation;

        public Home(Employee employe)
        {
            InitializeComponent();
            this.employee = employe;
        }
        //Events of page
        private void Home_Load(object sender, EventArgs e)
        {
            expensesList = FileOperations.GetExpenses();
            lbEmployeeInfo.Text = $"{employee.EmployeeFullName}-{employee.EmployeeType}";

            if (employee.EmployeeType.ToLower() == "worker")
            {
                foreach (Expense expense in expensesList)
                {
                    if (expense.Spender_Id == employee.EmployeeId)
                    {
                        employeeExpenses.Add(expense);
                    }
                }
            }
            else if (employee.EmployeeType.ToLower() == "manager")
            {
                foreach (Expense expense in expensesList)
                {
                    if (expense.Status.ToLower() != "paid")
                    {
                        employeeExpenses.Add(expense);
                    }
                }
                dgvExpenseList.ContextMenuStrip = contextMenuManager;
            }
            else
            {
                employeeExpenses = expensesList;
                pnlExpenseInfo.Enabled = false;
                pnlAccountant.Visible = true;
                dgvExpenseList.ContextMenuStrip = contextMenuAccountant;
            }
            
            SetDataView(employeeExpenses);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtExpenseTitle.Text.Trim().Length == 0 || txtExpenseDetail.Text.Trim().Length == 0)
            {
                MessageBox.Show($"Harcama adi ve aciklamasi bos birakilamaz {nudAmount.Value}");
                return;
            }
            if (nudAmount.Value == 0)
            {
                DialogResult result = MessageBox.Show("Tutar kısmını girmediniz.\nHarcamayı kayıt etmek istiyor msusunuz?", "Tutar Boş", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    AddExpense();
                }
                return;
            }
            AddExpense();
            txtExpenseTitle.Clear();
            txtExpenseDetail.Clear();
            nudAmount.Value= 0;
            dtpExpenseDate.Value = DateTime.Now;
        }
        private void AddExpense()
        {
            expense = new Expense
            {
                Expense_Date = dtpExpenseDate.Value,
                Spender_Id = employee.EmployeeId,
                Spender_Name = $"{employee.EmployeeFullName}-{employee.EmployeeType}",
                Expense_Title = txtExpenseTitle.Text,
                Expense_Detail = txtExpenseDetail.Text,
                Amount = nudAmount.Value,
                Status = employee.EmployeeType.ToLower() == "manager" ? "Approved" : "Waiting",

            };
            expensesList.Add(expense);
            employeeExpenses.Add(expense);
            FileOperations.SaveExpensesFile(expensesList);
            SetDataView(employeeExpenses);


        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (employee.EmployeeType.ToLower() == "worker" && (expense.Status.ToLower() == "rejected" || expense.Status.ToLower() == "waiting"))
            {
                UpdateExpense("Waiting");
            }
            else if (employee.EmployeeType.ToLower() == "worker" && expense.Status.ToLower() == "approved")
            {
                MessageBox.Show("Onaylanan harcamalarda degisiklk yapılamaz");
                btnDelete.Visible = false;
            }
            else if (employee.EmployeeType.ToLower() == "manager" && employee.EmployeeId == expense.Spender_Id)
            {
                UpdateExpense("Approved");
            }
            else if(employee.EmployeeType.ToLower() == "manager" && employee.EmployeeId != expense.Spender_Id)
            {
                MessageBox.Show("Sadece Kendi harcamalarınızı güncelleyebilirsiniz.");
                btnDelete.Visible = false;
            }
        }
        private void UpdateExpense(string newStatus)
        {
            employeeExpenses.Remove(expense);
            expensesList.Remove(expense);

            //update values of expense 
            expense.Expense_Title = txtExpenseTitle.Text;
            expense.Expense_Date = dtpExpenseDate.Value;
            expense.Amount = nudAmount.Value;
            expense.Expense_Detail = txtExpenseDetail.Text;
            expense.Status = newStatus;

            employeeExpenses.Add(expense);
            expensesList.Add(expense);
            SetDataView(employeeExpenses);
            FileOperations.SaveExpensesFile(expensesList);
            btnUpdate.Visible = false;
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (employee.EmployeeType.ToLower() == "worker" && expense.Status.ToLower() == "waiting")
            {
                RemoveExpense();
            }
            else if (employee.EmployeeType.ToLower() == "worker" && (expense.Status.ToLower() == "rejected" || expense.Status.ToLower() == "approved"))
            {
                MessageBox.Show("Onaylanan veya Reddedilen harcamalarda degisiklk yapılamaz");
                btnDelete.Visible = false;
            }
            else if (employee.EmployeeType.ToLower() == "manager" && employee.EmployeeId == expense.Spender_Id)
            {
                RemoveExpense();
            }
            else if (employee.EmployeeType.ToLower() == "manager" && employee.EmployeeId != expense.Spender_Id)
            {
                MessageBox.Show("Sadece Kendi harcamalarınızı Silebilirsiniz.");
                btnDelete.Visible = false;
            }

        }
        private void RemoveExpense()
        {
            employeeExpenses.Remove(expense);
            expensesList.Remove(expense);
            SetDataView(employeeExpenses);
            FileOperations.SaveExpensesFile(expensesList);
            btnDelete.Visible = false;
        }
        private void approveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expense currentExpense = SelectExpense();
            ChangeExpenseStatus(currentExpense,"waiting","Approved");
        }
        private void rejectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Expense currentExpense = SelectExpense();
            ChangeExpenseStatus(currentExpense, "waiting","Rejected");
        }
        private void payToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1[1,1].Value="tes";
            //colomn ile row kordinatını veriyor

            //dgvExpenseList.Rows[rowIndex].Selected.ToString()
            //dgvExpenseList.SelectedRows[rowIndex].Selected = true;

            Expense currentExpense = SelectExpense();
            ChangeExpenseStatus(currentExpense, "approved","Paid");
        }
        private void dgvExpenseList_CellMouseEnter(object sender, DataGridViewCellEventArgs location)
        {
            mouseLocation = location;
        }
        private void Home_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        //method
        private void SetDataView(List<Expense> expenseList)
        {
            dgvExpenseList.DataSource = null;
            dgvExpenseList.DataSource = employeeExpenses;
            foreach (DataGridViewColumn col in dgvExpenseList.Columns)
            {
                if (col.HeaderText == "ExpenseId" || col.HeaderText == "Spender_Id" || col.HeaderText == "Status")
                {
                    col.Width = 80;
                }
                else if (col.HeaderText == "Expense_Detail")
                {
                    col.Width = 260;
                }
                else if (col.HeaderText == "Expense_Title")
                {
                    col.Width = 180;
                }
            }
        }

        private Expense SelectExpense()
        {
            int rowIndex = dgvExpenseList.Rows[mouseLocation.RowIndex].Cells[mouseLocation.ColumnIndex].RowIndex;
            dgvExpenseList.CurrentCell = dgvExpenseList.Rows[rowIndex].Cells[0];
            Expense currentExpense = (Expense)dgvExpenseList.CurrentRow.DataBoundItem;
            return currentExpense;
        }
        private void ChangeExpenseStatus(Expense currentExpense, string process,string result)
        {
            if (currentExpense.Status.ToLower() == process.ToLower())
            {
                foreach (Expense expense in expensesList)
                {
                    if (expense.ExpenseId == currentExpense.ExpenseId)
                    {
                        expense.Status = result;
                    }
                }
                SetDataView(expensesList);
                FileOperations.SaveExpensesFile(expensesList);
            }
            else
            {
                string message = process == "approved" ? "onaylı" : "bekleyen";
                MessageBox.Show($"Sadece {message} harcamalar işlem yapılabilir");
            }
        }

        private void dgvExpenseList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            dgvExpenseList.CurrentCell = dgvExpenseList.Rows[index].Cells[0];
            Expense currentExpense = (Expense)dgvExpenseList.CurrentRow.DataBoundItem;
            expense = currentExpense;

            txtExpenseTitle.Text = expense.Expense_Title;
            dtpExpenseDate.Value = expense.Expense_Date;
            nudAmount.Value = expense.Amount;
            txtExpenseDetail.Text=expense.Expense_Detail;

            btnUpdate.Visible = true;
            btnDelete.Visible = true;


        }

        
    }
}
