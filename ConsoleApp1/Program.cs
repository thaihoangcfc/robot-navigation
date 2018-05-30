using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Load and initialize map, state information from text file
            resourceInitialize rI = new resourceInitialize(@"resources\test.txt");

            //Read test file and populate data to suitable variables
            rI.populateData();

            //Initialize map
            map Map = new map(rI.Map, rI.Wall);

            //Initialize robot
            robot ai = new robot(rI.InitialState, rI.GoalState, Map);

            //Console.WriteLine(ai.BfsSearch());

            //Response equivalent method to console argument
            switch (args[0].ToLower())
            {
                case "dfs":
                    Console.WriteLine(ai.DfsSearch());
                    break;
                case "bfs":
                    Console.WriteLine(ai.BfsSearch());
                    break;
                case "gbfs":
                    Console.WriteLine(ai.GbfsSearch());
                    break;
                case "astar":
                    Console.WriteLine(ai.AStar());
                    break;
                default:
                    Console.WriteLine("No search method called " + args[1]);
                    break;
            }


            Console.ReadLine();
        }
    }
}
