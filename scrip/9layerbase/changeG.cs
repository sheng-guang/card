using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//改变组
public abstract class CardTxt:MonoBehaviour  {


    //[Header("-------------------------TXT")]

    public virtual step_target test(step_target d)
    {
        return d;
    }

    public abstract bool run_and_Pop(Dictionary<CardTxt,step_target> data);

    public static void docall(Host h, Call_ c)
    {
        if (h.skill.OnGoing == false) return;

        foreach (Card_m m in h.Beens.Call_List)
        {
            m.getcall(c);
        }
    }
}

