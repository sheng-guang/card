using System;
using System.Collections.Generic;
using System.Text;

//卡牌
public abstract class card_ : skill_
{}
//技能
public abstract class skill_ : change_
{
    public Mini upmini;
    public virtual void link_load(Mini m) { upmini = m; load(); }
    public override Mini mini() { return upmini; }
    public override change_ Change() { return this; }
    public Queue<change_> list = new Queue<change_>();
    //测试
    public virtual bool test_data(List<byte> d) { return true; }
    public virtual void getData(List<byte> d) { }
}
//改变//参考回调函数修改
public abstract class change_ : layer_base
{
    public change_ toolchange;
    public virtual change_ Change() { return toolchange == null ? this : toolchange; }
    public override Mini mini() { return Change().mini(); }
    public virtual void link_load(change_ c) { toolchange = c; load(); }

    public virtual int kind() { return 0; }
    public virtual bool needCallBefore { get { return true; } }
    public abstract void run();
}
//改变报告
public abstract class Report_
{

}
public interface ICall_receiver {
    void Get(Report_ p);

}
//触发
public abstract class trigger_ : change_, ICall_receiver
{
    public abstract void Get(Report_ p);
}

public abstract class Call_text : ICall_receiver
{
    //提前记录使用数量
    //例如使用的法术牌数量 过载数量
    public abstract void Get(Report_ p);
}

public enum change_kind
{
    doskill,
    docard,
    damag,
    

}