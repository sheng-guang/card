using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public enum Skill_K1
{
    magic,attack,objskill,
}

public enum Target_K1
{
    __, friend=1,enemy=2,all=63,
}
public enum Target_K2
{
     hero=1,obj=2,building=4,all=63,
}
//-----------------------------------------------------------------------------------
public abstract class EVE_
{
    public void link_load(skill_ s) { skill = s; }
    public  skill_ skill;

    public abstract void do_();
}
//-----------------------------------------------------------------------------------
public abstract class skill_
{
    //基础
    public T addEVE<T>()where T:EVE_,new()
    {
        T n = new T();n.link_load(this);
        return n;
    }
    public void link_load(SkillObj o) { obj = o; _load(); }

    //属性
    public abstract Skill_K1 k { get; }
    private SkillObj obj;public CardPlayer player { get { return obj.player; } }
    
    //list-L----------------------------------------------------------------
    public LinkedList<EVE_> L = new LinkedList<EVE_>();
    //list-填充
    public abstract void _load();

    //条件-data-----------------------------------------------------------
    public virtual byte needdata { get { return 0; } }
    //条件-fei
    public abstract int needFei { get; }
    //条件-目标
    public abstract Target_K1 k1 { get; }public abstract Target_K2 k2 { get; }

    //测试-----通用----------------------------------------------------------
    public static  bool test_toDo(skill_ which,byte[]b)
    {
        //目标测试
        if (which.k1 != Target_K1.__)
        {
            
            SkillObj o = which.obj.player.find_the(which.k1, which.k2, b[0], b[1]);
            if (o == null) return false;
            if (o.geteffect.getthis(which.k)) return false;
        }
        //费用测试
        //距离测试
        return true;
    }
    //测试-----自定义
    public virtual bool data_test(byte[] b)
    { return test_toDo(this,b); }
    //释放-------------------------------------------------------------------------
    public int nowOrderID;
    public SkillObj now_Target;
    public virtual void do_(int ordernum)
    {
        if (k1 != Target_K1.__)
        {
            now_Target= player.find_the(k1, k2,player.orderID_Data[ordernum+1] , player.orderID_Data[ordernum + 2]);
        }
        nowOrderID = ordernum;
        //上传到host  补全
    }
}



//普通攻击
public class skill_ATK : skill_
{
    public override int needFei { get { return 0; } }

    public override Target_K1 k1 { get { return Target_K1.enemy; } }
    public override Target_K2 k2 { get { return Target_K2.all; } }
    public override Skill_K1 k { get { return Skill_K1.attack; } }
    public override void _load()
    {
        L.AddLast(addEVE<E_atk>());
    }
}
public class E_atk : EVE_
{
    public override void do_()
    {

    }
}