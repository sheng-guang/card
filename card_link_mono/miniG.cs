using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class miniG : layer_withID
{
    public override miniG player()  {    return this;}
    public override void load_ForCreater()
    {
        cards = ADDcomponet<cardG>();
    }

    /// <summary>
    /// cardG里面目前什么都有-_- 
    /// </summary>
    public cardG cards;
}
