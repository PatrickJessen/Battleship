using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMyShip
{
    class Field
    {
        public string MapField { get; set; } = "~";
        public Ship ship { get; set; }
        public bool isPlaced { get; set; }
    }
}
