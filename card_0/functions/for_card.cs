using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public abstract class layer_base : IFor_layer
{
    public virtual void add_in_systerm() { }

    
    public virtual host host() {return null; }public mini_G Group() {return null; }

    public virtual mini_G find_Group(int ID) { return null;  }  public virtual mini find_mini(int ID) { return null; }

}
public interface IFor_layer {
    host host();
    mini_G Group();
    mini_G find_Group(int ID);
    mini find_mini(int ID);
    void add_in_systerm();
}
