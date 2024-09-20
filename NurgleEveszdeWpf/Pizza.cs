using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NurgleEveszdeWpf
{
    internal class Pizza : Button
    {
        string name;
        string ingredients;
        int ar;
        string imageName;

        public Pizza(string[] tomb)
        {
            this.name = tomb[0];
            this.ingredients = tomb[1];
            this.ar = int.Parse(tomb[2]);
            this.imageName = tomb[3];
        }

        public Pizza(string szam) 
        {
            this.Content = szam;
            this.Background = Brushes.LightCoral;
        }

        public string Name => name;
        public string Ingredients  => ingredients;
        public int Ar  => ar;
        public string ImageName => imageName;
    }
}
