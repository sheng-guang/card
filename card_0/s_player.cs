using System;
using System.Collections;
using System.Collections.Generic;
public abstract class Mini_G:layer_base_ID
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
    public cardG_card cards=new cardG_card();
    
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

    public playerData data=new playerData();

}
public class playerData
{
    int energy;

    public void changeEnergy(int n) { }
}
public class cardG_card:CardG_int
{
    //手牌
    public List<card_> HandList = new List<card_>();
    //手牌是否有
    public bool havecard(int which) { if (HandList.Count > which) return true; else return false; }
    //which牌是否能用
    public bool cardCando(int which, order_ o) { if (havecard(which) && HandList[which].test_data(o)) return true; else return false; }
    //抽n张牌
    public void draw_N_ToHand(int n) { }
    //直接加入手牌
    public void addWhichToHand(int ID) { }
    //直接加入卡组
    public void addWhichToGroup(int ID) { }
}
public class CardG_int
{
    //初始化
    public void firstload() { }
    public List<card_ID_num> ID_num = new List<card_ID_num>();
    //加入一张
    public void add1(int ID) { }
    //ID//随机删除一张
    public int  remove1() { return 1; }
    //改变某种为另一种或者改为无
    public void change1(int IDfind,int IDto) { }
    //num//有几张
    public int find1(int ID) { return 1; }
}

public class card_ID_num
{
    int ID;int which;
}