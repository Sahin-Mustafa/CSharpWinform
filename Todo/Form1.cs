using MFramework.Services.FakeData;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Todo
{
    public partial class Form1 : Form
    {
        private List<ToDo> todos = new List<ToDo>();
        TextBox currentTextBox = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtTitle.Text.Trim().Length == 0)
            {
                errorProvider1.SetError(txtTitle, "Title cannot be empty");
                return;
            }
            errorProvider1.SetError(txtTitle, null);
            ToDo todo = new();
            todo.Id = Guid.NewGuid();
            todo.Title = txtTitle.Text;
            todo.Describtion = txtDescribtion.Text;
            todo.DueDate = dtpDate.Value;
            todo.IsCompleted = chkComplet.Checked;

            todos.Add(todo);
            //LoadListbocMethod1();

            //method2
            LoadListboxMethod2();

        }

        private void LoadListboxMethod2()
        {
            lstTask.DataSource = null;
            lstTask.DisplayMember = nameof(ToDo.Title);
            lstTask.ValueMember = nameof(ToDo.Id);
            lstTask.DataSource = todos;
        }

        private void LoadListbocMethod1()
        {
            lstTask.Items.Clear();
            foreach (ToDo item in todos)
            {
                lstTask.Items.Add(item);
            }
        }

        private void btnNewOpen_Click(object sender, EventArgs e)
        {
            txtDescribtion.Clear();
            txtDescribtion.Clear();
            dtpDate.Value = DateTime.Now;
            chkComplet.Checked = false;

        }

        private void btnCut_Click(object sender, EventArgs e)
        {
            currentTextBox.Cut();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            currentTextBox.Copy();
        }

        private void btnPaste_Click(object sender, EventArgs e)
        {
            currentTextBox.Paste();
        }

        private void txt_MouseClick(object sender, MouseEventArgs e)
        {
            
            currentTextBox = (TextBox) sender;
        }

        private async void saveToolStripButton_Click(object sender, EventArgs e)
        {
            List<string> lines = new List<string>();

            #region "my format"
                foreach (ToDo item in todos)
                {
                    string line = $"{item.Id}|{item.Title}|{item.Describtion}|{item.DueDate}|{item.IsCompleted}";
                    lines.Add(line);
                }
            #endregion



            #region "JSON Format"
                foreach (ToDo item in todos)
                {
                    string line = $"{{" +
                                  $"\"id\":\"{item.Id}\"," +
                                  $"\"title\":\"{item.Title}\"," +
                                  $"\"describtion\":\"{item.Describtion}\"," +
                                  $"\"dueDate\":\"{item.DueDate}\"," +
                                  $"\"isCompleted\":{item.IsCompleted.ToString().ToLower()}" +
                                  $"}}";
                    lines.Add(line);
                    //$"{item.Id}|{item.Title}|{item.Describtion}|{item.DueDate}|{item.IsCompleted}" lines.Add(line);
                }
                string json1 = $"{{\"tasks\": [{string.Join(",",lines)}}}]";
            #endregion

            string json = JsonSerializer.Serialize(todos);


            //string path =Application.StartupPath + "\\data.txt"; //my application path adress in start folder
            //string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\data.txt"; //special addres

            SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Record to data";
            saveFileDialog.OverwritePrompt = true;
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.Filter = "File Format(*.txt)|*.txt|ToDo App Format(*.todo)|*.todo";

            DialogResult result = saveFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                //File.WriteAllLines(saveFileDialog.FileName, lines);
                File.WriteAllText(saveFileDialog.FileName,json);
                MessageBox.Show("Data recorded");
            }
        }

        

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            

            openFileDialog.Title = "Open Files";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openFileDialog.Filter = "File Format(*.txt)|*.txt|ToDo App Format(*.todo)|*.todo";

            DialogResult result = openFileDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                //string[] read = File.ReadAllLines(openFileDialog.FileName);
                string json = File.ReadAllText(openFileDialog.FileName);
                todos = JsonSerializer.Deserialize<List<ToDo>>(json);
                
                //todos.Clear();
                //foreach (string item in read)
                //{
                //    string[] splitted = item.Split("|");
                //    ToDo todo = new();
                //    todo.Id =Guid.Parse(splitted[0]);
                //    todo.Title = splitted[1];
                //    todo.Describtion = splitted[2];
                //    todo.DueDate = DateTime.Parse(splitted[3]);
                //    todo.IsCompleted = bool.Parse(splitted[4]);
                //    todos.Add(todo);
   
                //}
                LoadListboxMethod2();
            }
            

        }
    }
}