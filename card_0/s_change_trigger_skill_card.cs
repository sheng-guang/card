using System;
using System.Collections.Generic;
using System.Text;
public abstract class change_G : change_
{
    public virtual void link_load(Mini m) { upone = m; load(); }

    public override Mini mini() { return upone.mini(); }
    public override change_G ChangeG() {return this; }
    public Queue<change_> list = new Queue<change_>();
}

//技能
public abstract class skill_ : change_G
{
    //测试
    public virtual bool test_data(List<byte> d) { return true; }
    public virtual void getData(List<byte> d) { }
}
//卡牌
public abstract class card_ : skill_
{
    public virtual void link_load(Mini_G g) { upone = g; load(); }
    public override Mini_G Group(){return upone.Group(); }

}
//改变//参考回调函数修改
public abstract class change_ : layer_base
{
    private change_G toolchange;
    public virtual change_G ChangeG() { return toolchange; }
    public override Mini mini() { return ChangeG().mini(); }
    public virtual void link_load(change_G c) { toolchange = c; load(); }

    public virtual int kind() { return 0; }
    public virtual bool needCallBefore { get { return true; } }
    public virtual bool needCallAfter { get { return true; } }
    public abstract void run();
}




//触发
public interface ICall_receiver
{
    int ID_ { get; set; }
    void Get(Call_ p);
    change_k1 k1 { get; }
    int needinfo();
}
public abstract class trigger_ : change_G, ICall_receiver
{
    public abstract void Get(Call_ p);
    public abstract int needinfo();
    public  int ID_  { get  { return ID;  } set {ID = value;} }
    public abstract change_k1 k1 { get; }
}
//报告信息
public abstract class Call_
{
    public Call_(Host h, bool after,bool add,change_k1 k)
    { k1 = k;
        info += after ? 1:0;
        info += add ? 2 : 0;info += (int)k;
    }
    public change_k1 k1;
    public int  info=0;
}


public abstract class Call_text : ICall_receiver
{//提前记录使用数量//例如使用的法术牌数量 过载数量
    private int ID;
    public int ID_ { get { return ID; } set { ID = value; } }

    public abstract change_k1 k1 { get; }

    public abstract void Get(Call_ p);
    public abstract int needinfo();

}


public enum change_k1
{
    //1   //2     //4 / 8  /16/          //32
    //第一位是前后//第二位加减//第三四五位分类型//后面为实际类型
    //before_reduce=0,
    //after=1,
    //add=2,

    use_card_skill=32,
    HP=64,
    mini=128,
    time=256,
    //before,
}


//public struct layerID
//{
//    int gID, mID, trID;
//}
