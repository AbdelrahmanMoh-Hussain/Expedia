namespace Expedia.Presentation_Layer
{
    partial class CheckOutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.status_label = new System.Windows.Forms.Label();
            this.reservations = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.type = new System.Windows.Forms.Label();
            this.balance_label = new System.Windows.Forms.Label();
            this.company = new System.Windows.Forms.Label();
            this.num = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(-3, 52);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 56;
            this.dataGridView1.RowTemplate.Height = 31;
            this.dataGridView1.Size = new System.Drawing.Size(730, 479);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            this.button1.Font = new System.Drawing.Font("Maiandra GD", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(130, 644);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 65);
            this.button1.TabIndex = 6;
            this.button1.Text = "Check Out";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // status_label
            // 
            this.status_label.AutoSize = true;
            this.status_label.Font = new System.Drawing.Font("Maiandra GD", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.status_label.Location = new System.Drawing.Point(838, 638);
            this.status_label.Name = "status_label";
            this.status_label.Size = new System.Drawing.Size(0, 30);
            this.status_label.TabIndex = 7;
            this.status_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // reservations
            // 
            this.reservations.AutoSize = true;
            this.reservations.Font = new System.Drawing.Font("Maiandra GD", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.reservations.ForeColor = System.Drawing.Color.MidnightBlue;
            this.reservations.Location = new System.Drawing.Point(921, 9);
            this.reservations.Name = "reservations";
            this.reservations.Size = new System.Drawing.Size(170, 30);
            this.reservations.TabIndex = 7;
            this.reservations.Text = "Reservastions";
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(733, 52);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(491, 529);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // type
            // 
            this.type.AutoSize = true;
            this.type.Font = new System.Drawing.Font("Maiandra GD", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.type.Location = new System.Drawing.Point(587, 596);
            this.type.Name = "type";
            this.type.Size = new System.Drawing.Size(0, 30);
            this.type.TabIndex = 7;
            // 
            // balance_label
            // 
            this.balance_label.AutoSize = true;
            this.balance_label.Font = new System.Drawing.Font("Maiandra GD", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.balance_label.Location = new System.Drawing.Point(414, 679);
            this.balance_label.Name = "balance_label";
            this.balance_label.Size = new System.Drawing.Size(0, 30);
            this.balance_label.TabIndex = 7;
            this.balance_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // company
            // 
            this.company.AutoSize = true;
            this.company.Font = new System.Drawing.Font("Maiandra GD", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.company.Location = new System.Drawing.Point(414, 596);
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(0, 30);
            this.company.TabIndex = 7;
            // 
            // num
            // 
            this.num.AutoSize = true;
            this.num.Font = new System.Drawing.Font("Maiandra GD", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.num.Location = new System.Drawing.Point(414, 638);
            this.num.Name = "num";
            this.num.Size = new System.Drawing.Size(0, 30);
            this.num.TabIndex = 7;
            this.num.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Maiandra GD", 9.969231F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(50, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 21);
            this.label8.TabIndex = 10;
            this.label8.Text = "Back";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Expedia.Properties.Resources.left_arrow;
            this.pictureBox2.Location = new System.Drawing.Point(9, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.MidnightBlue;
            this.button2.Font = new System.Drawing.Font("Maiandra GD", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(130, 561);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 65);
            this.button2.TabIndex = 11;
            this.button2.Text = "Add Card";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // CheckOutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1236, 732);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.reservations);
            this.Controls.Add(this.num);
            this.Controls.Add(this.balance_label);
            this.Controls.Add(this.company);
            this.Controls.Add(this.type);
            this.Controls.Add(this.status_label);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CheckOutForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckOutForm";
            this.Activated += new System.EventHandler(this.CheckOutForm_Activated);
            this.Load += new System.EventHandler(this.CheckOutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DataGridView dataGridView1;
        private Button button1;
        private Label status_label;
        private Label reservations;
        private RichTextBox richTextBox1;
        private Label type;
        private Label balance_label;
        private Label company;
        private Label num;
        private Label label8;
        private PictureBox pictureBox2;
        private Button button2;
    }
}