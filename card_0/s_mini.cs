using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
//随从
public abstract class mi_base : layer_base_ID
{
    public override Type toolType { get { return typeof(Mini); } }
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
    public override void load() { be.link_load(this); }
}


/// <summary>
/// 目前方法：
/// hp_change ||Getbuff
/// </summary>
public class Be:layer_base
{
    public void link_load(Mini m) { upone = m; }
    public void Before_give_buff(skill_ skill)  { }
    void give_HP(hp_change c) {/*foreach() */ }
    //buff-top判断是否受伤
    //middle-倍数减伤增伤
    //final-加减减伤
    
    public bool asTarget(skill_ which)
    { return false;  }


    public void hp_change(int n,hp_change_K k) { }
    //
    public void GetBuff(buff_ b) { add(b); }
    public void RemoveBuff(buff_ b) { remove(b); }

    
    void through(change_ c) { }
    void add(buff_ b)
    {
        List<buff_> to;
        if (b.k1 == buff_kind.stay_top) to = top;
        else if (b.k1 == buff_kind.stay_middle) to= middle;
        else to= final;
        to.Add(b);
    }
    void remove(buff_ b)
    {
        List<buff_> to;
        if (b.k1 == buff_kind.stay_top) to = top;
        else if (b.k1 == buff_kind.stay_middle) to = middle;
        else to = final;
        if (to.Contains(b)) to.Remove(b);
    }

    public override void load()
    {
    }

    List<buff_> top = new List<buff_>();
    List<buff_> middle = new List<buff_>();
    List<buff_> final = new List<buff_>();

    
}
//public class buffs
//{
    
//}

