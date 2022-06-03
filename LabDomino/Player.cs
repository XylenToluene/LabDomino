using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabDomino
{
    public class Player
    {
        public string Name { get; set; }

        public int Moves = 0;
        public int SelectedK { get; set; }

        public List<string> KInHand = new List<string>(); // кости первого игрока
        public int Score { get; set; }

    }
}
