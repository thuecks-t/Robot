using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public record ActionResult
{
    public string ActionName;
    public string Animation;

    public ActionResult(string name, string anim)
    {
        this.ActionName = name;
        this.Animation = anim;
    }
}
