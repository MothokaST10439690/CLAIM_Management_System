using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CLAIM
{
    public partial class TrackStatusPage : UserControl
    {
        public TrackStatusPage()
        {
            InitializeComponent();
            LoadClaims();
            EventHub.ClaimChanged += (c) => LoadClaims();
        }

        private void LoadClaims()
        {
            ClaimsListView.ItemsSource = ClaimRepository.GetAll().ToList();
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadClaims();
        }
    }
}
