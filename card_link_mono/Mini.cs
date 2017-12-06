using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//普通mini只能是建筑和被动随从
//没有主动技能
public abstract class Mini : layerBase {

    public int ID; public override Mini mini()  { return this;  }

    public override void _GetIDload()
    {
        ID = host().next.NextminiID;
        host().IDmini.Add(ID, this);
        player().id_minis.Add(ID);
    }

    private bool iscard;
    public void becomeCard() {
        iscard = true;

        //注册为卡牌 给出卡牌
    }

    public void becomeMini() {
        iscard = false;
        //注册为随从 给出触发器
    }
    
    public Buffs buffList;
}

//改变队列-卡牌
public abstract class card_ : changeG_
{
    public override card_ card() { return this; }

    public abstract int fei { get; }
    public abstract void decpmpose();
}