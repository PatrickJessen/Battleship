using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMyShip
{
    class Player
    {
        public ShipPosition pos = new ShipPosition();
        public ShipPosition navPos = new ShipPosition();
        public bool rotate;
        public bool PlaceShip(Map map, List<Ship> ships, int counter, bool isPlaced)
        {
            map.ClearMap();
            for (int i = 0; i < ships[counter].ShipLength; i++)
            {
                try
                {
                    if (rotate == true)
                    {
                        //x, y byttes om i array... x = y, y = x
                        map.MapArray[pos.x + i, pos.y].isPlaced = isPlaced;
                        map.MapArray[pos.x + i, pos.y].ship = ships[counter];
                    }
                    else if (rotate == false)
                    {
                        //x, y byttes om i array... x = y, y = x
                        map.MapArray[pos.x, pos.y + i].isPlaced = isPlaced;
                        map.MapArray[pos.x, pos.y + i].ship = ships[counter];
                    }
                    else
                    {
                        isPlaced = false;
                    }
                }
                catch
                {
                    isPlaced = false;
                }
            }
            return false;
        }

        public bool IsSpotEmpty(Map map, List<Ship> ships, int counter)
        {
            for (int i = 0; i < ships[counter].ShipLength; i++)
            {
                try
                {
                    if (rotate == true)
                    {
                        if (map.MapArray[pos.x + i, pos.y].ship != null)
                        {
                            if (map.MapArray[pos.x + i, pos.y].ship != ships[counter])
                                return false;

                        }
                    }
                    else if (rotate == false)
                    {
                        if (map.MapArray[pos.x, pos.y + i].ship != null)
                        {
                            if (map.MapArray[pos.x, pos.y + i].ship != ships[counter])
                                return false;
                        }
                    }
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }
        public void ShootShip(Map map, AI ai, bool isPlaced)
        {
            if (map.MapArray[navPos.x, navPos.y].MapField == map.MapArray[pos.x, pos.y].ship.ShipCharacter.ToString())
            {
                map.MapArray[navPos.x, navPos.y].isPlaced = isPlaced;
                map.MapArray[navPos.x, navPos.y].MapField = "o";
            }
            else
            {
                map.MapArray[navPos.x, navPos.y].isPlaced = isPlaced;
                map.MapArray[navPos.x, navPos.y].MapField = "x";
            }
        }
    }
}
