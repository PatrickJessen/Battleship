using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMyShip
{
    class Draw
    {
        Map playerOneMap = new Map(10, 20);
        Map map = new Map(10, 20);
        GameLogic logic = new GameLogic();

        public void GameLoop()
        {
            logic.AddShipToList();
            while (true)
            {
                if (logic.counter < logic.shipList.Count)
                {
                    PlayerOne();
                }
                else
                {
                    DrawMap(playerOneMap);
                    Console.WriteLine();
                    Console.ReadLine();
                }
            }
        }

        public void PlayerOne()
        {
            Console.ResetColor();
            Console.WriteLine("Player 1");
            DrawMap(playerOneMap);
            logic.Test(playerOneMap);
            //logic.HandleKeys(playerOneMap);
            logic.CheckOutOfBounds(playerOneMap);
            playerOneMap.ClearMap();
            Console.SetCursorPosition(0, 0);
        }

        public void DrawMap(Map playerMap)
        {
            for (int x = 0; x < playerMap.MapArray.GetLength(0); x++)
            {
                for (int y = 0; y < playerMap.MapArray.GetLength(1); y++)
                {
                    if (playerMap.MapArray[x, y].ship != null)
                    {
                        Console.ForegroundColor = playerMap.MapArray[x, y].ship.ShipColor;
                        Console.Write(playerMap.MapArray[x, y].ship.ShipCharacter);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(playerMap.MapArray[x, y].MapField);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
