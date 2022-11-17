using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleWarcraft
{
    public class GameLogic
    {
    

        public GameLogic(Unit unit1, Unit unit2)
        {
    

            

            start(unit1, unit2);
        }

        public void start (Unit unit1, Unit unit2)
        {
            while (unit1.health < 0 || unit2.health < 0)
            {
                if (unit1 is Mage mage1)
                {
                    Console.WriteLine("2");

                    if (unit2 is Mage mage2)
                    {
                        mage1.fireBall(mage2);
                        mage1.attack(mage2);
                        showMageAttack(mage1);
                        showHealth(mage2);
                    }

                    if (unit2 is Footman footman)
                    {
                        mage1.fireBall(footman);
                        mage1.attack(footman);
                        showMageAttack(mage1);
                        showHealth(footman);
                    }
                }

              
            }
        }

        public static void showMageAttack(Mage mage)
        {
            Console.WriteLine(mage.name + ": attack " + mage.damage + " | mana: " + mage.mana);
        }

        public static void showFootmanAttack(Footman footman)
        {
            Console.WriteLine(footman.name + ": attack " + footman.damage);
        }

        public static void showHealth(Unit unit)
        {
            Console.WriteLine(unit.name + ":  health:" + unit.health);
            Console.WriteLine();
        }

    }
}
