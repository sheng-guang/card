﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class test_player : MonoBehaviour {
    public host_asker asker;
    public CardPlayer p;
    public int ID;
    public void link(host_asker a,CardPlayer p0)
    {
        asker = a;
        
        p = p0;ID = p.ID;
        a.id_player.Add(ID, this);
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
            foreach(test_obj obj in objposs)
            {
                obj.upData_poss();
            }
        }
        if (i.k == outinfo_K.obj_destory) {
            test_obj o = id_obj[i.OID];
            objposs.Remove(o);
            id_obj.Remove(o.obj_id);
            Destroy(o.gameObject);
            foreach (test_obj obj in objposs)
            {
                obj.upData_poss();
            }
        }
        if (i.k == outinfo_K.c_hp) { id_obj[i.OID].upData_obj(); }
        
    }

    public Dictionary<int, test_player> id_player { get { return asker.id_player; } }
    public Dictionary<int, test_obj> id_obj = new Dictionary<int, test_obj>();
    public List<test_obj> objposs = new List<test_obj>();
    public test_obj obj;
    public Transform obj_space;











    public void giveorder(byte[]data,order_K k,int id1,int which)
    {
        p.getData_order(data, k, id1, which);
        
    }
}
