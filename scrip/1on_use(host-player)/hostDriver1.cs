using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hostDriver1 : MonoBehaviour
{
    public Host h;    


    public void Start()
    {
        start_game();
    }
    public List<miniG> player = new List<miniG>();

    public void start_game()
    {
        h.loadGame_waitLink();
        
        foreach (KeyValuePair<int,miniG> m in h.Beens.IDgroup)
        {
            player.Add(m.Value);
        }
        addClient_player(player[0]);
        h.gameStart();
    }

    public void FixedUpdate()
    {
        h.getTime_0_01s();
    }



    //本地玩家
    public void addClient_player(miniG p)
    {
        clientPlayer pl = clientCreater.creater.getplayer();
        pl.m = p;
        cplayer.Add(pl);
    }
    public List<clientPlayer> cplayer = new List<clientPlayer>();

    public void getinfo(out_info i)
    {
        foreach(clientPlayer c in cplayer) { c.getinfo(i); }
    }

}

