namespace make_your_life_easier
{
    partial class alert_message
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
            components = new System.ComponentModel.Container();
            lblMsg = new Label();
            pictureBox1 = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            timer2 = new System.Windows.Forms.Timer(components);
            rjButton1 = new rounded_things.RJButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblMsg
            // 
            lblMsg.AutoSize = true;
            lblMsg.FlatStyle = FlatStyle.Flat;
            lblMsg.Font = new Font("Comic Sans MS", 16.25F, FontStyle.Bold | FontStyle.Italic);
            lblMsg.Location = new Point(63, 39);
            lblMsg.Name = "lblMsg";
            lblMsg.Size = new Size(229, 32);
            lblMsg.TabIndex = 0;
            lblMsg.Text = "First select one app";
            lblMsg.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Bottom;
            pictureBox1.Image = Properties.Resources.warning5;
            pictureBox1.Location = new Point(12, 34);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(48, 44);
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // timer2
            // 
            timer2.Tick += timer2_Tick;
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.Transparent;
            rjButton1.BackgroundImage = Properties.Resources.close5;
            rjButton1.BorderColor = Color.PaleVioletRed;
            rjButton1.BorderRadius = 40;
            rjButton1.BorderSize = 0;
            rjButton1.Cursor = Cursors.Hand;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.ForeColor = Color.White;
            rjButton1.Location = new Point(421, 33);
            rjButton1.Name = "rjButton1";
            rjButton1.Size = new Size(45, 45);
            rjButton1.TabIndex = 4;
            rjButton1.TextColor = Color.White;
            rjButton1.UseVisualStyleBackColor = false;
            rjButton1.Click += rjButton1_Click;
            // 
            // alert_message
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ActiveCaption;
            ClientSize = new Size(481, 110);
            Controls.Add(rjButton1);
            Controls.Add(pictureBox1);
            Controls.Add(lblMsg);
            Font = new Font("Arial", 12F, FontStyle.Regular, GraphicsUnit.Point, 161);
            FormBorderStyle = FormBorderStyle.None;
            Name = "alert_message";
            Text = "alert_message";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblMsg;
        private PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private rounded_things.RJButton rjButton1;
    }
}