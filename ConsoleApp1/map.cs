using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class map
    {
        List<grid> grids = new List<grid>();
        private int width;
        private int length;
        private List<string> wall;
        private List<grid> wallList = new List<grid>();

        public List<grid> Grids
        {
            get
            {
                return grids;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }
        }

        public int Length
        {
            get
            {
                return length;
            }
        }

        public List<grid> WallList
        {
            get
            {
                return wallList;
            }
        }

        //Map constructor
        public map(string mapSize, List<string> mapWall)
        {
            IntFromString ifs = new IntFromString(mapSize);

            List<int> coordinate = ifs.getIntFromString();

            width = coordinate[0];
            length = coordinate[1];
            wall = mapWall;
            drawMap();
        }

        //Draw the whole map
        public void drawMap()
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    grids.Add(new grid(new point2D(j, i), false));
                }
            }          

            for (int i = 0; i < wall.Count; i++)
            {
                drawWall(wall[i]);
            }

            drawPath();
        }

        //Populate adjacent available paths for grid
        public void drawPath()
        {
            for (int i = 0; i < grids.Count; i++)
            {
                if (!grids[i].IsWall)
                {
                    for (int j = 0; j < width; j++)
                    {
                        if ((i >= j * length) && (i < (j + 1) * length - 1))
                        {
                            grids[i].Paths.Add(new Path(grids[i + 1]));
                        }
                    }

                    if (i < length * width - length)
                    {
                        if (!grids[i + length].IsWall)
                        {
                            grids[i].Paths.Add(new Path(grids[i + length]));
                        }
                    }

                    for (int j = 0; j < width; j++)
                    {
                        if ((i > j * length) && (i < (j + 1) * length))
                        {
                            grids[i].Paths.Add(new Path(grids[i - 1]));
                        }
                    }

                    if (i > length - 1)
                    {
                        if (!grids[i - length].IsWall)
                        {
                            grids[i].Paths.Add(new Path(grids[i - length]));
                        }
                    }
                }
            }

            //Remove paths that are obstacles
            foreach (grid g in grids)
            {
                for (int i = 0; i < g.Paths.Count; i++)
                {
                    if (g.Paths[i].Location.IsWall == true)
                    {
                        g.Paths.Remove(g.Paths[i]);
                    }
                }
            }
        }

        //Draw obstacles
        public void drawWall(string oneWall)
        {
            IntFromString ifs = new IntFromString(oneWall);
            List<int> coordinate = ifs.getIntFromString();

            for (int j = coordinate[1]; j < coordinate[1] + coordinate[3]; j++)
            {
                for (int i = coordinate[0]; i < coordinate[0] + coordinate[2]; i++)
                {
                    int index = grids.FindIndex(x => (x.Pos.X == i) && (x.Pos.Y == j));
                    grids[index].IsWall = true;
                }
            }

            foreach (grid g in grids)
            {
                if (g.IsWall == true)
                {
                    wallList.Add(g);
                }
            }
        }

        //Print map info
        public void printMap()
        {
            foreach (grid g in grids)
            {
                Console.WriteLine("Grid: ({0},{1}), wall: {2}", g.Pos.X, g.Pos.Y, g.IsWall);
                Console.WriteLine("Containing: ");
                foreach (Path p in g.Paths)
                {
                    Console.WriteLine(p.Location.Pos.Coordinate);
                }
                Console.WriteLine("");
            }
        }

    }
}
