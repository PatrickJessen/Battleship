﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMyShip
{
    class AI
    {
        Random rand = new Random();
        Random rotate = new Random();
        public int placePosX;
        public int placePosY;
        public int isRotated;
        public void PlaceRandomShips(Map map, List<Ship> ships, int counter)
        {
            isRotated = rotate.Next(0, 2);
            placePosX = rand.Next(0, 9 - ships[counter].ShipLength);
            placePosY = rand.Next(ships[counter].ShipLength, 19 - ships[counter].ShipLength);
            Random newrand = new Random();
            for (int i = 0; i < ships[counter].ShipLength; i++)
            {
                if (IsSpotEmpty(map, ships, counter, placePosX, placePosY, isRotated))
                {
                    if (isRotated == 1)
                    {
                        //x, y byttes om i array... x = y, y = x
                        map.MapArray[placePosX + i, placePosY].isPlaced = true;
                        map.MapArray[placePosX + i, placePosY].ship = ships[counter];
                    }
                    else if (isRotated == 0)
                    {
                        //x, y byttes om i array... x = y, y = x
                        map.MapArray[placePosX, placePosY + i].isPlaced = true;
                        map.MapArray[placePosX, placePosY + i].ship = ships[counter];
                    }
                }
            }
        }

        public bool IsSpotEmpty(Map map, List<Ship> ships, int counter, int x, int y, int rotate)
        {
            for (int i = 0; i < ships[counter].ShipLength; i++)
            {
                if (rotate == 1)
                {
                    if (map.MapArray[x + i, y].ship != null)
                    {
                        if (map.MapArray[x + i, y].ship != ships[counter])
                            return false;

                    }
                }
                else if (rotate == 0)
                {
                    if (map.MapArray[x, y + i].ship != null)
                    {
                        if (map.MapArray[x, y + i].ship != ships[counter])
                            return false;
                    }
                }
            }
            return true;
        }
    }
}
