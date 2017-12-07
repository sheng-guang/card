using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//卡组 触发器管理者
public class cardG :layerBase
{
    public List<int> minis = new List<int>();
    public List<int> triggers = new List<int>();

    public Mini main;
    //1获取卡牌
    public void getmini(Mini m)
    {

    }
    //2用卡
    public void getorder(int which, order o)
    {
        //判断距离 目标可用
    }
    //3组合分离
    public void givecardTo(int where, int cardID, int trigID)
    {
        //判断距离 锁定 给
    }
    //4移除
    public void removeCardFrom(int cardID)
    {
        //判断距离 锁定 拿出卡牌
    }
    //5分解卡牌
    public void decompose(int which) { }
}


public struct CardInDeck
{
    public int ID;//为-1表示不存在
}

public class order
{
    public int miniID;
    //Mini the;
}