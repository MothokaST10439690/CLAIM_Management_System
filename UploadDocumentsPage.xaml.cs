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

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            if (FilesListBox.SelectedItem != null)
                files.Remove(FilesListBox.SelectedItem.ToString());
            else
                MessageBox.Show("Please select a file to remove.");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (files.Count == 0) return;

            var lastClaim = ClaimRepository.GetAll().LastOrDefault(c => c.LecturerName == "John Doe");
            if (lastClaim != null)
            {
                ClaimService.AttachDocuments(lastClaim, files.ToList());
                MessageBox.Show("Documents attached!");
                files.Clear();
            }
        }

        private bool IsValidFile(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            double fileSizeMB = fileInfo.Length / (1024.0 * 1024.0);
            if (fileSizeMB > 10)
            {
                MessageBox.Show($"'{fileInfo.Name}' is larger than 10MB.");
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
    }
}
