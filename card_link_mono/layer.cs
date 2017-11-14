using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum layer_kind
{
    N,
    host,miniG,mini,
}
/// <summary>
/// 可重写方法：fix()   load()
/// </summary>
public abstract class layerBase : MonoBehaviour
{
    public virtual layer_kind getT() { return layer_kind.N; }
    public virtual Host host() { return upone.host(); }
    public virtual miniG Group() { return upone.Group(); }
    public virtual Mini mini() { return upone.mini(); }
    public layer_ID upone;
    public virtual void link(layer_ID b) {
        upone = b;
        _load();
    }
    public virtual void _load() { }//只是一个提醒 可能不需要


    public virtual void fixedUpDate() { }
    //public void outputchange(Call_ c) { }
}
public abstract class layer_ID : layerBase
{
    public int ID;
    public List<int> id_nextlevel;

    public override void link(layer_ID b)
    {
        base.link(b);
        switch (getT())
        {
            case layer_kind.miniG:
                ID = host().next.NextGID;
                host().IDgroup.Add(ID, (miniG)this);
                break;
            case layer_kind.mini:
                ID = host().next.NextminiID;
                host().IDmini.Add(ID, (Mini)this);
                break;
        }
        upone.id_nextlevel.Add(ID);
    }
    public static void unLink(layer_ID l) {
        switch (l. getT())
        {
            case layer_kind.miniG:
                l.host().IDgroup.Remove(l.ID);break;
            case layer_kind.mini:
                l.host().IDmini.Remove(l.ID);break;
        }
        l.upone.id_nextlevel.Remove(l.ID);
    }

    public miniG findGroup(int id) { return host().IDgroup.ContainsKey(ID) ? host().IDgroup[ID] : null; }
    public Mini findMini(int id) { return host().IDmini.ContainsKey(ID) ? host().IDmini[ID] : null; }

    public bool ownNextOne(int id) { return id_nextlevel.Contains(id) ? true:false; }


}



