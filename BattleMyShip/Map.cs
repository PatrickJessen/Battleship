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
        public void ClearMap()
        {
            for (int x = 0; x < MapArray.GetLength(0); x++)
            {
                for (int y = 0; y < MapArray.GetLength(1); y++)
                {
                    if (MapArray[x, y].isPlaced == false)
                    {
                        MapArray[x, y].ship = null;
                        //map.MapArray[x, y].MapField = ".";
                    }
                }
            }
        }
    }
}
