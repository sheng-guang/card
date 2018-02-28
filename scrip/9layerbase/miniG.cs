using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class miniG : layerBase
{
    public int ID; public override miniG player()  {  return this;  } 
    public List<int> cards = new List<int>();
    public List<int> inhand = new List<int>();
    public List<int> inspace = new List<int>();
    public List<int> indeck = new List<int>();
    public void List_removeone(int id)
    {
        cards.Remove(id);inhand.Remove(id);inspace.Remove(id);indeck.Remove(id);
    }
    public void List_addone(Card_m c) {
        cards.Add(c.ID);
        switch (c.state) {
            case cardWhere.deck:indeck.Add(c.ID);break;
            case cardWhere.hand:inhand.Add(c.ID);break;
            case cardWhere.space3d: inspace.Add(c.ID);break;
        }
    }
    public button_keep wsda = new button_keep();
    public hero hero;
    //从网络来的输入 先进入缓冲队列等候
    public void getinput(inputpackage p)
    {
        p.From = this;
        host().addTodoInput(p);
    }

    //顺序结算
    public void useinput(inputpackage p)
    {
        //if (p.wasd) { }
        if (p.useCard_skill)
        {
            card_mini c = mini(p.user).minion;//可能是手牌也可能是场上的
            if (c!=null&&cards.Contains(p.user))
            {
                order o = new order();
                o.usecard = mini( p.use_mini);
                o.whichTrigger = p.use_trigger;
                //------------------------------------
                o.Target_pos = p.targetposs;
                o.Target_card = mini(p.target_mini);
                o.Target_trigger = trigger(p.target_trigger);
                o.action = p.action;

               bool r= c.get_Input_order(o);
                if (r == false) print("tool  false");
            }
        }
    }


    public void freshWSDA(bool w,bool s,bool d, bool a)
    {

        wsda.w = w;
        wsda.s = s;wsda.d = d;wsda.a = a;
    }
    //到卡组 /到手牌/到场上
    //接收任意卡牌到己方的任意位置
    public void TXT_setHero(hero h)
    {
        hero = h;
    }
    public void TXT_move_card_to(Card_m c,cardWhere towhere)
    {
        //0进入层级
        if (c.upone == null) { beens.Add_in_layer(c, this); }
        //1变形悬在空中
        bool tonewplace=false;
        switch (towhere)
        {
            case cardWhere.space3d:tonewplace= c.Transform_ToMini(Vector3.zero);break;
            case cardWhere.hand:tonewplace= c.Transform_ToCard();break;
            case cardWhere.deck:tonewplace= c.Transform_ToDeck();break;
        }
        //2放下到指定地方
        //转变所有者
        c.player().List_removeone(c.ID);
        c.upone = this;
        c.player().List_addone(c);
        //注册 //如果到了新地方就刷新call
        if (tonewplace)
        {
            //print("-----");
            beens.removeCall(c);
            if (towhere == cardWhere.hand || towhere == cardWhere.space3d)
                beens.add_in_call_L(c);
        }

    }
    //随机抽一张牌

    public Card_m cardindeck()
    {
        return null; 
    }

    public LinkedList<Card_m> deck = new LinkedList<Card_m>();

}




public struct button_keep
{
    public  bool w, s, d, a;
    public int ws { get { return w ? 1 : (s ? -1 : 0); } }
    public int da { get { return d ? 1 : (a ? -1 : 0); } }
}

public struct CardInDeck
{
    public int ID;//为-1表示不存在
}


public enum cardWhere
{
    outlayer,space3d, hand, deck,drop
}    

//1获取卡牌 / 单位
    //从哪里来的 什么状态的牌
    //可以分很多函数 来添加不同完成度的单位(单位编号-空的-已经链接好的)//工厂也相同
    //public void getcard_mini(Card_m m, cardWhere where)   {  }//已经完成的mini
    ////3组合分离
    //public void givecardTo(int where, int cardID, int trigID)
    //{
    //    //判断距离 锁定 给
    //}
    ////4移除
    //public void removeCardFrom(int cardID)
    //{
    //    //判断距离 锁定 拿出卡牌
    //}
    ////5分解卡牌
    //public void decompose(int which) { }