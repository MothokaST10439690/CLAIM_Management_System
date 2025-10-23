using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace CLAIM
{
    public partial class UploadDocumentsPage : UserControl
    {
        // Store uploaded files
        private ObservableCollection<string> files = new ObservableCollection<string>();

        public UploadDocumentsPage()
        {
            InitializeComponent();
            FilesListBox.ItemsSource = files;
        }

       
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog
            {
                Multiselect = true,
                Filter = "Allowed Files (*.pdf;*.docx;*.xlsx)|*.pdf;*.docx;*.xlsx"
            };

            if (dlg.ShowDialog() == true)
            {
                foreach (var file in dlg.FileNames)
                {
                    if (IsValidFile(file))
                    {
                        files.Add(file);
                    }
                }
            }
        }

        // ========== Remove Selected ==========
        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FilesListBox.SelectedItem != null)
            {
                files.Remove(FilesListBox.SelectedItem.ToString());
            }
            else
            {
                MessageBox.Show("Please select a file to remove.",
                    "No Selection", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // ========== Upload Files ==========
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (files.Count == 0)
            {
                MessageBox.Show("Please select at least one file before uploading.",
                    "No Files", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // This is where you will upload to DB, API, file server, etc.
            MessageBox.Show("Files uploaded successfully!",
                "Upload Complete", MessageBoxButton.OK, MessageBoxImage.Information);

            // Clear after upload
            files.Clear();
        }

        // ========== Validation Helper ==========
        private bool IsValidFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);

            // Size in bytes → MB
            double fileSizeMB = fileInfo.Length / (1024.0 * 1024.0);

            // Limit 10MB
            if (fileSizeMB > 10)
            {
                MessageBox.Show($"❌ '{fileInfo.Name}' is larger than 10MB.",
                    "File Too Large", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            // Extension validation
            string ext = fileInfo.Extension.ToLower();

            if (ext != ".pdf" && ext != ".docx" && ext != ".xlsx")
            {
                MessageBox.Show($"❌ '{fileInfo.Name}' is not an allowed file type.",
                    "Invalid Format", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }

            return true;
        }
    }
}
