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
        public Map nLoc = Program.town;

        public static List<NPC> npcList = new List<NPC>();

        public static NPC getNpcByLoc(int x, int y)
        {
            foreach (NPC npc in npcList)
            {
                if (npc.npcX == x & npc.npcY == y)
                {
                    if (npc.npcCord[0] == Program.player.playerCord[0] & npc.npcCord[1] == Program.player.playerCord[1])
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
        }

        public void placeNPC()
        {
            nLoc.map[npcY][npcX] = "N";
            
        }
    }
}
