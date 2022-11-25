using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace RentACar
{
    public partial class NewVehicle : Form
    {
        private List<Vehicle> vehicles = new List<Vehicle>();
        string basePath = "C:\\Users\\Sabah\\source\\repos\\CSharp\\RentACar\\img\\noImg-128.png";
        private Vehicle vehicle;
        private bool isNewVehicle = false;
        Form home;
        public NewVehicle(Form Home)
        {
            this.home = Home;
            GetData();
            InitializeComponent();
            pbPhoto.Image = new Bitmap(this.basePath);

        }
        private void GetData()
        {
            //List<Vehicle> vehicles1 = new List<Vehicle>();
            string jsonPath = Application.StartupPath + "vehicles.json";
            string json = File.ReadAllText(jsonPath);
            this.vehicles = JsonSerializer.Deserialize<List<Vehicle>>(json);
        }
        
        private void btnNewVehiclePhoto_Click(object sender, EventArgs e)
        {

            if (CheckVehicle())
            {
                return;
            };

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Open Files";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.png;*.bmp)|*.jpg; *.jpeg; *.gif; *.png;*.bmp";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pbPhoto.Image = new Bitmap(openFileDialog.FileName);
                // image file path  
                pbPhoto.Text = openFileDialog.FileName;
                vehicle = new Vehicle
                {
                    Models =
                { new Model
                    {
                        ImgPath=openFileDialog.FileName
                    }
                }
                };
                this.isNewVehicle = true;

            }
        }

        private void btnSaveNewVehicle_Click(object sender, EventArgs e)
        {
            bool isHasBrand = false;
            if (!isNewVehicle)
            {
                vehicle = new Vehicle
                {
                    BrandName = txtBrandName.Text,
                    Models =
                    {
                        new Model
                        {
                            ImgPath = this.basePath
                        }
                    }
                };
                vehicles.Add(vehicle);
            }
            else
            {
                vehicle.BrandName = txtBrandName.Text;
            }
            vehicle.Models[0].ModelName = txtModelName.Text;
            if (CheckVehicle())
            {
                return;
            };

            if (vehicle.Models[0].ImgPath == string.Empty)
            {
                vehicle.Models[0].ImgPath = this.basePath;
            }


            foreach (Vehicle item in vehicles)
            {
                if (item.BrandName.ToLower() == txtBrandName.Text.ToLower())
                {
                    item.Models.Add(new Model
                    {
                        ModelName = txtModelName.Text,
                        ImgPath = vehicle.Models[0].ImgPath,
                    });
                    isHasBrand = true;
                    break;
                }
            }
            if (!isHasBrand)
            {
                this.vehicles.Add(vehicle);
            }


            string path = Application.StartupPath + "\\vehicles.json";
            string json = JsonSerializer.Serialize(vehicles);
            File.WriteAllText(path, json);
            txtBrandName.Clear();
            txtModelName.Clear();
            DialogResult result = MessageBox.Show("Araç Başarılı Şekilde Kayıt Edildi.\nAna sayfaya dönmek iste misiniz?", "İşlem Başarılı", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            if (result == DialogResult.Yes)
            {
                this.Close();
                home.Show();
            }
        }

        private bool CheckVehicle()
        {
            foreach (Vehicle item in vehicles)
            {
                if (item.BrandName.ToLower() == txtBrandName.Text.ToLower())
                {
                    foreach (Model model in item.Models)
                    {
                        if (model.ModelName.ToLower() == txtModelName.Text.ToLower())
                        {
                            DialogResult result = MessageBox.Show("Araç Kayıtlı Tekrar Kayıt edemezsiniz.\nAna sayfaya dönmek iste misiniz?", "Kayıtlı Araç", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                            if (result == DialogResult.Yes)
                            {
                                this.Close();
                                home.Show();
                            }
                            txtBrandName.Clear();
                            txtModelName.Clear();
                            return true;
                        }
                    }

                }
            }
            return false;
        }
    }
}

