using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace wpf8
{
    public class Pacient : INotifyPropertyChanged
    {


        
        private int _id;
        private string _name = "";
        private string _lastName = "";
        private string _middleName = "";
        private DateTime _birthday = DateTime.Today;
        private string _phoneNumber = "";
        private ObservableCollection<AppointmentStory> _appointmentStories = new ObservableCollection<AppointmentStory>();
        private bool soversh = false;


        public int Id
        {
            get => _id;
            set
            {
                if (_id != value)
                {

                    _id = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                if (_lastName != value)
                {

                    _lastName = value;
                    OnPropertyChanged();
                }
            }
        }

        public string MiddleName
        {
            get => _middleName;
            set
            {
                if (_middleName != value)
                {
                    _middleName = value;
                    OnPropertyChanged();
                }

            }
        }

        public DateTime Birthday
        {
            get => _birthday;
            set
            {
                if (_birthday != value)
                {
                    _birthday = value;
                    OnPropertyChanged();
                }


            }
        }

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                if (_phoneNumber != value)
                {
                    _phoneNumber = value;
                    OnPropertyChanged();
                }

            }
        }

        public ObservableCollection<AppointmentStory> AppointmentStories
        {
            get => _appointmentStories;
            set
            {
                if (_appointmentStories != value)
                {

                    _appointmentStories = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool Soversh
        {
            get
            {
                if(_birthday ==null)
                    return false;
                var today = DateTime.Today;
                var age = today.Year - _birthday.Year;
                return age >= 18;
            }
            
        }



        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
