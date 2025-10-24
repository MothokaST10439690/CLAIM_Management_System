using System;
using System.Windows;
using System.Windows.Controls;

namespace CLAIM
{
    public partial class SubmitClaimPage : UserControl
    {
        private decimal hourlyRate = 50m; // example hourly rate

        public SubmitClaimPage()
        {
            InitializeComponent();
            MonthComboBox.SelectedIndex = 0;
            HoursTextBox.TextChanged += HoursTextBox_TextChanged;
        }

        private void HoursTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!int.TryParse(HoursTextBox.Text, out int hours))
                hours = 0;

            decimal totalAmount = hours * hourlyRate;
            TotalAmountText.Text = $"R{totalAmount:N2}";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var lecturerName = LecturerNameTextBox.Text.Trim();
                if (string.IsNullOrEmpty(lecturerName))
                {
                    MessageBox.Show("Please enter your name.");
                    return;
                }

                var month = ((ComboBoxItem)MonthComboBox.SelectedItem)?.Content.ToString() ?? "January";
                if (!int.TryParse(YearTextBox.Text, out int year)) year = DateTime.Now.Year;
                if (!int.TryParse(HoursTextBox.Text, out int hours)) hours = 0;

                decimal totalAmount = hours * hourlyRate;
                TotalAmountText.Text = $"R{totalAmount:N2}"; // display in Rand

                var claim = new Claim
                {
                    LecturerName = lecturerName,
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
