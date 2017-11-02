using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_3d : MonoBehaviour {

    public host_3d host;
    public Mini_G miniG;
    public void giveOrder(int ID,int skill,order_ o )
    {
        miniG.getOrder(ID, skill, o);
    }

}
