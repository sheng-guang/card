using System;
using System.Collections;
using System.Collections.Generic;
public class Mini_G:layer_base
{
//public abstract class Gr_base : layer_base
//{
    public  void link_load(Host h){
        upone = h; ID = host().next.NextGID;
        load(); }
    public override Host host(){ return upone.host(); }

    public List<int> IDmini = new List<int>();
    public bool haveMini(int ID) { if (host().IDmini.ContainsKey(ID) && IDmini.Contains(ID)) return true; else return false; }
    public bool haveSkill(int ID,int which) { if (haveMini(ID) && find_mini(ID).haveskill(which)) return true; else return false; }
    public bool skillCando(int ID,int which,List<byte> d) { if(haveSkill(ID,which)&&find_mini(ID).skills[which].test_data(d)) return true; else return false; }
    public cardGroup cards=new cardGroup();
    public bool havecard(int which) {if(cards.List.Count>which) return true; else return false; }
    public bool cardCando(int which, List<byte> d) {if(havecard(which)&&cards.List[which].test_data(d)) return true; else return false; }
//}public class Mini_G:Gr_base{

    public override Mini_G Group()  {  return this; }
    public override void load()
    {
        //cards= new cardGroup();
    }
    //加入随从
    public T addmini<T>() where T : Mini, new()
    {
        T newone = new T();
        newone.link_load(this);
        host().IDmini.Add(newone.ID, newone);
        Group().IDmini.Add(newone.ID);
        return newone;
    }

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
        //上传
        else if (MID == -1) { host().Doskill_card(new Queue<change_>( cards.List[Which].list)); }
    }
    public void Be()
    {

    }
}

public class cardGroup
{
    public List<card_> List = new List<card_>();
}
