namespace make_your_life_easier
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            panelContainer = new Panel();
            Update_apps = new rounded_things.RJButton();
            delete_temp = new rounded_things.RJButton();
            install_apps = new rounded_things.RJButton();
            rjTextBox3 = new rounded_text_area2.RJTextBox();
            rjTextBox2 = new rounded_text_area2.RJTextBox();
            rjTextBox1 = new rounded_text_area2.RJTextBox();
            panelTitleBar = new Panel();
            pictureBox1 = new PictureBox();
            rjTextBox4 = new rounded_text_area2.RJTextBox();
            application_close = new Button();
            panelContainer.SuspendLayout();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panelContainer
            // 
            panelContainer.BackColor = Color.Gray;
            panelContainer.Controls.Add(Update_apps);
            panelContainer.Controls.Add(delete_temp);
            panelContainer.Controls.Add(install_apps);
            panelContainer.Controls.Add(rjTextBox3);
            panelContainer.Controls.Add(rjTextBox2);
            panelContainer.Controls.Add(rjTextBox1);
            panelContainer.Controls.Add(panelTitleBar);
            panelContainer.Dock = DockStyle.Fill;
            panelContainer.Location = new Point(0, 0);
            panelContainer.Name = "panelContainer";
            panelContainer.Size = new Size(464, 276);
            panelContainer.TabIndex = 0;
            panelContainer.Paint += panelContainer_Paint;
            // 
            // Update_apps
            // 
            Update_apps.BackColor = Color.White;
            Update_apps.BorderColor = SystemColors.ActiveCaption;
            Update_apps.BorderRadius = 23;
            Update_apps.BorderSize = 3;
            Update_apps.Cursor = Cursors.Hand;
            Update_apps.FlatAppearance.BorderColor = Color.Lime;
            Update_apps.FlatAppearance.BorderSize = 0;
            Update_apps.FlatStyle = FlatStyle.Flat;
            Update_apps.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            Update_apps.ForeColor = Color.Black;
            Update_apps.Location = new Point(296, 78);
            Update_apps.Name = "Update_apps";
            Update_apps.Size = new Size(95, 38);
            Update_apps.TabIndex = 6;
            Update_apps.Text = "Open";
            Update_apps.TextColor = Color.Black;
            Update_apps.UseVisualStyleBackColor = false;
            Update_apps.Click += update_apps_Click;
            // 
            // delete_temp
            // 
            delete_temp.BackColor = Color.White;
            delete_temp.BorderColor = SystemColors.ActiveCaption;
            delete_temp.BorderRadius = 23;
            delete_temp.BorderSize = 3;
            delete_temp.Cursor = Cursors.Hand;
            delete_temp.FlatAppearance.BorderColor = Color.Lime;
            delete_temp.FlatAppearance.BorderSize = 0;
            delete_temp.FlatStyle = FlatStyle.Flat;
            delete_temp.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            delete_temp.ForeColor = Color.Black;
            delete_temp.Location = new Point(296, 137);
            delete_temp.Name = "delete_temp";
            delete_temp.Size = new Size(95, 38);
            delete_temp.TabIndex = 5;
            delete_temp.Text = "Open";
            delete_temp.TextColor = Color.Black;
            delete_temp.UseVisualStyleBackColor = false;
            delete_temp.Click += temp_delete_Click;
            // 
            // install_apps
            // 
            install_apps.BackColor = Color.White;
            install_apps.BorderColor = SystemColors.ActiveCaption;
            install_apps.BorderRadius = 23;
            install_apps.BorderSize = 3;
            install_apps.Cursor = Cursors.Hand;
            install_apps.FlatAppearance.BorderColor = Color.Lime;
            install_apps.FlatAppearance.BorderSize = 0;
            install_apps.FlatStyle = FlatStyle.Flat;
            install_apps.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            install_apps.ForeColor = Color.Black;
            install_apps.Location = new Point(296, 195);
            install_apps.Name = "install_apps";
            install_apps.Size = new Size(95, 38);
            install_apps.TabIndex = 4;
            install_apps.Text = "Open";
            install_apps.TextColor = Color.Black;
            install_apps.UseVisualStyleBackColor = false;
            install_apps.Click += install_apps_Click;
            // 
            // rjTextBox3
            // 
            rjTextBox3.BackColor = Color.White;
            rjTextBox3.BorderColor = SystemColors.ActiveCaption;
            rjTextBox3.BorderFocusColor = Color.HotPink;
            rjTextBox3.BorderRadius = 15;
            rjTextBox3.BorderSize = 3;
            rjTextBox3.Cursor = Cursors.No;
            rjTextBox3.Enabled = false;
            rjTextBox3.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            rjTextBox3.ForeColor = Color.Black;
            rjTextBox3.Location = new Point(23, 137);
            rjTextBox3.Margin = new Padding(4);
            rjTextBox3.Multiline = false;
            rjTextBox3.Name = "rjTextBox3";
            rjTextBox3.Padding = new Padding(35, 7, 7, 7);
            rjTextBox3.PasswordChar = false;
            rjTextBox3.PlaceholderColor = Color.Black;
            rjTextBox3.PlaceholderText = "";
            rjTextBox3.Size = new Size(200, 38);
            rjTextBox3.TabIndex = 3;
            rjTextBox3.Texts = "Delete temp files";
            rjTextBox3.UnderlinedStyle = false;
            // 
            // rjTextBox2
            // 
            rjTextBox2.BackColor = Color.White;
            rjTextBox2.BorderColor = SystemColors.ActiveCaption;
            rjTextBox2.BorderFocusColor = Color.HotPink;
            rjTextBox2.BorderRadius = 15;
            rjTextBox2.BorderSize = 3;
            rjTextBox2.Cursor = Cursors.No;
            rjTextBox2.Enabled = false;
            rjTextBox2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            rjTextBox2.ForeColor = Color.Black;
            rjTextBox2.Location = new Point(23, 78);
            rjTextBox2.Margin = new Padding(4);
            rjTextBox2.Multiline = false;
            rjTextBox2.Name = "rjTextBox2";
            rjTextBox2.Padding = new Padding(50, 7, 7, 7);
            rjTextBox2.PasswordChar = false;
            rjTextBox2.PlaceholderColor = Color.Black;
            rjTextBox2.PlaceholderText = "";
            rjTextBox2.Size = new Size(200, 38);
            rjTextBox2.TabIndex = 2;
            rjTextBox2.Texts = "Update Apps";
            rjTextBox2.UnderlinedStyle = false;
            // 
            // rjTextBox1
            // 
            rjTextBox1.BackColor = Color.White;
            rjTextBox1.BorderColor = SystemColors.ActiveCaption;
            rjTextBox1.BorderFocusColor = Color.HotPink;
            rjTextBox1.BorderRadius = 15;
            rjTextBox1.BorderSize = 3;
            rjTextBox1.Cursor = Cursors.No;
            rjTextBox1.Enabled = false;
            rjTextBox1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);
            rjTextBox1.ForeColor = Color.Black;
            rjTextBox1.Location = new Point(23, 195);
            rjTextBox1.Margin = new Padding(4);
            rjTextBox1.Multiline = false;
            rjTextBox1.Name = "rjTextBox1";
            rjTextBox1.Padding = new Padding(50, 7, 7, 7);
            rjTextBox1.PasswordChar = false;
            rjTextBox1.PlaceholderColor = Color.Black;
            rjTextBox1.PlaceholderText = "";
            rjTextBox1.Size = new Size(200, 38);
            rjTextBox1.TabIndex = 1;
            rjTextBox1.Texts = "Install Apps";
            rjTextBox1.UnderlinedStyle = false;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(34, 34, 34);
            panelTitleBar.Controls.Add(pictureBox1);
            panelTitleBar.Controls.Add(rjTextBox4);
            panelTitleBar.Controls.Add(application_close);
            panelTitleBar.Cursor = Cursors.Hand;
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(0, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(464, 40);
            panelTitleBar.TabIndex = 0;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Location = new Point(118, -3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(40, 40);
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            // 
            // rjTextBox4
            // 
            rjTextBox4.BackColor = Color.FromArgb(34, 34, 34);
            rjTextBox4.BorderColor = Color.Maroon;
            rjTextBox4.BorderFocusColor = Color.HotPink;
            rjTextBox4.BorderRadius = 0;
            rjTextBox4.BorderSize = 2;
            rjTextBox4.Cursor = Cursors.Hand;
            rjTextBox4.Enabled = false;
            rjTextBox4.Font = new Font("Comic Sans MS", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            rjTextBox4.ForeColor = Color.DimGray;
            rjTextBox4.Location = new Point(161, -20);
            rjTextBox4.Margin = new Padding(0);
            rjTextBox4.Multiline = false;
            rjTextBox4.Name = "rjTextBox4";
            rjTextBox4.Padding = new Padding(2, 38, 5, 15);
            rjTextBox4.PasswordChar = false;
            rjTextBox4.PlaceholderColor = Color.DarkGray;
            rjTextBox4.PlaceholderText = "";
            rjTextBox4.Size = new Size(168, 77);
            rjTextBox4.TabIndex = 8;
            rjTextBox4.Texts = "Make your life easier";
            rjTextBox4.UnderlinedStyle = true;
            rjTextBox4.MouseDown += rjTextBox4_MouseDown;
            // 
            // application_close
            // 
            application_close.BackColor = Color.FromArgb(34, 34, 34);
            application_close.FlatAppearance.BorderSize = 0;
            application_close.FlatStyle = FlatStyle.Flat;
            application_close.Font = new Font("Segoe Script", 18F, FontStyle.Bold, GraphicsUnit.Point, 161);
            application_close.ForeColor = Color.White;
            application_close.Location = new Point(397, -3);
            application_close.Name = "application_close";
            application_close.Size = new Size(40, 40);
            application_close.TabIndex = 1;
            application_close.Text = "X";
            application_close.UseVisualStyleBackColor = false;
            application_close.Click += application_close_Click;
            // 
            // Form1
            // 
            BackColor = SystemColors.Window;
            ClientSize = new Size(464, 276);
            Controls.Add(panelContainer);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Activated += Form1_Activated;
            Load += Form1_Load_1;
            ResizeEnd += Form1_ResizeEnd;
            SizeChanged += Form1_SizeChanged;
            Paint += Form1_Paint;
            MouseDown += Form1_MouseDown;
            panelContainer.ResumeLayout(false);
            panelTitleBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelContainer;
        private Panel panelTitleBar;
        private Button application_close;
        private rounded_text_area2.RJTextBox rjTextBox1;
        private rounded_text_area2.RJTextBox rjTextBox2;
        private rounded_text_area2.RJTextBox rjTextBox3;
        private rounded_things.RJButton install_apps;
        private rounded_things.RJButton Update_apps;
        private rounded_things.RJButton delete_temp;
        private PictureBox pictureBox1;
        private rounded_text_area2.RJTextBox rjTextBox4;
    }
}
