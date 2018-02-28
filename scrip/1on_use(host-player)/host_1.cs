using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class host_1 : Host
{
    [Header("host1")]
    public int hostPlayer;
    public int normalPlayer;

    public override void loadGame_waitLink()
    {

        int i = hostPlayer;
        while (i-- > 0)
        {

            Beens.Add_in_layer(creater.aEmptyPlayer<miniG_1>(), this);
        }
        i = normalPlayer;
        while (i-- > 0)
        {
            Beens.Add_in_layer(creater.aEmptyPlayer<miniG_1>(), this);
        }
        
    }
    public hostTxt loadgame;
    public override void gameStart()
    {
        CopyDo_cardTxt(loadgame, new step_target(), true, this);
    }

}
