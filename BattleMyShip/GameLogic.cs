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
        ShipPosition navPos = new ShipPosition();
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
            map.ClearMap();
            for (int i = 0; i < shipList[counter].ShipLength; i++)
            {
                if (rotate == true)
                {
                    //x, y byttes om i array... x = y, y = x
                    map.MapArray[pos.x + i, pos.y].isPlaced = isPlaced;
                    map.MapArray[pos.x + i, pos.y].ship = shipList[counter];
                }
                else if (rotate == false)
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
            if (isPlaced == true)
            {
                counter++;
            }
            return false;
        }

        public void HandleKeys(Map map)
        {
            //ConsoleKeyInfo keyInfo = Console.ReadKey();
            //switch (keyInfo.Key)
            //{
            //    case ConsoleKey.UpArrow:
            //        Console.SetCursorPosition(pos.y, pos.x);
            //        pos.x--;
            //        if (IsSpotEmpty(map))
            //            PlaceShip(map, false);
            //        break;
            //    case ConsoleKey.DownArrow:
            //        Console.SetCursorPosition(pos.y, pos.x);
            //        pos.x++;
            //        if (IsSpotEmpty(map))
            //            PlaceShip(map, false);
            //        break;
            //    case ConsoleKey.LeftArrow:
            //        Console.SetCursorPosition(pos.y, pos.x);
            //        pos.y--;
            //        if (IsSpotEmpty(map))
            //            PlaceShip(map, false);
            //        break;
            //    case ConsoleKey.RightArrow:
            //        Console.SetCursorPosition(pos.y, pos.x);
            //        pos.y++;
            //        if (IsSpotEmpty(map))
            //            PlaceShip(map, false);
            //        break;
            //    case ConsoleKey.B:
            //        rotate = true;
            //        break;
            //    case ConsoleKey.N:
            //        rotate = false;
            //        break;
            //    case ConsoleKey.Enter:
            //        if (IsSpotEmpty(map))
            //            PlaceShip(map, true);
            //        break;
            //}
            //Console.SetCursorPosition(0, 0);
            if (Input.InputCheck(ConsoleKey.UpArrow))
            {
                Console.SetCursorPosition(pos.y, pos.x);
                pos.x--;
                if (IsSpotEmpty(map))
                PlaceShip(map, false);
            }
            else if (Input.InputCheck(ConsoleKey.DownArrow))
            {
                Console.SetCursorPosition(pos.y, pos.x);
                pos.x++;
                if (IsSpotEmpty(map))
                    PlaceShip(map, false);
            }
            else if (Input.InputCheck(ConsoleKey.LeftArrow))
            {
                Console.SetCursorPosition(pos.y, pos.x);
                pos.y--;
                if (IsSpotEmpty(map))
                    PlaceShip(map, false);
            }
            else if (Input.InputCheck(ConsoleKey.RightArrow))
            {
                Console.SetCursorPosition(pos.y, pos.x);
                pos.y++;
                if (IsSpotEmpty(map))
                    PlaceShip(map, false);
            }
            else if (Input.InputCheck(ConsoleKey.B))
            {
                rotate = true;
            }
            else if (Input.InputCheck(ConsoleKey.N))
            {
                rotate = false;
            }
            else if (Input.InputCheck(ConsoleKey.Enter))
            {
                if (IsSpotEmpty(map))
                    PlaceShip(map, true);
            }
            //Console.SetCursorPosition(0, 0);
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

        private bool IsSpotEmpty(Map map)
        {
            for (int i = 0; i < shipList[counter].ShipLength; i++)
            {
                if (rotate == true)
                {
                    if (map.MapArray[pos.x + i, pos.y].ship != null)
                    {
                        if (map.MapArray[pos.x + i, pos.y].ship != shipList[counter])
                            return false;

                    }
                }
                else if (rotate == false)
                {
                    if (map.MapArray[pos.x, pos.y + i].ship != null)
                    {
                        if (map.MapArray[pos.x, pos.y + i].ship != shipList[counter])
                            return false;
                    }
                }
            }
            return true;
        }

        public void CheckOutOfBounds(Map map)
        {
            if (rotate == false && pos.y <= 0)
            {
                pos.y += 1;
            }
            else if (rotate == false && pos.y + shipList[counter].ShipLength >= map.Height)
            {
                pos.y -= 1;
            }
            else if (rotate == false && pos.x <= 0)
            {
                pos.x += 1;
            }
            else if (rotate == false && pos.x >= 9)
            {
                pos.x -= 1;
            }
        }

        public void ShootShip(Map map)
        {

        }
    }
}
