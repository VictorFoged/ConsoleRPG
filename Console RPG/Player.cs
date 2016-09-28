using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class Player 
    {
        public int HP = 10;
        public int playerX = 2;
        public int playerY = 5;
        public char lastDir = 'd';
        public int[] playerCord = { 0, 0 };
        public static List<Item> Inventory = new List<Item>();

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
        public static void checkBossColli()
        {
            if(Program.player.playerX == Program.SnakeBoss.monsterX & Program.player.playerY == Program.SnakeBoss.monsterY)
            {
                Program.player.HP = Program.player.HP - 5;
            }
        }

        public void showInven()
        {
            string inven = "";
            foreach (Item i in Inventory)
            {
                inven = inven + i.name + "\n";
            }
            Program.dialouge = inven;
        }

        public bool checkInven(Item item)
        {
            foreach (Item n in Inventory)
            {
                if (n == item)
                {
                    return true;
                }
            }
            return false;
        }
    }


}
