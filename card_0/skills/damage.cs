using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class skill_1_damage : skill_
{
    public override void load()
    {
        addSelf_For_call();
        addHpChange<hp_change>(1, hp_change_K.ignore);
    }
}
public class hp_change : change_
{
    public int num;
    public hp_change_K k1;

    public override void load()
    {

    }

    public override void run()
    {
       changeG().from.be.giveHP(this);
       changeG().Target.be.hp(this);
    }
}
public enum hp_change_K
{
    buff,
    ignore, physics, magic, cure,
}