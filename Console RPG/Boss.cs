using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Console_RPG
{
    class Boss :Monster
    {
        public static Boss[] tailList = new Boss[3];
        public string icon = "M";
        public int tailChain = 0;

        public new void moveMonster() //Make Recursive Random Movement Function that doesn't risk infinity loops. Boss needs recursive because of tail.
        {
            Random ran = new Random();

            switch (lastDir)
            {
                case 0:
                    if (mLoc.map[monsterY][monsterX + 1] != "#" & mLoc.map[monsterY][monsterX + 1] != "0" & mLoc.map[monsterY][monsterX + 1] != "_")
                    {
                        monsterX = monsterX + 1;
                    }
                    
                    else
                    {
                        if (ran.Next(0, 2) == 0) //Numbers overflow around 3, so 3 + 1 = 0 and 0 - 1 = 3.
                        {                        // - and + depends on a random 0 or 1.
                            if (lastDir > 0)
                            {
                                lastDir = lastDir - 1;
                                moveMonster();
                            }
                            else
                            {
                                lastDir = 3;
                                moveMonster();
                            }
                        }
                        else
                        {
                            if (lastDir < 3)
                            {
                                lastDir = lastDir + 1;
                                moveMonster();
                            }
                            else
                            {
                                lastDir = 0;
                                moveMonster();
                            }
                        }


                    }
                    break;
                case 1:
                    if (mLoc.map[monsterY][monsterX - 1] != "#" & mLoc.map[monsterY][monsterX - 1] != "0" & mLoc.map[monsterY][monsterX - 1] != "_")
                    {
                        monsterX = monsterX - 1;
                    }
                   
                    else
                    {
                        if (ran.Next(0, 2) == 0)
                        {
                            if (lastDir > 0)
                            {
                                lastDir = lastDir - 1;
                                moveMonster();
                            }
                            else
                            {
                                lastDir = 3;
                                moveMonster();
                            }
                        }
                        else
                        {
                            if (lastDir < 3)
                            {
                                lastDir = lastDir + 1;
                                moveMonster();
                            }
                            else
                            {
                                lastDir = 0;
                                moveMonster();
                            }
                        }
                    }
                    break;
                case 2:
                    if (mLoc.map[monsterY + 1][monsterX] != "#" & mLoc.map[monsterY + 1][monsterX] != "0" & mLoc.map[monsterY + 1][monsterX] != "_")
                    {
                        monsterY = monsterY + 1;
                    }
                   
                    else
                    {
                        if (ran.Next(0, 2) == 0)
                        {
                            if (lastDir > 0)
                            {
                                lastDir = lastDir - 1;
                                moveMonster();
                            }
                            else
                            {
                                lastDir = 3;
                                moveMonster();
                            }
                        }
                        else
                        {
                            if (lastDir < 3)
                            {
                                lastDir = lastDir + 1;
                                moveMonster();
                            }
                            else
                            {
                                lastDir = 0;
                                moveMonster();
                            }
                        }
                    }
                    break;
                case 3:
                    if (mLoc.map[monsterY - 1][monsterX] != "#" & mLoc.map[monsterY - 1][monsterX] != "0" & mLoc.map[monsterY - 1][monsterX] != "_")
                    {
                        monsterY = monsterY - 1;
                    }
                   
                    else
                    {
                        if (ran.Next(0,2) == 0)
                        {
                            if (lastDir > 0)
                            {
                                lastDir = lastDir - 1;
                                moveMonster();
                            }
                            else
                            {
                                lastDir = 3;
                                moveMonster();
                            }
                        }
                        else
                        {
                            if (lastDir < 3)
                            {
                                lastDir = lastDir + 1;
                                moveMonster();
                            }
                            else
                            {
                                lastDir = 0;
                                moveMonster();
                            }
                        }
                    }
                    break;
            }
        }
        public new void placeMonster()
        {
            mLoc.map[monsterY][monsterX] = icon;

            /*
            switch (lastDir)
            {
                case 0:
                    mLoc.map[monsterY][monsterX-1] = "0";
                    
                    break;
                case 1:
                    mLoc.map[monsterY][monsterX+1] = "0";
                    
                    break;
                case 2:
                    mLoc.map[monsterY-1][monsterX] = "0";
                    
                    break;
                case 3:
                    mLoc.map[monsterY+1][monsterX] = "0";
                    
                    break;
            }
            */
        }
        public new void removeMonster()
        {

            mLoc.map[monsterY][monsterX] = " ";

            /*
            switch (lastDir)
            {
                case 0:
                    mLoc.map[monsterY][monsterX - 1] = " ";

                    break;
                case 1:
                    mLoc.map[monsterY][monsterX + 1] = " ";
                    break;
                case 2:
                    mLoc.map[monsterY - 1][monsterX] = " ";
                    break;
                case 3:
                    mLoc.map[monsterY + 1][monsterX] = " ";
                    break;
            }
            */
        }

        public void followTail(Boss lead)
        {
            if (Math.Abs(lead.monsterX - monsterX) > Math.Abs(lead.monsterY - monsterY))
            {
                if (lead.monsterX > monsterX)
                {
                    monsterX = monsterX + 1;
                }
                else
                {
                    monsterX = monsterX - 1;
                }
            }
            else
            {
                if (lead.monsterY > monsterY)
                {
                    monsterY = monsterY + 1;
                }
                else
                {
                    monsterY = monsterY - 1;
                }
            }
        }
        public void slayTail()
        {

        }

        public static Boss getTailbyNr(int nr)
        {     
            foreach (Boss tail in tailList)
            {
                if (tail.tailChain == nr)
                {
                    return tail;
                }
            }
            return null;
            
        }

    }
}
