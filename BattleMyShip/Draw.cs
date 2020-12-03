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
        Map AIMap = new Map(10, 20);
        Map map = new Map(10, 20);
        GameManager logic = new GameManager();

        public void GameLoop()
        {
            logic.AddPlayerShips();
            logic.AddAIShips();
            while (true)
            {
                AI();
                PlayerOne();
            }
        }

        public void PlayerOne()
        {
            if (logic.playerCounter != logic.playerShips.Count)
            {
                Console.ResetColor();
                Console.WriteLine("Player 1");
                DrawMap(playerOneMap);
                logic.HandleKeys(playerOneMap);
            }
            else
            {
                Console.WriteLine("Shoot AI Ship");
                DrawMap(AIMap);
                logic.HandleKeys(AIMap);
            }
        }

        public void AI()
        {

            //Console.WriteLine("AI");
            logic.AIManager(AIMap);
            //DrawMap(AIMap);
            
        }

        public void DrawMap(Map playerMap)
        {
            for (int x = 0; x < playerMap.MapArray.GetLength(0); x++)
            {
                for (int y = 0; y < playerMap.MapArray.GetLength(1); y++)
                {
                    if (playerMap.MapArray[x, y].Ships != null)
                    {
                        Console.ForegroundColor = playerMap.MapArray[x, y].Ships.ShipColor;
                        Console.Write(playerMap.MapArray[x, y].Ships.ShipCharacter);
                    
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
