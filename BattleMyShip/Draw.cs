﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMyShip
{
    class Draw
    {
        Map playerOneMap = new Map(10, 20);
        Map playerTwoMap = new Map(10, 20);
        GameLogic logic = new GameLogic();

        public void GameLoop()
        {
            logic.AddShipToList();
            while (logic.counter < logic.shipList.Count)
            {
                PlayerOne();
                PlayerTwo();
            }
            DrawMap(playerOneMap);
            DrawMap(playerTwoMap);

            //Console.WriteLine(playerOneMap.DrawMap(Console.ForegroundColor));
            //Console.WriteLine(playerTwoMap.DrawMap(Console.ForegroundColor));
            //Console.WriteLine(playerOneMap.DrawMap());
            //Console.WriteLine(playerTwoMap.DrawMap());
            Console.ReadLine();
        }

        public void PlayerOne()
        {
            if (logic.ChangeTurn() == true)
            {
                Console.WriteLine("Player 1");
                DrawMap(playerOneMap);
                logic.HandleKeys(playerOneMap);
                Console.ForegroundColor = logic.SetShipColor(playerOneMap);
            }
        }

        private void PlayerTwo()
        {
            if (logic.ChangeTurn() == false)
            {
                Console.WriteLine("Player 2");
                DrawMap(playerTwoMap);
                logic.HandleKeys(playerTwoMap);
                Console.ForegroundColor = logic.SetShipColor(playerTwoMap);
            }
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
