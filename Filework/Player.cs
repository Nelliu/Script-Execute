using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Filework
{
    public class Player
    {
        public string Class { get; set; }
        public int Health { get; set; }
        public int Strenght { get; set; }
        public int Inteligence { get; set; }
        public int Agility { get; set; }

        public items Inventory { get; set; }
        
        public void AddHealth(int number)
        {
            Health = Health + number;
        }
        public void AddStr(int numb)
        {
            Strenght = Strenght + numb;
        }

    }
}
