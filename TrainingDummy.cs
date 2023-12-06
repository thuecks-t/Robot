using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotCaveFightTestArena
{
    internal class TrainingDummy : IRobot
    {
        double health = 100;
        public double GetHealth() => health;

        public double GetMaxHealth() => 100;

        public string GetPrimaryColor() => "#FFC423";

        public string GetSecondaryColor() => "#002D62";

        public string GetRobotName() => "Training Dummy";

        public double GetSpeed() => 0;

        public string GetStats() => "No stats, dummy!";

        public string[] GetStudentNames() => new string[] { "Training", "Dummy" };

        public ActionResult PerformAction(IRobot opponent) => new ActionResult("Stare Menacingly", "None");

        public void Reset() => health = 100;

        public void TakeDamage(double damage) => health -= damage;

        public double GetAttack() => 0;


        public double GetDefense() => 0;
    }
}
