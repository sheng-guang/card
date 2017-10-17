using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public abstract class host_componet
{
    //组件的主人
    public gameHost host;
    //组件
    public mode mode { get { return host.mode; } }
    public Hostfac factory { get { return host.factory; } }
    //属性
    public Dictionary<int ,CardPlayer> player_L { get { return host.player_L; } }
}
//mode-
public abstract class mode : host_componet
{
    //mode-初始化
    public abstract void gameLoad_Link();
    //mode-开始游戏
    public abstract void gameStart();

    //call------------
    public LinkedList<IObj_Be_Call> obj_call = new LinkedList<IObj_Be_Call>();
    public LinkedList<IBe_Call> be_call = new LinkedList<IBe_Call>();
    //call------------do
    public void decall(Call_ c)
    {
        foreach(IBe_Call b in be_call)
        {
            b.getcall(c);
        }
    }


    //eve-
    public Stack<Queue<EVE_>> todoL = new Stack<Queue<EVE_>>(); 
    //eve-全新玩家主动行为
    public void doskill(Queue<EVE_> L)
    {
        if (todoL.Count == 0)
        {
            todoL.Push(E_Dtest.test_L(this));//加入测试
            //Debug.Log("+detest+skill");
            todoL.Push(L);//加入技能

            while (todoL.Count != 0)
            {
                Do_top_Q();
            }
                
        }
    }
    //eve-结算顶端
    private void Do_top_Q()
    {
        Queue<EVE_> todo_Q = todoL.Peek();
        if (todo_Q.Count != 0)
        {
            OpenNew_top_queue();
            EVE_ todo_e = todo_Q.Dequeue();
            Debug.Log(todo_e);
            todo_e.do_();
        }
        else { todoL.Pop();  }
    }
    //eve-开启接收队列
    void OpenNew_top_queue()
    {
        todoL.Push(new Queue<EVE_>());
        the_geter = todoL.Peek();
    }
    //eve-接收新生成队列
    Queue<EVE_> the_geter;
    public void addEVE(EVE_ e)
    {
        if (the_geter != null) the_geter.Enqueue(e);
    }
    public void addEVE(Queue<EVE_> eL)
    {
        if (the_geter != null)
        {
            while (eL.Count != 0)
            {
                the_geter.Enqueue(eL.Dequeue());
            }
        }
    }
}
public class E_Dtest : EVE_
{
    public  mode M;
    public E_Dtest(mode mode) { M = mode; }
    
    public override void do_()
    {
        E_Dtest_report report = new E_Dtest_report();
        foreach(IObj_Be_Call obj in M.obj_call)
        {
            if (obj.Des_test(d_test_sender.hp_test)) { report.l.Add(obj); }
        }
        M.addEVE(report);
    }
    //public struct poID {public poID(int a,int b) { pid = a;oid = b; }public int pid, oid; }

    public class E_Dtest_report : EVE_
    {
        public List<IObj_Be_Call> l = new List<IObj_Be_Call>();
        public override void do_()
        {
            foreach(IObj_Be_Call o in l)
                o.obj.player.get_P.destoryOBJ(o.obj.OID);
        }
    }

    //工厂方法
    //生产E_Dtest
    public static Queue<EVE_> test_L(mode m)
    {
        var n = new Queue<EVE_>();
        n.Enqueue(new E_Dtest(m));
        return n;
    }
}
//mode-六角形地图
public class mode_sixAngle : mode
{
    public override void gameLoad_Link()
    {
        factory.addHostPlayer();
        factory.addplayer();
        factory.addplayer();
    }

    public override void gameStart()
    {
        foreach( KeyValuePair<int ,CardPlayer> p in player_L)
        {
            p.Value.get_P.newMainobj();//创建英雄
        }
    }
}
//public interface IDo_Call{}

public interface IBe_Call
{
    //用于位运算
    int needcall_K { get; }
    //接收call之后的处理
    void getcall(Call_ c);
}
public interface IObj_Be_Call{
    //测试
    SkillObj obj { get; }
    bool Des_test(d_test_sender sender);
    void before_destory();
}
public enum EVE_call_K
{
    obj=2,card=4,HP_hit=8,
}
public class EVE_Player_Do : EVE_
{//主要eve 准备攻击和攻击
    public override void do_()
    {
        throw new NotImplementedException();
    }
}
public class EVE_call : EVE_
{
    //只有通知效果//可以触发trigger
    public override void do_()
    {
        throw new NotImplementedException();
    }
}
public class EVE_trigger : EVE_
{
    //由通知触发//可以触发通知
    public override void do_()
    {
        throw new NotImplementedException();
    }
}




public class Hostfac : host_componet
{
    //添加服务器玩家
    public void addHostPlayer()
    {
        CardPlayer p = new CardPlayer();p.ID = 0;p.host = host;
        host.hostPlayer = p;
    }

    //添加玩家
    int nextP_ID=1;
    public void addplayer()
    {
        CardPlayer p = new CardPlayer();
        p.ID = nextP_ID;p.host = host;
        host.player_L.Add(nextP_ID, p);
        nextP_ID++;
    }
}

