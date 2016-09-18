using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class Item :NPC
    {
        public string name = "";
        public static void swordInt()
        {
            npcList.Remove(Program.Sword);
            Program.currentMap.placeObject(6, 5, " ");
            Player.Inventory.Add(Program.Sword);
        }
        
    }
}
