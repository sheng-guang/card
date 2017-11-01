using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class skill_1_damage : skill_
{
    public override void loadList()
    {
        addSelf();
        addHpChange<hp_change>(1, hp_change_K.ignore);
    }
}
public class hp_change : change_
{
    public int num;
    public hp_change_K k1;

    public override void run()
    {
        Change().from.be.giveHP(this);
        Change().Target.be.hp(this);
    }
}
public enum hp_change_K
{
    buff,
    ignore, physics, magic, cure,
}