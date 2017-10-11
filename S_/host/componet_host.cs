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
public abstract class mode : host_componet
{
    //初始化
    public abstract void gameLoad_Link();
    //开始游戏
    public abstract void gameStart();

    //cal-
    public LinkedList<IBe_Call> all_obj = new LinkedList<IBe_Call>();

    //eve-
    public Stack<Queue<EVE_>> todoL = new Stack<Queue<EVE_>>(); 

    public void doskill(Queue<EVE_> L)
    {
        if (todoL.Count == 0)
        {
            todoL.Push(E_Dtest.test_L(this));//加入测试
            todoL.Push(L);//加入技能

            while(todoL.Count!=0)
                Do_top_Q();
        }
    }
    private void Do_top_Q()
    {
        Queue<EVE_> todo_Q = todoL.Peek();
       if(todo_Q.Count != 0)
        {
            OpenNewqueue();
            EVE_ todo_e = todo_Q.Dequeue();
            todo_e.do_();
        }
        todoL.Pop();
    }
    void OpenNewqueue()
    {
        todoL.Push(new Queue<EVE_>());
        the_geter = todoL.Peek();
    }
    Queue<EVE_> the_geter;
    public  void addEVE_(EVE_ e)
    {
        if (the_geter != null) the_geter.Enqueue(e);
    }
    public void addEVE(Queue<EVE_> eL)
    {
        if (the_geter != null)
        {
            while (eL.Count != 0)
            {

            }
        }
    }
    
}


public class E_Dtest : EVE_
{
    private mode M;
    public E_Dtest(mode mode) { M = mode; }
    
    public override void do_()
    {
        
    }
    public static Queue<EVE_> test_L(mode m)
    {
        var n = new Queue<EVE_>();
        n.Enqueue(new E_Dtest(m));
        return n;
    }
}
//六角形地图
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

public interface IDo_Call
{

}
public interface IBe_Call
{
    EVE_trigger Des_test();


    bool B_destory { get; }
    void DoEstory();
    void C__(/*Call c*/);

    bool Need_obj_call { get; }//关于单位 召唤和消失
    bool Need_HP_call { get; }//关于hp 受伤害
    bool Need_card_call { get; }//关于卡牌使用
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

