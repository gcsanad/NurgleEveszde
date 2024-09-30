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
using System.Net.Mail;
using System.Net;

namespace NurgleEveszdeWpf
{
    /// <summary>
    /// Interaction logic for Rendeles.xaml
    /// </summary>
    public partial class Rendeles : Window
    {
        public static string FROM_EMAIL = "nurglepizzeria@gmail.com";
        public static string FROM_PASS = "plpc pngt egjt jcvf ";
        public string connectionString = "datasource = 127.0.0.1;port=3306;username=root;password=;database=nurgleeveszde";
        private MySqlConnection connection;
        static int ar = 0;
        static int tip;
        Pizza jelenlegiPizza;
        static User bejelentkezettFelhasznalo;
        static User regisztraltFelhasznalo;
        public Rendeles()
        {
            
            InitializeComponent();
            ObservableCollection<StackPanel> kosar = [];
            ObservableCollection<StackPanel> pizzak = [];
            btnFelvetel.IsEnabled = false;
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
                {
                    

                    StackPanel stackPanelTarolo = new StackPanel();
                    Label labelNev = new Label();
                    Pizza pizza = new Pizza($"{reader.GetInt32(0)};{reader.GetString(1)};{reader.GetString(2)};{reader.GetInt32(3)};{reader.GetString(4)};{reader.GetBoolean(5)}".Split(";"));
                    labelNev.Content = pizza.Name;
                    labelNev.Foreground = Brushes.White;
                    labelNev.VerticalContentAlignment = VerticalAlignment.Center;
                    labelNev.HorizontalContentAlignment = HorizontalAlignment.Center;
                    stackPanelTarolo.Orientation = Orientation.Vertical;
                    stackPanelTarolo.Children.Add(pizza);
                    stackPanelTarolo.Children.Add(labelNev);
                    pizzak.Add(stackPanelTarolo);
                }

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
                BrushConverter bc = new BrushConverter();
                Brush brush = (Brush)bc.ConvertFrom("#6EC207");

                StackPanel stackpanelKosar = new StackPanel();
                Label labelKoasr = new Label();
                Pizza masolat = new Pizza(jelenlegiPizza.ImageName.ToString(), jelenlegiPizza.Ar, jelenlegiPizza.Available);
                labelKoasr.Content = jelenlegiPizza.Name;
                labelKoasr.Foreground = brush;
                labelKoasr.VerticalContentAlignment = VerticalAlignment.Center;
                labelKoasr.HorizontalContentAlignment = HorizontalAlignment.Center;
                stackpanelKosar.Children.Add(masolat);
                stackpanelKosar.Children.Add(labelKoasr);
                stackpanelKosar.Orientation = Orientation.Horizontal;
                masolat.Click += (s, e) => 
                {
                    if ((s as Pizza).Parent is StackPanel)
                    {
                        kosar.Remove((s as Pizza).Parent as StackPanel);
                        ar -= (s as Pizza).Ar;
                        lblAr.Content = $"Fizetendő összeg: {ar} Ft";   
                    }
                    else
                    {
                        MessageBox.Show("Hűha!", "ERROR", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                };
                kosar.Add(stackpanelKosar);
                ar += jelenlegiPizza.Ar;
                lblAr.Content = $"Fizetendő összeg: {ar} Ft";
            };

            sldTip.ValueChanged += (s, e) => 
            {
                lbTip.Content = Convert.ToInt32(sldTip.Value);
                tip = Convert.ToInt32(sldTip.Value);
            };

            btnRendeles.Click += (s, e) => 
            {
                if ((pizzak.OrderBy(x => (x.Children[0] as Pizza).Ar).First().Children[0] as Pizza).Ar > ar)
                    MessageBox.Show("Hát, a semmit nem szállítjuk ki, kösz.");
                else
                {
                    var Result = MessageBox.Show($"Végösszeg: {ar} + tip: {tip}\nBefejezi a rendelést?", "Rendelés", MessageBoxButton.YesNo, MessageBoxImage.Information);
                    if (Result == MessageBoxResult.Yes)
                        RendelesJovahagyvaEmail();
                    else
                        return;
                }
             };
            
            for (int i = 0; i < pizzak.Count; i++)
            {
                if (pizzak[i].Children[0] is Pizza && (pizzak[i].Children[0] as Pizza).Available == true)
                {

                    (pizzak[i].Children[0] as Pizza).Click += (s, e) =>
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
                            btnFelvetel.IsEnabled = true;
                        }
                    };

                }
                else
                    (pizzak[i].Children[0] as Pizza).Click += (s, e) => MessageBox.Show("Ez a pizza jelenleg nem elérhető!");
            }
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (mainWindow != null)
                bejelentkezettFelhasznalo = mainWindow.Bejelentkezett;
            
                txtTelefon.Text = bejelentkezettFelhasznalo.mobil;
                txtCim.Text = bejelentkezettFelhasznalo.address;
            
            
        }
        public static void RendelesJovahagyvaEmail()
        {

            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(FROM_EMAIL);
                mail.To.Add(bejelentkezettFelhasznalo.email);
                mail.Subject = "Pizza rendelés elfogadva";
                mail.Body = $"Köszönjük a rendelését, máris elkezdtük készíteni a pizzáját!\nFelhasználó neve: {bejelentkezettFelhasznalo.username}\nSzállítási cím: {bejelentkezettFelhasznalo.address}\nElérhetősége: {bejelentkezettFelhasznalo.mobil}\nRendelés összege: {ar + tip}Ft";
                mail.IsBodyHtml = false;

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.EnableSsl = true;
                smtpClient.Credentials = new NetworkCredential("nurglepizzeria@gmail.com", "plpc pngt egjt jcvf ");
                smtpClient.Send(mail);
                MessageBox.Show("Rendelés sikeresen leadva!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba az email küldése közben" + ex.Message);
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            this.Close();
            main.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
