﻿using MySql.Data.MySqlClient;
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
        int ar = 0;
        Pizza jelenlegiPizza;
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
            btnFelvetel.Click += (s, e) =>
            {

                Pizza masolat = new Pizza(jelenlegiPizza.ImageName.ToString(), jelenlegiPizza.Ar);
                masolat.Click += (s, e) => 
                {
                    kosar.Remove(s as Pizza);
                    ar -= (s as Pizza).Ar;
                    lblAr.Content = $"Fizetendő összeg: {ar} Ft";
                };
                kosar.Add(masolat);
                ar += jelenlegiPizza.Ar;
                lblAr.Content = $"Fizetendő összeg: {ar} Ft";
            };
            var Tip = (int tip) =>
            {
                ar += tip;
                lblAr.Content = $"Fizetendő összeg: {ar} Ft";
            };

            btnTip10.Click += (s, e) =>
            {
                if (s is Button)
                    Tip(int.Parse((s as Button).Content.ToString()));
            };

            btnTip50.Click += (s, e) =>
            {
                if (s is Button)
                    Tip(int.Parse((s as Button).Content.ToString()));
            };

            btnTip100.Click += (s, e) =>
            {
                if (s is Button)
                    Tip(int.Parse((s as Button).Content.ToString()));
            };

            btnRendeles.Click += (s, e) => MessageBox.Show("Fin.");

            for (int i = 0; i < lbPizzak.Items.Count; i++)
            {
                if (lbPizzak.Items[i] is Pizza)
                {

                    (lbPizzak.Items[i] as Pizza).Click += (s, e) =>
                    {
                        if (s is Pizza)
                        {
                            lbDetails.Items.Clear();
                            lbDetails.Items.Add($"Pizza: {(s as Pizza).Name}");
                            lbDetails.Items.Add($"Ingredients: \n\t{(s as Pizza).Ingredients.Replace("-","\n\t").Replace("_"," ")}");
                            lbDetails.Items.Add($"Cost: {(s as Pizza).Ar}Ft");
                            BitmapImage bitimg = new BitmapImage();
                            bitimg.BeginInit();
                            bitimg.UriSource = new Uri(@$".\\pizzaKepek\\{(s as Pizza).ImageName}", UriKind.RelativeOrAbsolute);
                            bitimg.EndInit();
                            rtKepPizza.Fill = new ImageBrush(bitimg);
                            jelenlegiPizza = (s as Pizza);

                        }
                    };

                }
            }
        }


    }
}
