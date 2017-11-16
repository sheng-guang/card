using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//public abstract class Call_text : ICall_receiver
//{//提前记录使用数量//例如使用的法术牌数量 过载数量
//    private int ID;
//    public int ID_ { get { return ID; } set { ID = value; } }
//    public abstract change_k1 simpleKind { get; }
//    public abstract void Get(Call_ p);
//    public abstract int needinfo();
//}
//触发器基类
public abstract class Trigger : layerBase
{
    public override Trigger trigger(){return this; }
    public bool forPlayer;
    public override Mini mini(){ return forPlayer?player().main:upone.mini();}

    
    

    public card_ ToDocard;
    public virtual void beTrigged() { }
}
//被动触发器
public abstract class Trigger_bycall:Trigger, ICall_receiver
{
    int ID; public  int ID_ { get { return ID; } set { ID = value; } }
    public abstract change_k1 simpleKind { get; }
    public abstract int needinfo();
   //运行函数
    public  void Get(Call_ c)
    { if (testCall_loadTarget(c)) beTrigged(); }
    public abstract bool testCall_loadTarget(Call_ c);
    public override void beTrigged()
    {
        host().mode.DoTriggered(new Queue<change_>(ToDocard.list));
        //被使用的卡牌
    }
}

////被物理触发
//public abstract class FixedTrigger : Trigger
//{

//}

public interface ICall_receiver
{
    int ID_ { get; set; }
    change_k1 simpleKind { get; }
    int needinfo();
    void Get(Call_ p);
    
}
public abstract class Call_
{
    public Call_(Host h, bool after, bool add, change_k1 k)
    {
        simpleKind = k;
        info += after ? 1 : 0;
        info += add ? 2 : 0; info += (int)k;
    }
    public change_k1 simpleKind;
    public int info = 0;
    //public List_ForCard L = new List_ForCard();
}

