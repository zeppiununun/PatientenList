using System.Windows;

namespace PatientenManagement
{
    /// <summary>
    /// Add/edit patient dialog window
    /// </summary>
    public partial class AddEditViewModel : Window
    {
        /// <summary>
        /// true if edit patient dialog, otherwise false (add patient dialog)
        /// </summary>
        public bool IsEditType { get; set; } = false;

        /// <summary>
        /// patient being processed (either existing or a new one)
        /// </summary>
        public Patient ThisPatient { get; set; } = new Patient();

        public AddEditViewModel(Patient? patient = null)
        {
            ThisPatient = patient ?? ThisPatient;
            IsEditType = patient != null;

            InitializeComponent();

            DataContext = this;
        }

        #region event handling
        private void OnOkBtnClicked(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        #endregion
    }
}
