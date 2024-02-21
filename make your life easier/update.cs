using rounded_text_area2;
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

using Octokit;
using System.IO;
using System.Net.Http.Headers;



namespace make_your_life_easier
{
    public partial class update : Form
    {
        public update() //InitializeComponent
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.Padding = new Padding(borderSize);
            this.panelTitleBar.BackColor = borderColor;
            this.BackColor = borderColor;
        }
        private List<CheckedListBox> GetAllCheckedListBox()
        {
            List<CheckedListBox> checkedListBoxes = new List<CheckedListBox>();

            // Add all CheckedListBox controls to the list
            checkedListBoxes.Add(checkedListBox1);
            checkedListBoxes.Add(checkedListBox2);
            checkedListBoxes.Add(checkedListBox3);
            checkedListBoxes.Add(checkedListBox4);
            checkedListBoxes.Add(checkedListBox5);
            checkedListBoxes.Add(checkedListBox6);
            checkedListBoxes.Add(checkedListBox7);
            checkedListBoxes.Add(checkedListBox8);
            checkedListBoxes.Add(checkedListBox9);
            checkedListBoxes.Add(checkedListBox10);
            checkedListBoxes.Add(checkedListBox11);
            checkedListBoxes.Add(checkedListBox12);
            checkedListBoxes.Add(checkedListBox13);
            checkedListBoxes.Add(checkedListBox14);
            checkedListBoxes.Add(checkedListBox15);
            checkedListBoxes.Add(checkedListBox16);
            checkedListBoxes.Add(checkedListBox17);
            checkedListBoxes.Add(checkedListBox18);
            checkedListBoxes.Add(checkedListBox19);
            checkedListBoxes.Add(checkedListBox20);
            checkedListBoxes.Add(checkedListBox21);
            checkedListBoxes.Add(checkedListBox22);
            checkedListBoxes.Add(checkedListBox23);
            checkedListBoxes.Add(checkedListBox24);
            checkedListBoxes.Add(checkedListBox25);
            checkedListBoxes.Add(checkedListBox26);
            checkedListBoxes.Add(checkedListBox27);
            checkedListBoxes.Add(checkedListBox28);
            checkedListBoxes.Add(checkedListBox29);
            checkedListBoxes.Add(checkedListBox30);
            checkedListBoxes.Add(checkedListBox31);
            checkedListBoxes.Add(checkedListBox32);
            checkedListBoxes.Add(checkedListBox33);

            return checkedListBoxes;
        }


        #region -> border-radius, border περιγράμματος,ποσες φορες πατησες το κουμπι, δηλώνει ένα timer για να κανει ενα transition αύξηση διαφάνειας.
        private int borderRadius = 30;
        private int borderSize = 5;
        private int buttonPressCount_check_all = 0;
        private int buttonPressCount_uncheck_all = 0;
        private int buttonPressCount_selected = 0;
        private int buttonPressCount3 = 0;
        private Color borderColor = Color.FromArgb(34, 34, 34);
        private Timer transitionTimer;
        private const int transitionInterval = 10;
        private const double opacityIncrement = 0.05;
        #endregion

        #region -> μετακίνηση της "παραθυρου" με το ποντίκι χρησιμοποιώντας τη μέθοδο Drag.

