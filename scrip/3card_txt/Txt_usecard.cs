using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//使用卡牌 txt
//以后可以重写成有战吼的
public class Txt_usecard : CardTxt {
    public override step_target test(step_target d)
    {
        //这里 测试下面 的run所需要的数据是否齐全；
        return d;
    }
    public override bool run_and_Pop(Dictionary<CardTxt, step_target> data)
    {
        step_target d = data[this];
        Card_m user=data[this].user;
        Card_m usecard= data[this].usecard;
        if (d.nextstep == 0)
        {  //还要扣费
            //call
            docall(user.host(), new Call_mini(usecard, usecard.ID, false, true));
            d.nextstep = 1;return false;
        }
        else if (d.nextstep == 1)
        {
            //召唤
            user.player().TXT_move_card_to(usecard, cardWhere.space3d);

            usecard.transform.position = d.targretposs;
            //call
            docall(user.host(), new Call_mini(usecard, usecard.ID, true, true));
            return true;
        }
        return true;
    }

}
