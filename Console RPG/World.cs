using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{

    class World
    { //Test Comment
        public static List<Map> MapList = new List<Map>();
        //public static List<Action> WorldGen = new List<Action>();

        public static void addMap(Map map)
        {
            MapList.Add(map);
        }
        public static void genWorld()
        {
            Program.createTown();
            Program.createTown2();
            Program.createForest();
            Program.createForest2();
            Program.createForest3();
            Program.createForest4();
            Program.createRoad();
            Program.createRoad2();
            Program.createRoad3();
            Program.createRoad4();
            Program.createRoad5();
            Program.createBossRoom();
            Program.createKingGarden();
            Program.createKingRoom();
            Program.createMazes();
            
            
        }

        public static string r;
        public static Random ran = new Random();
        public static string ranMake()
        {
            
            int n = ran.Next(0, 5);

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

        public static void ranGen(Map map)
        {
            int xlen;
            int ylen;
           
            xlen = 15;
            ylen = map.map.Length;

            for (int y = 1; y < ylen-1; y++) //10
            {
                for (int x = 1; x < xlen-1; x++) //15
                {
                    r = ranMake();
                    map.map[y][x] = r; 
                }
                Console.Write("\n");

            }
        }
      
    }
}
