using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    /// Interaction logic for VerifyClaimPage.xaml
    /// </summary>
    public partial class VerifyClaimPage : UserControl
    {
        public VerifyClaimPage()
        {
            InitializeComponent();
            // Here you would load data into ClaimsGrid
        }

        private void VerifyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Claim Verified Successfully!", "Verification", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}

