﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class Map :World
    {
        int xlen = 0;
        int ylen = 0;
        public int[] mapcord = { 0, 0 };
        public string[][] map =  { };
        public ConsoleColor Background = ConsoleColor.Black;
        public ConsoleColor Foreground = ConsoleColor.White;

        public string[] l1 = { "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };
        public string[] l2 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l3 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l4 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l5 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l6 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "|" };
        public string[] l7 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l8 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l9 = { "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l10 ={ "#", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", " ", "#" };
        public string[] l11 ={ "#", "#", "#", "#", "#", "#", "#", "_", "#", "#", "#", "#", "#", "#", "#" };

        public void createMap()
        {

           map = new string[][]{ l1, l2, l3, l4, l5, l6, l7, l8, l9, l10, l11 };
        }
        

        public void genMap(string[][] map)
        {
            createMap();
            Console.BackgroundColor = Background;
            Console.ForegroundColor = Foreground;
            //Console.WriteLine(map[0][0]);
            //Console.ReadLine();
            xlen = this.map[0].Length;
            ylen = this.map.Length;
            Console.Clear();
            for (int y = 0; y < ylen; y++) //9
            {
                for (int x = 0; x < xlen; x++) //13
                {
                    Console.Write(this.map[y][x]);
                }
                Console.Write("\n");

            }
            
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
                        //Arrival Cords on fixed 14x10 grid
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
                        player.playerCord[1] = player.playerCord[1] + 1;
                        locPlayer();
                        //Arrival Cords on fixed 14x10 grid
                        player.playerX = 7;
                        player.playerY = 1;

                        placePlayer();
                        removePlayer();
                        clearDia();
                    }
                    else
                    {
                        player.playerCord[1] = player.playerCord[1] - 1;
                        locPlayer();
                        //Arrival Cords on fixed 14x10 grid
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
            if (player.playerCord != mapcord)
            {
                Program.currentMap = getMapByLoc(player.playerCord);
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
        
        
    }
}