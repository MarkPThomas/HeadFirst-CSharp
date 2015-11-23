using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ExcuseManager
{
    public partial class ExcuseManager : Form
    {
        private Excuse currentExcuse = new Excuse();
        private string selectedFolder = Application.StartupPath;
        private Random random = new Random();
        private bool formChanged = false;
        private bool formLoaded = false;

        private const string STRING_FILTER = "Excuse Files (*" + Excuse.EXCUSE_FILE_EXTENSION + ")|*" + Excuse.EXCUSE_FILE_EXTENSION + "|All Files (*.*)|*.*";

        public ExcuseManager()
        {
            InitializeComponent();
            LoadControls();
            currentExcuse.LastUsed = lastUsed.Value;
        }

        private void LoadControls() {
            save.Enabled = false;
            open.Enabled = false;
            randomExcuse.Enabled = false;
        }

        private void EnableControls()
        {
            save.Enabled = true;
            open.Enabled = true;
            randomExcuse.Enabled = true;
        }

        private void UpdateForm(bool changed)
        {
            Text = "Excuse Manager";

            if (!changed)
            {
                description.Text = currentExcuse.Description;
                results.Text = currentExcuse.Results;
                lastUsed.Value = currentExcuse.LastUsed;

                if (!string.IsNullOrEmpty(currentExcuse.ExcusePath))
                {
                    fileDate.Text = File.GetLastWriteTime(currentExcuse.ExcusePath).ToString();
                }
            }
            else if(!formLoaded)
            {
                Text += "*";
            }

            formChanged = changed;
        }

        private bool Continue()
        {
            if (formChanged)
            {
                DialogResult result = MessageBox.Show("The current excuse has not been saved. Continue?", "Warning",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.No)
                {
                    return false;
                }
            }

            if (Directory.GetFiles(selectedFolder).Length == 0)
            {
                return false;
            }

            return true;
        }

        private string FileName() { return currentExcuse.Description + Excuse.EXCUSE_FILE_EXTENSION ; }

        private void folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            folderBrowser.Description = "Browse for Folder";
            folderBrowser.SelectedPath = selectedFolder;

            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                selectedFolder = folderBrowser.SelectedPath;
                EnableControls();
            }
        }

        private void save_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(description.Text) || string.IsNullOrEmpty(results.Text))
            {
                MessageBox.Show("Please specify an excuse and a result", "Unable to save", 
                                MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                SaveFileDialog saveDialog = new SaveFileDialog();
                saveDialog.InitialDirectory = selectedFolder;
                saveDialog.FileName = FileName();
                saveDialog.Filter = STRING_FILTER;

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    currentExcuse.Save(saveDialog.FileName);
                    UpdateForm(false);
                    MessageBox.Show("Excuse Written");
                }
            }
        }

        private void open_Click(object sender, EventArgs e)
        {
            if (!Continue()) { return; }
            
            OpenFileDialog openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = selectedFolder;
            openDialog.FileName = FileName();
            openDialog.Filter = STRING_FILTER;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                currentExcuse = new Excuse(openDialog.FileName);
                currentExcuse.OpenFile(openDialog.FileName);
                formLoaded = true;
                UpdateForm(false);
            }
        }

        private void randomExcuse_Click(object sender, EventArgs e)
        {
            if (!Continue()) { return; }

            currentExcuse = new Excuse(selectedFolder, random);
            currentExcuse.OpenFile(currentExcuse.ExcusePath);
            formLoaded = true;
            UpdateForm(false);
        }

        private void description_TextChanged(object sender, EventArgs e)
        {
            currentExcuse.Description = description.Text;
            UpdateForm(true);
        }

        private void results_TextChanged(object sender, EventArgs e)
        {
            currentExcuse.Results = results.Text;
            UpdateForm(true);
        }

        private void lastUsed_ValueChanged(object sender, EventArgs e)
        {
            currentExcuse.LastUsed = lastUsed.Value;
            UpdateForm(true);
        }


        private void FormEditingStarted()
        { 
            // Skips the first time this is triggered after the results are loaded. Otherwise, "*" appears whenever a new file is loaded.
            formLoaded = false;
        }

        private void description_KeyDown(object sender, KeyEventArgs e)
        {
            FormEditingStarted();
        }

        private void results_KeyDown(object sender, KeyEventArgs e)
        {
            FormEditingStarted();
        }

        private void lastUsed_KeyDown(object sender, KeyEventArgs e)
        {
            FormEditingStarted();
        }

        private void lastUsed_MouseDown(object sender, MouseEventArgs e)
        {
            FormEditingStarted();
        }
    }
}
