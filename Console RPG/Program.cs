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

        public static Map currentMap = roadBoss;
        public static string dialouge = "Welcome to The Town";

        static void Main(string[] args)
        {
            
            currentMap.genMap(currentMap.map);
            currentMap.placePlayer();
            /*
            createForest();
            createTown();
            createForest2();
            createForest3();
            createForest4();
            */
            World.genWorld();
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
                    /*
                    foreach (Boss tail in Boss.tailList)
                    {
                        tail.removeMonster();
                        if (tail.tailChain != 1)
                        {

                            tail.followTail(Boss.getTailbyNr(tail.tailChain -1 ));
                        }
                        else
                        {
                            tail.followTail(SnakeBoss);
                        }
                        
                        tail.placeMonster();
                    }
                    */
                    
                    SnakeTail.removeMonster();
                    SnakeTail2.removeMonster();
                    SnakeTail3.removeMonster();

                    SnakeTail3.followTail(SnakeTail2);
                    SnakeTail2.followTail(SnakeTail);
                    SnakeTail.followTail(SnakeBoss);

                    SnakeTail3.placeMonster();
                    SnakeTail2.placeMonster();
                    SnakeTail.placeMonster();
                    

                    SnakeBoss.moveMonster();
                    SnakeBoss.placeMonster();

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

            gateKeeper.npcDiag = "Hello";
            NPC.npcList.Add(gateKeeper);

        
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
            Player.Inventory.Add(Sword);

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
        public static Boss SnakeTail = new Boss();
        public static Boss SnakeTail2 = new Boss();
        public static Boss SnakeTail3 = new Boss();
        public static void createBossRoom()
        {
            World.addMap(roadBoss);
            roadBoss.l1 = new string[] { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
            roadBoss.l2 = new string[] { "#", " ", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l3 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l4 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l5 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#", "#" };
            roadBoss.l6 = new string[] { "#", "#", " ", " ", " ", " ", "#", "#", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l7 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l8 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l9 = new string[] { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l10 = new string[]{ "#", " ", " ", " ", " ", " ", "#", " ", " ", " ", " ", " ", " ", " ", "#" };
            roadBoss.l11 = new string[]{ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

            road2.mapcord = new int[] { 0, 6 };

            
            SnakeBoss.setMonster(7, 4);
            SnakeBoss.mLoc = roadBoss;

            SnakeTail.icon = "0";
            SnakeTail.setMonster(8, 4);
            SnakeTail.mLoc = roadBoss;
            SnakeTail.tailChain = 1;
            Boss.tailList[0] = SnakeTail;

            SnakeTail2.icon = "0";
            SnakeTail2.setMonster(9, 4);
            SnakeTail2.mLoc = roadBoss;
            SnakeTail2.tailChain = 2;
            Boss.tailList[1] = SnakeTail2;

            SnakeTail3.icon = "0";
            SnakeTail3.setMonster(10, 4);
            SnakeTail3.mLoc = roadBoss;
            SnakeTail3.tailChain = 3;
            Boss.tailList[2] = SnakeTail3;



        }
    }
    
}
