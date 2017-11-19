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