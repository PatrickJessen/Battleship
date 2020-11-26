using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BattleMyShip
{
    static class Input
    {
        static public bool InputCheck(ConsoleKey key)
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            if (keyInfo.Key == key)
            {
                return true;
            }
            return false;
        }

        public Task Testing()
        {
            
        }
    }
}
