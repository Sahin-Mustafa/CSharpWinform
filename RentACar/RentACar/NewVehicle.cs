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
        private List<Brand> brands;
        string basePath = Application.StartupPath+ "noImg-128.png";
        string jsonPath = Application.StartupPath + "brandList.json";
        private Brand brand;
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
            string json = File.ReadAllText(this.jsonPath);
            this.brands = new List<Brand>();
            if (string.Empty != json)
            {
                this.brands = JsonSerializer.Deserialize<List<Brand>>(json);
            }
            
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
                brand = new Brand
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
                brand = new Brand
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
                brands.Add(brand);
            }
            else
            {
                brand.BrandName = txtBrandName.Text;
            }
            brand.Models[0].ModelName = txtModelName.Text;
            if (CheckVehicle())
            {
                return;
            };

            if (brand.Models[0].ImgPath == string.Empty)
            {
                brand.Models[0].ImgPath = this.basePath;
            }


            foreach (Brand item in brands)
            {
                if (item.BrandName.ToLower() == txtBrandName.Text.ToLower())
                {
                    item.Models.Add(new Model
                    {
                        ModelName = txtModelName.Text,
                        ImgPath = brand.Models[0].ImgPath,
                    });
                    isHasBrand = true;
                    break;
                }
            }
            if (!isHasBrand)
            {
                this.brands.Add(brand);
            }
            string json = JsonSerializer.Serialize(brands);
            File.WriteAllText(this.jsonPath, json);
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
            foreach (Brand item in brands)
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

