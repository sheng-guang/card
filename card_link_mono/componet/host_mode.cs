using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class host_mode : layerBase {
    public abstract void loadGame_waitLink();
    public abstract void gameStart();
    //操做技能
    public void AddTrigger(ICall_receiver i)
    {
        IDtrigger.Add(i.ID_, i);
        LinkedList<int> to = null;
        if (i.simpleKind == change_k1.use_card_skill) { to = needSkill_cardcall; }
        else if (i.simpleKind == change_k1.HP) { to = needhpChangecall; }
        else if (i.simpleKind == change_k1.mini) { to = needMinicall; }
        else if (i.simpleKind == change_k1.time) { to = needTimecall; }
        to.AddLast(i.ID_);
    }
    //call------------
    public Dictionary<int, ICall_receiver> IDtrigger = new Dictionary<int, ICall_receiver>();

    public LinkedList<int> needSkill_cardcall = new LinkedList<int>();//卡牌技能
    public LinkedList<int> needMinicall = new LinkedList<int>();//随从
    public LinkedList<int> needTimecall = new LinkedList<int>();//回合时间
    public LinkedList<int> needhpChangecall = new LinkedList<int>();//血量改变
    //call------------do
    public void docall(Call_ c)
    {
        if (!toget) return;

        LinkedList<int> to = null;
        if (c.simpleKind == change_k1.use_card_skill) { to = needSkill_cardcall; }
        else if (c.simpleKind == change_k1.HP) { to = needhpChangecall; }
        else if (c.simpleKind == change_k1.mini) { to = needMinicall; }
        else if (c.simpleKind == change_k1.time) { to = needTimecall; }

        foreach (int n in to)
        {
            IDtrigger[n].Get(c);
        }
    }

    //eve-
    public Stack<Queue<change_>> todoL = new Stack<Queue<change_>>();
    //eve-全新玩家主动行为
    public void doCard(Queue<change_> L)
    {
        if (!toget)
        {
            Open_top_Get_queue();
            //todoL.Push(E_Dtest.test_L(this));//加入测试
            //Debug.Log("+detest+skill");
            todoL.Push(L);//加入技能
            while (todoL.Count != 0)
            {
                Do_top_Q();
            }
            Close_top_Get_queue();
        }

    }
    //eve-结算顶端
    private void Do_top_Q()
    {
        while (todoL.Peek().Count == 0)
        { todoL.Pop(); }
        change_ todo_c = todoL.Peek().Dequeue();
        //Debug.Log(todo_c);
        // if (todo_c.needCallBefore) { }//如果需要触发的话先进行触发
        //todo_c.run();
        // if (todo_c.needCallAfter) { }//如果需要触发的话先进行触发

        Change__top_Get_queue();
    }
    //eve-开启接收队列
    void Open_top_Get_queue() { toget = true; }
    void Change__top_Get_queue() { the_geter = null; }
    void Close_top_Get_queue() { toget = false; the_geter = null; }
    //eve-接收新生成队列
    Queue<change_> the_geter;
    bool toget;
    public void DoTriggered(change_ e)
    {
        if (toget && the_geter == null)
        {
            the_geter = new Queue<change_>();
            the_geter.Enqueue(e);
            todoL.Push(the_geter);
        }
    }
    public void DoTriggered(Queue<change_> eL)
    {
        if (toget && the_geter == null)
        {
            the_geter = new Queue<change_>();
            while (eL.Count != 0)
            {
                the_geter.Enqueue(eL.Dequeue());
            }
            todoL.Push(the_geter);
        }
    }

}

