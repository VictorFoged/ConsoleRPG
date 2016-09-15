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
        public static Map currentMap = town;
        public static string dialouge = "Welcome to The Town";

        static void Main(string[] args)
        {
            
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
                currentMap.genMap(currentMap.map);
                foreach (Monster m in Monster.mList)
                {
                    if (m.mLoc == currentMap)
                    {
                        m.removeMonster();
                        m.moveMonster();
                        m.placeMonster();
                    }
                }

               
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
                        player.lastDir = 'w';
                    }
                    break;
                case 'a':
                    if (map.map[player.playerY][player.playerX - 1] != "#")
                    {
                        player.playerX = player.playerX - 1;
                        player.lastDir = 'a';
                    }
                    break;
                case 's':
                    if (map.map[player.playerY + 1][player.playerX] != "#")
                    {
                        player.playerY = player.playerY + 1;
                        player.lastDir = 's';
                    }
                    break;
                case 'd':
                    if (map.map[player.playerY][player.playerX + 1] != "#")
                    {
                        player.playerX = player.playerX + 1;
                        player.lastDir = 'd';
                    }
                    break;
            }

        }

        /// #################################################################### Map Creation Below ###################################################################
        /// ###########################################################################################################################################################

        public static void createForest()
        {
            World.addMap(forest);
            forest.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            forest.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", "#", " ", " ", " ", " ", " ", "#" };
            forest.l3 = new string[] { "#", " ", " ", " ", "#", "#", " ", "#", "#", " ", " ", " ", " ", " ", "#" };
            forest.l4 = new string[] { "#", " ", " ", " ", "#", "#", " ", " ", " ", " ", "#", "#", " ", " ", "#" };
            forest.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", "#", " ", "#", "#", " ", " ", "#" };
            forest.l6 = new string[] { "|", "O", " ", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
            forest.l7 = new string[] { "#", " ", " ", "#", "#", " ", "#", "#", " ", "#", "#", " ", " ", " ", "#" };
            forest.l8 = new string[] { "#", " ", " ", " ", " ", " ", "#", "#", " ", "#", "#", " ", " ", " ", "#" };
            forest.l9 = new string[] { "#", "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", " ", "#", "#", "#" };
            forest.l10 = new string[]{ "#", "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", " ", "#", "#", "#" };
            forest.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };

            forest.mapcord = new int[] { 1,0};
            forest.Foreground = ConsoleColor.Green;
            Monster snake = new Monster();
            snake.setMonster(12, 5);
            Monster.mList.Add(snake);


        }

        public static void createTown()
        {
            World.addMap(town);
            town.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            town.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town.l3 = new string[] { "#", " ", "#", "#", "#", "#", " ", " ", " ", "#", "#", "#", "#", " ", "#" };
            town.l4 = new string[] { "#", " ", "#", " ", "N", "#", " ", " ", " ", "#", "N", " ", "#", " ", "#" };
            town.l5 = new string[] { "#", " ", "#", " ", "#", "#", " ", " ", " ", "#", "#", " ", "#", " ", "#" };
            town.l6 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
            town.l7 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", "#", " ", "#", "#", "#", " ", "#" };
            town.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", "#", " ", "#" };
            town.l10 = new string[]{ "#", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", "#", " ", "#" };
            town.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };


        
        }
    }
    
}
