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
    //public virtual void link_load() { }
    //public virtual void link_load(Host h) { } public virtual void link_load(Mini_G g) { } public virtual void link_load( Mini m) { }
    //public virtual void link_load(skill_ s) { }
    public abstract void load();
 
    public virtual Host host() { return Group() != null ? Group().host() : null; }
    public virtual Mini_G Group() { return mini() != null ? mini().Group() : null; }  public virtual Mini mini() { return /*skill() != null ? skill().mini() :*/ null; }
    //public virtual skill_ skill() { return change() != null ? change().skill() : null; }     public virtual change_ change() { return null; }

    public virtual Mini_G find_Group(int ID)
    { return host().IDgroup.ContainsKey(ID) ? host().IDgroup[ID] : null; }
    public virtual Mini find_mini(int ID)
    { return host().IDmini.ContainsKey(ID) ? host().IDmini[ID] : null; }

}


