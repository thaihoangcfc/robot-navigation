using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class grid
    {
        private point2D pos;
        private bool isWall;
        private List<Path> paths = new List<Path>();
        

        public point2D Pos
        {
            get
            {
                return pos;
            }
        }

        public grid(point2D ppos, bool wall)
        {
            pos = ppos;
            isWall = wall;
        }

        public bool IsWall
        {
            get
            {
                return isWall;
            }

            set
            {
                isWall = value;
            }
        }

        public List<Path> Paths
        {
            get
            {
                return paths;
            }

            set
            {
                paths = value;
            }
        }

        
    }
}