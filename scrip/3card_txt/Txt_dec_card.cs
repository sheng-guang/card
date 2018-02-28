using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Txt_dec_card : CardTxt
{
    public override step_target test(step_target d)
    {
        return d;
    }
    //public override step_target test(order o)
    //{
    //    if(o.usecard)
    //}
    public override bool run_and_Pop(Dictionary<CardTxt, step_target> data)
    {
        throw new System.NotImplementedException();
    }
}
