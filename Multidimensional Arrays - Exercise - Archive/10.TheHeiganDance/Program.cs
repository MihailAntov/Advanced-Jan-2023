using System;

namespace _10.TheHeiganDance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal playerHP = 18500;
            decimal heiganHP = 3_000_000;
            decimal dmg = decimal.Parse(Console.ReadLine());
            int currentCol = 7;
            int currentRow = 7;

            string lastSpell = string.Empty;
            bool poisoned = false;
            bool hitByPoison = false;
            bool hitByEruption = false;
            while (playerHP > 0 && heiganHP > 0)
            {
                hitByPoison = false;
                hitByEruption = false;
                string[] spellArgs = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string spell = spellArgs[0];
                
                int row = int.Parse(spellArgs[1]);
                int col = int.Parse(spellArgs[2]);

                heiganHP -= dmg;

                if (poisoned)
                {
                    playerHP -= 3500;
                    poisoned = false;
                }

                if (heiganHP <= 0 || playerHP <= 0)
                {
                    lastSpell = "Plague Cloud";
                    break;
                }

                if (Math.Abs(row - currentRow) <=1 && Math.Abs(col - currentCol) <= 1)
                {
                    //in damaged area

                    //up
                    if (currentRow > 0 && Math.Abs(row - (currentRow-1)) > 1 )
                    {
                        //can go up
                        currentRow--;
                    }
                    //right
                    else if (currentCol < 14 && Math.Abs(col - (currentCol+1)) > 1 )
                    {
                        //can go right
                        currentCol++;
                    }
                    //down
                    else if (currentRow < 14 && Math.Abs(row - (currentRow+1)) > 1 )
                    {
                        //can go down
                        currentRow++;
                    }
                    //left
                    else if (currentCol > 0 && Math.Abs(col - (currentCol-1)) > 1 )
                    {
                        //can go left
                        currentCol--;
                    }
                    //take damage
                    else
                    {
                        if(spell == "Eruption")
                        {
                            hitByEruption = true;
                            lastSpell = "Eruption";
                        }
                        else if (spell == "Cloud")
                        {
                            hitByPoison = true;
                            lastSpell = "Plague Cloud";
                        }
                    }

                }

                //order:
                // target -> move -> poison + damage -> spell hits

                

                if(hitByPoison)
                {
                    playerHP -= 3500;
                    lastSpell = "Plague Cloud";
                    poisoned = true;
                }

                if(hitByEruption)
                {
                    playerHP -= 6000;
                    lastSpell = "Eruption";
                }

            }

            // print 
            if (heiganHP <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganHP:f2}");
            }

            if (playerHP <= 0)
            {
                Console.WriteLine($"Player: Killed by {lastSpell}");
            }
            else
            {
                Console.WriteLine($"Player: {playerHP}");
            }

            Console.WriteLine($"Final position: {currentRow}, {currentCol}");
        }

        
    }
}
