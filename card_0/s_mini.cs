﻿using System;
using System.Collections.Generic;
using System.Text;

//随从
public abstract class mi_base : layer_base
{
    public abstract int baseHp { get; }
    public int maxHP, nowHP;
    public abstract int skillCount { get; }
    public  void link_load(Mini_G g)
    {
        upone = g;
        ID = host().next.NextminiID;
        skills = new skill_[skillCount];
        be.upone = this;
        maxHP = baseHp;nowHP = baseHp;
        load();
    }
    public override Mini_G Group()  { return upone.Group();  }
    public skill_[] skills;
    public bool haveskill(int which)
    {
        if (skills.Length > which && skills[which] != null) return true;
        else return false;
    }
    public Be be = new Be();
}
public abstract  class Mini:mi_base
{    
    public override Mini mini(){return this; }
    //加入技能
    public T addskill<T>() where T : skill_, new()
    {
        T newone = new T();
        newone.link_load(this);
        return newone;
    }
}
public class Be:layer_base
{

    public void giveHP(hp_change c)
    {
        //foreach()
    }
    //buff-top判断是否受伤
    //middle-倍数减伤增伤
    //final-加减减伤
    public void link_load(Mini m) { upone = m; }
    public bool asTarget(skill_ which)
    {
        return false;
    }
    public void hp(hp_change c) {

    }
    public void GetBuff(buff_ b) { add(b); }
    public void RemoveBuff(buff_ b) { remove(b); }

    
    void through(change_ c) { }
    void add(buff_ b)
    {
        List<buff_> to;
        if (b.k1 == buff_kind.top) to = top;
        else if (b.k1 == buff_kind.middle) to= middle;
        else to= final;
        to.Add(b);
    }
    void remove(buff_ b)
    {
        List<buff_> to;
        if (b.k1 == buff_kind.top) to = top;
        else if (b.k1 == buff_kind.middle) to = middle;
        else to = final;
        if (to.Contains(b)) to.Remove(b);
    }
    List<buff_> top = new List<buff_>();
    List<buff_> middle = new List<buff_>();
    List<buff_> final = new List<buff_>();
}
//public class buffs
//{
    
//}

