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
        AI ai = new AI();
        Player player = new Player();
        public List<Ship> shipList = new List<Ship>();
        public int counter = 0;
        public bool isShipPlaced = false;
        public void AddShipToList()
        {
            shipList.Add(new Ship(5, 'H', ConsoleColor.Red));
            shipList.Add(new Ship(4, 'S', ConsoleColor.Blue));
            shipList.Add(new Ship(3, 'D', ConsoleColor.Green));
            shipList.Add(new Ship(3, 'U', ConsoleColor.Yellow));
            shipList.Add(new Ship(2, 'P', ConsoleColor.Magenta));
        }

        public void Test(Map map)
        {
            ai.PlaceRandomShips(map, shipList, counter);
            if (ai.IsSpotEmpty(map, shipList, counter, ai.placePosX, ai.placePosY, ai.isRotated))
            {
                counter++;
            }
            Console.SetCursorPosition(0, 0);
        }

        public void HandleKeys(Map map)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    //Console.SetCursorPosition(player.pos.y, player.pos.x);
                    player.pos.x--;
                    ChangeTurn(map);
                    break;
                case ConsoleKey.DownArrow:
                    //Console.SetCursorPosition(player.pos.y, player.pos.x);
                    player.pos.x++;
                    ChangeTurn(map);
                    break;
                case ConsoleKey.LeftArrow:
                    //Console.SetCursorPosition(player.pos.y, player.pos.x);
                    player.pos.y--;
                    ChangeTurn(map);
                    break;
                case ConsoleKey.RightArrow:
                    //Console.SetCursorPosition(player.pos.y, player.pos.x);
                    player.pos.y++;
                    ChangeTurn(map);
                    break;
                case ConsoleKey.B:
                    player.rotate = true;
                    break;
                case ConsoleKey.N:
                    player.rotate = false;
                    break;
                case ConsoleKey.Enter:
                    PlaceShip(map);
                    break;
            }
            Console.SetCursorPosition(0, 0);
            
        }

        public void ChangeTurn(Map map)
        {
            if (isShipPlaced == false)
            {
                if (player.IsSpotEmpty(map, shipList, counter))
                    player.PlaceShip(map, shipList, counter, false);
            }
        }

        public void PlaceShip(Map map)
        {
            if (isShipPlaced == false)
            {
                if (player.IsSpotEmpty(map, shipList, counter))
                {
                    player.PlaceShip(map, shipList, counter, true);
                    counter++;
                }
            }
        }
    }
}
