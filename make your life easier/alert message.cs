using make_your_life_easier.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace make_your_life_easier
{
    public partial class alert_message : Form
    {
        #region -> InitializeComponent
        public alert_message()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None; // Remove the standard border
            this.DoubleBuffered = true; // Enable double buffering to reduce flickering
        }
        #endregion

        #region -> priviet
        public enum enmAction
        {
            wait,
            start,
            close
        }
        public enum enmType
        {
            Success,
            Warning,
            Error,
            Info,
            Notification
        }
        private int borderRadius = 30;
        private alert_message.enmAction action;
        private int x, y;
        #endregion

        #region -> popout message
        private void rjButton1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (this.action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    timer1.Interval = 1;
                    this.Opacity += 0.1;
                    if (this.x < this.Location.X)
                    {
                        this.Left--;
                    }
                    else
                    {
                        if (this.Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:

                    timer1.Interval = 1;
                    this.Opacity -= 0.1;

                    this.Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();
        }
        #endregion

        public void showAlert(string msg,enmType type)
        {
            this.Opacity = 0.0;
            this.StartPosition = FormStartPosition.Manual;
            string fname;

            // Check if the alert has been displayed more than three times
            int displayCount = 0;
            for (int i = 0; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                alert_message frm = (alert_message)Application.OpenForms[fname];
                if (frm != null)
                {
                    displayCount++;
                }
            }

            if (displayCount >= 4)
            {
                // Stop showing the alert for 10 seconds
                timer2.Interval = 15000; // 10 seconds
                timer2.Start();
                return;
            }

            // Calculate initial position at the center of the right side of the screen
            this.x = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
            this.y = (Screen.PrimaryScreen.WorkingArea.Height - this.Height) / 2;

            // Calculate vertical offset between each alert
            int verticalOffset = 10; // Adjust this value as needed

            // Loop through existing alert forms to find the last one
            for (int i = 0; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                alert_message frm = (alert_message)Application.OpenForms[fname];

                if (frm == null)
                {
                    this.Name = fname;
                    this.Location = new Point(this.x, this.y);
                    break;
                }
                else
                {
                    // If an existing alert form is found, update y coordinate
                    // If an existing alert form is found, update y coordinate with vertical offset
                    this.y = frm.Bottom + verticalOffset; // Place the new alert form below the last one with a space
                }
            }

            switch (type)
            {
                case enmType.Success:
                    this.pictureBox1.Image = Resources.success5;
                    this.BackColor = Color.FromArgb(0, 129, 64);
                    break;
                case enmType.Error:
                    this.pictureBox1.Image = Resources.error5;
                    this.BackColor = Color.DarkRed;
                    break;
                case enmType.Info:
                    this.pictureBox1.Image = Resources.info5;
                    this.BackColor = Color.FromArgb(211, 211, 211);
                    break;
                case enmType.Warning:
                    this.pictureBox1.Image = Resources.warning5;
                    this.BackColor = Color.DarkOrange;
                    break;
                case enmType.Notification:
                    this.pictureBox1.Image = Resources.notifie5;
                    this.BackColor = Color.Gray;
                    break;
            }
            // Set the region to create a rounded border effect only on the bottom-left side
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, 2 * borderRadius, 2 * borderRadius, 180, 90); // Top-left corner
            path.AddLine(0, borderRadius, 0, this.Height - borderRadius); // Left side
            path.AddArc(0, this.Height - 2 * borderRadius, 2 * borderRadius, 2 * borderRadius, 90, 90); // Bottom-left corner
            path.AddLine(borderRadius, this.Height, this.Width, this.Height); // Bottom side
            path.AddLine(this.Width, this.Height, this.Width, 0); // Right side
            path.AddLine(this.Width, 0, borderRadius, 0); // Top side
            path.CloseFigure();
            this.Region = new Region(path);

            this.lblMsg.Text = msg;
            this.Show();
            this.action = enmAction.start;
            this.timer1.Interval = 1;
            timer1.Start();

        }


    }
}
