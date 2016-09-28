using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Reflection;
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
        public int state = 1;
        public int tailChain = 0;

        public static List<NPC> tailList = new List<NPC>();

        public static List<NPC> npcList = new List<NPC>();

        public static NPC getNpcByLoc(int x, int y)
        {
            foreach (NPC npc in npcList)
            {
                if (npc.npcX == x & npc.npcY == y)
                {
                    if(npc.nLoc == Program.currentMap)
                    {
                        return npc;
                    }
                }
            }
            return null; //
        }
        public static NPC talker = null;
        public static void npcSpeak(int x, int y)
        {
            talker = getNpcByLoc(x, y);
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
            foreach (Item item in Player.Inventory)
            {
                if (item == Program.SnakeHead)
                {
                    Program.dialouge = "Thank You for slaying \nThe Giant Winter Snake \n \nYou got a Snake Head Hat";
                    Player.Inventory.Remove(Program.SnakeHead);
                    Player.Inventory.Add(Program.SnakeHeadHat);
                    return;
                }
                else if (item == Program.SnakeHeadHat)
                {
                    Program.dialouge = "Thank You Again!";
                }
            }
            
            Program.dialouge = "Help us slay the \nGiant Winter Snake to \nto the north.";
        }


        //Tail AI

        public void followTail(NPC lead)
        {
            if (state == 1)
            {


                if (Math.Abs(lead.npcX - npcX) > Math.Abs(lead.npcY - npcY))
                {
                    if (lead.npcX > npcX)
                    {
                        npcX = npcX + 1;
                    }
                    else
                    {
                        npcX = npcX - 1;
                    }
                }
                else
                {
                    if (lead.npcY > npcY)
                    {
                        npcY = npcY + 1;
                    }
                    else
                    {
                        npcY = npcY - 1;
                    }
                }
            }
        }
        public void placeMonster()
        {
            if (state == 1)
            {
                nLoc.map[npcY][npcX] = icon;
            }
        }
        public void removeMonster()
        {
            if (state == 1)
            {
                nLoc.map[npcY][npcX] = " ";
            }
            
        }
        //Tail Killing
        public static NPC lastTail = Program.SnakeTail;
        public void slayTail()
        {

            lastTail = Program.SnakeTail;
            foreach (NPC tail in tailList)
            {
                if(tail.tailChain > lastTail.tailChain)
                {
                    lastTail = tail;
                }
            }

            if(lastTail == talker)
            {
                icon = " ";
                Program.currentMap.placeObject(lastTail.npcX, lastTail.npcY, " ");
                npcX = 7;
                npcY = 5;
                state = 0;
                tailList.Remove(lastTail);
                
            }
            
            
            
        }

        public void followHead(Boss lead)
        {
            if (state == 1)
            {
                if (Math.Abs(lead.monsterX - npcX) > Math.Abs(lead.monsterY - npcY))
                {
                    if (lead.monsterX > npcX)
                    {
                        npcX = npcX + 1;
                    }
                    else
                    {
                        npcX = npcX - 1;
                    }
                }
                else
                {
                    if (lead.monsterY > npcY)
                    {
                        npcY = npcY + 1;
                    }
                    else
                    {
                        npcY = npcY - 1;
                    }
                }
            }
        }

        public static void openKing()
        {
            bool check = Program.player.checkInven(Program.SnakeHeadHat);
            if (check == true)
            {
                Program.dialouge = "That's a nice hat! \nYou may now enter";
                NPC.npcList.Remove(Program.kingKeeper);
                Program.currentMap.placeObject(7, 9, " ");

            }
            else
            {
                Program.dialouge = "You need to wear a \nhat to visit The King";
            }
        }
        public static void dogInter()
        {
            //Console.WriteLine("Woof \nFollow the dog back home? (y/n)");
            Program.dialouge = "Woof \nFollow the dog back home? (y/n)";
            Program.currentMap.placePlayer();
            Program.currentMap.genMap(Program.currentMap.map);
            char choice = Console.ReadKey().KeyChar;

            if (choice == 'y')
            {
                Program.player.playerCord = new int[] { 0, -2 };
                Program.currentMap.locPlayer();
                Program.currentMap.placePlayer();
                Program.dialouge = "You arrived back at King's house";
                Program.currentMap.map[9][6] = "D";
                Program.dog.state = 42;

            }
            else if (choice == 'n')
            {

            }
            else
            {
                dogInter();
            }
        }

        public static void kingInter()
        {
            if (Program.dog.state == 42)
            {
                Program.dialouge = "Thank you for finding my dog! \n \nHere, take this 'You Won the Game' trophy!";
                Player.Inventory.Add(Program.WonTheGame);
                SoundPlayer victory = new SoundPlayer(Assembly.GetExecutingAssembly().GetManifestResourceStream("Console_RPG.Victory.wav"));
                victory.Play();

            }
            else
            {
                Program.dialouge = "Hello, I am King \nMy dog ran into my maze and hasn't come back yet \nPlease help me find him \nI have unlocked the gate";
                Program.kingGarden.map[5][1] = " ";
                NPC.npcList.Remove(Program.gate);
            }
        }

    }
}
