using System;
using System.Collections.Generic;
using System.Text;
//卡牌
public abstract class card_ : skill_
{
    public virtual void link_load(Mini_G g) { upone = g; load(); }
    public override Mini_G Group(){return upone.Group(); }
    //卡牌分解//可以分解成能量//组件//卡牌中的卡牌
    public virtual void decompose() { }
}
//技能
public abstract class skill_ : change_G
{
    int usetimes;
    public  virtual void GetData_do(order_ o)
    {
         if(test_data(o)==false) return ;
         //可能需要重写
        findTarget(o);
        //可能需要重写
        usetimes -= 1;
        changeG().from.be.give_buff(this);
        host().Doskill_card(this);
    }
    public virtual void findTarget( order_ o)
    {Target = find_mini(o.miniID);from = mini(); }
    //测试
    public  bool test_data(order_ o) {
       if(times_Test()&&Target_Test(o.miniID))
            return true;
        return false;
    }
    //次数测试可重写
    public virtual bool times_Test()
    { if (usetimes <= 0) return false; return true; }
    //目标测试可重写
    public virtual bool Target_Test(int ID)
    { if (find_mini(ID).be.asTarget(this) == false) return false;return true; }
}
public abstract class change_G : change_
{
    public Mini Target;
    public Mini from;
    public override change_G changeG() {return this; }
    public Queue<change_> list = new Queue<change_>();

    public override void run(Be b) { }
    public void addSelf_For_call()
    {
        list.Enqueue(this);
    }

    public void addHpChange<T>(int n,hp_change_K k) where T : hp_change, new()
    {
        T newone = new T();
        newone.link(this, 0);
        newone.num = n;newone.k1 = k;
        newone.load();
        list.Enqueue(newone);
    }

}

//改变//参考回调函数修改
public abstract class change_ : layer_base
{
    public override change_ change() {return this; }
    public override void load() { }
    public virtual int kind() { return 0; }//返回一个组合
    public virtual bool needCallBefore { get { return false; } }
    public virtual bool needCallAfter { get { return false; } }
    public virtual void run() { run(changeG().Target.be);}
    public abstract void run(Be target);
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
    public List_ForCard L = new List_ForCard();
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


