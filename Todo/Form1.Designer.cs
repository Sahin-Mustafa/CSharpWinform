namespace Todo
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescribtion = new System.Windows.Forms.TextBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.chkComplet = new System.Windows.Forms.RadioButton();
            this.btnSave = new System.Windows.Forms.Button();
            this.lstTask = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnNewOpen = new System.Windows.Forms.ToolStripButton();
            this.btnOpen = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.printToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.btnCut = new System.Windows.Forms.ToolStripButton();
            this.btnCopy = new System.Windows.Forms.ToolStripButton();
            this.btnPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Title";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(238, 46);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.PlaceholderText = "Title";
            this.txtTitle.Size = new System.Drawing.Size(250, 23);
            this.txtTitle.TabIndex = 1;
            this.txtTitle.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "ToDo";
            // 
            // txtDescribtion
            // 
            this.txtDescribtion.Location = new System.Drawing.Point(238, 95);
            this.txtDescribtion.Multiline = true;
            this.txtDescribtion.Name = "txtDescribtion";
            this.txtDescribtion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescribtion.Size = new System.Drawing.Size(250, 140);
            this.txtDescribtion.TabIndex = 2;
            this.txtDescribtion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txt_MouseClick);
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(238, 256);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(250, 23);
            this.dtpDate.TabIndex = 3;
            // 
            // chkComplet
            // 
            this.chkComplet.AutoSize = true;
            this.chkComplet.Location = new System.Drawing.Point(238, 285);
            this.chkComplet.Name = "chkComplet";
            this.chkComplet.Size = new System.Drawing.Size(90, 19);
            this.chkComplet.TabIndex = 4;
            this.chkComplet.TabStop = true;
            this.chkComplet.Text = "Tamamlandı";
            this.chkComplet.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(413, 312);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lstTask
            // 
            this.lstTask.DisplayMember = "Title";
            this.lstTask.FormattingEnabled = true;
            this.lstTask.ItemHeight = 15;
            this.lstTask.Location = new System.Drawing.Point(12, 46);
            this.lstTask.Name = "lstTask";
            this.lstTask.Size = new System.Drawing.Size(209, 289);
            this.lstTask.TabIndex = 6;
            this.lstTask.ValueMember = "Id";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "ToDos";
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNewOpen,
            this.btnOpen,
            this.saveToolStripButton,
            this.printToolStripButton,
            this.toolStripSeparator,
            this.btnCut,
            this.btnCopy,
            this.btnPaste,
            this.toolStripSeparator1,
            this.helpToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(514, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnNewOpen
            // 
            this.btnNewOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNewOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnNewOpen.Image")));
            this.btnNewOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNewOpen.Name = "btnNewOpen";
            this.btnNewOpen.Size = new System.Drawing.Size(23, 22);
            this.btnNewOpen.Text = "&New";
            this.btnNewOpen.Click += new System.EventHandler(this.btnNewOpen_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnOpen.Image = ((System.Drawing.Image)(resources.GetObject("btnOpen.Image")));
            this.btnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(23, 22);
            this.btnOpen.Text = "&Open";
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.saveToolStripButton.Text = "&Save";
            this.saveToolStripButton.Click += new System.EventHandler(this.saveToolStripButton_Click);
            // 
            // printToolStripButton
            // 
            this.printToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.printToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("printToolStripButton.Image")));
            this.printToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.printToolStripButton.Name = "printToolStripButton";
            this.printToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.printToolStripButton.Text = "&Print";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // btnCut
            // 
            this.btnCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCut.Image = ((System.Drawing.Image)(resources.GetObject("btnCut.Image")));
            this.btnCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCut.Name = "btnCut";
            this.btnCut.Size = new System.Drawing.Size(23, 22);
            this.btnCut.Text = "C&ut";
            this.btnCut.Click += new System.EventHandler(this.btnCut_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCopy.Image = ((System.Drawing.Image)(resources.GetObject("btnCopy.Image")));
            this.btnCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(23, 22);
            this.btnCopy.Text = "&Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnPaste
            // 
            this.btnPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPaste.Image = ((System.Drawing.Image)(resources.GetObject("btnPaste.Image")));
            this.btnPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(23, 22);
            this.btnPaste.Text = "&Paste";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // helpToolStripButton
            // 
            this.helpToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.helpToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("helpToolStripButton.Image")));
            this.helpToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.helpToolStripButton.Name = "helpToolStripButton";
            this.helpToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.helpToolStripButton.Text = "He&lp";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Date";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 341);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lstTask);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkComplet);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.txtDescribtion);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ToDo";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtTitle;
        private Label label2;
        private TextBox txtDescribtion;
        private DateTimePicker dtpDate;
        private RadioButton chkComplet;
        private Button btnSave;
        private ListBox lstTask;
        private Label label4;
        private ErrorProvider errorProvider1;
        private ToolStrip toolStrip1;
        private ToolStripButton btnNewOpen;
        private ToolStripButton btnOpen;
        private ToolStripButton saveToolStripButton;
        private ToolStripButton printToolStripButton;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripButton btnCut;
        private ToolStripButton btnCopy;
        private ToolStripButton btnPaste;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton helpToolStripButton;
        private Label label3;
    }
}