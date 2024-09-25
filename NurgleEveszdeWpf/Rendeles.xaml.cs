using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
    /// Interaction logic for Rendeles.xaml
    /// </summary>
    public partial class Rendeles : Window
    {
        public string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=nurgleeveszde";
        private MySqlConnection connection;
        public Rendeles()
        {
            InitializeComponent();
            ObservableCollection<Pizza> kosar = [];
            ObservableCollection<Pizza> pizzak = [];
            lbKosar.ItemsSource = kosar;
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                string lekerdezesSzoveg = "SELECT * FROM foods";
                MySqlCommand lekerdezes = new(lekerdezesSzoveg, connection);
                lekerdezes.CommandTimeout = 60;
                MySqlDataReader reader = lekerdezes.ExecuteReader();
                while (reader.Read())
                    pizzak.Add(new Pizza($"{reader.GetInt32(0)};{reader.GetString(1)};{reader.GetString(2)};{reader.GetInt32(3)};{reader.GetString(4)}".Split(";")));

                reader.Close();
                connection.Close();
                lbPizzak.ItemsSource = pizzak;
            }
            catch (Exception e)
            {

                MessageBox.Show(e.Message);
            }
            for (int i = 0; i < lbPizzak.Items.Count; i++)
            {
                if (lbPizzak.Items[i] is Pizza)
                {

                    (lbPizzak.Items[i] as Pizza).Click += (s, e) =>
                    {
                        if (s is Pizza)
                        {
                            Pizza masolat = new Pizza((s as Pizza).ImageName.ToString());
                            masolat.Click += (s, e) => kosar.Remove(s as Pizza);
                            kosar.Add(masolat);

                        }
                    };

                }
            }
        }

    }
}
