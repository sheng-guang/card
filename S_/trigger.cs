using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public enum Call_K
{
    be_hit,
}
public  class Call_
{
   public Call_(int p,int o,Call_K _)
    {
        Pid = p;Oid = o;k = _;
    }
    public int Pid, Oid;
    public Call_K k;
}
public abstract class Trigger_ : notestskill_, IBe_Call
{
    public override void link_()
    {
        obj.player.host.mode.be_call.AddLast(this);
    }

    public abstract void getcall(Call_ c);

    public abstract int needcall_K { get; }
    public virtual void do_()
    {
        //上传到host  补全
        Queue<EVE_> copy = new Queue<EVE_>(L);
        player.host.mode.addEVE(copy);
    }
}


