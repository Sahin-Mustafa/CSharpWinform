namespace Expenses
{
    public partial class formLoginPage : Form
    {
        private List<Employee> employeeList =new List<Employee>();
        public formLoginPage()
        {
            InitializeComponent();
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            formSignUpPage signUpPage= new formSignUpPage();
            signUpPage.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool isRegistered=false;
            bool wrongPassword=false;
            foreach (Employee emp in employeeList)
            {
                if (emp.EmployeeFullName == txtName.Text )
                {
                    isRegistered = true;
                    break;
                }
            }
            if(isRegistered) 
            {
                foreach (Employee emp in employeeList)
                {
                    if (emp.EmployeeFullName == txtName.Text && emp.EmployeePassword == txtPassword.Text)
                    {
                        this.Hide();
                        Home home = new Home(emp);
                        home.Show();
                        break;
                    }
                    if (emp.EmployeeFullName == txtName.Text)
                    {
                        if(emp.EmployeePassword != txtPassword.Text)
                        {
                            wrongPassword = !wrongPassword;
                        }
                        else
                        {
                            wrongPassword = !wrongPassword;
                        }
                    }
                    
                }
                if (wrongPassword)
                {
                    MessageBox.Show("Hatal� �ifre Girdiniz.");
                }

            }
            else
            {
                MessageBox.Show("Kullan�c� Bulunamad�");
            }

        }

        private void formLoginPage_Load(object sender, EventArgs e)
        {
            employeeList = FileOperations.GetEmloyees();
        }
    }
}