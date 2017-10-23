using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public struct NextIDs
{
    public NextIDs(int n) { nextobj = 1; nextorder = 0; nextPlayer = 1; }
    public int nextorder,nextPlayer,nextobj;
}

public abstract class host_base : layer_base
{
    private NextIDs next = new NextIDs(0);
    public int NextorderID { get { return next.nextorder++; } }
    public int NextminiID { get { return next.nextobj++; } }
    public int NextGID { get { return next.nextPlayer++; } }


    public Dictionary<int, mini_G> IDgroup = new Dictionary<int, mini_G>();
    public Dictionary<int, mini> IDmini = new Dictionary<int, mini>();

}

public  class Host:host_base
{
    public override Host host(){return  this; }



}


