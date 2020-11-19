using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleMyShip
{
    class Map
    {
        public Field[,] MapArray { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public Map()
        {

        }
        public Map(int width, int height)
        {
            Width = width;
            Height = height;
            MapArray = new Field[width, height];

            for (int x = 0; x < height; x++)
            {
                for(int y = 0; y < width; y++)
                {
                    MapArray[y, x] = new Field();
                }
            }
        }

        public string DrawMap()
        {
            string combString = string.Empty;
            for(int x = 0; x < MapArray.GetLength(0); x++)
            {
                for(int y = 0; y < MapArray.GetLength(1); y++)
                {
                    if (MapArray[x, y].ship != null)
                    {
                        combString += MapArray[x, y].ship.ShipCharacter;
                    }
                    else
                    {
                        combString += MapArray[x, y].MapField;
                    }
                }
                combString += "\n";
            }
            return combString;
        }
    }
}
