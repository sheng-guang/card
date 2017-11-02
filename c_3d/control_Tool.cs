using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_Tool : MonoBehaviour {

    public host_3d Host { get { return player.host; } }
    public player_3d  player;


    public void giveOrder(int ID, int skill, order_ o)
    {
       player.giveOrder(ID, skill, o);
    }



}
