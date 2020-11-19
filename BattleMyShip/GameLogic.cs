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
        Map map = new Map();
        public bool PlaceShip(int x, int y, Ship ship, bool rotate)
        {
            for (int i = 0; i < ship.ShipLength; i++)
            {
                if (rotate == true)
                {
                    //x, y byttes om i array... x = y, y = x
                    map.MapArray[pos.x + i, pos.y].ship = ship;
                }
                else
                {
                    map.MapArray[pos.x, pos.y + i].ship = ship;
                }
            }
            return false;
        }
    }
}
