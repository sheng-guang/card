using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public enum order_K
{
    usecard,
    useskill,
}

public abstract  class sPlayer_Board
{   
    //host
    public gameHost host;
    public  int next_Orede_id { get { return host.nextorderID; }}
    public int next_Obj_id { get { return host.nextobjID; } }
    //in
    public abstract void getData_order(byte[] data, order_K k, int ID1, int which);
    //public void getdata(byte[] data)
    //{foreach (byte b in data) orderID_Data.Add(next_Orede_id, b);}
    // public Dictionary<int, byte> orderID_Data = new Dictionary<int, byte>();

    //out
}



public class CardPlayer:sPlayer_Board
{
    public CardPlayer()
    {
       cards= addcomponet<cards>();
       pskills=  addcomponet<Pskills>();
       get_P= addcomponet<Pget_effect>();
    }
    public int ID;
    public Dictionary<int, SkillObj> ID_obj=new Dictionary<int, SkillObj>();
    //寻找obj
    public SkillObj find_the(Target_K1 k1, Target_K2 k2, int pID, int oID)
    {
        SkillObj to = null;
        //下面判断需要改成位运算
        if (pID == ID && k1 == Target_K1.enemy)  return null; 
        if (pID != ID && k1 == Target_K1.friend)  return null;
        to = find_the(pID, oID);
        if (to == null) return null;
        if (((int)to.obj_K & (int)k2) == 0) return null;

        return to;
    }
    public SkillObj find_the(int pID, int oID) {
        if (host.player_L.ContainsKey(pID) && host.player_L[pID].ID_obj.ContainsKey(oID))
            return host.player_L[pID].ID_obj[oID];
        else return null;
    }

    //组件
    public cards cards;
    public Pskills pskills;
    public Pget_effect get_P;
    
    //获取命令
    public override void getData_order(byte[] data,order_K k,int ID1, int which)
    {
        
        //测试order是否正确
        if (k == order_K.usecard) {
            
            if (!cards.orderTest(data, ID1, which)) return;
        }
        else if (k == order_K.useskill) { //Debug.Log("useskill");
            pskills.orderTest_Do(data, ID1, which); }
        else { Debug.Log("orderFalse"); }
    }

    public T  addcomponet<T>()where T : componet_player, new()
    {
        T newone = new T(); newone.player = this; return newone;
    }
}
//被影响
public class Pget_effect : componet_player
{
    //新英雄
    public void newMainobj() {
        obj_main newo = SkillObj.getmain();
        newo.link_load(player, 0);
        output(new outinfo(player.ID, 0, outinfo_K.obj_new));
    }
    //新单位
    public void newobj<T>()where T:SkillObj,new()
    {
        T newone = new T();
        newone.link_load(player,player.next_Obj_id);
        output(new outinfo(player.ID, newone.OID, outinfo_K.obj_new));  
    }
    public void destoryOBJ(int oID)
    {
        SkillObj o = ID_obj[oID];
        o.before_destory();
        output(new outinfo(player.ID, o.OID, outinfo_K.obj_destory));
        o = null;
    }
}

//用技能
public class Pskills : componet_player
{
    public bool orderTest_Do(byte [] b,int ID1,int which)
    {
        if (ID_obj.ContainsKey(ID1)) {
            Debug.Log("haveobj");
            return ID_obj[ID1].test_do_skills(which, b); }
        else return false;
    }
}
//卡牌
public class cards : componet_player
{
    //List<card_> on_hand = new List<card_>();
    public bool orderTest(byte[] b, int ID1, int which) { return true; }
    public void usecard( int orderNum,int ID1,int which)
    {

    }
}


public class eventreport
{

}


