using System;
using System.Linq;
using System.Security.Claims;
using System.Windows;
using System.Windows.Controls;

namespace CLAIM
{
    public partial class SubmitClaimPage : UserControl
    {
        public SubmitClaimPage()
        {
            InitializeComponent();
            MonthComboBox.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var month = ((ComboBoxItem)MonthComboBox.SelectedItem)?.Content.ToString() ?? "January";
                if (!int.TryParse(YearTextBox.Text, out int year)) year = DateTime.Now.Year;
                if (!int.TryParse(HoursTextBox.Text, out int hours)) hours = 0;

                var claim = new Claim
                {
                    LecturerName = "John Doe", // replace with dynamic user
                    Month = month,
                    Year = year,
                    HoursWorked = hours,
                    Notes = NotesTextBox.Text
                };

                ClaimService.SubmitClaim(claim);
                MessageBox.Show("Claim submitted successfully!");

                // Reset form
                HoursTextBox.Text = "0";
                NotesTextBox.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error submitting claim: " + ex.Message);
            }
        }
    }
}
