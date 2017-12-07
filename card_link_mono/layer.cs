using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum layer_kind
{
    N,
    host,miniG,mini,
}
public abstract class layer_withID:layerBase
{
    public int ID;
}

/// <summary>
/// 可重写方法：fix()   load()
/// </summary>
public abstract class layerBase :MonoBehaviour
{
    public virtual Host host() { return upone.host(); }
    //指定位置ID
    public virtual miniG player() { return upone.player(); }
    //有位置 实体ID
    public virtual Mini mini() { return upone.mini(); }
    //附着位置ID
    public virtual Trigger trigger() { return upone.trigger(); }

    public virtual card_ card() { return upone.card(); }

    public layerBase upone;
    /// <summary>
    /// link连接上一层级load获取id
    /// </summary>
    public virtual void link_GetID(layerBase b) {
        upone = b;
        _GetIDload();
    }
    public virtual void _GetIDload() { }



    public virtual void unlink() { }
    public virtual void relink() { }

    public IdGroup beens { get { return host().Beens; } }

    //public void IDcheckIN(Mini m) { }

    public virtual void fixedUpD() { }

    public  T ADDcomponet<T>()where T : layerBase, new()
    {
        T newone = new T();
        newone.link_GetID(this);return newone;
    }


    //host1
    //player2
    public T addplayer<T>() where T : miniG, new()
    {
        if (player() != null) return null;
        T newone = new T();
        newone.link_GetID(this); return newone;
    }
    //mini3
    public T addminiBase<T>(bool card) where T : Mini, new()
    {//由玩家创建
        if (player() == null||mini()!=null) return null;
        T newone = new T();
        
        newone.link_GetID(this);
        //if (card) mini().becomeCard();
        //else mini().becomeMini();
        return newone;
    }
    //trigger4
    public T addtriggerBase<T>(bool forp) where T :Trigger, new()
    {//由mini创建
        if (trigger() != null || mini() == null) return null;
        T newone = new T();newone.forPlayer = forp;
        newone.link_GetID(this); return newone;
    }
    //card5
    //public void outputchange(Call_ c) { }
}

