using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class Program
    {
        public static Player player = new Player();
        public static Map town = new Map();
        public static Map forest = new Map();
        //public static int[] loc = { 0, 0 };
        public static Map currentMap = town;
        

        static void Main(string[] args)
        {
            World.addMap(town);
            World.addMap(forest);
            currentMap.genMap(currentMap.map);
            currentMap.placePlayer();
            createForest();
            createTown();
            while (true)
            {

                currentMap.genMap(currentMap.map);
                currentMap.removePlayer();
                move(Console.ReadKey().KeyChar, currentMap);
                currentMap.placePlayer();
            }
            
        }

        static void move(char key, Map map)
        {
            
        
            switch (key)
            {
                case 'w':
                    if (map.map[player.playerY - 1][player.playerX] != "#")
                    {
                        player.playerY = player.playerY - 1;
                    }
                    break;
                case 'a':
                    if (map.map[player.playerY][player.playerX - 1] != "#")
                    {
                        player.playerX = player.playerX - 1;
                    }
                    break;
                case 's':
                    if (map.map[player.playerY + 1][player.playerX] != "#")
                    {
                        player.playerY = player.playerY + 1;
                    }
                    break;
                case 'd':
                    if (map.map[player.playerY][player.playerX + 1] != "#")
                    {
                        player.playerX = player.playerX + 1;
                    }
                    break;
            }

        }
        public static void createForest()
        {
            forest.l1 =new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            forest.l2 =new string[] { "#", " ", " ", " ", " ", " ", " ", "#", "#", " ", " ", " ", " ", " ", "#" };
            forest.l3 = new string[] { "#", " ", " ", " ", "#", "#", " ", "#", "#", " ", " ", " ", " ", " ", "#" };
            forest.l4 = new string[] { "#", " ", " ", " ", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            forest.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            forest.l6 = new string[] { "|", " ", " ", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
            forest.l7 = new string[] { "#", " ", " ", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            forest.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            forest.l9 = new string[] { "#", "#", "#", " ", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            forest.l10 = new string[] { "#", "#", "#", " ", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            forest.l11 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };

            forest.mapcord = new int[] { 1,0};
            forest.Foreground = ConsoleColor.Green;

            /*
            forest.map[0] = forest.l1;
            forest.map[1] = forest.l2;
            forest.map[2] = forest.l3;
            forest.map[3] = forest.l4;
            forest.map[4] = forest.l5;
            forest.map[5] = forest.l6;
            forest.map[6] = forest.l7;
            forest.map[7] = forest.l8;
            forest.map[8] = forest.l9;
            forest.map[9] = forest.l10;
            */
        }

        public static void createTown()
        {
            town.l1 = { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            town.l2 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town.l3 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town.l4 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town.l5 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town.l6 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
            town.l7 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town.l8 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l9 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l10 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l11 = { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };


        town.l9 = new string[] { "#", " ", " ", " ", " ", "#", "#", "#", " ", " ", " ", " ", " "," ", "#" };
        }
    }
    
}
