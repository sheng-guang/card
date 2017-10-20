using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//mode-六角形地图
public class mode_sixAngle : mode
{
    public float Ax { get { return 2; } }
    public float Ay { get { return 0; } }
    public float Bx { get { return 1; } }
    public float By { get { return 1.732f; } }
    public override void gameLoad_Link()
    {
        factory.addHostPlayer();
        factory.addplayer();
        factory.addplayer();
    }

    public override void gameStart()
    {
        foreach (KeyValuePair<int, CardPlayer> p in player_L)
        {
            p.Value.get_P.newMainobj();//创建英雄
        }
    }
}
