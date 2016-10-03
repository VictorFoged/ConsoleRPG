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
        public static Map forest3 = new Map();
        public static Map forest4 = new Map();
        public static Map town2 = new Map();
        public static Map road = new Map();
        public static Map road2 = new Map();
        public static Map road3 = new Map();
        public static Map road4 = new Map();
        public static Map road5 = new Map();
        public static Map roadBoss = new Map();
        public static Map kingGarden = new Map();
        public static Map kingRoom = new Map();
        public static Map maze1 = new Map();
        public static Map maze2 = new Map();
        public static Map maze3 = new Map();
        public static Map maze4 = new Map();
        public static Map maze5 = new Map();
        public static Map maze6 = new Map();
        public static Map maze7 = new Map();
        public static Map maze8 = new Map();
        public static Map maze9 = new Map();
        public static Map maze10 = new Map();
        public static Map maze11 = new Map();
        public static Map maze12 = new Map();
        public static Map maze13 = new Map();
        public static Map maze14 = new Map();
        public static Item WonTheGame = new Item();

        public static int state = 1;
        public static Map currentMap = town;
        public static string dialouge = "Welcome to The Town";

        static void Main(string[] args)
        {
            World.genWorld();
            currentMap.genMap(currentMap.map);
            currentMap.placePlayer();
            


            Map.preRandom();
            while (player.HP > 0)
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
                if (currentMap == roadBoss)
                {
                    if (state == 1)
                    {
                        dialouge = "Use your Sword (e) to cut if the Snake's tail \nStart from the end";
                        state = 0;
                    }
                    
                    SnakeTail.removeMonster();
                    SnakeTail2.removeMonster();
                    SnakeTail3.removeMonster();
                    SnakeTail4.removeMonster();
                    SnakeTail5.removeMonster();

                    SnakeTail5.followTail(SnakeTail4);
                    SnakeTail4.followTail(SnakeTail3);
                    SnakeTail3.followTail(SnakeTail2);
                    SnakeTail2.followTail(SnakeTail);
                    SnakeTail.followHead(SnakeBoss);

                    SnakeTail5.placeMonster();
                    SnakeTail4.placeMonster();
                    SnakeTail3.placeMonster();
                    SnakeTail2.placeMonster();
                    SnakeTail.placeMonster();

                    SnakeBoss.removeMonster();
                    SnakeBoss.moveMonster();
                    SnakeBoss.placeMonster();
                    Boss.checkHead();
                    Player.checkBossColli();
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
                    else if (map.map[player.playerY - 1][player.playerX] == "0")
                    {
                        player.HP = player.HP - 2;
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
                    else if (map.map[player.playerY][player.playerX - 1] == "0")
                    {
                        player.HP = player.HP - 2;
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
                    else if (map.map[player.playerY + 1][player.playerX] == "0")
                    {
                        player.HP = player.HP - 2;
                    }

                    player.lastDir = 's';
                    break;
                case 'd':
                    if (map.map[player.playerY][player.playerX + 1] == " " || map.map[player.playerY][player.playerX + 1] == "|" || map.map[player.playerY][player.playerX + 1] == "_")
                    {
                        player.playerX = player.playerX + 1;
                        
                    }
                    
                    else if (map.map[player.playerY][player.playerX + 1] == "M")
                    {
                        player.HP = player.HP - 1;
                    }
                    else if (map.map[player.playerY][player.playerX + 1] == "0")
                    {
                        player.HP = player.HP - 2;
                    }
                    player.lastDir = 'd';
                    break;
                case 'e':
                    switch (player.lastDir)
                    {
                        
                        case 'w':
                            if (NPC.getNpcByLoc(player.playerX, player.playerY - 1) != null)
                            {
                                NPC.npcSpeak(player.playerX, player.playerY - 1);
                                
                            }
                            
                            break;
                        case 'a':
                            if (NPC.getNpcByLoc(player.playerX - 1, player.playerY) != null)
                            {
                                NPC.npcSpeak(player.playerX - 1, player.playerY);
                            }
                            break;
                        case 's':
                            if (NPC.getNpcByLoc(player.playerX, player.playerY + 1) != null)
                            {
                                NPC.npcSpeak(player.playerX, player.playerY + 1);
                            }
                            break;
                        case 'd':
                            if (NPC.getNpcByLoc(player.playerX + 1, player.playerY) != null)
                            {
                                NPC.npcSpeak(player.playerX + 1, player.playerY);
                            }
                            break;
                     }
                    break;
                case 'i':
                    player.showInven();
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
            forest.l6 = new string[] { "|", " ", " ", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
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
        public static NPC gateKeeper = new NPC();
        public static NPC kingKeeper = new NPC();
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
            town.l10 = new string[]{ "#", " ", " ", " ", " ", " ", " ", "N", "#", " ", " ", " ", "#", " ", "#" };
            town.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            NPC Bob = new NPC();
            Bob.npcX = 11;
            Bob.npcY = 10-1;
            Bob.npcDiag = "You should go to \nthe forest located east \nof the town";
            NPC.npcList.Add(Bob);

            NPC Louis = new NPC();
            Louis.npcX = 10;
            Louis.npcY = 3;
            Louis.npcDiag = "Beware of Snakes";
            NPC.npcList.Add(Louis);

            
            gateKeeper.npcX = 7;
            gateKeeper.npcY = 1;
            gateKeeper.interact = NPC.gateInter;
            NPC.npcList.Add(gateKeeper);

            kingKeeper.npcX = 7;
            kingKeeper.npcY = 9;
            kingKeeper.interact = NPC.openKing;
            NPC.npcList.Add(kingKeeper);

        
        }
        
        public static void createForest2()
        {
            World.addMap(forest2);

            forest2.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            forest2.l2 = new string[] { "#", "#", " ", " ", " ", " ", " ", "#", "#", " ", " ", " ", " ", " ", "#" };
            forest2.l3 = new string[] { "#", "#", " ", " ", "#", "#", " ", "#", "#", " ", " ", "#", "#", " ", "#" };
            forest2.l4 = new string[] { "#", "#", " ", " ", "#", "#", " ", "#", "#", " ", "#", "#", "#", " ", "#" };
            forest2.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", "#", " ", "#", "#", "#", " ", "#" };
            forest2.l6 = new string[] { "|", " ", " ", "#", "#", " ", " ", " ", " ", " ", "#", "#", " ", " ", "|" };
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
        public static void createForest3()
        {
            World.addMap(forest3);
            

            forest3.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            forest3.l2 = new string[] { "#", "#", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", "#" };
            forest3.l3 = new string[] { "#", "#", " ", "#", "#", "#", " ", "#", " ", "#", " ", "#", "#", " ", "#" };
            forest3.l4 = new string[] { "#", "#", " ", "#", "#", "#", " ", "#", " ", " ", " ", "#", "#", " ", "#" };
            forest3.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", "#", " ", "#", "#", "#", " ", "#" };
            forest3.l6 = new string[] { "|", " ", "#", "#", "#", " ", " ", "#", "#", " ", "#", "#", " ", " ", "|" };
            forest3.l7 = new string[] { "#", " ", " ", "#", "#", " ", "#", "#", " ", " ", " ", "#", " ", " ", "#" };
            forest3.l8 = new string[] { "#", " ", " ", "#", "#", " ", "#", "#", " ", "#", " ", "#", " ", "#", "#" };
            forest3.l9 = new string[] { "#", "#", " ", "#", " ", " ", " ", "#", " ", "#", " ", " ", " ", "#", "#" };
            forest3.l10 = new string[]{ "#", "#", " ", " ", " ", "#", " ", " ", " ", "#", "#", "#", "#", "#", "#" };
            forest3.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };

            forest3.mapcord = new int[] { 3, 0 };
            forest3.Foreground = ConsoleColor.DarkGreen;

            //Add Monsters
            Monster dSnake = new Monster();
            dSnake.setMonster(13, 1);
            dSnake.mLoc = Program.forest3;
            Monster.mList.Add(dSnake);


            Monster dSnake2 = new Monster();
            dSnake2.setMonster(5, 8);
            dSnake2.mLoc = forest3;
            Monster.mList.Add(dSnake2);

            Monster dSnake3 = new Monster();
            dSnake3.setMonster(2, 1);
            dSnake3.mLoc = forest3;
            Monster.mList.Add(dSnake3);

            Monster dSnake4 = new Monster();
            dSnake4.setMonster(6, 4);
            dSnake4.mLoc = forest3;
            Monster.mList.Add(dSnake4);
        }

        public static Item Sword = new Item();
        
        public static void createForest4()
        {
            
            World.addMap(forest4);
            forest4.l1 = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            forest4.l2 = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            forest4.l3 = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            forest4.l4 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", " ", " " };
            forest4.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " " };
            forest4.l6 = new string[] { "|", " ", " ", " ", " ", " ", "I", "#", " ", " ", " ", " ", " ", " ", " " };
            forest4.l7 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " " };
            forest4.l8 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", " ", " " };
            forest4.l9 = new string[] { " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };
            forest4.l10 = new string[]{ " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " }; 
            forest4.l11 = new string[]{ " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " " };

            forest4.mapcord = new int[] { 4, 0 };
            forest4.Foreground = ConsoleColor.Green;

            
            Sword.npcX = 6;
            Sword.npcY = 5;
            Sword.icon = "I";
            Sword.nLoc = forest4;
            Sword.name = "Forest Sword";
            Sword.npcDiag = "You found a Sword!";
            Sword.interact = Item.swordInt;
            NPC.npcList.Add(Sword);
            
        }
        public static NPC Jeppe = new NPC();
        
        public static void createTown2()
        {
            World.addMap(town2);
            //Player.Inventory.Add(Sword);

            town2.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            town2.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", "#", " ", "#" };
            town2.l3 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", "#", " ", "#" };
            town2.l4 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", "#", " ", "#", "#", " ", "#" };
            town2.l5 = new string[] { "#", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town2.l6 = new string[] { "#", "N", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town2.l7 = new string[] { "#", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town2.l8 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town2.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town2.l10 = new string[]{ "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            town2.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            town2.mapcord = new int[] { 0, 1};

            Jeppe.npcX = 1;
            Jeppe.npcY = 5;
            Jeppe.nLoc = town2;
            Jeppe.interact = NPC.jeppeInter;
            NPC.npcList.Add(Jeppe);

            NPC Knud = new NPC();
            Knud.npcX = 11;
            Knud.npcY = 1;
            Knud.nLoc = town2;
            Knud.npcDiag = "You can't hit small snakes or \nbirds with a sword.";
        }
        
        public static void createRoad()
        {

            
            World.addMap(road);
            road.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            road.l2 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road.l3 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road.l4 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road.l5 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road.l6 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road.l7 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road.l8 = new string[] { "#", "#", "#", "#", "#", "#", " ", " ", " ", "#", "#", "#", "#", "#", "#" };
            road.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            road.l10 = new string[]{ "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            road.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            road.mapcord = new int[] { 0, 2 };

            Monster bird = new Monster();
            bird.moveRange = 2;
            bird.setMonster(5, 6);
            bird.mLoc = road;
            Monster.mList.Add(bird);

            Monster bird2 = new Monster();
            bird2.moveRange = 2;
            bird2.setMonster(5, 4);
            bird2.mLoc = road;
            Monster.mList.Add(bird2);

            Monster bird3 = new Monster();
            bird3.setMonster(5, 2);
            bird3.moveRange = 2;
            bird3.mLoc = road;
            Monster.mList.Add(bird3);

            Monster bird4 = new Monster();
            bird4.setMonster(9, 3);
            bird4.mLoc = road;
            bird4.moveRange = 2;
            Monster.mList.Add(bird4);

            Monster bird5 = new Monster();
            bird5.setMonster(9, 5);
            bird5.moveRange = 2;
            bird5.mLoc = road;
            Monster.mList.Add(bird5);

            Monster bird6 = new Monster();
            bird6.setMonster(7, 3);
            bird6.moveRange = 2;
            bird6.mLoc = road;
            Monster.mList.Add(bird6);

            Monster bird7 = new Monster();
            bird7.setMonster(7, 5);
            bird7.moveRange = 2;
            bird7.mLoc = road;
            Monster.mList.Add(bird7);
        }
        
        public static void createRoad2()
        {
            World.addMap(road2);
            road2.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            road2.l2 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road2.l3 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road2.l4 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road2.l5 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            road2.l6 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
            road2.l7 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            road2.l8 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road2.l9 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road2.l10 = new string[]{ "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road2.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            road2.mapcord = new int[] { 0, 3 };
        }
        public static Item HPup = new Item();
        public static void createRoad3()
        {
            World.addMap(road3);
            road3.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            road3.l2 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", " ", "H", " ", "#" };
            road3.l3 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", " ", " ", " ", "#" };
            road3.l4 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", " ", " ", " ", "#" };
            road3.l5 = new string[] { "#", " ", " ", "#", "#", "#", "#", "#", "#", "#", "#", " ", " ", "#", "#" };
            road3.l6 = new string[] { "|", " ", " ", " ", "#", "#", "#", "#", "#", " ", " ", " ", " ", "#", "#" };
            road3.l7 = new string[] { "#", " ", " ", " ", "#", "#", "#", "#", " ", " ", " ", " ", "#", "#", "#" };
            road3.l8 = new string[] { "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road3.l9 = new string[] { "#", "#", "#", " ", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#", "#" };
            road3.l10 = new string[]{ "#", "#", "#", "#", "#", " ", " ", " ", "#", "#", "#", "#", "#", "#", "#" };
            road3.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };

            road3.mapcord = new int[] { 1, 3 };
            HPup.npcX = 12;
            HPup.npcY = 1;
            HPup.nLoc = road3;
            HPup.interact = Item.getHP;
            NPC.npcList.Add(HPup);


        }

        public static void createRoad4()
        {
            World.addMap(road4);
            road4.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            road4.l2 = new string[] { "#", "#", "#", "#", "#", "#", "#", " ", " ", " ", "#", "#", "#", "#", "#" };
            road4.l3 = new string[] { "#", "#", "#", "#", "#", "#", "#", " ", " ", " ", " ", "#", "#", "#", "#" };
            road4.l4 = new string[] { "#", "#", "#", "#", " ", " ", "#", "#", "#", " ", " ", "#", "#", "#", "#" };
            road4.l5 = new string[] { "#", "#", " ", " ", " ", " ", "#", "#", "#", " ", " ", "#", "#", "#", "#" };
            road4.l6 = new string[] { "#", " ", " ", " ", "#", " ", " ", "#", "#", " ", " ", "#", "#", "#", "#" };
            road4.l7 = new string[] { "#", " ", " ", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#" };
            road4.l8 = new string[] { "#", " ", " ", "#", "#", "#", "#", " ", " ", " ", "#", "#", "#", "#", "#" };
            road4.l9 = new string[] { "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            road4.l10 = new string[]{ "#", "#", " ", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#", "#", "#" };
            road4.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            road4.mapcord = new int[] { 0, 4 };
        }

        public static void createRoad5()
        {
            World.addMap(road5);

            road5.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            road5.l2 = new string[] { "#", "#", "#", "#", "#", "#", " ", " ", " ", "#", "#", "#", "#", "#", "#" };
            road5.l3 = new string[] { "#", "#", "#", "#", "#", "#", " ", " ", " ", "#", "#", "#", "#", "#", "#" };
            road5.l4 = new string[] { "#", "#", "#", "#", "#", " ", " ", "#", " ", " ", "#", "#", "#", "#", "#" };
            road5.l5 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road5.l6 = new string[] { "#", "#", "#", "#", "#", " ", "#", " ", "#", " ", "#", "#", "#", "#", "#" };
            road5.l7 = new string[] { "#", "#", "#", "#", "#", " ", " ", " ", " ", " ", "#", "#", "#", "#", "#" };
            road5.l8 = new string[] { "#", "#", "#", "#", "#", "#", " ", "#", " ", "#", "#", "#", "#", "#", "#" };
            road5.l9 = new string[] { "#", "#", "#", "#", "#", "#", " ", " ", " ", "#", "#", "#", "#", "#", "#" };
            road5.l10 = new string[]{ "#", "#", "#", "#", "#", "#", " ", " ", " ", "#", "#", "#", "#", "#", "#" };
            road5.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            road5.mapcord = new int[] { 0, 5 };
            road5.Background = ConsoleColor.Gray;
            road5.Foreground = ConsoleColor.Black;

            Monster rBird = new Monster();
            rBird.setMonster(6, 2);
            rBird.mLoc = road5;
            Monster.mList.Add(rBird);

            Monster rBird2 = new Monster();
            rBird2.setMonster(6, 6);
            rBird2.mLoc = road5;
            Monster.mList.Add(rBird2);

            Monster rBird3 = new Monster();
            rBird3.setMonster(8, 4);
            rBird3.mLoc = road5;
            Monster.mList.Add(rBird3);
        }

        public static Boss SnakeBoss = new Boss();
        public static NPC SnakeTail = new NPC();
        public static NPC SnakeTail2 = new NPC();
        public static NPC SnakeTail3 = new NPC();
        public static NPC SnakeTail4 = new NPC();
        public static NPC SnakeTail5 = new NPC();
        public static Item SnakeHead = new Item();
        public static Item SnakeHeadHat = new Item();

        public static void createBossRoom()
        
        {
            World.addMap(roadBoss);
            roadBoss.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            roadBoss.l2 = new string[] { "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l3 = new string[] { "#", " ", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", "#" };
            roadBoss.l4 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l5 = new string[] { "#", "#", " ", "#", " ", " ", "#", " ", "#", " ", " ", " ", " ", " ", "#" };
            roadBoss.l6 = new string[] { "#", " ", " ", " ", " ", " ", "#", " ", "#", " ", " ", "#", " ", "#", "#" };
            roadBoss.l7 = new string[] { "#", " ", " ", " ", "#", " ", " ", "#", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l8 = new string[] { "#", " ", "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", "#" };
            roadBoss.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", "#" };
            roadBoss.l10 = new string[]{ "#", " ", " ", " ", "#", " ", " ", " ", "#", " ", " ", " ", " ", " ", "#" };
            roadBoss.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            

            roadBoss.mapcord = new int[] { 0, 6 };
            roadBoss.Background = ConsoleColor.Gray;
            roadBoss.Foreground = ConsoleColor.Black;
            
            SnakeBoss.setMonster(7, 1);
            SnakeBoss.mLoc = roadBoss;

            SnakeTail.icon = "0";
            SnakeTail.npcX = 8;
            SnakeTail.npcY = 1;
            SnakeTail.nLoc = roadBoss;
            SnakeTail.tailChain = 1;
            SnakeTail.interact = SnakeTail.slayTail;
            NPC.npcList.Add(SnakeTail);
            NPC.tailList.Add(SnakeTail);

            SnakeTail2.icon = "0";
            SnakeTail2.npcX = 9;
            SnakeTail2.npcY = 1;
            SnakeTail2.nLoc = roadBoss;
            SnakeTail2.tailChain = 2;
            SnakeTail2.interact = SnakeTail2.slayTail;
            NPC.npcList.Add(SnakeTail2);
            NPC.tailList.Add(SnakeTail2);

            SnakeTail3.icon = "0";
            SnakeTail3.npcX = 10;
            SnakeTail3.npcY = 1;
            SnakeTail3.nLoc = roadBoss;
            SnakeTail3.tailChain = 3;
            SnakeTail3.interact = SnakeTail3.slayTail;
            NPC.npcList.Add(SnakeTail3);
            NPC.tailList.Add(SnakeTail3);

            SnakeTail4.icon = "0";
            SnakeTail4.npcX = 11;
            SnakeTail4.npcY = 1;
            SnakeTail4.nLoc = roadBoss;
            SnakeTail4.tailChain = 4;
            SnakeTail4.interact = SnakeTail4.slayTail;
            NPC.npcList.Add(SnakeTail4);
            NPC.tailList.Add(SnakeTail4);

            SnakeTail5.icon = "0";
            SnakeTail5.npcX = 12;
            SnakeTail5.npcY = 1;
            SnakeTail5.nLoc = roadBoss;
            SnakeTail5.tailChain = 5;
            SnakeTail5.interact = SnakeTail5.slayTail;
            NPC.npcList.Add(SnakeTail5);
            NPC.tailList.Add(SnakeTail5);

            SnakeHead.name = "Giant White Snake Head";
            SnakeHeadHat.name = "Snake Head Hat";

        }

        public static NPC gate = new NPC();
        public static void createKingGarden()
        {
            World.addMap(kingGarden);
            kingGarden.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            kingGarden.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            kingGarden.l3 = new string[] { "#", " ", " ", "#", "#", " ", " ", " ", " ", " ", "#", "#", " ", " ", "#" };
            kingGarden.l4 = new string[] { "#", " ", " ", "#", "#", " ", " ", " ", " ", " ", "#", "#", " ", " ", "#" };
            kingGarden.l5 = new string[] { "#", " ", " ", " ", " ", " ", "#", "#", "#", " ", " ", " ", " ", " ", "#" };
            kingGarden.l6 = new string[] { "|", "N", " ", " ", " ", " ", "#", "#", "#", " ", " ", " ", " ", " ", "#" };
            kingGarden.l7 = new string[] { "#", " ", " ", " ", " ", " ", "#", "#", "#", " ", " ", " ", " ", " ", "#" };
            kingGarden.l8 = new string[] { "#", " ", " ", "#", "#", " ", " ", " ", " ", " ", "#", "#", " ", " ", "#" };
            kingGarden.l9 = new string[] { "#", " ", " ", "#", "#", " ", " ", " ", " ", " ", "#", "#", " ", " ", "#" };
            kingGarden.l10 = new string[]{ "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            kingGarden.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            kingGarden.mapcord = new int[] { 0, -1 };
            gate.npcX = 1;
            gate.npcY = 5;
            gate.nLoc = kingGarden;
            gate.npcDiag = "The Gate is Locked";
            NPC.npcList.Add(gate);
            

        }

        public static NPC king = new NPC();
        public static void createKingRoom()
        {
            
            World.addMap(kingRoom);
            kingRoom.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            kingRoom.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            kingRoom.l3 = new string[] { "#", "#", "#", "#", " ", "#", " ", " ", " ", "#", " ", "#", "#", "#", "#" };
            kingRoom.l4 = new string[] { "#", " ", " ", "#", " ", "#", " ", " ", " ", "#", " ", "#", " ", " ", "#" };
            kingRoom.l5 = new string[] { "#", "#", "#", "#", " ", "#", " ", " ", " ", "#", " ", "#", "#", "#", "#" };
            kingRoom.l6 = new string[] { "#", "#", " ", " ", " ", "#", " ", " ", " ", "#", " ", " ", " ", "#", "#" };
            kingRoom.l7 = new string[] { "#", "#", "#", "#", " ", "#", " ", " ", " ", "#", " ", "#", "#", "#", "#" };
            kingRoom.l8 = new string[] { "#", " ", " ", "#", " ", "#", " ", " ", " ", "#", " ", "#", " ", " ", "#" };
            kingRoom.l9 = new string[] { "#", "#", "#", "#", " ", "#", " ", " ", " ", "#", " ", "#", "#", "#", "#" };
            kingRoom.l10 = new string[]{ "#", " ", " ", " ", " ", " ", " ", "N", " ", " ", " ", " ", " ", " ", "#" };
            kingRoom.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };

            kingRoom.mapcord = new int[] { 0, -2 };

            king.npcX = 7;
            king.npcY = 9;
            king.nLoc = kingRoom;
            king.interact = NPC.kingInter;
           // king.npcDiag = "Hello, I am King \nMy dog ran into my maze \nand hasn't come back yet \nPlease help me find him \nI have unlocked the gate";
            NPC.npcList.Add(king);
        }

        public static void createMazes()
        {
            World.addMap(maze1);

            maze1.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            maze1.l2 = new string[] { "#", "#", "#", "#", " ", " ", " ", " ", " ", " ", "#", "#", "#", " ", "#" };
            maze1.l3 = new string[] { "#", "#", "#", "#", " ", "#", "#", "#", "#", " ", "#", " ", " ", " ", "#" };
            maze1.l4 = new string[] { "#", "#", "#", "#", " ", "#", " ", " ", " ", " ", "#", " ", "#", " ", "#" };
            maze1.l5 = new string[] { "#", " ", "#", "#", " ", "#", " ", "#", "#", " ", "#", " ", "#", " ", "#" };
            maze1.l6 = new string[] { "|", " ", "#", " ", " ", "#", " ", " ", "#", " ", " ", " ", "#", " ", "|" };
            maze1.l7 = new string[] { "#", " ", "#", " ", "#", "#", "#", " ", "#", "#", "#", "#", "#", " ", "#" };
            maze1.l8 = new string[] { "#", " ", "#", " ", "#", " ", " ", " ", " ", " ", " ", " ", "#", " ", "#" };
            maze1.l9 = new string[] { "#", " ", "#", " ", "#", " ", "#", "#", "#", "#", "#", " ", "#", " ", "#" };
            maze1.l10 = new string[] { "#", " ", " ", " ", "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", "#" };
            maze1.l11 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            maze1.mapcord = new int[] { -1, -1 };

            /// Maze 2

            World.addMap(maze2);

            maze2.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            maze2.l2 = new string[] { "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze2.l3 = new string[] { "#", " ", "#", "#", "#", " ", "#", " ", "#", "#", "#", "#", "#", " ", "#" };
            maze2.l4 = new string[] { "#", " ", "#", " ", " ", " ", "#", " ", "#", " ", " ", " ", " ", " ", "#" };
            maze2.l5 = new string[] { "#", " ", "#", " ", "#", "#", "#", " ", "#", " ", "#", "#", "#", "#", "#" };
            maze2.l6 = new string[] { "|", " ", "#", " ", "#", "#", "#", "#", "#", " ", "#", " ", " ", " ", "|" };
            maze2.l7 = new string[] { "#", " ", "#", " ", "#", "#", "#", "#", "#", " ", "#", " ", "#", " ", "#" };
            maze2.l8 = new string[] { "#", " ", "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", "#", " ", "#" };
            maze2.l9 = new string[] { "#", " ", "#", "#", "#", "#", "#", " ", "#", "#", "#", "#", "#", " ", "#" };
            maze2.l10 = new string[] { "#", " ", " ", " ", " ", " ", "#", " ", "#", " ", " ", " ", " ", " ", "#" };
            maze2.l11 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            maze2.mapcord = new int[] { -2, -1 };

            // Maze 3

            World.addMap(maze3);
            /*
            maze3.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            maze3.l2 = new string[] { "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze3.l3 = new string[] { "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze3.l4 = new string[] { "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze3.l5 = new string[] { "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze3.l6 = new string[] { "|", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze3.l7 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze3.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze3.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze3.l10 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze3.l11 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            */
            maze3.l11[7] = "_";
            maze3.l6[0] = "|";
            maze3.l6[14] = "#";
            maze3.l1[7] = "#";


            maze3.mapcord = new int[] { -2, -0 };

            //Maze 4

            World.addMap(maze4);

            maze4.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            maze4.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze4.l3 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", "#" };
            maze4.l4 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", "#" };
            maze4.l5 = new string[] { "#", " ", " ", " ", " ", " ", "#", "#", "#", " ", " ", " ", " ", " ", "#" };
            maze4.l6 = new string[] { "#", " ", " ", "#", "#", "#", "#", " ", "#", "#", "#", "#", " ", " ", "|" };
            maze4.l7 = new string[] { "#", " ", " ", " ", " ", " ", "#", "#", "#", " ", " ", " ", " ", " ", "#" };
            maze4.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", "#" };
            maze4.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", "#" };
            maze4.l10 = new string[]{ "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze4.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };

            maze4.mapcord = new int[] { -3, -1 };


            //Maze 5
            World.addMap(maze5);

            maze5.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            maze5.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze5.l3 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze5.l4 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze5.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze5.l6 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
            maze5.l7 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze5.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze5.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze5.l10 = new string[]{ "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze5.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            
            maze5.mapcord = new int[] { -3, -0 };

            //Maze 6
            World.addMap(maze6);

            maze6.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            maze6.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze6.l3 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze6.l4 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze6.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze6.l6 = new string[] { "|", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze6.l7 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze6.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze6.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze6.l10 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze6.l11 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            
            maze6.mapcord = new int[] { -2, -2 };


            //Maze 7
            World.addMap(maze7);

            maze7.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            maze7.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", "#", "#", " ", " ", " ", "#" };
            maze7.l3 = new string[] { "#", "#", " ", "#", "#", " ", "#", "#", " ", " ", " ", " ", "#", " ", "#" };
            maze7.l4 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", " ", "#", "#", " ", "#", " ", "#" };
            maze7.l5 = new string[] { "#", "#", " ", " ", " ", " ", " ", " ", " ", "#", "#", " ", "#", " ", "#" };
            maze7.l6 = new string[] { "#", " ", " ", "#", "#", "#", "#", "#", " ", "#", "#", " ", "#", " ", "|" };
            maze7.l7 = new string[] { "#", "#", " ", "#", " ", " ", " ", "#", " ", "#", "#", " ", "#", " ", "#" };
            maze7.l8 = new string[] { "#", " ", " ", "#", " ", "#", " ", "#", " ", " ", " ", " ", "#", " ", "#" };
            maze7.l9 = new string[] { "#", "#", "#", "#", " ", "#", " ", "#", "#", " ", "#", "#", "#", " ", "#" };
            maze7.l10 = new string[]{ "#", " ", " ", " ", " ", "#", " ", " ", "#", " ", " ", " ", " ", " ", "#" };
            maze7.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            
            maze7.mapcord = new int[] { -3, -2 };

            //Maze 8
            World.addMap(maze8);

            maze8.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            maze8.l2 = new string[] { "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze8.l3 = new string[] { "#", " ", "#", "#", "#", "#", "#", "#", "#", " ", "#", "#", "#", " ", "#" };
            maze8.l4 = new string[] { "#", " ", "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", "#" };
            maze8.l5 = new string[] { "#", " ", "#", " ", "#", "#", "#", "#", " ", "#", "#", " ", "#", " ", "#" };
            maze8.l6 = new string[] { "|", " ", "#", " ", " ", " ", " ", " ", " ", " ", "#", " ", "#", " ", "#" };
            maze8.l7 = new string[] { "#", " ", "#", " ", "#", "#", "#", "#", "#", "#", "#", " ", "#", " ", "#" };
            maze8.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", "#" };
            maze8.l9 = new string[] { "#", " ", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", " ", "#" };
            maze8.l10 = new string[]{ "#", "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", "#" };
            maze8.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };

            maze8.mapcord = new int[] { -2, -3 };

            //Maze 9
            World.addMap(maze9);

            maze9.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            maze9.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze9.l3 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze9.l4 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze9.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze9.l6 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
            maze9.l7 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze9.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze9.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze9.l10 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze9.l11 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            
            maze9.mapcord = new int[] { -3, -3 };

            //Maze 10
            World.addMap(maze10);

            maze10.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            maze10.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze10.l3 = new string[] { "#", " ", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", " ", "#" };
            maze10.l4 = new string[] { "#", " ", "#", " ", " ", "#", " ", "D", " ", "#", " ", " ", "#", " ", "#" };
            maze10.l5 = new string[] { "#", " ", "#", " ", " ", "#", " ", " ", " ", "#", " ", " ", "#", " ", "#" };
            maze10.l6 = new string[] { "#", " ", "#", " ", " ", "#", " ", " ", " ", "#", " ", " ", "#", " ", "|" };
            maze10.l7 = new string[] { "#", " ", "#", " ", " ", "#", " ", "#", " ", "#", " ", " ", "#", " ", "#" };
            maze10.l8 = new string[] { "#", " ", "#", " ", " ", "#", " ", "#", " ", "#", " ", " ", "#", " ", "#" };
            maze10.l9 = new string[] { "#", " ", "#", "#", "#", "#", " ", "#", " ", "#", "#", "#", "#", " ", "#" };
            maze10.l10 = new string[]{ "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", "#" };
            maze10.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            
            maze10.mapcord = new int[] { -3, -4 };

            dog.nLoc = maze10;
            dog.icon = "D";
            dog.npcX = 7;
            dog.npcY = 3;
            dog.interact = NPC.dogInter;
            dog.npcDiag = "Woof \nFollow the dog back home? (y/n)";
            NPC.npcList.Add(dog);
            WonTheGame.name = "Won The Game Trophy";

            //Maze 11
            World.addMap(maze11);

            maze11.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
            maze11.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze11.l3 = new string[] { "#", " ", " ", "#", " ", " ", " ", " ", "#", " ", "#", " ", "#", " ", "#" };
            maze11.l4 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze11.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze11.l6 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze11.l7 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", "#" };
            maze11.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", " ", "#" };
            maze11.l9 = new string[] { "#", " ", " ", "#", " ", " ", " ", " ", " ", "#", "#", " ", "#", " ", "#" };
            maze11.l10 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            maze11.l11 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };

            maze11.mapcord = new int[] { -1, -2 };


        }
        public static NPC dog = new NPC();
    }
}
