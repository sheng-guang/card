using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Txt_flyuse : CardTxt
{
    public override step_target test(step_target d)
    {
        return d;
    }
    //魔法卡 召唤一个fly 飞向mini
    public override bool run_and_Pop(Dictionary<CardTxt, step_target> data)
    {
        step_target d = data[this];

        Card1_1fly f = createrMono.creater.aEmptycard<Card1_1fly>();
        //2交给玩家变成mini
        d.user.player().TXT_move_card_to(f, cardWhere.space3d);
        //设置位置和目标
        f.transform.position = d.user.transform.position;
        f.target = data[this].targetcard;
        return true;
    }
}
