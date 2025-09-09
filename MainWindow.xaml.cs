using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CLAIM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ShowRoleSelection();
        }

        private void LoadPage(UserControl page)
        {
            MainContent.Content = page;
            RoleSelectionPanel.Visibility = Visibility.Collapsed;
            NavBar.Visibility = Visibility.Visible;
        }

        private void ShowRoleSelection()
        {
            MainContent.Content = null;
            RoleSelectionPanel.Visibility = Visibility.Visible;
            NavBar.Visibility = Visibility.Collapsed;
        }

        private void SubmitClaim_Click(object sender, RoutedEventArgs e)
        {
            LoadPage(new SubmitClaimPage());
        }

        private void ApproveClaim_Click(object sender, RoutedEventArgs e)
        {
            LoadPage(new ApproveClaimPage());
        }

        private void UploadDocs_Click(object sender, RoutedEventArgs e)
        {
            LoadPage(new UploadDocumentsPage());
        }

        private void TrackStatus_Click(object sender, RoutedEventArgs e)
        {
            LoadPage(new TrackStatusPage());
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ShowRoleSelection();
        }

        private void Lecturer_Click(object sender, RoutedEventArgs e)
        {
            ShowLecturerView();
        }

        private void Coordinator_Click(object sender, RoutedEventArgs e)
        {
            ShowCoordinatorView();
        }

        private void Manager_Click(object sender, RoutedEventArgs e)
        {
            ShowManagerView();
        }

        private void ShowLecturerView()
        {
            NavBar.Visibility = Visibility.Visible;
            foreach (var child in NavBar.Children)
            {
                if (child is Button btn)
                {
                    btn.Visibility = (btn.Content.ToString() == "Submit Claim" ||
                                      btn.Content.ToString() == "Upload Documents" ||
                                      btn.Content.ToString() == "Track Status")
                                      ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            LoadPage(new SubmitClaimPage());
        }

        private void VerifyClaim_Click(object sender, RoutedEventArgs e)
        {
            LoadPage(new VerifyClaimPage());
        }

        private void ShowCoordinatorView()
        {
            NavBar.Visibility = Visibility.Visible;
            foreach (var child in NavBar.Children)
            {
                if (child is Button btn)
                {
                    btn.Visibility = (btn.Content.ToString() == "Verify Claim" ||
                                      btn.Content.ToString() == "Track Status")
                                      ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            LoadPage(new VerifyClaimPage());
        }

        private void ShowManagerView()
        {
            NavBar.Visibility = Visibility.Visible;
            foreach (var child in NavBar.Children)
            {
                if (child is Button btn)
                {
                    btn.Visibility = (btn.Content.ToString() == "Approve Claim" ||
                                      btn.Content.ToString() == "Track Status")
                                      ? Visibility.Visible : Visibility.Collapsed;
                }
            }
            LoadPage(new ApproveClaimPage());
        }
    }
}