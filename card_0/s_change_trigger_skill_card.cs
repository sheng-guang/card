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
    public abstract void run();
}

//触发
public abstract class trigger_ : change_G, ICall_receiver
{
    public abstract void Get(Call_ p);
    public change_k1 need1;
    public change_k2 need2;
}
//改变报告
public abstract class Call_
{
    public change_k1 k1;
    public change_k2 k2;
    //public layer_base from;
    
}
public interface ICall_receiver {
    void Get(Call_ p);
}



public abstract class Call_text : ICall_receiver
{//提前记录使用数量//例如使用的法术牌数量 过载数量
    public abstract void Get(Call_ p);}

public enum change_k1
{
    //both
    usecard=1,useskill=2,bout_finish_begin,//回合
    //after
    HP_cure,HP_reduce,mini_new,mini_destory,
    //before,
}
public enum change_k2
{
    before,
    after,
}
public struct layerID
{
    int gID, mID, trID;
}