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
        if (cards.havecard(which)) cards.HandList[which].decompose();
    }
    public playerData data=new playerData();

}
public class playerData
{
    int maxenergy;
    int energy;
    public void EnergyAdd(int add) { energy += energy; fixenergy(); }
   
    public void MaxAdd(int add) { maxenergy += add; fixenergy(); }

    public void MaxChangeto(int newMax) { maxenergy = newMax; fixenergy(); }
    public void EnergyMaxChangeTo(int newE) {maxenergy = newE; energy = newE; }
    void fixenergy() {
        if (energy >= maxenergy) energy = maxenergy;
        else if (energy <= 0) energy = 0;
    }
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
    public void draw_N_ToHand(int n)
    {
        while (n-- >= 1) { addWhichToHand( G_remove1()); }
    }
    //直接加入手牌
    public void addWhichToHand(int ID)
    {
        if (ID == 0) return;
        if (HandList.Count <= 10 ) {
            HandList.Add(addcard(ID));
        }
    }
    //直接加入卡组
    public void addWhichToGroup(int ID) {
        G_add1(ID);
    }

}
public class CardG_int:layer_base
{    
    //初始化
    public void firstload() { }
    protected LinkedList<card_node> Group_card = new LinkedList<card_node>();
    public int G_amount { get { return Group_card.Count; }}
    //1加入一张
    protected bool G_add1(int ID) {
        if (G_amount >= 60) return false;
        Group_card.AddLast(new card_node(ID));
        return true;
    }
    //2删除第一张
    protected int  G_remove1()
    {
        if (G_amount <= 0) return 0;
        int n = Group_card.First.Value.ID; Group_card.RemoveFirst();return n;
    }
    //3有几张
    public int G_haveNum(int ID) {
        int n=0;
        foreach(card_node c in Group_card)if (c.ID == ID) n++;
        return n;
    }

    public override void load()
    {
        
    }
    //改变某种为另一种或者改为无
    //public void change1(int IDchange,int IDto) { }
}
public class card_node
{
    public card_node(int I) { ID = I; }
    public int ID;
}