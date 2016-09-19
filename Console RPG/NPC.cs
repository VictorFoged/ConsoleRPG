using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class NPC
    {
        public int npcX = 0;
        public int npcY = 0;
        public string npcDiag = " ";
        public int[] npcCord = { 0, 0 };
        public string icon = "N";
        public Map nLoc = Program.town;
        public Action interact = null;

        public static List<NPC> npcList = new List<NPC>();

        public static NPC getNpcByLoc(int x, int y)
        {
            foreach (NPC npc in npcList)
            {
                if (npc.npcX == x & npc.npcY == y)
                {
                    //if (npc.npcCord[0] == Program.player.playerCord[0] & npc.npcCord[1] == Program.player.playerCord[1])
                    if(npc.nLoc == Program.currentMap)
                    {
                        return npc;
                    }
                }
            }
            return null; //
        }
        public static void npcSpeak(int x, int y)
        {
            NPC talker = getNpcByLoc(x, y);
            Program.dialouge = talker.npcDiag;
            if (talker.interact != null)
            {
                talker.interact();
            }
        }

        public void placeNPC()
        {
            nLoc.map[npcY][npcX] = icon;
            
        }
        
        public static void gateInter()
        {

            /*
            foreach (Item item in Player.Inventory)
            {
                if (item == Program.Sword)
                {
                    Program.dialouge = "You may now pass";
                    NPC.npcList.Remove(Program.gateKeeper);
                    Program.currentMap.placeObject(7, 1, " ");
                    return;
                }
            }*/
            bool check = Program.player.checkInven(Program.Sword);
            if (check == true)
            {
                Program.dialouge = "You may now pass";
                NPC.npcList.Remove(Program.gateKeeper);
                Program.currentMap.placeObject(7, 1, " ");
                
            }
            else
            {
                Program.dialouge = "You need to find the \nForest Sword before \npassing here";
            }   
        }
        public static void jeppeInter()
        {
            Program.dialouge = "Help us slay the \nGiant Winter Snake to \nto the north.";
        }

    }
}
