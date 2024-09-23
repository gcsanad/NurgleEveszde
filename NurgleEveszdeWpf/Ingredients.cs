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

        public int Id  => id;
        public string Name  => name; 
        public int Available => available; 
    }
}
