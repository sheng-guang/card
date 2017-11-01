using System;
using System.Collections.Generic;
using System.Text;
public abstract class card_ : skill_
{
    public virtual void link_load(Mini_G g) { upone = g; load(); }
    public override Mini_G Group(){return upone.Group(); }

}
//技能
public abstract class skill_ : change_G
{
    int usetimes;
    public  virtual void GetData_do(order_ o)
    {
        //可能需要重写
        usetimes -= 1;
        //可能需要重写
        Target = find_mini(o.miniID);from = mini();
        host().Doskill_card(new Queue<change_>(list));
    }
    //测试
    public  bool test_data(order_ o) {
       if(time_Test()&&Target_Test(o.miniID))
            return true;
        return false;
    }
    //次数测试可重写
    public virtual bool time_Test()
    { if (usetimes <= 0) return false; return true; }
    //目标测试可重写
    public virtual bool Target_Test(int ID)
    { if (find_mini(ID).be.asTarget(this) == false) return false;return true; }
}
//卡牌

//改变//参考回调函数修改
public abstract class change_ : layer_base
{
    private change_G toolchange;
    public virtual change_G Change() { return toolchange; }
    public override Mini mini() { return Change().mini(); }
    public virtual void link_load(change_G c) { toolchange = c; load(); }
    public virtual int kind() { return 0; }//返回一个组合
    public virtual bool needCallBefore { get { return false; } }
    public virtual bool needCallAfter { get { return false; } }
    public abstract void run();
}

public abstract class change_G : change_
{    public Mini Target;
    public Mini from;
    public virtual void link_load(Mini m) { upone = m; loadList(); }
    public abstract void  loadList();
    public override Mini mini() { return upone.mini(); }
    public override change_G Change() {return this; }
    public Queue<change_> list = new Queue<change_>();
    public override void run() { }
    //public void  addChange<T>()where T:change_,new()//{//    T newone = new T();//    newone.link_load(this);//    list.Enqueue(newone);//}
    //自己用于call
    public void addSelf()
    {
        list.Enqueue(this);
    }
    public void addHpChange<T>(int n,hp_change_K k) where T : hp_change, new()
    {
        T newone = new T();
        newone.link_load(this);
        newone.num = n;newone.k1 = k;
        list.Enqueue(newone);
    }

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
    //after=1,//add=2,
    use_card_skill=32,
    HP=64,
    mini=128,
    time=256,
    //before,
}


