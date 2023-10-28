using System.ComponentModel;
using System.Windows;

namespace PatientenManagement
{
    /// <summary>
    /// Add/edit patient dialog window
    /// </summary>
    public partial class AddEditViewModel : Window
    {

        public Patient ThisPatient { get; set; } = new Patient();   
        
        public AddEditViewModel(Patient? patient = null)
        {
            ThisPatient = patient ?? ThisPatient;
            InitializeComponent();

            DataContext = this;
        }

      
        private void OnOkBtnClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

    }
}
