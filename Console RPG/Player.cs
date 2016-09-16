using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class Player //Test
    {
        public int HP = 10;
        public int playerX = 2;
        public int playerY = 5;
        public char lastDir = 'd';
        public int[] playerCord = { 0, 0 };

        public static void checkColli()
        {
            foreach (Monster m in Monster.mList)
            {
                if(m.mLoc == Program.currentMap)
                {
                    if(Program.player.playerX == m.monsterX & Program.player.playerY == m.monsterY)
                    {
                        Program.player.HP = Program.player.HP - 1;
                    }
                }
            }
        }
    }


}
