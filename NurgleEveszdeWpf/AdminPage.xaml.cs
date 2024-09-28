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
        Ingredients kivalasztottAlapanyag;

        public string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=nurgleeveszde";
        private MySqlConnection connection;
        ObservableCollection<Pizza> pizzas = [];
        public AdminPage()
        {
            InitializeComponent();
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string lekerdezesPizzak = "SELECT * FROM foods";
                MySqlCommand lekerdezes = new(lekerdezesPizzak, connection);
                lekerdezes.CommandTimeout = 60;
                MySqlDataReader reader = lekerdezes.ExecuteReader();
                while (reader.Read())
                    pizzas.Add(new Pizza($"{reader.GetInt32(0)};{reader.GetString(1)};{reader.GetString(2)};{reader.GetInt32(3)};{reader.GetString(4)}".Split(";")));

                reader.Close();
                connection.Close();
            }
            catch (Exception z)
            {

                MessageBox.Show(z.Message);
            }
            var Beolvasas = () =>
            {
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
            };
            Beolvasas();

            btnModositas.Click += (s, e) =>
            {
                if (dgAlapanyagok.SelectedIndex != -1 && dgAlapanyagok.SelectedItems.Count == 1 && dgAlapanyagok.SelectedItem is Ingredients)
                {
                    btnFelvetel.IsEnabled = false;
                    btnModosit.IsEnabled = true;
                    tbAlapanyagNev.Text = (dgAlapanyagok.SelectedItem as Ingredients).Name;
                    tbAlapanyagCount.Text = ((dgAlapanyagok.SelectedItem as Ingredients).Available).ToString();
                    kivalasztottAlapanyag = dgAlapanyagok.SelectedItem as Ingredients;
                }
                else
                    MessageBox.Show("Nnincs kiválasztva sor, vagy több mint egy sor választott ki!");
            };

            btnModosit.Click += (s, e) => 
            {


                try
                {
                    connection = new MySqlConnection(connectionString);
                    connection.Open();
                    string lekerdezesSzoveg = $"UPDATE `ingredients` SET `Name`='{tbAlapanyagNev.Text}',`Available`='{Convert.ToInt32(tbAlapanyagCount.Text)}' WHERE Ingredient_Id = {kivalasztottAlapanyag.Id}";
                    using (var lekerdezes = new MySqlCommand(lekerdezesSzoveg, connection))
                    {
                        lekerdezes.ExecuteNonQuery();
                    }
                    kivalasztottAlapanyag.Name = tbAlapanyagNev.Text;
                    kivalasztottAlapanyag.Available = Convert.ToInt32(tbAlapanyagCount.Text);
                    dgAlapanyagok.Items.Refresh();
                    btnFelvetel.IsEnabled = true;
                    btnModosit.IsEnabled = false;
                    tbAlapanyagNev.Text = "";
                    tbAlapanyagCount.Text = "";
                    MessageBox.Show("Sikeres Módosítás");
                }
                catch (Exception v)
                {

                    MessageBox.Show(v.Message);
                }
            };

            btnFelvetel.Click += (s, e) => 
            {
                if ((tbAlapanyagNev.Text != null || tbAlapanyagNev.Text != "") || (tbAlapanyagCount.Text != null || tbAlapanyagCount.Text != ""))
                {
                    try
                    {
                        connection = new MySqlConnection(connectionString);
                        connection.Open();
                        string lekerdezesSzoveg = $"INSERT INTO `ingredients` (`Name`,`Available`) VALUES (@Name,@Available)";
                        using (var lekerdezes = new MySqlCommand(lekerdezesSzoveg, connection))
                        {
                            lekerdezes.Parameters.AddWithValue("@Name", tbAlapanyagNev.Text);
                            lekerdezes.Parameters.AddWithValue("@Available", Convert.ToInt32(tbAlapanyagCount.Text));
                            lekerdezes.ExecuteNonQuery();
                        }
                        ingredients.Clear();
                        Beolvasas();
                        dgAlapanyagok.Items.Refresh();
                        tbAlapanyagNev.Text = "";
                        tbAlapanyagCount.Text = "";
                        MessageBox.Show("Sikeres Felvétel");
                    }
                    catch (Exception v)
                    {

                        MessageBox.Show(v.Message);
                    }
                }
                else
                    MessageBox.Show("Valami nem okés!");
            };

            /*btnTorles.Click += (s, e) =>
            {
                if (dgAlapanyagok.SelectedIndex != -1 && dgAlapanyagok.SelectedItems.Count == 1 && dgAlapanyagok.SelectedItem is Ingredients)
                {
                    try
                    {
                        var törlendoPizzak = pizzas.Where(x => x.Ingredients.Contains(tbAlapanyagNev.Text));
                        törlendoPizzak.ToList().ForEach(x =>
                        {
                            connection = new MySqlConnection(connectionString);
                            connection.Open();
                            string lekerdezesKetto = $"DELETE FROM `orders` WHERE orders.Food_Id = {x.Id}";
                            using (var lekerdezesOrders = new MySqlCommand(lekerdezesKetto, connection))
                            {
                                lekerdezesOrders.ExecuteNonQuery();
                            }
                            string lekerdezesSzoveg = $"DELETE FROM `foods` WHERE Food_Id = {x.Id}";
                            using (var lekerdezes = new MySqlCommand(lekerdezesSzoveg, connection))
                            {
                                lekerdezes.ExecuteNonQuery();
                            }

                        });

                        connection = new MySqlConnection(connectionString);
                        connection.Open();
                        string lekerdezesSzoveg = $"DELETE FROM `ingredients` WHERE Ingredient_Id = {(dgAlapanyagok.SelectedItem as Ingredients).Id}";
                        using (var lekerdezes = new MySqlCommand(lekerdezesSzoveg, connection))
                        {
                            lekerdezes.ExecuteNonQuery();
                        }


                        dgAlapanyagok.Items.Refresh();
                    }
                    catch (Exception n)
                    {

                        MessageBox.Show(n.Message);
                    }
                }
                else
                    MessageBox.Show("Nnincs kiválasztva sor, vagy több mint egy sor választott ki!");
            };*/
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
            var lineCount = tbAlapanyagNev.LineCount;

            // Ha több mint 10 sor van, akkor levágjuk a felesleget
            if (lineCount > 10)
            {
                // Megakadályozzuk további sorok hozzáadását
                int lastVisibleCharIndex = tbAlapanyagNev.GetCharacterIndexFromLineIndex(10);
                tbAlapanyagNev.Text = tbAlapanyagNev.Text.Substring(0, lastVisibleCharIndex);

                // A kurzort a végére helyezzük
                tbAlapanyagNev.CaretIndex = tbAlapanyagNev.Text.Length;
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
