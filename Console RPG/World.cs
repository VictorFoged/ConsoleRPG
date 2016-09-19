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
            
        }

    }
}
