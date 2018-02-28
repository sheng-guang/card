using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tr_usecard : Trigger_byinput
{
    //public void askHostDo(step_target data, bool a)
    //{

    //    host().CopyDo_cardTxt(ToDocard, data, a);
    //}
    public override bool Do_order(order d)
    {
        //step_target data = test(d);
        //data = ToDocard.test(data);
        //if (data == null) return false;
        //askHostDo(data, true);
        //return true;
        //测试
        step_target data = test(d);
        if (data == null) return false;
        if (data.usecard.use) {
            host().CopyDo_cardTxt(data.usecard.use, data, true,host()); }
        else
            host().CopyDo_cardTxt(ToDocard, data, true,host());
        return true;
    }

    public override step_target test(order o)
    {
        //使用卡牌的触发器
        //检测牌的状态  
        if (o.usecard.state != cardWhere.hand) { return null; }

        step_target s = new step_target(mini(),this,o);
        //检测触发器的范围 和使用次数；
        //是否拥有卡牌

        if (o.usecard.use) {
            return o.usecard.use.test(s);
        }
        else
        {
            return ToDocard.test(s);
        }
    }
    
}
