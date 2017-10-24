using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public struct NextIDs
{
    public NextIDs(int n) { lastmini = 0; lastorder = 0; lastPlayer = 0; }
    public int lastorder,lastPlayer, lastmini;
}

public abstract class host_base : layer_base
{
    private NextIDs next = new NextIDs(0);
    public int NextorderID { get { return ++next.lastorder; } }
    public int NextminiID { get { return ++next.lastmini; } }
    public int NextGID { get { return ++next.lastPlayer; } }


    public Dictionary<int, Mini_G> IDgroup = new Dictionary<int, Mini_G>();
    public Dictionary<int, Mini> IDmini = new Dictionary<int, Mini>();
    
    public Dictionary<int, List<byte>> ID_Data = new Dictionary<int, List<byte>>();
    public List<byte> testingOrder;
}

public  class Host:host_base
{
    public override Host host(){return  this; }
    Hostmode mode;
    public void loadGame_waitLink() { }
    public void gameStart() { }
    public void Doskill() { }
    public void Docall() { }
    public void Dotrigger() { }



}
public abstract class Hostmode
{

    public abstract void loadGame_waitLink();
    public abstract void gameStart();
    public abstract void addskill();

}


