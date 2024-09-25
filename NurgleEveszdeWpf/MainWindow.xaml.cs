using K4os.Compression.LZ4.Internal;
using MySql.Data.MySqlClient;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NurgleEveszdeWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=nurgleeveszde";
        private MySqlConnection connection;
        List<User> users;



        public MainWindow()
        {
            InitializeComponent();
            loadUsers();
            txtPasswordInput.KeyDown += new KeyEventHandler(input_KeyDown);
            txtUsernameInput.KeyDown += new KeyEventHandler(input_KeyDown);

        }

        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                checkUser();
            }
        }

        
        private void btnRegisztracio_Click(object sender, RoutedEventArgs e)
        {
            Window registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
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
        private void checkUser()
        {
            bool vanNev = false;
            bool vanJelszo = false;
            foreach (var user in users)
            {
                if (user.username == txtUsernameInput.Text && user.password == txtPasswordInput.Password)
                {
                    vanNev = true;
                    vanJelszo = true;
                    if (user.status == "Admin")
                    {
                        isAdmin = true;
                    }
                    break;

                }
                else if (user.username == txtUsernameInput.Text && user.password != txtPasswordInput.Password)
                {
                    vanNev = true;
                    break;

                }
                else if (user.username != txtUsernameInput.Text && user.password == txtPasswordInput.Password)
                {
                    vanJelszo = true;
                    break;

                }
            if (vanNev && vanJelszo)

            {
                Rendeles rendeles = new Rendeles();
                this.Close();
                rendeles.ShowDialog();
            }
            else if (vanNev && !vanJelszo)
            {
                MessageBox.Show("Hibás a jelszó!");
            }
            else if (!vanNev && vanJelszo)
            {
                MessageBox.Show("Hibás a felhasználónév!");
            }
            else
            {
                MessageBox.Show("Nincs regisztálva ilyen fiók!");
            }
        }

      

        private void btnBejelentkezes_Click(object sender, RoutedEventArgs e)
        {
           
            checkUser();

        }

        //private void PlayagainGIF(object sender, RoutedEventArgs e)
        //{
        //    media.Position = new TimeSpan(0, 0, 1);
        //    media.Play();
        //}

        private void media_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("asd");
        }
    }
}