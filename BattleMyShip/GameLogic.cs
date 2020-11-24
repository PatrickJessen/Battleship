using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BattleMyShip
{
    class GameLogic
    {
        bool rotate;
        ShipPosition pos = new ShipPosition();
        public List<Ship> shipList = new List<Ship>();
        public int counter = 0;
        public void AddShipToList()
        {
            shipList.Add(new Ship(3, 'x', ConsoleColor.Red));
            shipList.Add(new Ship(4, 'c', ConsoleColor.Blue));
            shipList.Add(new Ship(5, 'z', ConsoleColor.Green));
            shipList.Add(new Ship(3, 'x', ConsoleColor.Red));
            shipList.Add(new Ship(4, 'c', ConsoleColor.Blue));
            shipList.Add(new Ship(5, 'z', ConsoleColor.Green));
        }
        private bool PlaceShip(Map map, bool isPlaced)
        {
            //AddShipToList();
            ClearMap(map);
            for (int i = 0; i < shipList[counter].ShipLength; i++)
            {
                if (rotate == true)
                {
                    if (map.MapArray[pos.x + i, pos.y].ship != shipList[0] && map.MapArray[pos.x + i, pos.y].ship != shipList[1] && map.MapArray[pos.x + i, pos.y].ship != shipList[2] && map.MapArray[pos.x + i, pos.y].ship != shipList[3] && map.MapArray[pos.x + i, pos.y].ship != shipList[4] && map.MapArray[pos.x + i, pos.y].ship != shipList[5])
                    {
                        //x, y byttes om i array... x = y, y = x
                        map.MapArray[pos.x + i, pos.y].isPlaced = isPlaced;
                        map.MapArray[pos.x + i, pos.y].ship = shipList[counter];
                    }
                    else
                    {
                        isPlaced = false;
                    }
                }
                else if (rotate == false)
                {
                    if (map.MapArray[pos.x, pos.y + i].ship == null)
                    {
                        //x, y byttes om i array... x = y, y = x
                        map.MapArray[pos.x, pos.y + i].isPlaced = isPlaced;
                        map.MapArray[pos.x, pos.y + i].ship = shipList[counter];
                    }
                    else
                    {
                        isPlaced = false;
                    }
                }
            }
            if (isPlaced == true)
            {
                counter++;
            }
            return false;
        }

        public void HandleKeys(Map map)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    Console.SetCursorPosition(pos.x--, pos.y);
                    PlaceShip(map, false);
                    break;
                case ConsoleKey.DownArrow:
                    Console.SetCursorPosition(pos.x++, pos.y);
                    PlaceShip(map, false);
                    break;
                case ConsoleKey.LeftArrow:
                    Console.SetCursorPosition(pos.x, pos.y--);
                    PlaceShip(map, false);
                    break;
                case ConsoleKey.RightArrow:
                    Console.SetCursorPosition(pos.x, pos.y++);
                    PlaceShip(map, false);
                    break;
                case ConsoleKey.B:
                    rotate = true;
                    break;
                case ConsoleKey.N:
                    rotate = false;
                    break;
                case ConsoleKey.Enter:
                    PlaceShip(map, true);
                    break;
            }
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
                        //map.MapArray[x, y].MapField = ".";
                    }
                }
            }
        }
        // map.MapArray[pos.x, pos.y + i].ship != shipList[0] && map.MapArray[pos.x, pos.y + i].ship != shipList[1] && map.MapArray[pos.x, pos.y + i].ship != shipList[2] && map.MapArray[pos.x, pos.y + i].ship != shipList[3] && map.MapArray[pos.x, pos.y + i].ship != shipList[4] && map.MapArray[pos.x, pos.y].ship != shipList[5]
        private void IsXFieldEmpty(Map map, int i, bool isPlaced)
        {
            if (map.MapArray[pos.x, pos.y + i].ship == null)
            {
                //x, y byttes om i array... x = y, y = x
                map.MapArray[pos.x, pos.y + i].isPlaced = isPlaced;
                map.MapArray[pos.x, pos.y + i].ship = shipList[counter];
            }
            else
            {
                isPlaced = false;
            }
        }

        private bool IsYFieldEmpty(Map map)
        {
            bool temp = true;
            for (int i = 0; i < shipList[counter].ShipLength; i++)
            {
                if (map.MapArray[pos.x + i, pos.y].ship != shipList[0] && map.MapArray[pos.x + i, pos.y].ship != shipList[1] && map.MapArray[pos.x + i, pos.y].ship != shipList[2] && map.MapArray[pos.x + i, pos.y].ship != shipList[3] && map.MapArray[pos.x + i, pos.y].ship != shipList[4] && map.MapArray[pos.x + i, pos.y].ship != shipList[5])
                {
                    //x, y byttes om i array... x = y, y = x
                    temp = true;
                }
                else
                {
                    temp = false;
                }
            }
            return temp;
        }

        public bool ChangeTurn()
        {
            if (counter < shipList.Count / 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
