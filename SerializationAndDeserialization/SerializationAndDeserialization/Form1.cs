using System.Text.Json;

using static System.Windows.Forms.LinkLabel;

namespace SerializationAndDeserialization
{
    public partial class Form1 : Form
    {
        List<Person> persons = new List<Person>();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFullName.Text.Trim().Length == 0)
            {
                MessageBox.Show("Kiþi Bilgileri Eksik");
                return;
            }
            AddNewPerson();
            LoadListboxMethod();
            MessageBox.Show("Kiþi Baþarý ile Eklendi.");
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();


            openFileDialog.Title = "Open Files";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "File Format(*.json)|*.json";


            DialogResult result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                string json = File.ReadAllText(openFileDialog.FileName);
                persons = JsonSerializer.Deserialize<List<Person>>(json);

                LoadListboxMethod();
            }
    }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //string path = Application.StartupPath + "\\User.json"; aplicationun baþladýðý yerde dosyayý baþlatýr
            if(persons.Count== 0)
            {
                MessageBox.Show("Kiþi Listesi Boþ. Kayýt iþlemi baþarýsýz.");
                return;
            }
            string json = JsonSerializer.Serialize(persons);

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Record to data";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.Filter = "File Format(*.json)|*.json";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                //File.WriteAllLines(saveFileDialog.FileName, lines);
                File.WriteAllText(saveFileDialog.FileName, json);
                MessageBox.Show("Data recorded");
            }
        }

        private void AddNewPerson()
        {
            Person person = new();
            Address address= new();
            Country country= new();
            Experience experiencess= new();
            ExperiencesAddress experiencesAddress = new();

            person.Fullname = txtFullName.Text;
            person.Tc = txtTc.Text;
            person.BirthDate = dbdBirthDate.Value;
            person.Email = txtEmail.Text;
            person.Phone = txtPhone.Text;
            person.Gender = rdbFemale.Checked;

            country.Name= txtCountry.Text;
            country.RegionCode = txtRegionCode.Text;

            address.Country= country;
            address.City = txtPersonCity.Text;
            address.District = txtDistrict.Text;
            address.PostalCode = txtPostalCode.Text;
            address.Street = txtStreet.Text;
            person.Addresses.Add(address);

            experiencesAddress.Country = txtCompanyCountry.Text;
            experiencesAddress.City = txtCompanyCity.Text;

            experiencess.CompanyAdress = experiencesAddress;
            experiencess.CompanyName= txtCompanyName.Text;
            experiencess.ExperienceDesc = txtExperienceDesc.Text;
            person.Experiences.Add(experiencess);

            persons.Add(person);
        }

        private void LoadListboxMethod()
        {
            listBox1.Items.Clear();
            for (int i = 0; i < persons.Count; i++)
            {
                listBox1.Items.Add(persons[i]);
            }
        }

        //
    }
}