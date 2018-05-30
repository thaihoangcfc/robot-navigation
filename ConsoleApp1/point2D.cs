using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class point2D
    {
        private int x;
        private int y;
        private double distanceToGoal;
        private double fScore;
        private double gScore;
        private point2D parentNode;

        public point2D(int px, int py)
        {
            x = px;
            y = py;
        }

        public point2D(point2D parent)
        {
            x = parent.X;
            y = parent.Y;
        }

        public int X
        {
            get
            {
                return x;
            }

            set
            {
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }

            set
            {
                y = value;
            }
        }

        public double DistanceToGoal
        {
            get
            {
                return distanceToGoal;
            }

            set
            {
                distanceToGoal = value;
            }
        }

        public string Coordinate
        {
            get
            {
                return "(" + X + "," + Y + ")";
            }
        }

        public double FScore
        {
            get
            {
                return fScore;
            }

            set
            {
                fScore = value;
            }
        }

        public double GScore
        {
            get
            {
                return gScore;
            }

            set
            {
                gScore = value;
            }
        }

        public point2D ParentNode
        {
            get
            {
                return parentNode;
            }

            set
            {
                parentNode = value;
            }
        }
    }
}
