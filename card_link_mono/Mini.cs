using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//普通mini只能是建筑和被动随从
//没有主动技能
public abstract class Mini : layerBase {

    public int ID; public override Mini mini()  { return this;  }
    public override void _GetIDload()
    {
       ID = host().next.NextminiID;
        host().IDmini.Add(ID, this);
       player().id_minis.Add(ID);
    }

    public Buffs buffList;
}
