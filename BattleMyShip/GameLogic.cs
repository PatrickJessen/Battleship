using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMyShip
{
    class GameLogic
    {
        bool rotate;
        ShipPosition pos = new ShipPosition();
        public bool PlaceShip(Ship ship, Map map, bool isPlaced)
        {
            for (int i = 0; i < ship.ShipLength; i++)
            {
                if (rotate == true)
                {
                    map.MapArray[pos.x + i, pos.y].ship = ship;
                }
                else
                {
                    //x, y byttes om i array... x = y, y = x
                    map.MapArray[pos.x, pos.y + i].ship = ship;
                }
                map.MapArray[pos.x + i, pos.y].isPlaced = isPlaced;
                map.MapArray[pos.x, pos.y + i].isPlaced = isPlaced;
            }
            ClearMap(map);
            return false;
        }

        public void HandleKeys(Ship ship, Map map)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    Console.SetCursorPosition(pos.x--, pos.y);
                    break;
                case ConsoleKey.DownArrow:
                    Console.SetCursorPosition(pos.x++, pos.y);
                    break;
                case ConsoleKey.LeftArrow:
                    Console.SetCursorPosition(pos.x, pos.y--);
                    break;
                case ConsoleKey.RightArrow:
                    Console.SetCursorPosition(pos.x, pos.y++);
                    break;
                case ConsoleKey.B:
                    rotate = true;
                    break;
                case ConsoleKey.N:
                    rotate = false;
                    break;
                case ConsoleKey.Enter:
                    PlaceShip(ship, map, true);
                    break;
            }
            PlaceShip(ship, map, false);
            Console.Clear();
        }

        public void ClearMap(Map map)
        {
            for(int x = 0; x < map.MapArray.GetLength(0); x++)
            {
                for(int y = 0; y < map.MapArray.GetLength(1); y++)
                {
                    if (map.MapArray[x, y].isPlaced == false)
                    {
                        map.MapArray[x, y].ship = null;
                        map.MapArray[x, y].MapField = ".";
                    }
                }
            }
        }
    }
}
