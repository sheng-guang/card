using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public struct NextIDs
{
    public NextIDs(int max) { lastmini = 0; lastorder = 0; lastPlayer = 0; lastTrigget = 0; }
    public int lastorder,lastPlayer, lastmini,lastTrigget;
    public int NextorderID { get { return ++lastorder; } }
    public int NextGID { get { return ++lastPlayer; } }
    public int NextminiID { get { return ++lastmini; } }
    public int NextTriggerID { get { return ++lastmini; } }
}
public abstract class host_base : layer_base
{
    public  void link_load() { load(); }
    public  NextIDs next = new NextIDs(0);


    public Dictionary<int, Mini_G> IDgroup = new Dictionary<int, Mini_G>();
    public Dictionary<int, Mini> IDmini = new Dictionary<int, Mini>();
    
    public Dictionary<int, List<byte>> ID_Data = new Dictionary<int, List<byte>>();
    //public List<byte> testingOrder;
}

public  class Host:host_base
{
    public void addminiG()
    {
        if (Group() != null) return;
        Mini_G newone = new Mini_G();
        newone.link_load(this);
        host().IDgroup.Add(newone.ID, newone);
    }

    public override Host host(){return  this; }
    public override void load()
    {
    }
    
    Hostmode mode;
    public void AddTrigger(ICall_receiver i) { mode.AddTrigger(i); }
    //开始
    public void loadGame_waitLink() { mode.loadGame_waitLink(); }
    public void gameStart() { mode.gameStart(); }
    //使用技能
    public void Doskill_card(Queue<change_> c) { mode.doskill(c); }
    //广播
    public void Docall(Call_ c) { mode.docall(c); }
    public void DoTrigger(Queue<change_> c) { mode.addTriggered(c); }
    public void DoTrigger(change_ c) { mode.addTriggered(c); }
   
    
}

public abstract class Hostmode
{
    //开始
    public abstract void loadGame_waitLink();
    public abstract void gameStart();
    //操做技能
    public void AddTrigger(ICall_receiver i)
    {
        IDtrigger.Add(i.ID_, i);
        if ((i.needk() & ((int)change_k1.use_card_skill)) != 0) { needSkill_cardcall. AddLast(i.ID_); }
        if ((i.needk() & ((int)change_k1.HP)) != 0) { hpChangecall.AddLast(i.ID_); }
        if ((i.needk() & ((int)change_k1.mini )) != 0) { needMinicall.AddLast(i.ID_); }
        if ((i.needk() & ((int)change_k1.time)) != 0) { needTimecall.AddLast(i.ID_); }
    }
    //call------------
    public Dictionary<int, ICall_receiver> IDtrigger = new Dictionary<int, ICall_receiver>();

    public LinkedList<int> needSkill_cardcall = new LinkedList<int>();//卡牌技能

    public LinkedList<int> needMinicall = new LinkedList<int>();//随从
    
    public LinkedList<int> needTimecall = new LinkedList<int>();//回合时间
    public LinkedList<int> hpChangecall = new LinkedList<int>();//血量改变
    //call------------do
    public void docall(Call_ c)
    {
        foreach (KeyValuePair<int ,ICall_receiver>  b in IDtrigger)
        {
            b.Value.Get(c);
        }
    }

    //eve-
    public Stack<Queue<change_>> todoL = new Stack<Queue<change_>>();
    //eve-全新玩家主动行为
    public void doskill(Queue<change_> L)
    {
        if (todoL.Count == 0)
        {
            //todoL.Push(E_Dtest.test_L(this));//加入测试
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
        Queue<change_> todo_Q = todoL.Peek();
        if (todo_Q.Count != 0)
        {
            OpenNew_top_queue();
            change_ todo_c = todo_Q.Dequeue();
            //Debug.Log(todo_c);
            if (todo_c.needCallBefore) { }//如果需要触发的话先进行触发
            todo_c.run();
        }
        else { todoL.Pop(); }
    }
    //eve-开启接收队列
    void OpenNew_top_queue()
    {
        todoL.Push(new Queue<change_>());
        the_geter = todoL.Peek();
    }
    //eve-接收新生成队列
    Queue<change_> the_geter;
    public void addTriggered(change_ e)
    {
        if (the_geter != null) the_geter.Enqueue(e);
    }
    public void addTriggered(Queue<change_> eL)
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


