using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{

    class World
    {
        public static List<Map> MapList = new List<Map>(); 
        public static void addMap(Map map)
        {
            MapList.Add(map);
        }

    }
}
