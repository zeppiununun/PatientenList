using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PatientenManagement
{
    /// <summary>
    /// PatientenManagement view model
    /// </summary>
    public partial class PatientenViewModel : Window
    {        
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
            AddEditViewModel addPatientModalDlg = new AddEditViewModel();
            var dlgRes = addPatientModalDlg.ShowDialog();
            
            if (dlgRes is true)
            {
                PatientenListe.Add(addPatientModalDlg.ThisPatient);
            }
        }
        private void OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if ((e.OriginalSource as FrameworkElement)?.DataContext is Patient patient)
            {
                AddEditViewModel editPatientModalDlg = new AddEditViewModel(patient); 
                editPatientModalDlg.ShowDialog();
            }
        }
        #endregion
    }
}
