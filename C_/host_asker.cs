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
        //订阅p的事件
        h.out_ += getinfo;
        //游戏开始
        h.mode.gameStart();
	}
    public void getinfo(outinfo i)
    {
        id_player[i.PID].upadta_num(i);
        infoL.Enqueue(i);
    }

    public void doinfo()
    {
        if (infoL.Count != 0)
        {
            outinfo to = infoL.Dequeue();
            outinfo_K k = to.k;
            id_player[to.PID].showINui(to);
            if(k== outinfo_K.obj_destory||k== outinfo_K.c_hp||k== outinfo_K.obj_new)
                while (infoL.Count!=0 &&infoL.Peek().k == k)
                {
                    to = infoL.Dequeue();
                    id_player[to.PID].showINui(to);
                }
        }
    }
    [Range(1, 20)]
    public int fixonce;
    int fix=0;
    public void FixedUpdate()
    {
        if (fix++ > fixonce)  fix = 0;  else return; 

        doinfo();
    }

    public Queue<outinfo> infoL = new Queue<outinfo>();

    public Dictionary<int, test_player> id_player = new Dictionary<int, test_player>();
	

}
