using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class obj_main : SkillObj
{
    //基础属性描述
    public override int baseATK {get{return 0;}}
    public override int baseHP {get{ return 64;} }
    public override int baseskillNum  {get{ return 6;}}

    public override Target_K2 obj_K
    { get  {return Target_K2.hero;}}
    public override void loadskills()
    {
        skills[1] = addskill<skill_1damage>();
        skills[2] = addskill<skill_1damage>();
    }
}
//测试
public class skill_test1 : skill_
{
    public override Skill_K1 k  { get  {  return Skill_K1.objskill; }  }

    public override Target_K1 k1
    {  get   {  return Target_K1.all;  }  }

    public override Target_K2 k2
    {  get  { return Target_K2.all;  }  }

    public override int needFei
    {
        get
        {
            return 0;
        }
    }

    public override void _load()
    {
       
    }
}

//造成1点伤害
public class skill_1damage : skill_
{
    public override Skill_K1 k {get  { return Skill_K1.objskill; }  }

    public override Target_K1 k1  {get{return Target_K1.all;}}

    public override Target_K2 k2  { get  {return Target_K2.all;}}

    public override int needFei {get{ return 0;} }

    public override void _load()
    {
        L.Enqueue(addEVE<E_1damage>());
    }
}
public class E_1damage : EVE_
{
    public override void do_()
    {
        Debug.Log("do_1_damage");
        skill.now_Target.geteffect.getHPchange(Skill_K1.objskill, -1);
    }
}
//召唤11
public class skill_new11 : skill_
{
    public override Skill_K1 k { get { return Skill_K1.objskill; } }

    public override Target_K1 k1
    { get { return Target_K1.__; } }

    public override Target_K2 k2
    { get { return Target_K2.hero; } }

    public override int needFei
    { get { return 0; } }

    public override void _load()
    {
        L.Enqueue(addEVE<e_new11>());
    }
}
public class e_new11 : EVE_
{
    public override void do_()
    {

    }
}