using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMyShip
{
    class Program
    {
        static void Main(string[] args)
        {
            Draw draw = new Draw();
            draw.GameLoop();
        }
    }
}
