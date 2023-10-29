using System.ComponentModel;

namespace PatientenManagement
{
    /// <summary>
    /// Patient data model
    /// </summary>
    public class Patient : INotifyPropertyChanged
    {
        /// <summary>
        /// Name property
        /// </summary>
		private string _name = string.Empty;

        public string Name
        {
            get => _name;

            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name)));
            }
        }

        /// <summary>
        /// Vorname property
        /// </summary>
        private string _vorname = string.Empty;

        public string Vorname
        {
            get => _vorname;

            set
            {
                _vorname = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Vorname)));
            }
        }

        /// <summary>
        /// Wohnort property 
        /// </summary>
        private string _wohnort = string.Empty;

        public string Wohnort
        {
            get => _wohnort;

            set
            {
                _wohnort = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Wohnort)));
            }
        }


        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
