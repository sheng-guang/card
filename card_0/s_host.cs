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
    public override void link_load() { load(); }
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
    public override void load()
    {
    }
    
    //加入玩家
    public void addminiG()
    {
        if (Group() != null) return;
        Mini_G newone = new Mini_G();
        newone.link_load(this);
        host().IDgroup.Add(newone.ID, newone);
    }
    Hostmode mode;
    //开始
    public void loadGame_waitLink() { }
    public void gameStart() { }
    //使用技能
    public void Doskill() { }
    public void Docall() { }
    public void Dotrigger() { }


}
public abstract class Hostmode
{
    //开始
    public abstract void loadGame_waitLink();
    public abstract void gameStart();

    //操做技能
    public  void doskill() { }
    public void docall() {}
    public void addtrigger() { }
}


