﻿using System;
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
                if (rotate == true)
                {
                    //x, y byttes om i array... x = y, y = x
                    map.MapArray[pos.x + i, pos.y].IsPlaced = isPlaced;
                    map.MapArray[pos.x + i, pos.y].Ships = ships[counter];
                }
                else if (rotate == false)
                {
                    //x, y byttes om i array... x = y, y = x
                    map.MapArray[pos.x, pos.y + i].IsPlaced = isPlaced;
                    map.MapArray[pos.x, pos.y + i].Ships = ships[counter];
                }
                else
                {
                    isPlaced = false;
                }
            }
            return false;
        }

        public bool IsSpotEmpty(Map map, List<Ship> ships, int counter)
        {
            try
            {
                for (int i = 0; i < ships[counter].ShipLength; i++)
                {
                        if (rotate == true)
                        {
                            if (map.MapArray[pos.x + i, pos.y].Ships != null)
                            {
                                if (map.MapArray[pos.x + i, pos.y].Ships != ships[counter])
                                    return false;

                            }
                        }
                        else if (rotate == false)
                        {
                            if (map.MapArray[pos.x, pos.y + i].Ships != null)
                            {
                                if (map.MapArray[pos.x, pos.y + i].Ships != ships[counter])
                                    return false;
                            }
                        }
                    }
                }
            catch
            {
                return false;
            }
            return true;
        }

        public void ShootShip(Map map, AI ai, bool isPlaced, int x, int y, List<Ship> shipList)
        {
            //if (map.MapArray[navPos.x, navPos.y].MapField == map.MapArray[pos.x, pos.y].Ships.ShipCharacter.ToString())
            //{
            map.ClearMap();
            HitShip(map, shipList, isPlaced);
            if (HasBeenShot(map))
            {
                map.MapArray[x, y].IsPlaced = isPlaced;
                map.MapArray[x, y].MapField = "x";
            }
            //}
            //else
            //{
            //    map.MapArray[navPos.x, navPos.y].IsPlaced = isPlaced;
            //    map.MapArray[navPos.x, navPos.y].Ships.ShipCharacter = 'x';
            //}
        }

        public void HitShip(Map map, List<Ship> shipList, bool isPlaced)
        {
            for (int i = 0; i < shipList.Count; i++)
            {
                if (map.MapArray[pos.x, pos.y].Ships == shipList[i] && map.MapArray[pos.x, pos.y].IsPlaced == isPlaced)
                {
                    map.MapArray[pos.x, pos.y].MapField = "o";
                    map.MapArray[pos.x, pos.y].Ships = null;
                }
                Console.WriteLine(map.MapArray[pos.x, pos.y].MapField);
            }
        }

        private bool HasBeenShot(Map map)
        {
            if (map.MapArray[pos.x, pos.y].MapField != "x" && map.MapArray[pos.x, pos.y].MapField != "o" && map.MapArray[pos.x, pos.y].Ships == null) //  && map.MapArray[pos.x, pos.y].Ships == null && map.MapArray[pos.x, pos.y].IsPlaced == false
            {
                return true;
            }
            return false;
        }
    }
}
