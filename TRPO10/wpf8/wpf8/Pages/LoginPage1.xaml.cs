using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;


namespace wpf8.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage1.xaml
    /// </summary>
    public partial class LoginPage1 : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged ([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public LoginPage1()
        {
            InitializeComponent();
        }

        public static List<Doctor> LoadAllDoctors()
        {
            var doctors = new List<Doctor>();

            if (!Directory.Exists("Doctors"))
                return doctors;

            string[] files = Directory.GetFiles("Doctors", "D_*.json");

            foreach (string file in files)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    var doctor = JsonSerializer.Deserialize<Doctor>(json);

                    string fileName = Path.GetFileNameWithoutExtension(file);
                    if (fileName.StartsWith("D_") && int.TryParse(fileName.Substring(2), out int id))
                    {
                        doctor.Id = id;
                    }

                    doctors.Add(doctor);
                }
                catch (Exception ex)
                {
                }
            }

            return doctors;
        }

        private LogClass _lg;
        public LogClass LG
        {
            get => _lg;
            set
            {

                if (_lg != value)
                {
                    _lg = value;
                    OnPropertyChanged();
                }
            }
        }
        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            
            

          

            

            var doctors = LoadAllDoctors();
            var doctor = doctors.FirstOrDefault(d => d.Id == LG.ID && d.Password == LG.pass);

            if (doctor == null)
            {
                MessageBox.Show("Неверный ID или пароль");
                return;
            }

            NavigationService.Navigate(new MainPage(doctor));
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterPage());
        }
    }
}

