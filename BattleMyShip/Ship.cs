﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMyShip
{
    class Ship
    {
        public int ShipLength { get; set; }
        public char ShipCharacter { get; set; }
        public ConsoleColor ShipColor { get; set; }
        
        public Ship(int shipLength, char ShipCharacter, ConsoleColor shipColor)
        {
            this.ShipLength = shipLength;
            this.ShipCharacter = ShipCharacter;
            this.ShipColor = shipColor;
        }
    }
}
