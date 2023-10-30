using System;
using System.Windows;
using System.Windows.Data;

namespace PatientenManagement
{
    /// <summary>
    /// Type of dialog (Add/Edit) => cancel button caption
    /// </summary>
    public class ModalDialogTypeToCaption : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? "Schließen" : "Abbrechen";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Type of dialog (Add/Edit) => OK button visibilty
    /// </summary>
    public class OKButtonVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return (bool)value ? Visibility.Hidden : Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
