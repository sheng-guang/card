using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class miniG : layerBase
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
        
    }
    //3组合分离
    public void givecardTo(int where,int cardID,int trigID) { }

    public void removeCardFrom(int cardID) {

    }
    //4分解卡牌
    public void decompose(int which) { }
    //public List<Trigger>triggers
    public cardG cards;
}


public struct CardInDeck
{
    public int ID;//为-1表示不存在
}



public class order
{
    public  int miniID;
    //Mini the;
}