﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;
//public class test_player : MonoBehaviour {
//    public host_asker asker;
//    public CardPlayer p;
//    public int ID;
//    public void link(host_asker a,CardPlayer p0)
//    {
//        asker = a;
        
//        p = p0;ID = p.ID;
//        a.id_player.Add(ID, this);
//    }
//    public void upadta_num(outinfo i)
//    {
//        if (i.k == outinfo_K.obj_new)
//        {
//            test_obj o = Instantiate(obj, obj_space.transform);
//            o.link_load(this, i.OID);
//            foreach (test_obj obj in objposs)
//            {
//                obj.D_poss();
//            }
//            o.gameObject.SetActive(false);
//        }
//        if (i.k == outinfo_K.obj_destory)
//        {
//            test_obj o = id_obj[i.OID];
//            objpossD.Remove(o);
//            foreach (test_obj obj in objposs)
//            {
//                obj.D_poss();
//            }
//        }
//        if (i.k == outinfo_K.c_hp)
//        {

//            id_obj[i.OID].D_data();
//        }
//    }

//    public  void  showINui(outinfo i)
//    {
//        if (i.k == outinfo_K.obj_new)
//        {
//            id_obj[i.OID].gameObject.SetActive(true);
//            foreach(test_obj obj in objposs)
//            {
//                obj.U_poss();
//            }
            
//            id_obj[i.OID].U_Data();
//        }
//        if (i.k == outinfo_K.obj_destory) {
//            test_obj o = id_obj[i.OID];
//            objposs.Remove(o);
//            id_obj.Remove(o.obj_id);
//            Destroy(o.gameObject);
//            foreach (test_obj obj in objposs)
//            {
//                obj.U_poss();
//            }
//        }
//        if (i.k == outinfo_K.c_hp) {

//            id_obj[i.OID].U_Data();
//        }
//    }

//    public Dictionary<int, test_player> id_player { get { return asker.id_player; } }
//    public Dictionary<int, test_obj> id_obj = new Dictionary<int, test_obj>();
//    public List<test_obj> objposs = new List<test_obj>();
//    public List<test_obj> objpossD = new List<test_obj>();
//    public test_obj obj;
//    public Transform obj_space;

//    public Slider d1, d2;
//    public Text t1, t2;
//    public byte  _1, _2;

//    public void c_data1()
//    {

//        _1 = (byte)d1.value;
//        if (p.host.player_L.ContainsKey(_1))
//        {
//            t1.text = _1.ToString();
//        }
//        else t1.text = "---";
//    }
//    public void c_data2()
//    {
//        int _n = (byte)d2.value;
//        if (id_player.ContainsKey(_1) && id_player[_1].objpossD.Count > _n)
//        { _2 = (byte)id_player[_1].objpossD[_n].obj_id; t2.text = _2.ToString(); }
//        else t2.text = "---";
//        //if (player.p.host.player_L.ContainsKey(_1) && player.p.host.player_L[_1].ID_obj.ContainsKey(_2))
//        //{ t2.text = _2.ToString(); }
//    }

//    public void giveorder(byte[]data,order_K k,int id1,int which)
//    {
//        p.getData_order(data, k, id1, which);
//        c_data1();
//        c_data2();
//    }
//}
