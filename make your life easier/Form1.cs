using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Timer = System.Windows.Forms.Timer;

namespace make_your_life_easier
{
    public partial class Form1 : Form
    {
        //Fields
        private int borderRadius = 30;
        private int borderSize = 5;
        private Color borderColor = Color.FromArgb(34, 34, 34);
        private Timer transitionTimer;
        private double opacityIncrement = 0.05;


        //Consructor
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.panelTitleBar.BackColor = borderColor;
            this.BackColor = borderColor;
            rjTextBox1.TextAlign = HorizontalAlignment.Center; // Set text alignment to center
        }


        #region -> mouse drag Window
        //Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override CreateParams CreateParams => base.CreateParams;
        #endregion
        #region -> mouse drag
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void rjTextBox4_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        #endregion
        #region -> border,rounded,color
        // Private Methods
        private GraphicsPath GetRoundedPath(Rectangle rect, float radius)
        {
            GraphicsPath path = new GraphicsPath();
            float curveSize = radius * 2F;
            path.StartFigure();
            path.AddArc(rect.X, rect.Y, curveSize, curveSize, 180, 90);
            path.AddArc(rect.Right - curveSize, rect.Y, curveSize, curveSize, 270, 90);
            path.AddArc(rect.Right - curveSize, rect.Bottom - curveSize, curveSize, curveSize, 0, 90);
            path.AddArc(rect.X, rect.Bottom - curveSize, curveSize, curveSize, 90, 90);
            path.CloseFigure();
            return path;
        }
        private void FormRegionAndBorder(Form form, float radius, Graphics graph, Color borderColor, float borderSize)
        {
            if (this.WindowState != FormWindowState.Minimized)
            {
                using (GraphicsPath roundPath = GetRoundedPath(form.ClientRectangle, radius))
                using (Pen penBorder = new Pen(borderColor, borderSize))
                using (Matrix transform = new Matrix())
                {
                    graph.SmoothingMode = SmoothingMode.AntiAlias;
                    form.Region = new Region(roundPath);
                    if (borderSize >= 1)
                    {
                        Rectangle rect = form.ClientRectangle;
                        float scaleX = 1.0F - ((borderSize + 1) / rect.Width);
                        float scaleY = 1.0F - ((borderSize + 1) / rect.Height);

                        transform.Scale(scaleX, scaleY);
                        transform.Translate(borderSize / 1.6F, borderSize / 1.6F);

                        graph.Transform = transform;
                        graph.DrawPath(penBorder, roundPath);
                    }
                }
            }
        }
        private void ControlRegionAndBorder(Control control, float radius, Graphics graph, Color borderColor)
        {
            using (GraphicsPath roundPath = GetRoundedPath(control.ClientRectangle, radius))
            using (Pen penBorder = new Pen(borderColor, 1))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                control.Region = new Region(roundPath);
                graph.DrawPath(penBorder, roundPath);
            }
        }
        private void DrawPath(Rectangle rect, Graphics graph, Color color)
        {
            using (GraphicsPath roundPath = GetRoundedPath(rect, borderRadius))
            using (Pen penBorder = new Pen(color, 3))
            {
                graph.DrawPath(penBorder, roundPath);
            }
        }
        private struct FormBoundsColors
        {
            public Color TopLeftColor;
            public Color TopRightColor;
            public Color BottomLeftColor;
            public Color BottomRightColor;
        }
        private FormBoundsColors GetFormBoundsColors()
        {
            var fbColor = new FormBoundsColors();
            using (var bmp = new Bitmap(1, 1))
            using (Graphics graph = Graphics.FromImage(bmp))
            {
                Rectangle rectBmp = new Rectangle(0, 0, 1, 1);
                //Top Left
                rectBmp.X = this.Bounds.X - 1;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopLeftColor = bmp.GetPixel(0, 0);
                //Top Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Y;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.TopRightColor = bmp.GetPixel(0, 0);
                //Bottom Left
                rectBmp.X = this.Bounds.X;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomLeftColor = bmp.GetPixel(0, 0);
                //Bottom Right
                rectBmp.X = this.Bounds.Right;
                rectBmp.Y = this.Bounds.Bottom;
                graph.CopyFromScreen(rectBmp.Location, Point.Empty, rectBmp.Size);
                fbColor.BottomRightColor = bmp.GetPixel(0, 0);
            }
            return fbColor;
        }
        #endregion

        #region -> Form redisgn
        //Event Methods
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            // - > SMOOTH OUTER BORDER
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle rectForm = this.ClientRectangle;
            int mWidht = rectForm.Width / 2;
            int mHeight = rectForm.Height / 2;
            var fbColors = GetFormBoundsColors();

            //top left
            DrawPath(rectForm, e.Graphics, fbColors.TopLeftColor);

            //Top right
            Rectangle rectTopRight = new Rectangle(mWidht, rectForm.Y, mWidht, mHeight);
            DrawPath(rectTopRight, e.Graphics, fbColors.TopRightColor);

            //Botton Left
            Rectangle rectBottonLeft = new Rectangle(rectForm.X, rectForm.X + mHeight, mWidht, mHeight);
            DrawPath(rectBottonLeft, e.Graphics, fbColors.BottomLeftColor);

            //Botton Right
            Rectangle rectBottonRight = new Rectangle(mWidht, rectForm.Y + mHeight, mWidht, mHeight);
            DrawPath(rectBottonRight, e.Graphics, fbColors.BottomRightColor);

        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(panelContainer, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void Form1_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
        private void application_close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region -> Temp,prefetch,update
        private void update_apps_Click(object sender, EventArgs e)
        {
            try
            {
                // Path to save the file in the Public directory
                string publicDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string batFilePath = Path.Combine(publicDirectoryPath, "Update.bat");

                if (!File.Exists(batFilePath))
                {
                    // If the local .bat file does not exist in the Public directory, download it from GitHub
                    string url = "https://raw.githubusercontent.com/thomasthanos/update_apps/main/Update.bat";
                    WebClient webClient = new WebClient();
                    try
                    {
                        webClient.DownloadFile(url, batFilePath);
                    }
                    catch (WebException webEx)
                    {
                        var response = webEx.Response as HttpWebResponse;
                        if (response != null)
                        {
                            MessageBox.Show($"Failed to download the file. Server returned status code: {response.StatusCode}");
                        }
                        else
                        {
                            MessageBox.Show($"Failed to download the file. Error: {webEx.Message}");
                        }
                        return; // Exit the method to prevent attempting to execute the file
                    }
                }

                // Start a new process to run the .bat file
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.FileName = batFilePath;
                startInfo.UseShellExecute = true;
                startInfo.Verb = "runas";

                process.StartInfo = startInfo;

                process.Start();

                // Wait for the process to exit
                process.WaitForExit();

                // Delete the file after it has been executed
                File.Delete(batFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }


        private void install_apps_Click(object sender, EventArgs e)
        {
            // Create a new instance of the update form
            update updateForm = new update();

            // Set initial opacity for the update form
            updateForm.Opacity = 0;

            // Start the transition timer
            transitionTimer = new Timer();
            transitionTimer.Interval = 10; // Adjust as needed
            transitionTimer.Tick += (s, args) =>
            {
                // Fade out the current form
                this.Opacity -= opacityIncrement;
                if (this.Opacity <= 0)
                {
                    this.Opacity = 0;
                    this.Hide(); // Hide the current form
                                 // Stop the timer once the current form is completely faded out
                    transitionTimer.Stop();
                }

                // Fade in the update form
                updateForm.Opacity += opacityIncrement;
                if (updateForm.Opacity >= 1)
                {
                    updateForm.Opacity = 1;
                    // Stop the timer once the update form is completely faded in
                    transitionTimer.Stop();
                }
            };
            transitionTimer.Start();

            // Show the update form
            updateForm.FormClosed += (s, args) =>
            {
                // When the update form is closed, show the current form again with a transition
                this.Opacity = 0;
                this.Show();
                // Start the transition timer again to fade in the current form
                transitionTimer.Start();
            };
            updateForm.Show();
        }


        private void temp_delete_Click(object sender, EventArgs e)
        {
            try
            {
                // Path to save the file in the Public directory
                string publicDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string batFilePath = Path.Combine(publicDirectoryPath, "temp.bat");

                if (!File.Exists(batFilePath))
                {
                    // If the local .bat file does not exist in the Public directory, download it from GitHub
                    string url = "https://raw.githubusercontent.com/thomasthanos/update_apps/main/temp.bat";
                    WebClient webClient = new WebClient();
                    try
                    {
                        webClient.DownloadFile(url, batFilePath);
                    }
                    catch (WebException webEx)
                    {
                        var response = webEx.Response as HttpWebResponse;
                        if (response != null)
                        {
                            MessageBox.Show($"Failed to download the file. Server returned status code: {response.StatusCode}");
                        }
                        else
                        {
                            MessageBox.Show($"Failed to download the file. Error: {webEx.Message}");
                        }
                        return; // Exit the method to prevent attempting to execute the file
                    }
                }

                // Start a new process to run the .bat file
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();

                startInfo.FileName = batFilePath;
                startInfo.UseShellExecute = true;
                startInfo.Verb = "runas";

                process.StartInfo = startInfo;

                process.Start();

                // Wait for the process to exit
                process.WaitForExit();

                // Delete the file after it has been executed
                File.Delete(batFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
        #endregion

    }
}
