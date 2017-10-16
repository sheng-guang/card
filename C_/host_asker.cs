using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class host_asker : MonoBehaviour {

    gameHost h;
    public int modeK;
    public test_player pReady;
    public GameObject testplace;
	void Start ()
    {
        testplace.SetActive(false);
        h = new gameHost(modeK);//包含创建player
                                //print(h.factory);
                                //print(h.mode);
                                //print(h.player_L[1] );
                                //print(h.player_L[2]);
                                //链接player
        foreach (KeyValuePair<int ,CardPlayer> p0 in h.player_L)
        {
            var p= Instantiate(pReady);
            p.link(this,p0.Value);
        }
        //游戏开始
        h.mode.gameStart();
	}
    public Dictionary<int, test_player> id_player = new Dictionary<int, test_player>();
	

}
