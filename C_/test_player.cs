using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_player : MonoBehaviour {

    public CardPlayer p;
    public int ID;
    public void link(CardPlayer p0)
    {
        p = p0;ID = p.ID;
        //print(p);
        //订阅p的事件
        p.host.out_ += getinfo;
    }

    public void giveorder(byte[]data,order_K k,int id1,int which)
    {
        p.getData_order(data, k, id1, which);
    }


    public void getinfo(outinfo i)
    {
        if (i.PID == ID) { show(i); }
    }
    private void  show(outinfo i)
    {

        print(i.PID +" "+ i.OID+"  "+i.k);
    }

}
