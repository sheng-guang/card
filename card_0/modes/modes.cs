using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class mixmode : Hostmode
{
    public override void load()
    { }

    public override void loadGame_waitLink()
    {
        player p;
        //p= host().addMiniG<player>();
        //Debug.Log( p.addMini<mini_main>());
        //p= host().addMiniG<player>();
        //p.addMini<mini_main>();
    }
    public override void gameStart()
    {
       //释放第一回合开始call
    }
}