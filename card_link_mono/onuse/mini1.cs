using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public  class mini1:Mini
{
    public override void _GetIDload()
    {
        base._GetIDload();
        Trigger t = addtriggerBase<Triggernewmini>(false);
        //t.ToDocard=
    }

}
public class Triggernewmini : Trigger_bycall
{
    public override change_k1 simpleKind
    {
        get
        {
            return change_k1.mini;
        }
    }

    public override int needinfo()
    {
        return 0;
    }

    public override bool testCall_loadTarget(Call_ c)
    {
        return false;
        //ToDocard.Target = ;
    }
}
