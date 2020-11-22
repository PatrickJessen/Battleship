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
            Console.WriteLine(playerOneMap.DrawMap());
            Console.WriteLine(playerTwoMap.DrawMap());
            Console.ReadLine();
        }

        public void PlayerOne()
        {
            if (logic.ChangeTurn() == true)
            {
                Console.WriteLine("Player 1");
                Console.WriteLine(playerOneMap.DrawMap());
                logic.HandleKeys(playerOneMap);
            }
        }

        private void PlayerTwo()
        {
            if (logic.ChangeTurn() == false)
            {
                Console.WriteLine("Player 2");
                Console.WriteLine(playerTwoMap.DrawMap());
                logic.HandleKeys(playerTwoMap);
            }
        }
    }
}
