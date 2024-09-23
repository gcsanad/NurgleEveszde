using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace NurgleEveszdeWpf
{
    internal class Pizza : Button
    {
        int id;
        string name;
        string ingredients;
        int ar;
        string imageName;

        public Pizza(string[] tomb)
        {
            this.id = int.Parse(tomb[0]);
            this.name = tomb[1];
            this.ingredients = tomb[2];
            this.ar = int.Parse(tomb[3]);
            this.imageName = tomb[4];
            Kepek(tomb[4]);
        }

        public Pizza(string nev)
        {

            Kepek(nev);
        }

        public void Kepek(string nev)
        {
            BitmapImage bitimg = new BitmapImage();
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(@$".\\pizzaKepek\\{nev}", UriKind.RelativeOrAbsolute);
            bitimg.EndInit();
            this.Width = 50;
            this.Height = 50;
            this.Background = new ImageBrush(bitimg);
            this.imageName = nev;
        }

        public int Id => id;
        public string Name => name;
        public string Ingredients => ingredients;
        public int Ar => ar;
        public string ImageName => imageName;
    }
}
