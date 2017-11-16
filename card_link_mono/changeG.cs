using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//改变队列-卡牌
public abstract class card_ : changeG_
{
    public override card_ card() { return this; }

    public abstract int fei { get; }
    public abstract void decpmpose();
}
//单个改变
public abstract class change_:layerBase
{
    public virtual int kind() {  return 0;  }
    public void run() { run(card().Target); }
    public abstract void run(Mini Target);
}

//改变组
public abstract class changeG_ : layerBase {
    //public override changeG_ changeG() { return this;  }
    public Queue<change_> list = new Queue<change_>();
    public Mini Target;

    //---add---
    public T addchange<T>()where T : change_, new()
    {  T n = new T();n.link_GetID(this);
        list.Enqueue(n); return n; }
    //public void adddamage(int n,HPCkind k)
    //{
    //    HPchange d = addchange<HPchange>();
    //    d.kind = k;d.n = n;
    //}
}


public enum change_k1
{
    //1   //2     //4 / 8  /16/          //32
    //第一位是前后//第二位加减//第三四五位分类型//后面为实际类型
    //before_reduce=0,
    //after=1,//add=2,
    use_card_skill = 32,
    HP = 64,
    mini = 128,
    time = 256,
    //before,
}