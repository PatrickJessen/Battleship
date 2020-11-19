using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMyShip
{
    class GameLogic
    {
        ShipPosition pos = new ShipPosition();
        public bool PlaceShip(Ship ship, Map map, bool rotate)
        {
            for (int i = 0; i < ship.ShipLength; i++)
            {
                if (rotate == true)
                {
                    HandleKeys();
                    
                    map.MapArray[pos.x + i, pos.y].ship = ship;
                }
                else
                {
                    HandleKeys();
                    //x, y byttes om i array... x = y, y = x
                    map.MapArray[pos.x, pos.y + i].ship = ship;
                }
            }
            return false;
        }

        private void HandleKeys()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    pos.y--;
                    break;
                case ConsoleKey.DownArrow:
                    pos.y++;
                    break;
                case ConsoleKey.LeftArrow:
                    pos.x--;
                    break;
                case ConsoleKey.RightArrow:
                    pos.x++;
                    break;
                default:
                    break;
            }
        }
    }
}
