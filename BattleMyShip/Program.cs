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
            Ship ship = new Ship(4, 'd');
            Ship ship2 = new Ship(4, 'x');

            Map map = new Map(10, 20);
            GameLogic logic = new GameLogic();
            while (true)
            {
                logic.PlaceShip(ship2, map, false);
                Console.WriteLine(map.DrawMap());
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}
