namespace RentACar
{
    public partial class Form1 : Form
    {
        public List<Vehicle> vehicles = new List<Vehicle>();
        private Vehicle vehicle;
        public Form1()
        {
            InitializeComponent();
            
        }
        private void btnNewVehicle_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewVehicle newVehicle = new NewVehicle(this);
            newVehicle.Show();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnSavePage_Click(object sender, EventArgs e)
        {

        }

    }
}