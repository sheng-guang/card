using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class miniG : layer_withID
{
    public override miniG player()  {    return this;}
    public Mini main;

    public override void _GetIDload()
    {
        beens.Add(this);
        cards = addtriggerBase<cardG>(true);
    }

   
    //1
    //2用卡
    public void getorder(int which, order o)
    {
        //判断距离 目标可用
    }
    //3组合分离
    public void givecardTo(int where,int cardID,int trigID)
    {
        //判断距离 锁定 给
    }
    //4移除
    public void removeCardFrom(int cardID) {
        //判断距离 锁定 拿出卡牌
    }
    //5分解卡牌
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