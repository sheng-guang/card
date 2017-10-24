using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Gr_base : layer_base
{
    private Host upHost;//为空需补全
    public override Host host(){ return upHost; }

    public List<int> IDmini = new List<int>();
    public bool haveMini(int ID) { if (host().IDmini.ContainsKey(ID) && IDmini.Contains(ID)) return true; else return false; }
    public bool haveSkill(int ID,int which) { if (haveMini(ID) && find_mini(ID).haveskill(which)) return true; else return false; }
    public bool skillCando(int ID,int which,List<byte> d) { if(haveSkill(ID,which)&&find_mini(ID).skills[which].test_data(d)) return true; else return false; }
    public cardGroup cards;//运行之后为空需补全
    public bool havecard(int which) {if(cards.List.Count>which) return true; else return false; }
    public bool cardCando(int which, List<byte> d) {if(havecard(which)&&cards.List[which].test_data(d)) return true; else return false; }
}
public class Mini_G:Gr_base
{
    public override Mini_G Group()  {  return this; }

    public void getOrder(int MID,int Which, List<byte> data) { if (testOrder(MID,Which, data)) { doOrder(MID, Which, data); } }

    public bool testOrder(int MID,int Which,List<byte> d)
    {
        if (MID >= 0) { if (skillCando(MID, Which, d)) return true; }
        else if (MID == -1) { if (cardCando(Which, d)) return true; }
        return false;
    }
    public void doOrder(int MID, int Which, List<byte> d)
    {
        if (MID >= 0) { find_mini(MID).doSkill(Which, d); }
        else if (MID == -1) { cards.List[Which].do_(d); }
    }


    public void Be()
    {

    }

}

public class cardGroup
{
    public List<card_> List = new List<card_>();
}
public class card_ : skill_
{

}