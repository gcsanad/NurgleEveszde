using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NurgleEveszdeWpf
{
    internal class Ingredients
    {
        int id;
        string name;
        int available;


        public Ingredients(string[] tomb)
        {
            this.id = int.Parse(tomb[0]);
            this.name = tomb[1];
            this.available = int.Parse(tomb[2]);
        }

        public Ingredients() { }

        public int Id => id;

        public string Name { get => name; set => name = value; }
        public int Available { get => available; set => available = value; }
    }
}
