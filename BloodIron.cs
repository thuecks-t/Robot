using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCaveFightTestArena
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Net.Mail;

    //using UnityEngine;

    public interface IRobot
    {
        public string GetRobotName();
        public void Reset();
        public string[] GetStudentNames();
        public string GetStats();
        public double GetSpeed();
        public double GetHealth();
        public double GetMaxHealth();
        public string GetPrimaryColor();
        public string GetSecondaryColor();
        public void TakeDamage(double damage);
        public ActionResult PerformAction(IRobot opponent);
        public double GetAttack();
        public double GetDefense();
    }

    public class BloodIron : IRobot
    {
        public string RobotName { get; set; }
        public string[] StudentNames { get; set; }
        public double Attack { get; set; }
        public double Defense { get; set; }
        public double Speed { get; set; }
        public double Constitution { get; set; }
        public double Health { get; set; }
        public string PrimaryColor { get; set; }
        public string SecondaryColor { get; set; }

        public BloodIron()
        {
            RobotName = "BloodIron";

            StudentNames = new string[] { "Reo Day, Austin Landes, Elijah Mckeehan, Truitt Thuecks " };

            // 40 stat points to distribute.
            Attack = 12;
            Defense = 8;
            Speed = 8;
            Constitution = 12;

            Health = 10 * Constitution;

            // Primary and secondary colors
            PrimaryColor = "#000000"; // Black
            SecondaryColor = "#FF0000"; // Red
        }

        // Reset method
        public void Reset()
        {
            // Reset all stats
            Attack = 12;
            Defense = 8;
            Speed = 8;
            Constitution = 12;

            // Reset health to 10 * constitution
            ResetHealth();

            // Validate that the total points do not exceed 40
            ValidateTotalPoints();
        }

        // Method to reset health
        private void ResetHealth()
        {
            // Reset health to 10 * constitution
            Health = 10 * Constitution;
        }

        // ValidateTotalPoints method
        private void ValidateTotalPoints()
        {
            if (Attack + Defense + Speed + Constitution > 40)
            {
                throw new Exception("Total points exceed 40.");
            }
        }
        //returning the proper values to their names
        public string GetRobotName()
        {
            return RobotName;
        }

        public string[] GetStudentNames()
        {
            return StudentNames;
        }
        //returninng all important stats
        public string GetStats()
        {
            return $"Current Health: {Health:F2}, Attack: {Attack:F2}, Defense: {Defense:F2}, Speed: {Speed:F2}.";
        }

        public double GetSpeed()
        {
            return Speed;
        }

        public double GetHealth()
        {
            Health.ToString("F2");
            return Health;
        }
        //Max Health set to 10 * Constitution
        public double GetMaxHealth()
        {
            return 10 * Constitution;
        }

        public string GetPrimaryColor()
        {
            return PrimaryColor;
        }

        public string GetSecondaryColor()
        {
            return SecondaryColor;
        }

        public double GetAttack()
        {
            return Attack;
        }

        public double GetDefense()
        {
            return Defense;
        }
        //Implementing a way to reduce the robots health from opponent attacks.
        public void TakeDamage(double incomingDamage)
        {
            double damageDealt = incomingDamage - (Defense / 100 * incomingDamage);
            Health -= damageDealt;
        }

        public ActionResult Attack1(IRobot opponent)
        {
            ActionResult actionResult = new ActionResult("", "");
            actionResult.ActionName = "Blazing RED ARM Punch";
            actionResult.Animation = "Punch";
            double attack = .6 * Attack + .4 * Speed;
            opponent.TakeDamage(attack);
            return actionResult;

        }

        public ActionResult Defense1()
        {
            ActionResult actionResult = new ActionResult("", "");

            // Ensures that Defense doesn't go above a certain value
            double maxDefense = 13;
            if (Defense + 2 > maxDefense)
            {
                Defense = maxDefense;
            }
            else
            {
                Defense += 2;
            }

            // Ensure that Speed doesn't go below 3
            if (Speed > 3)
            {
                Speed -= 2;
            }

            actionResult.ActionName = "Reo's Defense Matrix";
            actionResult.Animation = "Power Up";

            return actionResult;

        }

        public ActionResult Attack2(IRobot opponent)
        {
            ActionResult actionResult = new ActionResult("", "");
            actionResult.ActionName = "Iron Impaler of Truitt";
            actionResult.Animation = "Punch";
            double attack = .7 * Attack + .3 * Speed;
            opponent.TakeDamage(attack);
            return actionResult;

        }

        public ActionResult Heal()
        {
            ActionResult actionResult = new ActionResult("", "");

            // Prevent Health from exceeding its maximum value
            double healedAmount = 6;
            double maxHealth = GetMaxHealth();
            if (Health + healedAmount > maxHealth)
            {
                healedAmount = maxHealth - Health;
            }

            // Ensures that Defense doesn't go below 7
            if (Defense > 7)
            {
                Defense -= 2;
            }

            Health += healedAmount;

            actionResult.ActionName = "ZAM: Electrolysis";
            actionResult.Animation = "Heal";

            return actionResult;

        }



        public ActionResult PerformAction(IRobot opponent)
        {

            Random rnd = new Random();
            int customActions = rnd.Next(1, 5);
            ActionResult actionResult;

            if (customActions == 1)
            {
                actionResult = Attack1(opponent);
            }
            else if (customActions == 2 && Health <= 60)
            {
                actionResult = Defense1();
            }
            else if (customActions == 3)
            {
                actionResult = Attack2(opponent);
            }
            else if (Health <= 48)
            {
                actionResult = Heal();
            }
            else
            {
                actionResult = Attack1(opponent);
            }
            return actionResult;
        }
    }
}