using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
//public abstract class Call_text : ICall_receiver
//{//提前记录使用数量//例如使用的法术牌数量 过载数量
//    private int ID;
//    public int ID_ { get { return ID; } set { ID = value; } }
//    public abstract change_k1 simpleKind { get; }
//    public abstract void Get(Call_ p);
//    public abstract int needinfo();
//}
//触发器基类
/// <summary>
/// 重写对应对的触发条件/写单个change
/// </summary>
public abstract class Trigger : layerBase
{
    public int ID;
    //public override Card_m mini(){ return /*forPlayer?player().main:*/upone.mini();}// public bool forPlayer=false;
    //public abstract bool isactive { get; }
    public override Trigger trigger(){return this; } public virtual Trigger_byinput input {  get { return null; } } public virtual Trigger_bycall call { get { return null; } }
    [Header("-------------trigger----------")]
    public bool card_stay;//是否消耗
    public bool card_lock;//是否可以拆除
    public int maxtimes;//最大充能层数
    public int usetimes;//目前充能层数
    public abstract  CardTxt ToDocard { get; }

    public void askHostDo(step_target data,bool a)
    {

        host().CopyDo_cardTxt(ToDocard, data,a,host());
    }

}
//主动触发器 输入
public abstract class Trigger_byinput : Trigger
{
    //public override bool isactive {  get {  return true;  } }
    public override Trigger_byinput input  {  get   { return this;  }  }
    public CardTxt point;
    public override CardTxt ToDocard  { get { return point;  }  }

    public virtual bool Do_order(order d) {
        step_target data = test(d);
        data = ToDocard.test(data);
        if (data==null) return false;
        askHostDo(data,true);
        return true;
    }
    public abstract step_target test(order d);
    //-------------------------------------------------------------

}

//被动触发器 信息
public abstract class Trigger_bycall:Trigger//, ICall_receiver
{
    //public override bool isactive  {  get  {   return false;  }  }
    public override Trigger_bycall call  { get   {  return this;  } }
    public CardTxt point;
    public override CardTxt ToDocard { get { return point; } }
    //运行函数
    public abstract bool Get(Call_ c);
}

//被动触发器 位置
public abstract class Trigger_bymove : Trigger_bycall
{

    public override bool Get(Call_ c)
    {

        if (c.movecall == null) return false;
        step_target data = test();
        data = ToDocard.test(data);
        if (data != null)
        {
            askHostDo(data,false);
            return true;
        }
        return false;
    }
    public abstract step_target test();
}














public abstract  class Call_
{

    public virtual Call_move movecall { get { return null; } }
    public virtual Call_mini minicall { get { return null; } }
    public virtual call_HP HPcall { get { return null; } }
    public virtual Call_clock clockCall { get { return null; } }
    public int info = 0;
    //public List_ForCard L = new List_ForCard();
}
public class Call_clock:Call_
{
    public Call_clock(int time)
    {
        info = time;
    }
    public override Call_clock clockCall  { get  {  return this; }  }
}

public class Call_move : Call_
{
    public override Call_move movecall { get { return this; } }
}

public class Call_mini : Call_
{
    public override Call_mini minicall  {    get   { return this; }  }

    public Card_m which;
    public int ID;
    public Call_mini(Card_m c,int id,bool after,bool add)
    {
        which = c;
        ID = id;
        info += after ? 1 : 0;
        info += add ? 2 : 0;
        info += (int)change_k1.mini;
    }
}

public class call_HP:Call_
{

    public override call_HP HPcall { get { return this; } }

}

public enum change_k1
{
    //1                    //2               //4 / 8  /16/          //32
    //第一位是前后//第二位加减//第三四五位分类型//后面为实际类型
    //before_reduce=0,
    //after=1,//add=2,
    use_card_skill = 32,
    HP = 64,
    mini = 128,
    time = 256,
    move = 512,
    //before,
}