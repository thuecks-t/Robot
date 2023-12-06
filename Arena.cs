using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCaveFightTestArena
{
    public class Arena
    {

        IRobot Contestant1 { get; set; }
        IRobot Contestant2 { get; set; }

        public Arena(IRobot c1, IRobot c2)
        {
            Contestant1 = c1;
            Contestant2 = c2;
        }

        public void RunBattle()
        {

            int roundCount = 0;
            bool roundOverflow = false;

            while (Contestant1.GetHealth() > 0 && Contestant2.GetHealth() > 0)
            {

                //short circuit at 100 rounds
                if (roundCount > 100)
                {
                    roundOverflow = true;
                    break;
                }

                //Determine who to allow to go first in combat, and then run each action in order, breaking out if
                //the first contestant to act is successful.
                if (Contestant1.GetSpeed() > Contestant2.GetSpeed())
                {
                    ActionResult firstAction = Contestant1.PerformAction(Contestant2);
                    Console.WriteLine($"{Contestant1.GetRobotName()}: {firstAction.ActionName}");
                    Thread.Sleep(175);

                    if (Contestant2.GetHealth() <= 0) break;

                    ActionResult secondAction = Contestant2.PerformAction(Contestant1);
                    Console.WriteLine($"{Contestant2.GetRobotName()}: {secondAction.ActionName}");
                    Thread.Sleep(175);
                }
                else
                {
                    ActionResult firstAction = Contestant2.PerformAction(Contestant1);
                    Console.WriteLine($"{Contestant2.GetRobotName()}: {firstAction.ActionName}");
                    Thread.Sleep(175);

                    if (Contestant1.GetHealth() <= 0) break;

                    ActionResult secondAction = Contestant1.PerformAction(Contestant2);
                    Console.WriteLine($"{Contestant1.GetRobotName()}: {secondAction.ActionName}");
                    Thread.Sleep(175);
                }

                // display stats
                Console.WriteLine();
                Console.WriteLine($"{Contestant1.GetRobotName()}: HP({Contestant1.GetHealth()}) {Contestant1.GetStats()}");
                Console.WriteLine($"{Contestant2.GetRobotName()}: HP({Contestant2.GetHealth()}) {Contestant2.GetStats()}");
                Console.WriteLine();
                Thread.Sleep(350);

                roundCount++;
            }

            //Determine the winner
            IRobot winner = null;
            if (roundOverflow)
            {
                //winner = highest hp
                winner = Contestant1.GetHealth() > Contestant2.GetHealth() ? Contestant1 : Contestant2;
            }
            else
            {
                //winner = highest hp
                winner = Contestant2.GetHealth() <= 0 ? Contestant1 : Contestant2;
            }

            Console.WriteLine($"{winner.GetRobotName()} has won the battle!");
        }
    }

}
