using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Expenses
{
    public partial class formSignUpPage : Form
    {
        public List<Employee> employeeList = new List<Employee>();
        private Employee employee;

        public formSignUpPage()
        {
            InitializeComponent();            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text.Trim().Length < 3)
            {
                MessageBox.Show("Isim Kısmı bos birakilamz.");
                return;
            }
            if (txtPassword.Text.Contains(" ") || txtPassword.Text.Length < 8)
            {
                MessageBox.Show("Sifre bosluk kullanılamaz ve EN AZ 8 karakterli olmalı");
                return;
            }
            if (txtPassword.Text != txtRePassword.Text)
            {
                MessageBox.Show("Sifreler aynı olmalı");
                return;
            }
            if (cmbEmployeType.SelectedIndex == -1)
            {
                MessageBox.Show("Calisanin pozisyonunu seciniz");
                return;
            }

            
            this.employeeList.Add(employee);
            FileOperations.SaveEmployeeFile(this.employeeList);
            MessageBox.Show("Calisan Eklendi.");
            Application.Restart();          
        }

        private void formSignUpPage_Load(object sender, EventArgs e)
        {
            this.employeeList = FileOperations.GetEmloyees();
        }

        private void cmbEmployeType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string employeeType = cmbEmployeType.SelectedItem.ToString().ToLower();
            
            switch (employeeType)
            {
                case ("worker"):
                    employee = new Worker
                    {
                        EmployeeId= Guid.NewGuid(),
                        EmployeeFullName = txtUserName.Text,
                        EmployeePassword = txtPassword.Text,
                    };

                    break;
                case ("manager"):
                    employee = new Manager
                    {
                        EmployeeId = Guid.NewGuid(),
                        EmployeeFullName = txtUserName.Text,
                        EmployeePassword = txtPassword.Text,
                    };
                    break;
                case ("accountant"):
                    employee = new Accountant
                    {
                        EmployeeId = Guid.NewGuid(),
                        EmployeeFullName = txtUserName.Text,
                        EmployeePassword = txtPassword.Text,
                    };
                    break;
                default:
                    break;
            }

        }
    }
}
