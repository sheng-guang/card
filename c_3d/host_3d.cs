using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class host_3d : MonoBehaviour {


    public  Host h;

    public void startGame()
    {
        h = new Host(0);
        h.loadGame_waitLink();
        print(h.IDmini.Count + "" + h.IDgroup.Count);
        //print(h.IDmini[0] +""+ h.IDmini[1]);
        //h.gameStart();
    }
	

}
