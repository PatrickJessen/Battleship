using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BattleMyShip
{
    class GameManager
    {
        AI ai = new AI();
        Player player = new Player();
        public List<Ship> playerShips = new List<Ship>();
        public List<Ship> AIShips = new List<Ship>();
        public int playerCounter = 0;
        public int aiCounter = 0;
        public void AddPlayerShips()
        {
            playerShips.Add(new Ship(5, "H", ConsoleColor.Red));
            playerShips.Add(new Ship(4, "S", ConsoleColor.Blue));
            playerShips.Add(new Ship(3, "D", ConsoleColor.Green));
            playerShips.Add(new Ship(3, "U", ConsoleColor.Yellow));
            playerShips.Add(new Ship(2, "P", ConsoleColor.Magenta));
        }
        public void AddAIShips()
        {
            AIShips.Add(new Ship(5, "1", ConsoleColor.White));
            AIShips.Add(new Ship(4, "2", ConsoleColor.White));
            AIShips.Add(new Ship(3, "3", ConsoleColor.White));
            AIShips.Add(new Ship(3, "4", ConsoleColor.White));
            AIShips.Add(new Ship(2, "5", ConsoleColor.White));
        }

        public void AIManager(Map map)
        {
            try
            {
                if (IsAIShipPlaced() == false)
                {
                    ai.PlaceRandomShips(map, AIShips, aiCounter);
                    if (ai.IsSpotEmpty(map, AIShips, aiCounter, ai.placePosX, ai.placePosY, ai.isRotated))
                    {
                        aiCounter++;
                    }
                    Console.SetCursorPosition(0, 0);
                }
            }
            catch
            {

            }
        }

        public void PlayerManager(Map map)
        {

        }

        public void HandleKeys(Map map)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            switch (keyInfo.Key)
            {
                case ConsoleKey.UpArrow:
                    //Console.SetCursorPosition(player.pos.y, player.pos.x);
                    player.pos.x--;
                    player.navPos.y--;
                    Navigate(map);
                    break;
                case ConsoleKey.DownArrow:
                    //Console.SetCursorPosition(player.pos.y, player.pos.x);
                    player.pos.x++;
                    player.navPos.y++;
                    Navigate(map);
                    break;
                case ConsoleKey.LeftArrow:
                    //Console.SetCursorPosition(player.pos.y, player.pos.x);
                    player.pos.y--;
                    player.navPos.x--;
                    Navigate(map);
                    break;
                case ConsoleKey.RightArrow:
                    //Console.SetCursorPosition(player.pos.y, player.pos.x);
                    player.pos.y++;
                    player.navPos.x++;
                    Navigate(map);
                    break;
                case ConsoleKey.B:
                    player.rotate = true;
                    break;
                case ConsoleKey.N:
                    player.rotate = false;
                    break;
                case ConsoleKey.Enter:
                    PlaceObject(map);
                    break;
            }
            Console.SetCursorPosition(0, 0);

        }

        public void Navigate(Map map)
        {
            if (IsPlayerShipPlaced() == false)
            {
                if (player.IsSpotEmpty(map, playerShips, playerCounter))
                    player.PlaceShip(map, playerShips, playerCounter, false);

            }
            else
            {
                //player.pos.x = 0;
                //player.pos.y = 0;
                player.ShootShip(map, ai, false, player.pos.x, player.pos.y, AIShips);
            }
        }

        public void PlaceObject(Map map)
        {
            if (IsPlayerShipPlaced() == false)
            {
                if (player.IsSpotEmpty(map, playerShips, playerCounter))
                {
                    player.PlaceShip(map, playerShips, playerCounter, true);
                    playerCounter++;
                }
            }
            else
            {
                player.ShootShip(map, ai, true, player.pos.x, player.pos.y, AIShips);
            }
        }

        public bool IsPlayerShipPlaced()
        {
            if (playerCounter == playerShips.Count)
            {
                return true;
            }
            return false;
        }
        public bool IsAIShipPlaced()
        {
            if (aiCounter == AIShips.Count)
            {
                return true;
            }
            return false;
        }


    }
}
