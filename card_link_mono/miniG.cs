using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniG : layerBase
{

    public int ID;public override miniG player()  {    return this;}
    public Mini main;
    public override void _GetIDload()
    {
        ID = host().next.NextGID;host().IDgroup.Add(ID, this);
        cards = addtriggerBase<cardG>(true);
    }

    public List<int> id_minis;
    public bool ownMini(int id) { return id_minis.Contains(id) ? true : false; }
    public List<int> id_trigger;
    public bool ownTrigger(int id) { return id_trigger.Contains(id) ? true : false; }
    //1
    //2用卡
    public void getorder(int which, order o)
    {
        cards.getorder(which, o);
    }
    //3组合分离
    public void givecardTo(int where,int cardID,int trigID)
    {
        card_ to=null;Trigger t = findTrig(trigID);
        if (where == 0) {
            if ((to= cards.OnHand[cardID]) == null) return;
            if (ownTrigger(trigID) == false || t == null) return;
            t.ToDocard = to;
        }
    }
    public void removeCardFrom(int cardID) {

    }
    //4分解卡牌
    public void decompose(int which) { }
    //public List<Trigger>triggers
    public cardG cards;
}


public struct CardOnDesk
{
    public int ID;//为-1表示不存在
}
//提供一个目标mini
public abstract class cardUser : Trigger
{
    //运行函数
    public bool getDataToDo(order o)
    {
        if (loadTarget(o.miniID) == false) return false;
        if (TESTFei() == false) return false;
        return true;
    }
    public virtual bool loadTarget(int ID)
    {
        Mini to = findMini(ID);
        //对to询问:是否是卡牌目标
        ToDocard.Target = to;
        return ToDocard.Target == null ? false : true;
    }
    public virtual bool TESTFei()
    { return false; }
}


public class order
{
    public  int miniID;
    //Mini the;
}