
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CLAIM
{
    public partial class UploadDocumentsPage : UserControl
    {
        private ObservableCollection<string> files = new ObservableCollection<string>();

        public UploadDocumentsPage()
        {
            InitializeComponent();
            FilesListBox.ItemsSource = files;
        }

        // Add files
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.Filter = "Documents (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx";
            dlg.Multiselect = true;

            if (dlg.ShowDialog() == true)
            {
                foreach (string file in dlg.FileNames)
                {
                    FilesListBox.Items.Add(file);
                }
            }
        }

        // Remove selected file
        private void RemoveFileButton_Click(object sender, RoutedEventArgs e)
        {
            if (FilesListBox.SelectedItem != null)
                files.Remove(FilesListBox.SelectedItem.ToString());
            else
                MessageBox.Show("Please select a file to remove.");
        }

        // Attach files to the last claim of the current lecturer
        private void AttachFilesButton_Click(object sender, RoutedEventArgs e)
        {
            if (files.Count == 0)
            {
                MessageBox.Show("No files to attach.");
                return;
            }

            string lecturerName = LecturerNameTextBox.Text.Trim();
            if (string.IsNullOrEmpty(lecturerName))
            {
                MessageBox.Show("Please enter your name.");
                return;
            }

            var lastClaim = ClaimRepository.GetAll()
                                .LastOrDefault(c => c.LecturerName == lecturerName);

            if (lastClaim != null)
            {
                ClaimService.AttachDocuments(lastClaim, files.ToList());
                MessageBox.Show("Documents attached successfully!");
                files.Clear();
            }
            else
            {
                MessageBox.Show("No claim found for the entered lecturer.");
            }
        }

        // Validate file type and size
        private bool IsValidFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            double fileSizeMB = fileInfo.Length / (1024.0 * 1024.0);

            if (fileSizeMB > 10)
            {
                MessageBox.Show($"'{fileInfo.Name}' exceeds 10MB limit.");
                return false;
            }

            string ext = fileInfo.Extension.ToLower();
            if (ext != ".pdf" && ext != ".docx" && ext != ".xlsx")
            {
                MessageBox.Show($"'{fileInfo.Name}' is not an allowed file type.");
                return false;
            }

            return true;
        }

        private void AddFilesButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Filter = "Documents (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx",
                Multiselect = true
            };

            if (dlg.ShowDialog() == true)
            {
                foreach (string file in dlg.FileNames)
                {
                    if (IsValidFile(file) && !files.Contains(file))
                    {
                        files.Add(file);
                    }
                }
            }
        }
    }
}

