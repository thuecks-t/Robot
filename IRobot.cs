using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections;
using System.Collections.Generic;
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
