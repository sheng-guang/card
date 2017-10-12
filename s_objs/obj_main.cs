using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class obj_main : SkillObj
{
    //基础属性描述
    public override int baseATK {get{return 0;}}
    public override int baseHP {get{ return 64;} }
    public override int baseskillNum  {get{ return 6;}}


    public override int needcall_K {get { return 0; } }

    public override Target_K2 obj_K
    { get  {return Target_K2.hero;}}

    public override void C__()
    {}

    public override void loadskills()
    {
        //skills[1] =addskill<_one_damage>();
        //skills[2] = addskill<_new1_1>();
    }
}

