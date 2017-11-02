using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_3d :layer_3d {

    public Mini_G miniG { get { return host().h.find_Group(ID); } }

    public void giveOrder(int ID,int skill,order_ o )
    {
        miniG.getOrder(ID, skill, o);
    }

    public override void load()
    {
        
    }
}
