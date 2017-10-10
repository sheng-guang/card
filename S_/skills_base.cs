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
public abstract class EVE_
{
    public void link_load(skill_ s) { skill = s; }
    private skill_ skill;
    public abstract void do_();
}
public abstract class skill_
{
    

    private SkillObj obj;public CardPlayer player { get { return obj.player; } }
    public void link_load(SkillObj o) { obj = o; load(); }
    //list-
    public LinkedList<EVE_> L = new LinkedList<EVE_>();
    //list-补充
    public abstract void load();
    public T addEVE<T>()where T:EVE_,new()
    {
        T n = new T();n.link_load(this);
        return n;
    }
    //属性
    public abstract Skill_K1 k { get; }
    //释放要求的数据个数
    public virtual byte needdata { get { return 0; } }
    public int nowOrderID;
    //释放技能的fei
    public abstract int needFei { get; }
    public abstract Target_K1 k1 { get; }
    public abstract Target_K2 k2 { get; }
    
    //通用测试
    public static  bool test_toDo(skill_ which,byte[]b)
    {
        //目标测试
        if (which.k1 != Target_K1.__)
        {
            
            SkillObj o = which.obj.player.find_the(which.k1, which.k2, b[1], b[2]);
            if (o == null) return false;
            if (o.geteffect.getthis(which.k)) return false;
        }
        //费用测试
        //距离测试
        return true;
    }

    //特殊使可重写测试
    public virtual bool data_test(byte[] b)
    { return test_toDo(this,b); }
    public virtual void do_(int ordernum)
    {
        nowOrderID = ordernum;
        //上传到host  补全
    }
}

public class skill_1damage : skill_
{
    public override Skill_K1 k
    {
        get
        {
            return Skill_K1.objskill;
        }
    }

    public override Target_K1 k1
    {
        get
        {
            return Target_K1.all;
        }
    }

    public override Target_K2 k2
    {
        get
        {
            return Target_K2.all;
        }
    }

    public override int needFei
    {
        get
        {
            return 0;
        }
    }

    public override void load()
    {
        L.AddLast(addEVE<>();)
    }
}
//召唤11
public class skill_new11 : skill_
{
    public override Skill_K1 k { get { return Skill_K1.objskill; } }

    public override Target_K1 k1
    { get { return Target_K1.__; } }

    public override Target_K2 k2
    { get { return Target_K2.hero; } }

    public override int needFei
    { get { return 0; } }

    public override void load()
    {
        L.AddLast(addEVE<e_new11>());
    }
}
public class e_new11 : EVE_
{
    public override void do_()
    {

    }
}
//普通攻击
public class skill_ATK : skill_
{
    public override int needFei { get { return 0; } }

    public override Target_K1 k1 { get { return Target_K1.enemy; } }
    public override Target_K2 k2 { get { return Target_K2.all; } }
    public override Skill_K1 k { get { return Skill_K1.attack; } }
    public override void load()
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