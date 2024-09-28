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

        private void kijelentkezes(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void myTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Ellenőrizzük, hány sor van a TextBoxban
            var lineCount = myTextBox.LineCount;

            // Ha több mint 10 sor van, akkor levágjuk a felesleget
            if (lineCount > 10)
            {
                // Megakadályozzuk további sorok hozzáadását
                int lastVisibleCharIndex = myTextBox.GetCharacterIndexFromLineIndex(10);
                myTextBox.Text = myTextBox.Text.Substring(0, lastVisibleCharIndex);

                // A kurzort a végére helyezzük
                myTextBox.CaretIndex = myTextBox.Text.Length;
            }
        }

        private void NumberValidationTextBox(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            e.Handled = !IsTextNumeric(e.Text);
        }

        private static bool IsTextNumeric(string text)
        {
            return int.TryParse(text, out _);
        }
    }
}
