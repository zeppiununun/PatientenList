﻿using System.Collections.ObjectModel;
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

        /// <summary>
        /// Second solution. Use ICommand and relative ancestor
        /// </summary>
        /// public ICommand RemovePatient { get; set; }

        public PatientenViewModel()
        {
            InitializeComponent();

            //second solution for patient removal

            //RemovePatient = new RelayCommand(obj => 
            //{
            //    if (obj is Patient patient)
            //        PatientenListe?.Remove(patient);

            //}, obj => true);

            DataContext = this;
        }

        #region event handling
        private void Button_RemoveClick(object sender, RoutedEventArgs e)
        {
            if (sender is Button button
                && button.Tag is Patient patient)
            {
                PatientenListe?.Remove(patient);
            }
        }

        private void Button_AddClick(object sender, RoutedEventArgs e)
        {
            AddEditViewModel addPatientModalDlg = new AddEditViewModel() { Title = "Patient hinzufügen", Owner = this };
            var dlgRes = addPatientModalDlg.ShowDialog();

            if (dlgRes is true)
            {
                PatientenListe.Add(addPatientModalDlg.ThisPatient);
            }
        }


        private void ListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //get data context of ItemTemplate
            if ((e.OriginalSource as FrameworkElement)?.DataContext is Patient patient)
            {
                AddEditViewModel editPatientModalDlg = new AddEditViewModel(patient) { Title = "Patient editieren", Owner = this };
                editPatientModalDlg.ShowDialog();
            }
        }

        /// <summary>
        ///  Another possible solution: binding event to listview item 
        /// </summary>              
        //private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        //{
        //    if ((sender as ListViewItem)?.Content is Patient patient)
        //    {
        //        AddEditViewModel editPatientModalDlg = new AddEditViewModel(patient) { Title = "Patient editieren", Owner = this };
        //        editPatientModalDlg.ShowDialog();
        //    }
        //}


        #endregion
    }
}
