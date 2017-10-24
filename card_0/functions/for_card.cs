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

public abstract class layer_base : IFor_layer
{
    public  int ID;

    public virtual Host host() {return null; }public virtual Mini_G  Group() {return null; }
    public virtual Mini_G find_Group(int ID)
    { return host().IDgroup.ContainsKey(ID) ? host().IDgroup[ID] : null; }
    public virtual Mini find_mini(int ID)
    { return host().IDmini.ContainsKey(ID) ? host().IDmini[ID] : null; }

    
    //加入玩家
    public void addminiG() {
        if (Group() != null) return;
        Mini_G newone = new Mini_G();
        newone.ID = host().NextGID;
        host().IDgroup.Add(newone.ID, newone);
    }
    //加入随从
    public T addmini<T>() where T: Mini, new()
    {
        if (Group() == null) return default(T);
        T newone = new T();
        int ID=host().NextminiID;
        newone.ID = ID;
        host().IDmini.Add(ID, newone);
        Group().IDmini.Add(ID);
        return newone;
    }


}

