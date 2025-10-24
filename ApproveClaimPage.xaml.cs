using System.Linq;
using System.Security.Claims;
using System.Windows;
using System.Windows.Controls;

namespace CLAIM
{
    public partial class ApproveClaimPage : UserControl
    {
        public ApproveClaimPage()
        {
            InitializeComponent();
            LoadClaims();
            EventHub.ClaimChanged += (c) => LoadClaims();
        }

        private void LoadClaims()
        {
            ClaimsGrid.ItemsSource = ClaimRepository.GetByStatus(ClaimStatus.Verified).ToList();
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsGrid.SelectedItem is Claim claim)
            {
                ClaimService.ApproveClaim(claim, "Manager Name");
                MessageBox.Show("Claim approved!");
            }
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClaimsGrid.SelectedItem is Claim claim)
            {
                ClaimService.RejectClaim(claim, "Manager Name");
                MessageBox.Show("Claim rejected!");
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            LoadClaims();
        }
    }
}
