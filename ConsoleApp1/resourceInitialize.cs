using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class resourceInitialize
    {
        private string line;
        private System.IO.StreamReader file;
        private List<string> wall = new List<string>();
        private string map;
        private string initialState;
        private string goalState;
        
        public List<string> Wall
        {
            get
            {
                return wall;
            }
        }

        public string InitialState
        {
            get
            {
                return initialState;
            }
        }

        public string GoalState
        {
            get
            {
                return goalState;
            }
        }

        public string Map
        {
            get
            {
                return map;
            }
        }

        public resourceInitialize(string testfile)
        {
            file = new System.IO.StreamReader(testfile);
        }

        //Allocate data from text file to program variable
        public void populateData()
        {
            int counter = 0;

            while((line = file.ReadLine()) != null)
            {
                if (counter == 0)
                {
                    map = line;
                }

                if (counter == 1)
                {
                    initialState = line;
                }

                if (counter == 2)
                {
                    goalState = line;
                }

                if (counter >= 3)
                {
                    wall.Add(line);
                }

                counter++;
            }
        }

        //Print map info
        public void printInfo()
        {
            Console.WriteLine("Map size: {0}", map);
            Console.WriteLine("Initial state: {0}", initialState);
            Console.WriteLine("Goal state: {0}", goalState);

            foreach (string w in wall)
            {
                Console.WriteLine("Wall: {0}", w);
            }
        }

        public void closeFile()
        {
            file.Close();
        }
    }
}
