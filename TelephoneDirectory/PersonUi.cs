using System.Diagnostics;
using MFramework.Services.FakeData;
using Microsoft.VisualBasic.Devices;
using static System.Net.WebRequestMethods;

namespace TelephoneDirectory
{
    public partial class PersonUi : Form
    {
        List<Person> copyListBox = new List<Person>();
        public PersonUi()
        {
            InitializeComponent();
        }
        private void PersonUi_Load(object sender, EventArgs e)
        {
            string[] category = { "Family", "Friend", "Work", "Course" };
            bool[] checkedLevel = { false, true };
            Random rnd = new Random();

            for (int i = 0; i < 10; i++)
            {
                Person person = new Person();
                person.Fullname = NameData.GetFullName();
                person.Username = person.Fullname.Replace(" ", "");
                person.PhoneNumber = PhoneNumberData.GetPhoneNumber();
                person.Email = $"{person.Username}@gmail.com";
                person.Category = category[rnd.Next(0, category.Length)];

                int randomEnglishLevel = rnd.Next(0, category.Length);

                if (randomEnglishLevel == 0)
                {
                    rdbElementry.Enabled = true;
                    person.EnlisghLevel = "Elementry";
                }
                else if (randomEnglishLevel == 1)
                {
                    rdbIntermediate.Enabled = true;
                    person.EnlisghLevel = "Interediate";
                }
                else if (randomEnglishLevel == 2)
                {
                    rdbUpper.Enabled = true;
                    person.EnlisghLevel = "Upper";
                }
                else
                {
                    rdbNative.Enabled = true;
                    person.EnlisghLevel = "Native";
                }


                person.ProgramSkilC = checkedLevel[rnd.Next(0, checkedLevel.Length)];
                person.ProgramSkilPython = checkedLevel[rnd.Next(0, checkedLevel.Length)];
                person.ProgramSkilJava = checkedLevel[rnd.Next(0, checkedLevel.Length)];
                person.ProgramSkilJs = checkedLevel[rnd.Next(0, checkedLevel.Length)];

                person.SocialLinkedln = $"https://www.linkedin.com/in/{person.Username}/";
                person.SocialGitHub = $"https://github.com/{person.Username}";
                person.SocialTwiter = $"https://twitter.com/{person.Username}";

                copyListBox.Add(person);
                lstFilterCategory.Items.Add(person);
            }
        }


        private void mnuSave_Click(object sender, EventArgs e)
        {
            Person person = new Person();
            person.Fullname = txtFullName.Text;
            person.Username = txtUserName.Text;
            person.PhoneNumber = txtPhone.Text;
            person.Email = txtEmail.Text;
            person.Category = cmbInformationCategory.Text;

            CheckLanguageLevel(person);

            person.ProgramSkilC = cbC.Checked;
            person.ProgramSkilPython = cbPython.Checked;
            person.ProgramSkilJava = cbJava.Checked;
            person.ProgramSkilJs = cbJs.Checked;

            person.SocialLinkedln = txtSocialUrl1.Text;
            person.SocialGitHub = txtSocialUrl2.Text;
            person.SocialTwiter = txtSocialUrl3.Text;

            copyListBox.Add(person);

            lstFilterCategory.Items.Clear();
            foreach (Person p in copyListBox)
            {
                lstFilterCategory.Items.Add(p);
            }

            ClearPages();

        }
        private void mnuRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void mnuInfo_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
            ClearPages();
        }
          
        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (copyListBox.Count < 1)
            {
                MessageBox.Show("Telefon Rehberiniz Boþ");
                return;
            }
            if (cmbCategory.Text == "All")
            {
                lstFilterCategory.Items.Clear();
                foreach (Person p in copyListBox)
                {
                    lstFilterCategory.Items.Add(p);
                }
            }
            else
            {
                string selectCategory = cmbCategory.Text;
                lstFilterCategory.Items.Clear();

                for (int i = 0; i < copyListBox.Count; i++)
                {
                    if (copyListBox[i].Category == selectCategory)
                    {
                        lstFilterCategory.Items.Add(copyListBox[i]);
                    }
                }
            }
            //complete filter
        }

        private void ClearPages()
        {
            txtFullName.Clear();
            txtUserName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            cbC.Checked = false;
            cbPython.Checked = false;
            cbJava.Checked = false;
            cbJs.Checked = false;
            txtSocialUrl1.Clear();
            txtSocialUrl2.Clear();
            txtSocialUrl3.Clear();
        }


        private void CheckLanguageLevel(Person person)
        {
            if (rdbElementry.Checked)
            {
                person.EnlisghLevel = "Elementry";
            }
            else if (rdbIntermediate.Checked)
            {
                person.EnlisghLevel = "Elementry";
            }
            else if (rdbUpper.Checked)
            {
                person.EnlisghLevel = "Upper";

            }
            else
            {
                person.EnlisghLevel = "Native";

            }
        }

        private void btnWhatsapp_Click(object sender, EventArgs e)
        {
            string target = "https://wa.me/" + 1111111111111;
            Process.Start("explorer.exe", target);
            ClearPages();
        }
        private void btnSendMail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.Length < 1)
            {
                MessageBox.Show("Mail adresi boþ býrakýlamaz!", "Mail Gönderme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            bool isMail = txtEmail.Text.Contains("@");
            if (!isMail)
            {
                MessageBox.Show("Hatalý Mail adresi.", "Mail Gönderme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string isGmail = txtEmail.Text.Split("@")[1];

            if (isGmail != "gmail.com")
            {
                MessageBox.Show("Hatalý Mail adresi. Yalnýzca Gmail hesabý giriniz", "Mail Gönderme", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            EmailBody email = new EmailBody();
            email.To = txtEmail.Text;
            email.Subject = "Deneme Testi";
            email.Body = "Bu bir denemedir.Mail gönderimi baþarýlý";

            EmailService emailService = new EmailService();
            emailService.SendEmail(email);
            //Cursor = Cursors.WaitCursor;
            MessageBox.Show("Mailiniz Gönderildi", "Mail Gönderme", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }  
    }
}