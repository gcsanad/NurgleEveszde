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
        public Rendeles()
        {
            InitializeComponent();
            ObservableCollection <Pizza> kosar= new();
            List<string> pizzak = File.ReadAllLines("teszt.txt").Select(x => x).ToList();
            lbKosar.ItemsSource = kosar;
            for (int i = 0; i < pizzak.Count; i++)
            {
                var pizza = new Pizza(pizzak[i]);
                lbPizzak.Items.Add(pizza);
                
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
