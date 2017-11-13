using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public interface IFor_layer {
    Host host();
    Mini_G Group();
    Mini_G find_Group(int ID);
    Mini find_mini(int ID);
}
public abstract class layer_base_ID : layer_base
{
    public  int ID;
    public  void link(layer_base b, int I) { upone = b; ID = I; }
    public T addMiniG<T>() where T : Mini_G, new()
    {
        if (toolType != typeof(Host)) return null;
        T newone = new T();
        newone.link(this, host().next.NextGID);
        host().IDgroup.Add(newone.ID, newone);
        newone.load();
        return newone;
    }
    public T addMini<T>() where T : Mini, new()
    {
        if (toolType != typeof(Mini_G)) return null;
        T newone = new T();
        newone.link(this, host().next.NextminiID);
        host().IDmini.Add(newone.ID, newone);
        Group().IDmini.Add(newone.ID);
        newone.load();
        return newone;
    }
}
public abstract class layer_base : IFor_layer
{
    public virtual Type toolType { get { return typeof(layer_base); } }
    public  void link(layer_base b) { upone = b; }
    public abstract void load();//只是一个提醒 可能不需要
    
    public layer_base upone;
    public virtual Host host() { return upone.host(); }
    public virtual Mini_G Group() { return upone.Group(); }public virtual Mini mini() { return upone.mini(); }
    public virtual change_G changeG() { return upone.changeG(); }public virtual change_ change() { return upone.change(); }
    public void outputchange(Call_ c) { }
    //public virtual skill_ skill() { return change() != null ? change().skill() : null; }     public virtual change_ change() { return null; }
    //加入玩家

    public T addskill<T>() where T : skill_, new()
    {
        if (toolType != typeof(Mini)) return null;
        T newone = new T();newone.link(this); newone.load();
        return newone;
    }

    public T addcard   <T>() where T :card_, new()
    {
        if (toolType != typeof(Mini)) return null;
        T newone = new T();newone.link(this);newone.load();

        return newone;
    }
    public card_ addcard(int n)
    {
        if (toolType != typeof(Mini)) return null;
        card_ newone=creaater.creat_card(n);newone.link(this);newone.load();

        return newone;
    }
    public T addChange<T>() where T : change_, new()
    {
        if (GetType() != typeof(change_G)) return null;
        T newone = new T();newone.link(this);newone.load();

        return newone;
    }

    public virtual Mini_G find_Group(int ID)
    { return host().IDgroup.ContainsKey(ID) ? host().IDgroup[ID] : null; }
    public virtual Mini find_mini(int ID)
    { return host().IDmini.ContainsKey(ID) ? host().IDmini[ID] : null; }

}

public class order_
{
    public Type type;
    public  int miniID;
    
}
