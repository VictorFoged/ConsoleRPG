using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class Monster :NPC
    {
        public static List<Monster> mList = new List<Monster>();

        public int monsterX = 0;
        public int monsterY = 0;
        public int lastDir = 1;
        public int moveRange = 4;
        public Map mLoc = Program.forest;

        public void moveMonster() //Fully random movement, changes direction when wall is hit.
        {
            Random ran = new Random(); 

            switch (lastDir) //Lastdir is the direction the mob is moveing, numbers between 0 and move range.
            {                //Changes Monster coordinates based on lastDir. If lastDir hits a wall, generate new random lastDir
                case 0:      //Mobs can get unlucky and get stuck on wall for a long time, untill they roll a proper direction.
                    if (mLoc.map[monsterY][monsterX+1] != "#"  &  mLoc.map[monsterY][monsterX + 1] != "|" & mLoc.map[monsterY][monsterX + 1] != "_")
                    {
                        monsterX = monsterX + 1;
                    }
                
                    else
                    {
                        lastDir = ran.Next(0, moveRange);
                    }
                    break;
                case 1:
                    if (mLoc.map[monsterY][monsterX - 1] != "#" & mLoc.map[monsterY][monsterX - 1] != "|" & mLoc.map[monsterY][monsterX - 1] != "_")
                    {
                        monsterX = monsterX - 1;
                    }
                    
                    else
                    {
                        lastDir = ran.Next(0, moveRange);
                    }
                    break;
                case 2:
                    if (mLoc.map[monsterY+1][monsterX] != "#" & mLoc.map[monsterY+1][monsterX] != "|" & mLoc.map[monsterY+1][monsterX] != "_")
                    {
                        monsterY = monsterY + 1;
                    }
                    
                    else
                    {
                        lastDir = ran.Next(0, moveRange);
                    }
                    break;
                case 3:
                    if (mLoc.map[monsterY-1][monsterX] != "#" & mLoc.map[monsterY - 1][monsterX] != "|" & mLoc.map[monsterY - 1][monsterX] != "_")
                    {
                        monsterY = monsterY - 1;
                    }
                    
                    
                    else
                    {
                        lastDir = ran.Next(0, moveRange);
                    }
                    break;
            }
        }

        public new void placeMonster()
        {
            mLoc.map[monsterY][monsterX] = "M";
        }
        public new void removeMonster()
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
