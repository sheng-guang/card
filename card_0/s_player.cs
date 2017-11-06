using System;
using System.Collections;
using System.Collections.Generic;
public abstract class Mini_G:layer_base
{
    public override Type toolType { get { return typeof(Mini_G); } }
    public override Mini_G Group()  {  return this; }

    //随从
    public List<int> IDmini = new List<int>();
    public bool haveMini(int ID) { if (host().IDmini.ContainsKey(ID) && IDmini.Contains(ID)) return true; else return false; }
    //技能
    public bool haveSkill(int ID,int which) { if (haveMini(ID) && find_mini(ID).haveskill(which)) return true; else return false; }
    public bool skillCando(int ID,int which, order_ o) { if(haveSkill(ID,which)&&find_mini(ID).skills[which].test_data(o)) return true; else return false; }
    //卡牌
    public cardGroup cards=new cardGroup();
    
    //order
    public void getOrder(int MID,int Which, order_ o)
    { if (testOrder(MID,Which, o)) { doOrder(MID, Which, o); } }
    bool testOrder(int MID,int Which, order_ o)
    {
        if (MID >= 0) { if (skillCando(MID, Which, o)) return true; }
        else if (MID == -1) { if (cards.cardCando(Which, o)) return true; }
        return false;
    }
    void doOrder(int MID, int Which, order_ o)
    {
        //技能
        if (MID >= 0) { find_mini(MID).skills[Which].GetData_do(o); }
        //上传//卡牌
        else if (MID == -1) { host().Doskill_card( cards.HandList[Which]); }
    }
    //behaviour操作
    public void composeSkill() {

    }
    public void decomposecard(int which)
    {

    }


    public void Be()
    {
        
    }

}

public class cardGroup
{
    public List<card_> HandList = new List<card_>();
    //public List<>
    public bool havecard(int which) { if (HandList.Count > which) return true; else return false; }
    public bool cardCando(int which, order_ o) { if (havecard(which) && HandList[which].test_data(o)) return true; else return false; }

    public void firstload() { }
}
public class cardNode
{
    public cardNode upone;
    public bool used;
    public cardNode nextone;

}