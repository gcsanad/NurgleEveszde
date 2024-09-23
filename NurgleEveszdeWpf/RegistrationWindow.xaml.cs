using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;
using System.Diagnostics.Eventing.Reader;

namespace NurgleEveszdeWpf
{
    /// <summary>
    /// Interaction logic for RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=nurgleeveszde";
        private MySqlConnection connection;
        List<User> users;
        bool vanHiba = false;
        string hibaÜzenet = "";
        string nev = "";
        string email = "";
        string cim = "";
        string jelszo = "";
        string telefon = "";
        string status = "";
        public RegistrationWindow()
        {
            InitializeComponent();
            loadUsers();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e) {

            
            checkRegistration();
            if (!vanHiba)
            {
                userUpload();
                Window mainWin = new MainWindow();
                mainWin.Show();
                this.Close();
            }


        }

        private void userUpload()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string lekerdezesSzoveg = $"INSERT INTO `accounts`(`Username`, `Password`, `Mobil`, `Email`, `Address`, `Status`) VALUES ({nev},{jelszo},{telefon},{email},{cim},{status})";

                MySqlCommand lekerdezes = new MySqlCommand(lekerdezesSzoveg, connection);
                lekerdezes.CommandTimeout = 60;
                lekerdezes.ExecuteReader();
                
                
                connection.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void loadUsers()
        {
            users = new List<User>();

            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string lekerdezesSzoveg = "SELECT Account_Id, Username, Password, Mobil, Email, Address, Status, Registration_Date FROM accounts ORDER BY Account_Id";

                MySqlCommand lekerdezes = new MySqlCommand(lekerdezesSzoveg, connection);
                lekerdezes.CommandTimeout = 60;
                MySqlDataReader reader = lekerdezes.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new User(reader));
                }
                reader.Close();
                connection.Close();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void checkRegistration()
        {
             nev = txtName.Text;
             email = txtEmail.Text;
             cim = txtAddress.Text;
             jelszo = txtPassword.Text;
             telefon = txtMobile.Text;
            string emailPattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            List<string> nevek = new();
            List<string> emailCimek = new();
            hibaÜzenet = "";
            vanHiba = false;
            foreach (var item in users)
            {
                nevek.Add(item.username);
                emailCimek.Add(item.email);
                
            }
            if (nevek.Contains(nev) || nev == "")
            {
                hibaÜzenet += "\nMár van ilyen felhasználónév!";
                txtName.Focus();
                txtName.BorderBrush = Brushes.Red;
                vanHiba = true;
            }
            if (jelszo.Length < 8)
            {
                hibaÜzenet += "\nLegalább 8 karakternek kell lennie a jelszónak!";
                txtPassword.Focus();
                txtPassword.BorderBrush = Brushes.Red;
                vanHiba = true;
            }
            if (telefon.Length < 12 || !telefon.StartsWith('+'))
            {
                hibaÜzenet += "\nHibás a telefonszám!";
                txtMobile.Focus();
                txtMobile.BorderBrush = Brushes.Red;
                vanHiba = true;
            }
            if (emailCimek.Contains(email) || email == "")
            {
                hibaÜzenet += "\nMár van ilyen email cím hozzárendelve egy fiókhoz!";
                txtEmail.Focus();
                txtEmail.BorderBrush = Brushes.Red;
                vanHiba = true;

            }
            if (!Regex.IsMatch(email, emailPattern))
            {
                hibaÜzenet += "\nHibás az email formátuma!";
                txtEmail.Focus();
                txtEmail.BorderBrush = Brushes.Red;
                vanHiba = true;
            }
            if (cim == "")
            {
                hibaÜzenet += "\nÜres a szállítási cím!";
                txtAddress.Focus();
                txtAddress.BorderBrush = Brushes.Red;
                vanHiba = true;
            }
            if (vanHiba)
            {
                MessageBox.Show(hibaÜzenet);
            }
            if (rdUser.IsChecked == true)
            {
                status = "User";
            }
            else
            {
                status = "Admin";
            }


        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            checkRegistration();
            if (!vanHiba)
            {
                Window mainWin = new MainWindow();
                mainWin.Show();
                this.Close();
            }
        }
    }
}
