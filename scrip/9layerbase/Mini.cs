using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 添加技能对应的触发器（已经有两个 使用和分解）
/// 还需要把所有被动触发器  注册到host中；
/// </summary>
public abstract class Card_m : layerBase
{
    public abstract int CardID { get; }
    public override Card_m mini()  { return this;  }
    public virtual card_mini minion { get { return null; } }
    public virtual card_magic magic { get { return null; } }
    [Header("card_m--------------------|")]
    public Card_m target;
     public int ID;
    //触发器-------------------------------------------------------------------------|
    public int fei = 0;
    //使用
    public CardTxt use;
    //分解
    public CardTxt deconposs;
    //亡语
    //技能触发器 只能在

    public List<Trigger_bycall> callTrigger;

    public virtual bool getcall(Call_ call)
    {
        bool r=false;
        foreach (Trigger_bycall c in callTrigger)
        {
            if (c.Get(call)) r = true;
        }
        return r;
    }
    //--------------------------------------------------------------------------------|
    //根据玩家的输入参数  设置新位置
    //变形方法 由group使用
    public virtual bool Transform_ToMini(Vector3 pos)
    {
        if (state == cardWhere.space3d) return false;
        state = cardWhere.space3d;
        return false;
    }
    //会去掉所有buff
    public virtual bool Transform_ToCard() {
        if (state == cardWhere.hand) return false;
        state = cardWhere.hand;
        return true;
    }
    //去掉更多buff
    public virtual bool Transform_ToDeck() {
        if (state == cardWhere.deck) return false;
        state = cardWhere.deck;
        return true;
    }
    public void Txt_get_staybuff()
    {

    }
    //public Buffs buffList;

    public cardWhere state;
}

public class stayBuff
{
    // +1/+1 减费用
    public void add()
    {

    }
}




