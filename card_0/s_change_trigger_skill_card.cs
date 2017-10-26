using System;
using System.Collections.Generic;
using System.Text;
public abstract class trigger_ : change_
{

}

//改变
public abstract class change_ : layer_base
{
    public change_ toolchange;
    public virtual change_ Change() { return toolchange == null ? this : toolchange; }
    public override Mini mini() { return Change().mini(); }
    public virtual void link_load(change_ c) { toolchange = c; load(); }

    public virtual int kind() { return 0; }
    public virtual bool needCallBefore { get { return true; } }
    public abstract void run();
}

public enum change_kind
{
    doskill,
    docard,
    Trigger_before_damagk,
    trigger_after_call,

}