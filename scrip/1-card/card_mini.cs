using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//普通单位
public abstract class card_mini : Card_m {
    public override card_mini minion { get { return this; } }

    [Header("_mini--------------------|")]
    public List<Trigger_byinput> skillTrigger;   
    //第一版本 用于使用技能
    public virtual bool get_Input_order(order o)
    {
        bool ret = false;
        if (o.action != cardM_Action.mini_useTrigger) { print("is not skill action"); return ret; }//报错

        Trigger_byinput t = trigger(o.whichTrigger).input;
        if (t && state == cardWhere.space3d && skillTrigger.Contains(t))
            ret = t.Do_order(o);
        return ret;
    }

    card_mini upmove_;
    public card_mini upmove { get { return upmove_; } set { setUpMove(value); } }

    public void setUpMove(card_mini theset)
    {
        card_mini toTest = theset;
        while (toTest.upmove_ != null)
        {
            if (toTest.upmove_ == this) return;
            else { toTest = toTest.upmove_; }
        }
        upmove = theset; return;
    }
    public card_mini topMove()
    {
        if (upmove_ == null) return null;
        else return upmove_.topMove();
    }
    //根据玩家的输入参数  设置新位置
    public virtual bool move_New_pos(float deltaTime) {return true; }
    //变形方法 由group使用
    public GameObject mini_;
    //改变可以运行的trigger
    public override  bool Transform_ToMini( Vector3 pos)
    {
        if (state == cardWhere.space3d) return false;
        transform.position = pos;
        mini_.SetActive(true);
        state = cardWhere.space3d;
        return true;
    }
    //会去掉所有buff
    public override  bool Transform_ToCard()
    {
        
        if (state == cardWhere.hand) return false;
        mini_.SetActive(false);
        state = cardWhere.hand;
        return true;
    }
    //去掉更多buff
    public override  bool Transform_ToDeck()
    {
        if (state == cardWhere.deck) return false;
        mini_.SetActive(false);
        state = cardWhere.deck;
        return true;
    }

    public abstract float base_MaxHP { get; }
    [Header("data----------------|")]
    public float now_HP;
    public float now_MaxHP;
    public float v;
    public virtual HPchange_info TXT_getdamage(float n, HPchange_K k)
    {
        HPchange_info i = new HPchange_info();
        i.before = now_HP;
        now_HP -= n;
        i.after = now_HP;
        ui.setHP(this);///
        return i;
    }
    [Header("data----------------|")]
    public SimpleUI ui;
}


//魔法本身
public abstract class card_magic : Card_m {
    public override card_magic magic  { get  {  return this;  } }
}

//魔法单位
public abstract class ca_Magic_sprit : card_mini
{
    public override float base_MaxHP {  get  {  return 0;  }    }
}


public struct HPchange_info
{

    public float before;
    public float after;
    public float change { get { return after - before; } }
    //还有发生了什么特殊事件/比如圣盾挡伤害/护甲减少伤害/
}

public enum HPchange_K
{
    cure,
    normal_Dam,
    magic_Dam,
}