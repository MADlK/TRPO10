using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для CreatePatientPage.xaml
    /// </summary>
    public partial class CreatePatientPage : Page, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private Doctor _currentDoctor;

        public static List<Pacient> LoadAllPatients()
        {
            var patients = new List<Pacient>();

            if (!Directory.Exists("Patients"))
                return patients;

            string[] files = Directory.GetFiles("Patients", "P_*.json");

            foreach (string file in files)
            {
                try
                {
                    string json = File.ReadAllText(file);
                    var patient = JsonSerializer.Deserialize<Pacient>(json);

                    string fileName = Path.GetFileNameWithoutExtension(file);
                    if (fileName.StartsWith("P_") && int.TryParse(fileName.Substring(2), out int id))
                    {
                        patient.Id = id;
                    }

                    patients.Add(patient);
                }
                catch (Exception ex)
                {
                }
            }

            return patients;
        }



        int newId;
        private Pacient _pacient;

        public Pacient Pat
        {
            get => _pacient;
            set
            {
                if (value != _pacient)
                {
                    _pacient = value;
                    OnPropertyChanged();
                }

            }
        }



        public CreatePatientPage(Doctor doctor)
        {
            InitializeComponent();
            DataContext = this;
            _currentDoctor = doctor;

            BirthdayDatePicker.DisplayDateEnd = DateTime.Today;
            LastNameTextBox.Focus();
            var existingPatients = LoadAllPatients();
             newId = GeneratePatientId(existingPatients);

            _pacient = new Pacient
            {
                Id = newId
            };
        }

        public static int GeneratePatientId(List<Pacient> existingPatients)
        {
            Random rnd = new Random();
            int newId;
            bool isUnique;

            do
            {
                isUnique = true;
                newId = rnd.Next(1000000, 9999999);

                foreach (var patient in existingPatients)
                {
                    if (patient.Id == newId)
                    {
                        isUnique = false;
                        break;
                    }
                }
            } while (!isUnique);

            return newId;
        }


        public static void SavePatient(Pacient patient)
        {
            if (!Directory.Exists("Patients"))
                Directory.CreateDirectory("Patients");

            string fileName = $"P_{patient.Id}.json";
            string filePath = Path.Combine("Patients", fileName);

            var options = new JsonSerializerOptions { WriteIndented = true };
            var json = JsonSerializer.Serialize(patient, options);
            File.WriteAllText(filePath, json);
        }

       

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            //if (string.IsNullOrWhiteSpace(LastNameTextBox.Text) ||
            //    string.IsNullOrWhiteSpace(NameTextBox.Text) ||
            //    string.IsNullOrWhiteSpace(MiddleNameTextBox.Text) ||
            //    !BirthdayDatePicker.SelectedDate.HasValue ||
            //    string.IsNullOrWhiteSpace(PhoneTextBox.Text))
            //{
            //    MessageBox.Show("Все поля обязательны");
            //    return;
            //}

            //if (BirthdayDatePicker.SelectedDate > DateTime.Today)
            //{
            //    MessageBox.Show("Дата рождения не может быть в будущем");
            //    return;
            //}

            //string phone = PhoneTextBox.Text.Trim();
            //if (!phone.StartsWith("+"))
            //{
            //    MessageBox.Show("Телефон должен начинаться с +");
            //    return;
            //}

            

            

            SavePatient(Pat);

            MessageBox.Show($"Пациент создан! ID: {newId}");

            var mainPage = NavigationService.Content as MainPage;

            
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
