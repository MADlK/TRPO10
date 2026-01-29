using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace wpf8
{
    public class AppointmentStory : INotifyPropertyChanged
    {
        private string _date = "";
        private int _doctor_id;
        private string _diagnos = "";
        private string _recomendations = "";

        public string date
        {
            get => _date;
            set
            {
                if (_date != value)
                {
                    _date = value;
                    OnPropertyChanged();
                }
            }
        }

        public int doctor_id
        {
            get => _doctor_id;
            set
            {
                if (_doctor_id != value)
                {
                    _doctor_id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Diagnos
        {
            get => _diagnos;
            set
            {
                if (_diagnos != value)
                {

                    _diagnos = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Recomendations
        {
            get => _recomendations;
            set
            {
                if (_recomendations != value)
                {

                    _recomendations = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
