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
    /// Interaction logic for Rendeles.xaml
    /// </summary>
    public partial class Rendeles : Window
    {
        public Rendeles()
        {
            InitializeComponent();
            ObservableCollection <Pizza> kosar= new();
            lbKosar.ItemsSource = kosar;
            for (int i = 0; i < 100; i++)
            {
                var pizza = new Pizza(i.ToString());
                lbPizzak.Items.Add(pizza);
            }
            for (int i = 0; i < lbPizzak.Items.Count; i++)
            {
                if (lbPizzak.Items[i] is Pizza)
                {

                    (lbPizzak.Items[i] as Pizza).Click += (s, e) =>
                    {
                        if (s is Pizza)
                            kosar.Add(new Pizza((s as Pizza).Content.ToString()));
                    };

                }
            }
        }
    }
}
