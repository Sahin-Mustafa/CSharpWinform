using System.Text.Json;
using System.Windows.Forms;

namespace RentACar
{
    public partial class Form1 : Form
    {
        public List<RentalVehicle> rentalList= new List<RentalVehicle>();
        public List<Vehicle> vehicles= new List<Vehicle>();
        public List<Brand> brands = new List<Brand>();
        private Vehicle vehicle;
        string baseImgPath = Application.StartupPath + "noImg-128.png";
        string jsonPath = Application.StartupPath + "brandList.json";
        public Form1()
        {
            InitializeComponent();
            pbPhoto.Image = new Bitmap(this.baseImgPath);

        }
        private void Form1_Load(object sender, EventArgs e)
        {

            if (!File.Exists(this.jsonPath)) // If file does not exists
            {
                File.Create(this.jsonPath).Close(); // Create file
            }
            else // If file already exists
            {
                string json = File.ReadAllText(this.jsonPath);
                this.brands = new List<Brand>();
                if (string.Empty != json)
                {
                    this.brands = JsonSerializer.Deserialize<List<Brand>>(json);
                    foreach(Brand item in brands)
                    {
                        cmbBrands.Items.Add(item.BrandName);
                        foreach(Model model in item.Models)
                        {
                            cmbModels.Items.Add(model.ModelName);
                        }
                    }
                }
            }
        }
        
        //menu button events
        private void btnNewVehicle_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewVehicle newVehicle = new NewVehicle(this);
            newVehicle.Show();
        }
        private void btnSavePage_Click(object sender, EventArgs e)
        {

        }
        private void btnRestart_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        //page button events
        private void btnDeleteVehicle_Click(object sender, EventArgs e)
        {
            if (lstVehicles.Items.Count > 0)
            {
                vehicles.RemoveAt(lstVehicles.SelectedIndex);

                lstVehicles.DataSource = null;
                lstVehicles.DataSource = vehicles; ;
            }
        }
        private void cmbModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.vehicle = new Vehicle
            {
                Brand = new Brand
                {
                    BrandName = cmbBrands.SelectedItem.ToString(),
                    Models =
                    { new Model
                        {
                            ModelName = cmbModels.SelectedItem.ToString(),
                            ImgPath = GetImgPath()

                        }
                    }
                },
            };
            pbPhoto.Image = new Bitmap(this.vehicle.Brand.Models[0].ImgPath);

        }
        private void cmbBrands_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbModels.Items.Clear();
            if (cmbBrands.SelectedIndex < 0)
            {
                foreach (Brand item in brands)
                {
                    foreach (Model model in item.Models)
                    {
                        cmbModels.Items.Add(model.ModelName);
                    }
                }
                return;
            }

            foreach (Brand item in brands)
            {
                if (item.BrandName == cmbBrands.SelectedItem.ToString())
                {
                    foreach (Model model in item.Models)
                    {
                        cmbModels.Items.Add(model.ModelName);
                    }
                }
            }

        }
        private void btnAddVehicle_Click(object sender, EventArgs e)
        {
            if(cmbModels.SelectedIndex < 0 && cmbBrands.SelectedIndex<0) 
            {
                MessageBox.Show("Marka ve Modeli Seçmelisiniz. \nAradýðýnýz Marka model Yok ise ctrl+N ile eklyebilirsiniz.","Hatalý Seçim",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                ClearVehicleInformation();
                return;
            }

            vehicle.Km = txtKm.Text;
            vehicle.Year = txtYears.Text;
            vehicle.IsItRent = chlstIsRent.Checked;
            vehicle.DailyPrice = numericRentalPrice.Value;
            


            vehicles.Add(vehicle);
            lstVehicles.DataSource = null;
            lstVehicles.DataSource = vehicles;
            ClearVehicleInformation();
        }
        private void ClearVehicleInformation()
        {
            txtKm.Clear();
            txtYears.Clear();
            chlstIsRent.Checked = false;
            cmbBrands.SelectedIndex= -1;
            cmbModels.SelectedIndex= -1;
            cmbBrands.Text = "Please Select Brand";
            cmbModels.Text = "please Select Model";
            pbPhoto.Image = new Bitmap(this.baseImgPath);
        }
        private void chlstIsRent_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxDaily.Enabled = chlstIsRent.Checked;
            if (!chlstIsRent.Checked)
            {
                numericRentalPrice.Value = 0m;
            }

            //MessageBox.Show(cmbBrands.SelectedIndex.ToString()); to Index
            //MessageBox.Show(cmbBrands.SelectedItem.ToString()); TO TEXT
            //cmbBrands.Text= ""; SET DEFAULT TEXT
        }
        private void btnRentPerson_Click(object sender, EventArgs e)
        {
            if (lstVehicles.SelectedIndex == -1)
            {
                MessageBox.Show("Araç Listesinden Araç seçiniz.", "Hatalý Ýþlem");
                return;
            }
            if (dtpEndDate.Value.Date.Subtract(dtpRentalDate.Value.Date).Days < 2)
            {
                MessageBox.Show("En az 2 gün kiralanabilir.\nTeslim Tarihi Baþlangýç Tarihinden Önce Olamaz");
                return;
            }
            if (!chlstIsRent.Checked)
            {
                MessageBox.Show("Bu araç Kiralanamaz.");
            }
            RentalVehicle rentalVehicle = new RentalVehicle
            {
                Vehicle = this.vehicle,
                PersonFullName = txtFullName.Text,
                Id = txtID.Text,
                RentalDate = dtpRentalDate.Value,
                EndDate = dtpEndDate.Value,
                DownPayment = decimal.Parse(txtDownPayment.Text)
            };

            rentalList.Add(rentalVehicle);
            lstRental.DataSource = null;
            lstRental.DataSource = rentalList;

        }
        private void btnRentalLstDelete_Click(object sender, EventArgs e)
        {
            if (lstRental.Items.Count > 0)
            {
                rentalList.RemoveAt(lstRental.SelectedIndex);

                lstRental.DataSource = null;
                lstRental.DataSource = vehicles; ;
            }
        }

        //methods
        private string GetImgPath()
        {
            foreach (Brand item in brands)
            {
                if (item.BrandName == cmbBrands.SelectedItem.ToString())
                {
                    foreach (Model model in item.Models)
                    {
                        if (model.ModelName == cmbModels.SelectedItem.ToString())
                        {
                            return model.ImgPath;
                        }
                    }
                }
            }
            return this.baseImgPath;
        }

        
    }
}