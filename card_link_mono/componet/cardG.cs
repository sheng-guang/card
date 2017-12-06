using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//卡组 触发器管理者
public class cardG : cardUser
{
    public List<card_> from_Mini = new List<card_>();
    //手牌中的
    public List<card_> OnHand = new List<card_>();

    public void getorder(int which, order o)
    {
        if (OnHand[which] == null) return; ToDocard = OnHand[which];
        getDataToDo(o);
    }

}

//提供一个目标mini
public abstract class cardUser : Trigger
{
    //运行函数
    public bool getDataToDo(order o)
    {
        Mini to;
        if ((to = loadTarget(o.miniID) )) return false; 
        //对to询问:是否是卡牌目标
        if (TESTFei() == false) return false;
        ToDocard.Target = to;
        return true;
    }
    
    public virtual Mini loadTarget(int ID)
    {
        return findMini(ID);
    }
    public virtual bool TESTFei()
    { return false; }
}