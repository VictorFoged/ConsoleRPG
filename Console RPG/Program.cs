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
        public static Map forest2 = new Map();
        public static Map currentMap = town;
        public static string dialouge = "Welcome to The Town";

        static void Main(string[] args)
        {
            
            currentMap.genMap(currentMap.map);
            currentMap.placePlayer();
            createForest();
            createTown();
            createForest2();
            while (player.HP >= 0)
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
                foreach (NPC npc in NPC.npcList)
                {
                    if(npc.nLoc == currentMap)
                    {
                        npc.placeNPC();
                    }
                }
                Player.checkColli();
               
            }
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine("\n            \n            \n            \n You Died   \n            \n            \n            \n");
            Console.ReadLine();
            
        }

        static void move(char key, Map map)
        {
            
        
            switch (key)
            {
                case 'w':
                    if (map.map[player.playerY - 1][player.playerX] == " " || map.map[player.playerY - 1][player.playerX] == "|" || map.map[player.playerY - 1][player.playerX] == "_" )
                    {
                        player.playerY = player.playerY - 1;
                        
                    }
                    
                    else if (map.map[player.playerY - 1][player.playerX] == "M")
                    {
                        player.HP = player.HP - 1;
                    }
                    

                    player.lastDir = 'w';
                    break;
                case 'a':
                    if (map.map[player.playerY][player.playerX - 1] == " " || map.map[player.playerY][player.playerX - 1] == "|" || map.map[player.playerY][player.playerX - 1] == "_")
                    {
                        player.playerX = player.playerX - 1;
                        
                    }
                    
                    else if (map.map[player.playerY][player.playerX - 1] == "M")
                    {
                        player.HP = player.HP - 1;
                    }
                    
                    player.lastDir = 'a';
                    break;
                case 's':
                    if (map.map[player.playerY + 1][player.playerX] == " " || map.map[player.playerY + 1][player.playerX] == "|" || map.map[player.playerY + 1][player.playerX] == "_")
                    {
                        player.playerY = player.playerY + 1;
                        
                    }
                    
                    else if (map.map[player.playerY + 1][player.playerX] == "M")
                    {
                        player.HP = player.HP - 1;
                    }
                    
                    player.lastDir = 's';
                    break;
                case 'd':
                    if (map.map[player.playerY][player.playerX + 1] == " " || map.map[player.playerY][player.playerX + 1] == "|" || map.map[player.playerY][player.playerX + 1] == "_")
                    {
                        player.playerX = player.playerX + 1;
                        
                    }
                    
                    else if (map.map[player.playerY][player.playerX + 1] == " ")
                    {
                        player.HP = player.HP - 1;
                    }
                    
                    player.lastDir = 'd';
                    break;
                case 'e':
                    switch (player.lastDir)
                    {
                        
                        case 'w':
                            if (NPC.getNpcByLoc(player.playerX, player.playerY + 1) != null)
                            {
                                NPC.npcSpeak(player.playerX, player.playerY + 1);
                            }
                            break;
                        case 'a':
                            if (NPC.getNpcByLoc(player.playerX - 1, player.playerY) != null)
                            {
                                NPC.npcSpeak(player.playerX - 1, player.playerY);
                            }
                            break;
                        case 's':
                            if (NPC.getNpcByLoc(player.playerX, player.playerY - 1) != null)
                            {
                                NPC.npcSpeak(player.playerX, player.playerY - 1);
                            }
                            break;
                        case 'd':
                            if(NPC.getNpcByLoc(player.playerX + 1,player.playerY) != null)
                            NPC.npcSpeak(player.playerX + 1 , player.playerY);
                            break;
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


            //Add Monsters
            //LastDir, 0 = Right, 1 = Left, 2 = Up, 3 = Down
            Monster snake = new Monster();
            snake.setMonster(12, 5);
            Monster.mList.Add(snake);

            Monster snake2 = new Monster();
            snake2.setMonster(8, 7);
            snake2.lastDir = 2;
            Monster.mList.Add(snake2);

            Monster snake3 = new Monster();
            snake3.setMonster(6, 1);
            Monster.mList.Add(snake3);

            Monster snake4 = new Monster();
            snake4.setMonster(12, 1);
            Monster.mList.Add(snake4);
        }

        public static void createTown()
        {
            World.addMap(town);
            town.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            town.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town.l3 = new string[] { "#", " ", "#", "#", "#", "#", " ", " ", " ", "#", "#", "#", "#", " ", "#" };
            town.l4 = new string[] { "#", " ", "#", " ", " ", "#", " ", " ", " ", "#", " ", " ", "#", " ", "#" };
            town.l5 = new string[] { "#", " ", "#", " ", "#", "#", " ", " ", " ", "#", "#", " ", "#", " ", "#" };
            town.l6 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
            town.l7 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", "#", " ", "#", "#", "#", " ", "#" };
            town.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", "#", " ", "#" };
            town.l10 = new string[]{ "#", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", "#", " ", "#" };
            town.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            NPC Bob = new NPC();
            Bob.npcX = 11;
            Bob.npcY = 10-1;
            Bob.npcDiag = " You should go to \n the forest located east \n of the town";
            NPC.npcList.Add(Bob);

            NPC Louis = new NPC();
            Louis.npcX = 10;
            Louis.npcY = 3;
            Louis.npcDiag = "Beware of Snakes";
            NPC.npcList.Add(Louis);

        
        }
        public static void createForest2()
        {
            World.addMap(forest2);
            

            forest2.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            forest2.l2 = new string[] { "#", "#", " ", " ", " ", " ", " ", "#", "#", " ", " ", " ", " ", " ", "#" };
            forest2.l3 = new string[] { "#", "#", " ", " ", "#", "#", " ", "#", "#", " ", " ", "#", "#", " ", "#" };
            forest2.l4 = new string[] { "#", "#", " ", " ", "#", "#", " ", "#", "#", " ", "#", "#", "#", " ", "#" };
            forest2.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", "#", " ", "#", "#", "#", " ", "#" };
            forest2.l6 = new string[] { "|", " ", " ", "#", "#", " ", " ", "#", " ", " ", "#", "#", " ", " ", "|" };
            forest2.l7 = new string[] { "#", " ", " ", "#", "#", " ", "#", "#", " ", "#", "#", " ", " ", " ", "#" };
            forest2.l8 = new string[] { "#", " ", " ", "#", "#", " ", "#", "#", " ", "#", "#", " ", " ", "#", "#" };
            forest2.l9 = new string[] { "#", "#", "#", "#", " ", " ", " ", "#", " ", " ", " ", " ", "#", "#", "#" };
            forest2.l10 = new string[]{ "#", "#", "#", " ", " ", "#", " ", " ", " ", "#", "#", "#", "#", "#", "#" };
            forest2.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };

            forest2.mapcord = new int[] {2,0};
            forest2.Foreground = ConsoleColor.Green;

            //Add Monsters
            Monster fSnake = new Monster();
            fSnake.setMonster(11, 8);
            fSnake.mLoc = Program.forest2;
            Monster.mList.Add(fSnake);


            Monster fSnake2 = new Monster();
            fSnake2.setMonster(6, 1);
            fSnake2.mLoc = forest2;
            Monster.mList.Add(fSnake2);

            Monster fSnake3 = new Monster();
            fSnake3.setMonster(3, 9);
            fSnake3.mLoc = forest2;
            Monster.mList.Add(fSnake3);
        }
    }
    
}
