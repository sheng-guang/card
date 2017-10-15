using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public void getinfo(outinfo i)
    {
        
        if (i.PID == ID) { show(i); }
    }
    private void  show(outinfo i)
    {
        print(i.PID +"-"+ i.OID+"-"+i.k);
        if (i.k == outinfo_K.obj_new) {
            test_obj o = Instantiate(obj, obj_space.transform);
            
            o.link_load(this, i.OID);

        }
        if (i.k == outinfo_K.obj_destory) { }
        if (i.k == outinfo_K.c_hp) { id_obj[i.OID].upData_obj(); }
        
    }

    public Dictionary<int, test_obj> id_obj = new Dictionary<int, test_obj>();

    public test_obj obj;
    public Transform obj_space;











    public void giveorder(byte[]data,order_K k,int id1,int which)
    {
        p.getData_order(data, k, id1, which);
        
    }
}
