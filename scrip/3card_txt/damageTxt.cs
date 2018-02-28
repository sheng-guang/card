using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageTxt :CardTxt {
    public int damage;

    public override bool run_and_Pop(Dictionary<CardTxt, step_target> data)
    {
        step_target d = data[this];
        //print("-"+damage+d.target.ToString());
       HPchange_info ret = d.targetcard.minion.TXT_getdamage(damage,HPchange_K.normal_Dam);
        if (ret.change<0) docall(d.user.host(),new call_HP());
        return true ;

    }
}
