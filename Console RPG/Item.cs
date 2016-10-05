using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class Item :NPC //Class for item interactions and items.
    {
        public string name = ""; //Name shown when you showInventory.
        public static void swordInt()
        {
            npcList.Remove(Program.Sword);
            Program.currentMap.placeObject(6, 5, " ");
            Player.Inventory.Add(Program.Sword);
        }

        public static void getHP()
        {
            Program.player.HP = Program.player.HP + 5;
            Program.dialouge = "You got 5 HP";
            NPC.npcList.Remove(Program.HPup);
            Program.currentMap.placeObject(12, 1, " ");


        }

    }
}
