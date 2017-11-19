using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class card_onedamage : HPchange
{

    public override void run(Mini Target)
    {
        ChangeToMini.changeHP(Target, this);
    }
}
