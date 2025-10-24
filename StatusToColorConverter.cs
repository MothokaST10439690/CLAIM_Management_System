using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace CLAIM
{
    public class StatusToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                return status switch
                {
                    "Submitted" => Brushes.Gray,
                    "Verified" => Brushes.Orange,
                    "Approved" => Brushes.Green,
                    "Rejected" => Brushes.Red,
                    _ => Brushes.Gray
                };
            }
            return Brushes.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
