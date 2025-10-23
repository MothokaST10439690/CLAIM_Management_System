using System.Windows;
using System.Windows.Controls;

namespace CLAIM
{
    public partial class ApproveClaimPage : UserControl
    {
        public ApproveClaimPage()
        {
            InitializeComponent();
           
        }

        private void ApproveButton_Click(object sender, RoutedEventArgs e)
        {
        
        }

        private void RejectButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            ClaimsGrid.Items.Refresh();
        }
    }
}
