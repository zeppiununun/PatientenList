using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PatientenManagement
{
    /// <summary>
    /// Patient management view model
    /// </summary>
    public partial class PatientenViewModel : Window
    {        
        /// <summary>
        /// patient collection
        /// </summary>
        public ObservableCollection<Patient> PatientenListe { get; set; } = new ObservableCollection<Patient>();       
        
        public PatientenViewModel()
        {
            InitializeComponent();
            DataContext = this;            
        }

        #region event handling
        private void OnRemoveClick(object sender, RoutedEventArgs e) 
        {
            if (sender is Button button 
                && button.Tag is Patient patient)
            {
                PatientenListe?.Remove(patient);
            }
        }

        private void OnAddClick(object sender, RoutedEventArgs e)
        {
            AddEditViewModel addPatientModalDlg = new AddEditViewModel() {Title = "Patient hinzufügen", Owner = this };
            var dlgRes = addPatientModalDlg.ShowDialog();
            
            if (dlgRes is true)
            {
                PatientenListe.Add(addPatientModalDlg.ThisPatient);
            }
        }
        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //get data context of ItemTemplate
            if ((e.OriginalSource as FrameworkElement)?.DataContext is Patient patient)
            {
                AddEditViewModel editPatientModalDlg = new AddEditViewModel(patient) { Title = "Patient editieren", Owner = this }; 
                editPatientModalDlg.ShowDialog();
            }
        }
        #endregion
    }
}
