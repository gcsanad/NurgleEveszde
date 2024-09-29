﻿using System;
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
        bool available;

        public Pizza(string[] tomb)
        {
            this.id = int.Parse(tomb[0]);
            this.name = tomb[1];
            this.ingredients = tomb[2];
            this.ar = int.Parse(tomb[3]);
            this.imageName = tomb[4];
            this.available = tomb[5] == "True" ? true : false;
            Kepek(tomb[4], ar, available);
        }

        public Pizza(string nev, int arMasolat, bool available)
        {

            Kepek(nev, arMasolat, available);
        }

        public void Kepek(string nev, int arMasolat, bool available)
        {
            string kep = "";

            kep = (available == true) ? @$".\\pizzaKepek\\{nev}" : @$".\\pizzaKepek\\not.jpg";

            BitmapImage bitimg = new BitmapImage();
            bitimg.BeginInit();
            bitimg.UriSource = new Uri(kep, UriKind.RelativeOrAbsolute);
            bitimg.EndInit();
            this.Width = 100;
            this.Height = 100;
            this.Background = new ImageBrush(bitimg);
            this.imageName = nev;
            this.ar = arMasolat;
        }

        public int Id => id;
        public new string Name => name;
        public string Ingredients => ingredients;
        public int Ar => ar;
        public string ImageName => imageName;
        public bool Available { get => available; set => available = value; }
    }
}
