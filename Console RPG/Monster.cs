using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class Monster :Map
    {
        public static List<Monster> mList = new List<Monster>();

        public int monsterX = 0;
        public int monsterY = 0;
        public int lastDir = 1;
        public Map mLoc = Program.forest;
        public void moveMonster()
        {
            Random ran = new Random();

            switch (lastDir)
            {
                case 0:
                    if (mLoc.map[monsterY][monsterX+1] != "#"  &  mLoc.map[monsterY][monsterX + 1] != "|" & mLoc.map[monsterY][monsterX + 1] != "_")
                    {
                        monsterX = monsterX + 1;
                    }
                    /*
                    if (mLoc.map[monsterY][monsterX + 1] == "O")
                    {
                        Program.player.HP = Program.player.HP - 1;
                    }
                    */
                    else
                    {
                        lastDir = ran.Next(0, 4);
                    }
                    break;
                case 1:
                    if (mLoc.map[monsterY][monsterX - 1] != "#" & mLoc.map[monsterY][monsterX - 1] != "|" & mLoc.map[monsterY][monsterX - 1] != "_")
                    {
                        monsterX = monsterX - 1;
                    }
                    /*
                    if (mLoc.map[monsterY][monsterX - 1] == "O")
                    {
                        Program.player.HP = Program.player.HP - 1;
                    }
                    */
                    else
                    {
                        lastDir = ran.Next(0, 4);
                    }
                    break;
                case 2:
                    if (mLoc.map[monsterY+1][monsterX] != "#" & mLoc.map[monsterY+1][monsterX] != "|" & mLoc.map[monsterY+1][monsterX] != "_")
                    {
                        monsterY = monsterY + 1;
                    }
                    /*
                    if (mLoc.map[monsterY + 1][monsterX] == "O")
                    {
                        Program.player.HP = Program.player.HP - 1;
                    }
                    */
                    else
                    {
                        lastDir = ran.Next(0, 4);
                    }
                    break;
                case 3:
                    if (mLoc.map[monsterY-1][monsterX] != "#" & mLoc.map[monsterY - 1][monsterX] != "|" & mLoc.map[monsterY - 1][monsterX] != "_")
                    {
                        monsterY = monsterY - 1;
                    }
                    /*
                    if (mLoc.map[monsterY - 1][monsterX] == "O")
                    {
                        Program.player.HP = Program.player.HP - 1;
                    }
                    */
                    else
                    {
                        lastDir = ran.Next(0, 4);
                    }
                    break;
            }
        }

        public void placeMonster()
        {
            mLoc.map[monsterY][monsterX] = "M";
        }
        public void removeMonster()
        {
           
            mLoc.map[monsterY][monsterX] = " ";
        }

        public void setMonster(int x, int y)
        {
            monsterX = x;
            monsterY = y;
        }
        
    }
}
