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
        skills[0] = addskill<skill_1damage>();
        skills[1] = addskill<skill_1damage>();
        skills[2] = addskill<skill_new11>();
        skills[3] = addskill<skill_aoe_1damage>();
    }
    public override void loadtrigger()
    {
        triggers.Add(addtrigger<tri_hit_new11>());
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
    public override eve_K1 k
    {  get  {  return eve_K1.damage;  }  }

    public override void do_()
    {
        //Debug.Log("do_1_damage");
        skill.now_Target.geteffect.getdamage(Skill_K1.objskill, -1);
    }
}
//aoe1
public class skill_aoe_1damage : skill_
{
    public override Skill_K1 k
    { get {return Skill_K1.objskill; } }

    public override Target_K1 k1
    { get { return Target_K1.__;  }  }

    public override Target_K2 k2
    { get  { return Target_K2.all;  }  }

    public override int needFei
    {  get { return 0;  } }

    public override void _load()
    {
        L.Enqueue(new e_aoe1(obj.player.host.mode));
    }
}
public class e_aoe1 : EVE_
{
    public  e_aoe1(mode _)
    { m = _; }
    mode m;
    public override eve_K1 k
    {get { return eve_K1.damage; } }

    public override void do_()
    {
        foreach(IObj_Be_Call o in m.obj_call)
        {
            o.obj.geteffect.getdamage (Skill_K1.objskill,-1);
        }
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
public abstract  class e_newobj : EVE_
{
    public override eve_K1 k{  get  { return eve_K1.newobj;  } }
}
public class e_new11 : e_newobj
{
    public override void do_()
    {
        skill.player.get_P.newobj<obj_1_1>();
    }
}
public class obj_1_1 : SkillObj
{
    public override Target_K2 obj_K { get { return Target_K2.obj; } }
    public override int baseHP { get { return 1; } }
    public override int baseATK { get { return 1; } }
    public override int baseskillNum { get { return 1; } }

    public override void loadskills()
    {
        
    }
    public override void loadtrigger()
    {
    }

}
//受伤召唤11
public class tri_hit_new11 : Trigger_
{
    public override Skill_K1 k
    {  get  { return Skill_K1.tregger; }  }

    public override int needcall_K
    { get  { return 0;  } }

    public override void getcall(Call_ c)
    {
        
        if (c.k ==Call_K.be_hit&&c.Pid==obj.player.ID&&c.Oid==obj.OID)
        {
            do_(); 
        }
    }

    public override void _load()
    {
        L.Enqueue(addEVE<e_new11>());
    }
}
