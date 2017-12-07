using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Mini : layer_withID {

    public override Mini mini()  { return this;  }
    public override void _load() {  }

    private bool iscard;
    //变成卡牌的触发器里面是卡牌
    public cardTrigger maincard;

    public Buffs buffList;
}

public abstract class cardTrigger : Trigger
{

}