        // window mouse drag
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);
        protected override CreateParams CreateParams => base.CreateParams;
        private void update_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panelTitleBar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
        private void panelContainer_MouseDown(object sender, MouseEventArgs e)
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

        #region -> Δημιουργία στρογγυλεμένων γραφικών περιγραμμάτων για φόρμες και ελέγχους, καθώς και για την ανάκτηση των χρωμάτων των γωνιών μιας φόρμας.

        // Rounded window and border color
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

        #region -> border,rounded,color
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
        private void update_Paint(object sender, PaintEventArgs e)
        {
            FormRegionAndBorder(this, borderRadius, e.Graphics, borderColor, borderSize);
        }
        private void update_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void update_Load(object sender, EventArgs e)
        {

        }
        private void update_SizeChanged(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void update_Activated(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void panelContainer_Paint(object sender, PaintEventArgs e)
        {
            ControlRegionAndBorder(panelContainer, borderRadius - (borderSize / 2), e.Graphics, borderColor);
        }
        #endregion


        private bool isDownloading = false;
        private void close_window_click(object sender, EventArgs e)
        {
            // Create a new instance of Form1
            Form1 newForm1 = new Form1();
            newForm1.Opacity = 0; // Set initial opacity to 0

            // Start the transition timer
            transitionTimer = new Timer();
            transitionTimer.Interval = transitionInterval;
            transitionTimer.Tick += (s, args) =>
            {
                // Decrease opacity of the current form
                this.Opacity -= opacityIncrement;

                // Increase opacity of the new form
                newForm1.Opacity += opacityIncrement;

                // Check if transition is complete
                if (this.Opacity <= 0)
                {
                    // Close the current instance of Form1
                    this.Close();

                    // Stop the timer
                    transitionTimer.Stop();
                }
            };

            // Show the new instance of Form1
            newForm1.Show();

            // Start the transition timer
            transitionTimer.Start();
        }
        private CheckedListBox[] checkedListBoxes;


        #region -> buttons for the installer
        // Updated method to toggle the checked state of items in a CheckedListBox
        public void Alert(string msg, alert_message.enmType type)
        {
            alert_message frm = new alert_message();
            frm.showAlert(msg, type);
        }
        private void ToggleCheckedState(CheckedListBox checkedListBox)
        {
            // Check if all items are currently checked
            bool allChecked = true;
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                if (!checkedListBox.GetItemChecked(i))
                {
                    allChecked = false;
                    break;
                }
            }
            // Toggle the checked state of all items
            for (int i = 0; i < checkedListBox.Items.Count; i++)
            {
                checkedListBox.SetItemChecked(i, !allChecked);
            }
        }

        private void check_all(object sender, EventArgs e)
        {
            buttonPressCount_check_all++; // Increment button press count

            if (buttonPressCount_check_all == 3)
            {
                // Show message after two button presses
                this.Alert("Dont spam the button", alert_message.enmType.Warning);
                buttonPressCount_check_all = 1; // Reset counter after showing message

                // Disable the button temporarily
                rjButton4.Enabled = false;

                // Set a timer to re-enable the button after a delay
                Timer enableButtonTimer = new Timer();
                enableButtonTimer.Interval = 1000; // 3000 milliseconds = 3 seconds
                enableButtonTimer.Tick += (sender, e) =>
                {
                    rjButton4.Enabled = true;
                    enableButtonTimer.Stop(); // Stop the timer
                };
                enableButtonTimer.Start(); // Start the timer
            }

            // Get all CheckedListBox controls
            List<CheckedListBox> checkedListBoxes = GetAllCheckedListBox();


            // Loop through all CheckedListBox controls
            foreach (CheckedListBox checkedListBox in checkedListBoxes)
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    checkedListBox.SetItemChecked(i, false); // Uncheck all items
                }
                ToggleCheckedState(checkedListBox); // Toggle checked state
            }
        }

        private void uncheck_all(object sender, EventArgs e)
        {
            buttonPressCount_uncheck_all++; // Increment button press count

            if (buttonPressCount_uncheck_all == 3)
            {
                // Show message after three button presses
                this.Alert("Dont spam the button", alert_message.enmType.Warning);
                buttonPressCount_uncheck_all = 1; // Reset counter after showing message

                // Disable the button temporarily
                rjButton2.Enabled = false;

                // Set a timer to re-enable the button after a delay
                Timer enableButtonTimer = new Timer();
                enableButtonTimer.Interval = 1000; // 3000 milliseconds = 3 seconds
                enableButtonTimer.Tick += (sender, e) =>
                {
                    rjButton2.Enabled = true;
                    enableButtonTimer.Stop(); // Stop the timer
                };
                enableButtonTimer.Start(); // Start the timer
            }



            // Uncheck all items in the CheckedListBox controls
            // Get all CheckedListBox controls
            List<CheckedListBox> checkedListBoxes = GetAllCheckedListBox();

            foreach (CheckedListBox checkedListBox in checkedListBoxes)
            {
                for (int i = 0; i < checkedListBox.Items.Count; i++)
                {
                    checkedListBox.SetItemChecked(i, false); // Uncheck all items
                }
            }
        }

        private void Selected(object sender, EventArgs e)
        {


            listBox1.Items.Clear(); // Clear the listBox
            // Get all CheckedListBox controls
            List<CheckedListBox> checkedListBoxes = GetAllCheckedListBox();

            try
            {
                // Check if any checkbox is checked
                bool anyChecked = checkedListBoxes.Any(checkedListBox => checkedListBox.CheckedItems.Count > 0);

                if (!anyChecked)
                {
                    this.Alert("First select one app", alert_message.enmType.Info);
                    return;


                }

                // Path to save the file in the Public directory
                string publicDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string batFilePath = Path.Combine(publicDirectoryPath, "install_apps.bat");

                // Clear the existing content of the .bat file or create a new one if it doesn't exist
                using (StreamWriter sw = File.CreateText(batFilePath))
                {
                    // Add the initial command to start the batch file
                    sw.WriteLine("@echo off");
                    sw.WriteLine("echo Installing selected applications...");

                    // Iterate through each checkedListBox
                    foreach (CheckedListBox checkedListBox in checkedListBoxes)
                    {
                        // Iterate through the checked items in the current checkedListBox
                        foreach (string item in checkedListBox.CheckedItems)
                        {
                            // Add the item to the listBox
                            listBox1.Items.Add(item);
                            // Append command lines to the batch file to install the selected applications using winget
                            sw.WriteLine($"winget install {item}");
                        }
                    }

                    // Add a message to indicate the completion of installations
                    sw.WriteLine("echo Installation completed.");
                    // Add a pause to keep the command window open after installation
                    sw.WriteLine("pause");
                }

                this.Alert("Click Install now", alert_message.enmType.Notification);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void unistaller(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count == 0)
                {
                    this.Alert("the list is empty", alert_message.enmType.Info);
                    return;
                }

                // Path to save the file in the Public directory
                string publicDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string batFilePath = Path.Combine(publicDirectoryPath, "uninstall_apps.bat");

                // Clear the existing content of the .bat file or create a new one if it doesn't exist
                using (StreamWriter sw = File.CreateText(batFilePath))
                {
                    // Add the initial command to start the batch file
                    sw.WriteLine("@echo off");
                    sw.WriteLine("echo Uninstalling selected applications from Listbox 1...");

                    // Iterate over all items in the ListBox
                    foreach (var item in listBox1.Items)
                    {
                        // Assuming the items are strings, you can directly use them
                        string phrase = item.ToString();
                        sw.WriteLine($"winget uninstall {phrase}");
                        // Add a delay of 5 seconds after each uninstallation
                        sw.WriteLine("timeout /t 5 /nobreak >nul");
                    }

                    // Add a message to indicate the completion of uninstallations
                    sw.WriteLine("echo Uninstallation completed.");
                    // Add a pause to keep the command window open after uninstallation
                    sw.WriteLine("pause");
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
                this.Alert("admin perms not accepted", alert_message.enmType.Error);
            }
        }

        private void install(object sender, EventArgs e)
        {
            try
            {
                if (listBox1.Items.Count == 0)
                {
                    this.Alert("the list is empty", alert_message.enmType.Info);
                    return;
                }

                // Path to save the file in the Public directory
                string publicDirectoryPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonDocuments);
                string batFilePath = Path.Combine(publicDirectoryPath, "install_apps.bat");

                // Clear the existing content of the .bat file or create a new one if it doesn't exist
                using (StreamWriter sw = File.CreateText(batFilePath))
                {
                    // Add the initial command to start the batch file
                    sw.WriteLine("@echo off");
                    sw.WriteLine("echo installing selected applications from Listbox 1...");

                    // Iterate over all items in the ListBox
                    foreach (var item in listBox1.Items)
                    {
                        // Assuming the items are strings, you can directly use them
                        string phrase = item.ToString();
                        sw.WriteLine($"winget install {phrase}");
                        sw.WriteLine("timeout /t 5 /nobreak >nul");
                    }

                    // Add a message to indicate the completion of uninstallations
                    sw.WriteLine("echo installation completed.");
                    // Add a pause to keep the command window open after uninstallation
                    sw.WriteLine("pause");
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
                this.Alert("admin perms not accepted", alert_message.enmType.Error);
            }
        }

        #endregion











        private void rjButton9_Click(object sender, EventArgs e)
        {
            if (!isDownloading)
            {
                isDownloading = true;
                this.Alert("Dont spam the button", alert_message.enmType.Warning);
                string url = "https://github.com/BetterDiscord/Installer/releases/latest/download/BetterDiscord-Windows.exe";
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "BetterDiscord-Windows.exe");

                // Αλλάζει το cursor σε "No"
                this.Cursor = Cursors.No;

                // Αλλάζει το χρώμα του κουμπιού σε μαύρο
                rjButton9.BackColor = Color.Black;
                rjButton9.ForeColor = Color.White;

                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileCompleted += (sender, e) =>
                    {
                        isDownloading = false;
                        // Αλλάζει πίσω το cursor
                        this.Cursor = Cursors.Default;

                        // Αναστρέφει το χρώμα του κουμπιού στην αρχική του κατάσταση
                        rjButton9.BackColor = SystemColors.Control;
                        rjButton9.ForeColor = SystemColors.ControlText;

                        if (e.Error == null)
                        {
                            Process.Start(fileName);
                        }
                        else
                        {
                            this.Alert("An error occurred while downloading the app", alert_message.enmType.Error);
                        }
                    };
                    wc.DownloadFileAsync(new Uri(url), fileName);
                }

                // Απενεργοποιεί το κουμπί για 20 δευτερόλεπτα.
                rjButton9.Enabled = false;
                Timer timer = new Timer();
                timer.Interval = 20000; // 20 δευτερόλεπτα
                timer.Tick += (s, ev) =>
                {
                    rjButton9.Enabled = true;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        private void rjButton11_Click(object sender, EventArgs e)
        {
            if (!isDownloading)
            {
                isDownloading = true;
                this.Alert("Dont spam the button", alert_message.enmType.Warning);
                string url = "https://github.com/Vencord/Installer/releases/latest/download/VencordInstaller.exe";
                string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads", "VencordInstaller.exe");

                // Αλλάζει το cursor σε "No"
                this.Cursor = Cursors.No;

                // Αλλάζει το χρώμα του κουμπιού σε μαύρο
                rjButton11.BackColor = Color.Black;
                rjButton11.ForeColor = Color.White;

                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFileCompleted += (sender, e) =>
                    {
                        isDownloading = false;
                        // Αλλάζει πίσω το cursor
                        this.Cursor = Cursors.Default;

                        // Αναστρέφει το χρώμα του κουμπιού στην αρχική του κατάσταση
                        rjButton11.BackColor = SystemColors.Control;
                        rjButton11.ForeColor = SystemColors.ControlText;

                        if (e.Error == null)
                        {
                            Process.Start(fileName);
                        }
                        else
                        {
                            this.Alert("An error occurred while downloading the app", alert_message.enmType.Error);
                        }
                    };
                    wc.DownloadFileAsync(new Uri(url), fileName);
                }

                // Απενεργοποιεί το κουμπί για 20 δευτερόλεπτα.
                rjButton11.Enabled = false;
                Timer timer = new Timer();
                timer.Interval = 20000; // 20 δευτερόλεπτα
                timer.Tick += (s, ev) =>
                {
                    rjButton11.Enabled = true;
                    timer.Stop();
                    timer.Dispose();
                };
                timer.Start();
            }
        }

        private void rjButton10_Click(object sender, EventArgs e)
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads");

            // Λίστα για να αποθηκεύσουμε όλα τα αρχεία με κατάληξη .exe στον φάκελο.
            string[] exeFiles = Directory.GetFiles(folderPath, "*.exe");

            // Δημιουργία μηνύματος για επιβεβαίωση της διαγραφής.
            string confirmMessage = "Είστε σίγουρος ότι θέλετε να διαγράψετε τα παρακάτω αρχεία;\n";
            foreach (string file in exeFiles)
            {
                confirmMessage += Path.GetFileName(file) + "\n";
            }
            confirmMessage += "\nΘέλετε να συνεχίσετε;";

            // Εμφάνιση μηνύματος επιβεβαίωσης.
            DialogResult result = MessageBox.Show(confirmMessage, "Επιβεβαίωση Διαγραφής", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Αν ο χρήστης επιλέξει να συνεχίσει, τότε διαγράψτε τα αρχεία.
            if (result == DialogResult.Yes)
            {
                // Διαγραφή κάθε αρχείου .exe που βρίσκεται στο φάκελο.
                foreach (string file in exeFiles)
                {
                    try
                    {
                        File.Delete(file);
                    }
                    catch (Exception ex)
                    {
                        this.Alert("Σφάλμα κατά τη διαγραφή του αρχείου", alert_message.enmType.Error);
                    }
                }

                // Εμφάνιση μηνύματος επιβεβαίωσης ολοκλήρωσης.
                this.Alert("Η διαγραφή ολοκληρώθηκε", alert_message.enmType.Info);
            }
        }
    }
}