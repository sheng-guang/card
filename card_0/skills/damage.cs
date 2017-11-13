using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class skill_1_damage : skill_
{
    public override void load()
    {
        //addSelf_For_call();
        //addHpChange<hp_change>(1, hp_change_K.ignore);
    }

    public override void run(Be target)
    {

    }
}
public class hp_change : change_
{
    public int num;
    public hp_change_K k1;
    public override void run(Be target)
    {
        target.hp_change(num, k1);
    }
}
public enum hp_change_K
{
    buff,
    ignore, physics, magic, cure,
}