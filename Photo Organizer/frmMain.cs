using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Goheer.EXIF;
using System.Drawing.Imaging;

namespace PhotoOrganizer
{
    /// <summary>
    /// Summary description for Form1.
    /// </summary>
    public partial class frmMain : Form
    {
        private Label lblFile;
        private TextBox txtSourceFolder;
        private Button btnBrowse;
        private Button btnGo;
        private Button button1;
        private TextBox txtDestinationFolder;
        private Label label1;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private readonly System.ComponentModel.Container components = null;

        public frmMain()
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.lblFile = new System.Windows.Forms.Label();
            this.txtSourceFolder = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtDestinationFolder = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.cbOverwrite = new System.Windows.Forms.CheckBox();
            this.cbMove = new System.Windows.Forms.CheckBox();
            this.deleteEmptyDirsSource = new System.Windows.Forms.Button();
            this.deleteEmptyDirsTarget = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 9);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(41, 13);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "Source";
            // 
            // txtSourceFolder
            // 
            this.txtSourceFolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtSourceFolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtSourceFolder.Location = new System.Drawing.Point(56, 6);
            this.txtSourceFolder.Name = "txtSourceFolder";
            this.txtSourceFolder.Size = new System.Drawing.Size(506, 20);
            this.txtSourceFolder.TabIndex = 1;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(568, 3);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowseSource_Click);
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(56, 109);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(568, 29);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Browse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnBrowseDestination_Click);
            // 
            // txtDestinationFolder
            // 
            this.txtDestinationFolder.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDestinationFolder.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.txtDestinationFolder.Location = new System.Drawing.Point(56, 32);
            this.txtDestinationFolder.Name = "txtDestinationFolder";
            this.txtDestinationFolder.Size = new System.Drawing.Size(506, 20);
            this.txtDestinationFolder.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Target";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(955, 329);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "save log";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnSave_click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 149);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1018, 174);
            this.richTextBox1.TabIndex = 11;
            this.richTextBox1.Text = "";
            // 
            // cbOverwrite
            // 
            this.cbOverwrite.AutoSize = true;
            this.cbOverwrite.Location = new System.Drawing.Point(56, 81);
            this.cbOverwrite.Name = "cbOverwrite";
            this.cbOverwrite.Size = new System.Drawing.Size(170, 17);
            this.cbOverwrite.TabIndex = 12;
            this.cbOverwrite.Text = "Always Overwrite Existing Files";
            this.cbOverwrite.UseVisualStyleBackColor = true;
            // 
            // cbMove
            // 
            this.cbMove.AutoSize = true;
            this.cbMove.Location = new System.Drawing.Point(56, 58);
            this.cbMove.Name = "cbMove";
            this.cbMove.Size = new System.Drawing.Size(109, 17);
            this.cbMove.TabIndex = 13;
            this.cbMove.Text = "Delete After Copy";
            this.cbMove.UseVisualStyleBackColor = true;
            // 
            // deleteEmptyDirsSource
            // 
            this.deleteEmptyDirsSource.Location = new System.Drawing.Point(12, 329);
            this.deleteEmptyDirsSource.Name = "deleteEmptyDirsSource";
            this.deleteEmptyDirsSource.Size = new System.Drawing.Size(333, 23);
            this.deleteEmptyDirsSource.TabIndex = 6;
            this.deleteEmptyDirsSource.Text = "Delete Empty Subdirectories in Source";
            this.deleteEmptyDirsSource.UseVisualStyleBackColor = true;
            this.deleteEmptyDirsSource.Click += new System.EventHandler(this.deleteEmptyDirsSource_Click);
            // 
            // deleteEmptyDirsTarget
            // 
            this.deleteEmptyDirsTarget.Location = new System.Drawing.Point(12, 358);
            this.deleteEmptyDirsTarget.Name = "deleteEmptyDirsTarget";
            this.deleteEmptyDirsTarget.Size = new System.Drawing.Size(333, 23);
            this.deleteEmptyDirsTarget.TabIndex = 14;
            this.deleteEmptyDirsTarget.Text = "Delete Empty Subdirectories in Target";
            this.deleteEmptyDirsTarget.UseVisualStyleBackColor = true;
            this.deleteEmptyDirsTarget.Click += new System.EventHandler(this.deleteEmptyDirsTarget_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(728, 368);
            this.progressBar1.Maximum = 10000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(302, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 15;
            this.progressBar1.Value = 100;
            // 
            // frmMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1042, 403);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.deleteEmptyDirsTarget);
            this.Controls.Add(this.cbMove);
            this.Controls.Add(this.cbOverwrite);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteEmptyDirsSource);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtDestinationFolder);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.txtSourceFolder);
            this.Controls.Add(this.lblFile);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Exif Organizer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new frmMain());
        }

        private void btnBrowseSource_Click(object sender, EventArgs e)
        {

            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtSourceFolder.Text = fbd.SelectedPath;
            }
        }

        private void btnBrowseDestination_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
      
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtDestinationFolder.Text = fbd.SelectedPath;
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if(!Directory.Exists(txtSourceFolder.Text))
            {
                MessageBox.Show("Please choose a valid source directory.");
                return;
            }
            if (!Directory.Exists(txtDestinationFolder.Text))
            {
                try
                {
                    DirectoryInfo dirInfo = Directory.CreateDirectory(txtSourceFolder.Text);
                    if (!dirInfo.Exists) throw new Exception("Could not create the directory!");
                }
                catch
                {
                    MessageBox.Show("Please choose a valid destination directory.");
                    return;
                }
            }

            string[] filePaths = Directory.GetFiles(txtSourceFolder.Text, "*", SearchOption.AllDirectories);
            DateTime datePictureTaken = new DateTime();
            System.Text.StringBuilder sb = new System.Text.StringBuilder("Starting.");
            int i = 0;
            foreach (string sourceFilePath in filePaths)
            {
                i++;
                progressBar1.Value = (int)(((double)i / (double)filePaths.Length) * 10000);
                richTextBox1.Text = sb.ToString();
                Application.DoEvents(); //forces UI update

              


                datePictureTaken = DateTime.MaxValue;
                FileInfo info = new FileInfo(sourceFilePath);
                if (info.Exists)
                {
                    if ((info.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden)
                    {
                        sb.Insert(0, string.Format("File {0} skipped, it is a hidden file.\n", sourceFilePath));
                        // the file is hidden, skip it.
                        continue;
                    }

                    if ((info.Attributes & FileAttributes.System) == FileAttributes.System)
                    {
                        sb.Insert(0, string.Format("File {0} skipped, it is a system file.\n", sourceFilePath));
                        // the file is system, skip it.
                        continue;
                    }
                 
                    string[] supportedExtensions = { ".jpeg", ".jpg", ".bmp" , ".gif", ".exif", ".png", ".tiff"};
                    string extension = info.Extension.ToLower();

                    if (supportedExtensions.Any(extension.ToLowerInvariant().Contains))
                    {
                        using (System.Drawing.Bitmap bmp = new System.Drawing.Bitmap(sourceFilePath))
                        {

                            // create a new instance of Extractor 
                            // class. Here "\n" is the newline 
                            // that is used to seprate output of two tags. 
                            // You can replace it with "," if you want
                            Goheer.EXIF.EXIFextractor er = new Goheer.EXIF.EXIFextractor(bmp, "\n");


                            // now dump all the tags on console
                            //Console.Write(er);

                            // to set a tag you have to specify the tag id
                            // code 0x13B is for artist name
                            // since this number has ascii string with 
                            // it pass the string you want to set
                            //er.setTag(0x13B, "http://www.goheer.com");

                            // dispose the image here or do whatever you want.                        
                            // Extract the tag data using the ExifTags enumeration
                            object temp = er["DTOrig"];

                            if (temp != null)
                            {
                                if (DateTime.TryParseExact(temp.ToString().Replace("\0", string.Empty).Trim(), "yyyy:MM:dd HH:mm:ss", System.Globalization.CultureInfo.CurrentCulture, System.Globalization.DateTimeStyles.None, out datePictureTaken))
                                {
                                    if (datePictureTaken.Year < 1950 || datePictureTaken.Year >= 9999)
                                    {
                                        sb.Insert(0, string.Format("ERROR: File {0}, DTOrig data bad: read as \"{1}\".\n", sourceFilePath, temp.ToString()));
                                        DialogResult dr = MessageBox.Show(string.Format("File {0}, read DTOrig as {1}. Creation time is {2}, Last modified time is {3}. Press OK to continue processing this file, cancel to skip.", sourceFilePath, temp.ToString(), info.CreationTime, info.LastWriteTime), "Error", MessageBoxButtons.OKCancel);
                                        if(dr != DialogResult.OK)
                                        {
                                            continue;
                                        }
                                    }
                                    sb.Insert(0, string.Format("File {0}, DTOrig exif data successfully parsed.\n", sourceFilePath));
                                    //we had success reading the exif date, maybe the rotation is set too, we can auto-rotate here.
                                    //RotateImage(er, sourceFilePath, ref bmp);
                                }
                            }
                            else
                            {
                                sb.Insert(0, string.Format("ERROR: File {0}, DTOrig was null.  Creation time is {1}, Modified time is {2}.\n", sourceFilePath, info.CreationTime, info.LastWriteTime));
                                DialogResult dr = MessageBox.Show(string.Format("File {0}, DTOrig was null.  Creation time is {1}, Modified time is {2}. Press OK to continue processing this file, cancel to skip.", sourceFilePath, info.CreationTime, info.LastWriteTime), "Error", MessageBoxButtons.OKCancel);
                                if (dr != DialogResult.OK)
                                {
                                    continue;
                                }
                            }
                        }
                    }


                    if (datePictureTaken == null || datePictureTaken == DateTime.MaxValue)//could not read the exif data for some reason, use the earlier of file creation date or modified date instead.
                    {

                        if (info.LastWriteTime < info.CreationTime)
                        {
                            datePictureTaken = info.LastWriteTime;
                            sb.Insert(0, string.Format("WARNING: File {0}, used last modified date, creation date was newer.\n", sourceFilePath));
                        }
                        else
                        {
                            datePictureTaken = info.CreationTime;
                            sb.Insert(0, string.Format("WARNING: File {0}, used created date, last modified was newer.\n", sourceFilePath));
                        }
                    }

                    string destinationFolder = Path.Combine(txtDestinationFolder.Text, datePictureTaken.ToString("yyyy-MM-dd"));

                    if (!Directory.Exists(destinationFolder))
                    {
                        sb.Insert(0, string.Format("Created Directory {0}.\n", destinationFolder));
                        Directory.CreateDirectory(destinationFolder);
                    }
                    string destinationFilePath = Path.Combine(destinationFolder, info.Name);

                    try
                    {
                        if(destinationFilePath == sourceFilePath)
                        {
                            sb.Insert(0, string.Format("WARNING: Source and destination are the same for {0}.\n", sourceFilePath));
                            continue;
                        }
                        if (File.Exists(destinationFilePath))
                        {
                            FileInfo sourceFileInfo = new FileInfo(sourceFilePath);
                            FileInfo destFileInfo = new FileInfo(destinationFilePath);

                            if (cbOverwrite.Checked)
                            {
                                // now you can safely overwrite it
                                sb.Insert(0, copyFile(sourceFilePath, destinationFilePath));
                            }
                            else
                            {
                               sb.Insert(0, string.Format("WARNING: did not copy file {0} because a file of the same name already exists at the destination {1}.\n", sourceFilePath, destinationFilePath));
                            }
                        }
                        else
                        {
                            sb.Insert(0, copyFile(sourceFilePath, destinationFilePath));
                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                        sb.Insert(0, "EXCEPTION: "+ ex.ToString()+ "\n\n");

                    }
                    

                }

                
            }

            sb.Insert(0, string.Format("Done. {0} files processed. \n", i.ToString()));
            richTextBox1.Text = sb.ToString();
        }

        string copyFile(string sourceFilePath, string destinationFilePath)
        {
            File.Copy(sourceFilePath, destinationFilePath, true);
            if (cbMove.Checked)
            {
                File.Delete(sourceFilePath);
            }
            return string.Format("Successfully copied file {0} to {1}.\n", sourceFilePath, destinationFilePath);
        }


        /*void RotateImage(Goheer.EXIF.EXIFextractor exif, string pathToImageFile, System.Drawing.Bitmap bmp)
        {// Rotate the image according to EXIF data

            if (exif["Orientation"] != null)
            {
                RotateFlipType flip = OrientationToFlipType(exif["Orientation"].ToString());

                if (flip != RotateFlipType.RotateNoneFlipNone) // don't flip of orientation is correct
                {
                    bmp.RotateFlip(flip);
                    exif.setTag(0x112, "1"); // Optional: reset orientation tag
                    bmp.Save(pathToImageFile, ImageFormat.Jpeg);
                }
            }
        }

        // Match the orientation code to the correct rotation:

        private static RotateFlipType OrientationToFlipType(string orientation)
        {
            switch (int.Parse(orientation))
            {
                case 1:
                    return RotateFlipType.RotateNoneFlipNone;
                case 2:
                    return RotateFlipType.RotateNoneFlipX;
                case 3:
                    return RotateFlipType.Rotate180FlipNone;
                case 4:
                    return RotateFlipType.Rotate180FlipX;
                case 5:
                    return RotateFlipType.Rotate90FlipX;
                case 6:
                    return RotateFlipType.Rotate90FlipNone;
                case 7:
                    return RotateFlipType.Rotate270FlipX;
                case 8:
                    return RotateFlipType.Rotate270FlipNone;
                default:
                    return RotateFlipType.RotateNoneFlipNone;
            }
        }
        */
        private void btnSave_click(object sender, EventArgs e)
        {
            const string sPath = "save.txt";

            System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(sPath);
        
           SaveFile.WriteLine(richTextBox1.Text);
            string fullPath = ((FileStream)(SaveFile.BaseStream)).Name;
            SaveFile.Close();

            System.Diagnostics.Process.Start(fullPath);
        }

        private void deleteEmptyDirsTarget_Click(object sender, EventArgs e)
        {
            processDirectory(txtDestinationFolder.Text);
        }

        private void deleteEmptyDirsSource_Click(object sender, EventArgs e)
        {
            processDirectory(txtSourceFolder.Text);
        }


        private static void processDirectory(string startLocation)
        {
            string[] filePaths = Directory.GetFiles(startLocation, "*", SearchOption.AllDirectories);

            //delete hidden and system files/folders
            foreach (string sourceFilePath in filePaths)
            {
                if (File.Exists(sourceFilePath))
                {
                    FileInfo info = new FileInfo(sourceFilePath);

                    if ((info.Attributes & FileAttributes.Hidden) == FileAttributes.Hidden || (info.Attributes & FileAttributes.System) == FileAttributes.System)
                    {
                        // delete/clear hidden attribute
                        File.SetAttributes(sourceFilePath, File.GetAttributes(sourceFilePath) & ~FileAttributes.Hidden);
                        // delete/clear archive and read only attributes
                        File.SetAttributes(sourceFilePath, File.GetAttributes(sourceFilePath) & ~(FileAttributes.Archive | FileAttributes.ReadOnly));
                        File.Delete(sourceFilePath);
                    }          
                }
            }

            //delete directories
            foreach (var directory in Directory.GetDirectories(startLocation))
            {
                processDirectory(directory);
                if (Directory.GetFiles(directory).Length == 0 && Directory.GetDirectories(directory).Length == 0)
                {
                    Directory.Delete(directory, false);
                }
            }
        }


    }
    }

          

