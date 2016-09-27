using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class Map
    {
        int xlen = 0;
        int ylen = 0;
        public int[] mapcord = { 0, 0 };
        public string[][] map =  { };
        public ConsoleColor Background = ConsoleColor.Black;
        public ConsoleColor Foreground = ConsoleColor.White;

        public string[] l1 = { "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };
        public string[] l2 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l3 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l4 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l5 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l6 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l7 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l8 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l9 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l10 ={ "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l11 ={ "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#", "#" };

        public void createMap()
        {

           map = new string[][]{ l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11 };
        }
        

        public void genMap(string[][] map)
        {
            createMap();
            Console.Clear();
            Console.BackgroundColor = Background;
            Console.ForegroundColor = Foreground;
            //Console.WriteLine(map[0][0]);
            //Console.ReadLine();
            xlen = this.map[0].Length;
            ylen = this.map.Length;
            
            for (int y = 0; y < ylen; y++) //10
            {
                for (int x = 0; x < xlen; x++) //15
                {
                    Console.Write(this.map[y][x]);
                }
                Console.Write("\n");

            }
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Program.player.HP);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("(" + Program.player.playerCord[0] + "," + Program.player.playerCord[1] + ")");
            Console.WriteLine("\n" + Program.dialouge);
        }
        public void placePlayer()
            
        {
            createMap();
            Player player = Program.player;
            switch ( map[player.playerY][player.playerX])
            {
                case " ":
                    map[player.playerY][player.playerX] = "O";
                    break;
                case "#":

                    break;
                case "|":
                    if(player.playerX > 3)
                    {
                        player.playerCord[0] = player.playerCord[0] + 1;
                        locPlayer();
                        //Arrival Cords on fixed 15x11 grid
                        player.playerX = 1;
                        player.playerY = 5;
                        placePlayer();
                        removePlayer();
                        clearDia();
                       

                    }
                    else
                    {
                        player.playerCord[0] = player.playerCord[0] - 1;
                        locPlayer();
                        //Arrival Cords
                        player.playerX = 13;
                        player.playerY = 5;
                        placePlayer();
                        removePlayer();
                        clearDia();
                        
                    }
                    break;
                case "_":
                    if(player.playerY > 3)
                    {
                        player.playerCord[1] = player.playerCord[1] - 1;
                        locPlayer();
                        //Arrival Cords on fixed 15x11 grid
                        player.playerX = 7;
                        player.playerY = 1;

                        placePlayer();
                        removePlayer();
                        clearDia();
                        
                    }
                    else
                    {
                        player.playerCord[1] = player.playerCord[1] + 1;
                        locPlayer();
                        //Arrival Cords on fixed 15x11 grid
                        player.playerX = 7;
                        player.playerY = 9;

                        placePlayer();
                        removePlayer();
                        clearDia();
                       
                    }
                    break;
            }
            
        }
        public void removePlayer()
        {
            Player player = Program.player;
            map[player.playerY][player.playerX] = " ";
        }
        public void placeObject(int x, int y, string ob)
        {
            map[y][x] = ob;
        }
        public void locPlayer()
        {
            Player player = Program.player;
            if (player.playerCord != Program.currentMap.mapcord)
            {
                Program.currentMap = getMapByLoc(player.playerCord);


                if (Program.currentMap == Program.maze3)
                {
                    Program.maze3.ranGen();
                }
                if (Program.currentMap == Program.maze5)
                {
                    Program.maze5.ranGen();
                }
                if (Program.currentMap == Program.maze6)
                {
                    Program.maze6.ranGen();
                }
                if (Program.currentMap == Program.maze9)
                {
                    Program.maze9.ranGen();
                }
                if (Program.currentMap == Program.maze11)
                {
                    Program.maze11.ranGen();
                }
            }
            
        }
        public Map getMapByLoc(int[] cord)
        {
            foreach (Map i in World.MapList)
            {
    
                if(i.mapcord[0] == cord[0] & i.mapcord[1] == cord[1])
                {   
                    return i;
                }
            }
            return null; //Wont be needed unless I fuck up
            
        }
        public void clearDia()
        {
            Program.dialouge = "";
        }
        public static void preRandom()
        {
            Program.maze3.ranGen();
            Program.maze5.ranGen();
            Program.maze6.ranGen();
            Program.maze9.ranGen();
            Program.maze11.ranGen();
            
        }


        public static string r;
        public static Random ran = new Random();
        public static string ranMake()
        {

            int n = ran.Next(0, 3);

            switch (n)
            {
                case 0:
                    r = " ";
                    break;
                case 1:
                    r = " ";
                    break;
                case 2:
                    r = "#";
                    break;

            }

            return r;
        }

        public void ranGen()
        {
            createMap();
            int xlen;
            int ylen;

            xlen = 15;
            ylen = 10;

            for (int y = 1; y < ylen - 1; y++) //10
            {
                for (int x = 1; x < xlen - 1; x++) //15
                {
                    r = ranMake();
                    map[y][x] = r;
                }


            }
        }



    }
}