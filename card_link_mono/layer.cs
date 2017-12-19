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
    public layerBase upone;

    public virtual Host host() { return upone.host(); }
    //指定位置ID
    public virtual miniG player() { return upone.player(); }
    //有位置 实体ID
    public virtual Mini mini() { return upone.mini(); }
    //附着位置ID
    public virtual Trigger trigger() { return upone.trigger(); }

    public virtual card_ card() { return upone.card(); }

    


    public virtual void load_ForCreater() { }
    public virtual void link_ForBeens() { }

    public IdGroup beens { get { return host().Beens; } }
    public  T ADDcomponet<T>()where T : layerBase, new()
    {
        T newone = new T();
        newone.upone = this;newone.load_ForCreater(); return newone;
    }

    public virtual void fixedUpD() { }
}

