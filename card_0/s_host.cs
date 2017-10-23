using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public class host_base : layer_base
{
    public override void add_in_systerm()
    {
        throw new NotImplementedException();
    }

    public override mini find_mini(int ID)
    {
        return null;
    }
}

public  class host:host_base
{
    public Dictionary<int, mini> IDmini = new Dictionary<int, mini>();
    public Dictionary<int, mini_G> IDgroup = new Dictionary<int, mini_G>();

}


