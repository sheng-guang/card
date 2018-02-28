using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tr_dec_card : Trigger_byinput {
    public override bool Do_order(order d)
    {
        step_target data = test(d);
        if (data == null) return false;
        if (data.user.deconposs) { host().CopyDo_cardTxt(data.user.deconposs, data,true,host()); }
        else askHostDo(data,true);
        return true;
    }
    public override step_target test(order o)
    {

        if (o.usecard.state != cardWhere.hand) { return null; }
        if (o.usecard.deconposs)
        {
            step_target s = new step_target();

        return o.usecard.deconposs.test(s); }//战吼特殊使用测试
        //普通使用测试
        else
        {
            //测试距离
            //if(o.usecard.distance<(o.Target_pos-o.usecard.player().hero.transform.position).magnitude )
            //{ return null; }
            //测试费用
            step_target s = new step_target();

            s.user = o.usecard;
            s.targretposs = o.Target_pos;
            return s;
        }
    }


}
