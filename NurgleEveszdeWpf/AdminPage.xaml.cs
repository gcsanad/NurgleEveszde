using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace NurgleEveszdeWpf
{
    /// <summary>
    /// Interaction logic for AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Window
    {
        ObservableCollection<Ingredients> ingredients = [];

        public string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=nurgleeveszde";
        private MySqlConnection connection;
        public AdminPage()
        {
            InitializeComponent();
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string lekerdezesSzoveg = "SELECT * FROM ingredients";
                MySqlCommand lekerdezes = new(lekerdezesSzoveg, connection);
                lekerdezes.CommandTimeout = 60;
                MySqlDataReader reader = lekerdezes.ExecuteReader();
                while (reader.Read())
                    ingredients.Add(new Ingredients($"{reader.GetInt32(0)};{reader.GetString(1)};{reader.GetInt32(2)}".Split(";")));

                reader.Close();
                connection.Close();
                dgAlapanyagok.ItemsSource = ingredients;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
        }
    }
}
