namespace Expedia.Presentation_Layer
{
    partial class SignUpForm
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
            System.Windows.Forms.Button button2;
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.password_txtbox = new System.Windows.Forms.TextBox();
            this.userName_txtbox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.confirmPassword_txtbox = new System.Windows.Forms.TextBox();
            this.name_txtbox = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            button2.BackColor = System.Drawing.Color.MidnightBlue;
            button2.Font = new System.Drawing.Font("Maiandra GD", 13.84615F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            button2.ForeColor = System.Drawing.Color.White;
            button2.Location = new System.Drawing.Point(268, 466);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(232, 80);
            button2.TabIndex = 12;
            button2.Text = "Sign Up";
            button2.UseVisualStyleBackColor = false;
            button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Expedia.Properties.Resources.user;
            this.pictureBox1.Location = new System.Drawing.Point(311, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 127);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(136, 346);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 35);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(139, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 35);
            this.label1.TabIndex = 7;
            this.label1.Text = "User Name";
            // 
            // password_txtbox
            // 
            this.password_txtbox.Font = new System.Drawing.Font("Segoe UI", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.password_txtbox.Location = new System.Drawing.Point(358, 340);
            this.password_txtbox.Name = "password_txtbox";
            this.password_txtbox.Size = new System.Drawing.Size(270, 41);
            this.password_txtbox.TabIndex = 4;
            // 
            // userName_txtbox
            // 
            this.userName_txtbox.Font = new System.Drawing.Font("Segoe UI", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.userName_txtbox.Location = new System.Drawing.Point(358, 274);
            this.userName_txtbox.Name = "userName_txtbox";
            this.userName_txtbox.Size = new System.Drawing.Size(270, 41);
            this.userName_txtbox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(136, 412);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 35);
            this.label3.TabIndex = 10;
            this.label3.Text = "Confirm Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(139, 214);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 35);
            this.label4.TabIndex = 11;
            this.label4.Text = "Name";
            // 
            // confirmPassword_txtbox
            // 
            this.confirmPassword_txtbox.Font = new System.Drawing.Font("Segoe UI", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.confirmPassword_txtbox.Location = new System.Drawing.Point(358, 406);
            this.confirmPassword_txtbox.Name = "confirmPassword_txtbox";
            this.confirmPassword_txtbox.Size = new System.Drawing.Size(270, 41);
            this.confirmPassword_txtbox.TabIndex = 8;
            // 
            // name_txtbox
            // 
            this.name_txtbox.Font = new System.Drawing.Font("Segoe UI", 13.84615F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.name_txtbox.Location = new System.Drawing.Point(358, 208);
            this.name_txtbox.Name = "name_txtbox";
            this.name_txtbox.Size = new System.Drawing.Size(270, 41);
            this.name_txtbox.TabIndex = 9;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(344, 570);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 21);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Log in";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(287, 549);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "Already have an account?";
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(814, 673);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.confirmPassword_txtbox);
            this.Controls.Add(this.name_txtbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_txtbox);
            this.Controls.Add(this.userName_txtbox);
            this.Controls.Add(this.pictureBox1);
            this.Name = "SignUpForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignUpForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox1;
        private Label label2;
        private Label label1;
        private TextBox password_txtbox;
        private TextBox userName_txtbox;
        private Label label3;
        private Label label4;
        private TextBox confirmPassword_txtbox;
        private TextBox name_txtbox;
        private LinkLabel linkLabel1;
        private Label label5;
    }
}