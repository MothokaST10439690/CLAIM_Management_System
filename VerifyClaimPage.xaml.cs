using System.Linq;
using System.Security.Claims;
using System.Windows;
using System.Windows.Controls;

namespace CLAIM
{
    public partial class VerifyClaimPage : UserControl
    {
        public VerifyClaimPage()
        {
            InitializeComponent();
            LoadClaims();
            EventHub.ClaimChanged += (c) => LoadClaims();
        }

        private void LoadClaims()
        {
            ClaimsGrid.ItemsSource = ClaimRepository.GetByStatus(ClaimStatus.Submitted).ToList();
        }

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsGrid.SelectedItem is Claim claim)
            {
                ClaimService.VerifyClaim(claim, "Coordinator Name");
                MessageBox.Show("Claim verified!");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadClaims();
        }
    }
}
