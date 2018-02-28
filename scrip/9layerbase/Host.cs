using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Host : layerBase
{
    public Icreater creater;
    public getLayer_Information outGeter;//输出信息的委托方法
    public override miniG player()  {  return null;  }  public override Card_m mini()  {return null;}public override Trigger trigger() { return null; }public override Host host()  {   return this;  }

    public abstract void loadGame_waitLink();
    public abstract void gameStart();

    //bean----------------------------------------------------------------------------
    public IdGroup Beens = new IdGroup();
    //skill-----------------------------------------------------------------------------
    public Skill skill = new Skill();
    public void CopyDo_cardTxt(CardTxt cardTxt,step_target data,bool isactive,Host h)
    {
        if (isactive) { skill.doCard(cardTxt,data,h); }
        else skill.AddTriggered(cardTxt,data);
    }

    //更新模块==========================================
    //输入一秒15-25次
    //物理50-100次
    //同步输入*1
    //移动*4/同时接收下次输入
    //同步输入*1
    public float deltaTime = 0.05f;
    public int times_move=5;//50ms/时间间隔向移动转化
    public int times_input=20;//200ms/move向输入转化
    public int times_test =10;//触发测试
    public int times_MAXclock = 16;//时间16秒
    int clockTime=0,moveTime=0,inputTimes = 0,triggerTime=0;
    //10ms
    public void getTime_0_01s()
    {
        //充能
        clockTime++;
        int i = 1;
        while (clockTime >= i * 100)
        {
            if (clockTime % (i * 100) != 0) break;
            skill.doactiveCall(this, new Call_clock(i));
            i *= 2;
            //print("i");
        }
        if (clockTime >= times_MAXclock * 100)
        {
            clockTime = 0;
        }
        //输入
        inputTimes++;
        if (inputTimes >= times_input)
        {
            inputUpdate(); inputTimes = 0;
        }
        //触发
        triggerTime++;
        if (triggerTime >= times_test)//4
        {
            skill.doactiveCall(this, new Call_move());
            triggerTime = 0;
        }
        //移动
        moveTime++;//1/2/3/4/5(会出现的数字)
        if (moveTime >= times_move)//5
        {
            moveUpdate();            moveTime = 0;
        }
    }
    //-------------------------------------------------------------|移动
    public void moveUpdate()
    {
        todoList=new List<Card_m>(Beens.Call_List);

        while (todoList.Count > 0)
            if (todoList[0].minion) moveOneLine(todoList[0].minion);
            else todoList.RemoveAt(0);
    }
    List<Card_m> todoList;
    //递归 逐条分解
    void moveOneLine(card_mini begin)
    {
        //如果有等待的上级移动 而且还没有移动
        if (begin.upmove&&todoList.Contains(begin.upmove)) moveOneLine(begin.upmove);
        begin.move_New_pos(deltaTime);//调用
        todoList.Remove(begin);
    }
    //-------------------------------------------------------------|移动
    //输入
    public void inputUpdate()
    {
        while (Input_todo_L.Count != 0)
        {
            inputpackage p = Input_todo_L.Dequeue();
            p.From.useinput(p);
        }
        //先处理玩家按键数据包 按先后顺序来//解析数据包
    }
    public void addTodoInput(inputpackage p)
    {
        Input_todo_L.Enqueue(p);
    }
    Queue<inputpackage> Input_todo_L=new Queue<inputpackage>();

}

public class Skill
{
    //public Skill(layerBase l)
    //{
    //    h = l;
    //}
    //layerBase h;

    ////发布call
    ////public void AddTrigger(ICall_receiver i)
    ////{
    ////    IDtrigger.Add(i.ID_, i);
    ////    LinkedList<int> to = null;
    ////    if (i.simpleKind == change_k1.use_card_skill) { to = needSkill_cardcall; }
    ////    else if (i.simpleKind == change_k1.HP) { to = needhpChangecall; }
    ////    else if (i.simpleKind == change_k1.mini) { to = needMinicall; }
    ////    else if (i.simpleKind == change_k1.time) { to = needTimecall; }
    ////    to.AddLast(i.ID_);
    ////}
    ////call------------
    // //Dictionary<int, ICall_receiver> IDtrigger = new Dictionary<int, ICall_receiver>();

    ////LinkedList<int> needSkill_cardcall = new LinkedList<int>();//卡牌技能
    ////LinkedList<int> needMinicall = new LinkedList<int>();//随从
    ////LinkedList<int> needTimecall = new LinkedList<int>();//回合时间
    ////LinkedList<int> needhpChangecall = new LinkedList<int>();//血量改变
    ////call------------do
    //public void docall(Call_ c)
    //{
    //    if (!OnGoing) return;
    //    //LinkedList<int> to = null;
    //    //if (c.simpleKind == change_k1.use_card_skill) { to = needSkill_cardcall; }
    //    //else if (c.simpleKind == change_k1.HP) { to = needhpChangecall; }
    //    //else if (c.simpleKind == change_k1.mini) { to = needMinicall; }
    //    //else if (c.simpleKind == change_k1.time) { to = needTimecall; }
    //    foreach (Card_m m in c.h.Beens.miniList)
    //    {
    //        m.getcall(c);
    //    }
    //}

    //eve-

    Stack<Queue<CardTxt>> todoL = new Stack<Queue<CardTxt>>();
    //记录txt运行到了哪一步 每次结算开始清空
    Dictionary<CardTxt, step_target> step;
    //eve-全新玩家主动行为
    public void doactiveCall( Host host,Call_ c)
    {
        h = host;
        if (!OnGoing) OnGoing = true;
        else { Debug.Log("ongoing_error"); return; }//需要报错//
        step = new Dictionary<CardTxt, step_target>();

        CardTxt.docall(h, c);
        if (todoL.Count != 0)
            doall();
        OnGoing = false;

    }
    public void doCard(CardTxt c,step_target data,Host host)
    {
        h = host;

        if (!OnGoing) OnGoing = true;
        else { Debug.Log("ongoing_error"); return; }//需要报错//
        step = new Dictionary<CardTxt, step_target>();
        //-----------------------------------------------------------|
        step.Add(c,data);
        Queue<CardTxt> q = new Queue<CardTxt>();
        q.Enqueue(c);
        todoL.Push(q);//加入技能   
        //-----------------------------------------------------------|
        doall();
        OnGoing = false;
    }

    Host h;
    //all
    public void doall()
    {
        int  n = 0;
        h.output(new out_info(different.active_start));
        while (todoL.Count != 0)
        {
            if (n++ >= 50)
            {
                Debug.Log("error");
                return;
            }
            while (todoL.Count != 0)
            {
                if (n++ >= 50)
                {
                    Debug.Log("error");
                    return;
                }
                Do_top_Q();
            }
            //最后一次触发为destory test(触发亡语) 可能可以写在这里
            //可能是发布一个call
        }
        h.output(new out_info(different.active_end));

    }
    //top
    private void Do_top_Q()
    {
        //peek是查看pop是弹出
        while (todoL.Peek().Count == 0)
        {
            todoL.Pop();
            if (todoL.Count == 0) {
                //Debug.Log("here");
                return;
            }
        }
        var todo_q = todoL.Peek();
        CardTxt todo_c = todo_q.Peek();

        //if(todo_c.GetType()!=typeof(moveTxt)&& todo_c.GetType() != typeof(clockTxt))
        //    Debug.Log(todo_c);
        //run之后会加入新的触发 call也由change 发出
        //如果返回false 下次运行到这里还是使用这个change_直到可以弹出
        if (todo_c.run_and_Pop(step))
        {
            h.output(new out_info(todo_c, step[todo_c],true));
            todo_q.Dequeue();
        }
        else
        {
            h.output(new out_info(todo_c, step[todo_c],false));
        }


        the_geter = null;//关闭被动触发接收开始下一轮结算        
      //if(todoL.Count!=0)  Debug.Log(todoL.Peek());
       // if (todoL.Peek().Count != 0) Debug.Log(todoL.Peek().Peek());
    }

    Queue<CardTxt> the_geter;
    public  bool OnGoing;

    public void AddTriggered(CardTxt eL,step_target data)
    {

        if (!OnGoing) { Debug.Log("error unGoing  triggered"); return; }//报错
        //Debug.Log("gettrigged");
        step.Add(eL, data);
        if (the_geter == null)
        { the_geter = new Queue<CardTxt>(); todoL.Push(the_geter);}
        the_geter.Enqueue(eL);
    }
}
//容器
public class IdGroup
{
    //记录
    public  Dictionary<int, Card_m> IDmini = new Dictionary<int, Card_m>();
   public  Dictionary<int, miniG> IDgroup = new Dictionary<int, miniG>();
    Dictionary<int, Trigger> IDtrigger = new Dictionary<int, Trigger>();

    //触发顺序======================================
    public   List<Card_m> Call_List = new List<Card_m>();
    //副列表在mini里

    //增加
    public void Add_in_layer(miniG p,Host h)
    { 
        IDgroup.Add(p.ID, p);
        p.upone = h;
    }
    public void Add_in_layer(Card_m c,miniG p)
    {
        c.upone = p;
        IDmini.Add(c.ID, c); c.player().cards.Add(c.ID);
        foreach (Trigger_bycall t in c.callTrigger) { IDtrigger.Add(t.ID, t); }
        if(c.minion)
        foreach (Trigger_byinput t in c.minion.skillTrigger) {IDtrigger.Add(t.ID, t);}
    }
    public void add_in_call_L(Card_m c)
    {
        if (Call_List.Contains(c)) return;//报错
        else Call_List.Add(c);
    }
    public void removeCall(Card_m c) { Call_List.Remove(c); }
    //
    //find
    public miniG findGroup(int id) { return  IDgroup.ContainsKey(id) ?  IDgroup[id] : null; }
    public Card_m findMini(int id) { return  IDmini.ContainsKey(id) ?  IDmini[id] : null; }
    public Trigger findTrig(int id) { return IDtrigger.ContainsKey(id) ? IDtrigger[id] : null; }
    //change

    //clean
    public void relink(Card_m m,miniG p) { m.player().cards.Remove(m.ID);}

    //----------------------------------------------------------------------------
}

public struct IDtxt
{
    public IDtxt(bool b)
    {
        lastPlayer = 0; lastmini = 0; lastTrigger = 0;
    }
    public int lastPlayer, lastmini, lastTrigger;
    public int NextGID { get { return ++lastPlayer; } }
    public int NextminiID { get { return ++lastmini; } }
    public int NextTriggerID { get { return ++lastTrigger; } }
}














/// <summary>
///     cardM_Action action |
///      Card_m Target_card |
///     Trigger Target_trigger |
/// </summary>
public struct order
{
    public cardM_Action action;

    public Card_m usecard;
    public int whichTrigger;
    //----------------------------
    public Card_m Target_card;
    public Vector3 Target_pos;
    public Trigger Target_trigger;
}

public class step_target
{
    public step_target() { }

    public step_target(Card_m user,Trigger t,order o)
    {
        this.user = user;
        //--------------------------------|
        this.useTr =t ;
        this.usecard = o.usecard;
        //---------------------------------|
        this.targetcard = o.Target_card;
        this.targretposs = o.Target_pos;
        this.target_tr = o.Target_trigger;
    }

    public int nextstep = 0;
    //-----------------------------------------
    public Card_m user;//使用者（主动或者被动触发）
    //-----------------------------------------

    public Card_m usecard;//使用了那张牌 自己使用自己 或者使用拥有的牌
    public Trigger useTr;//来自哪个触发器

    //----------------------------------------
    public Card_m targetcard;//战吼目标
    public Vector3 targretposs;//战吼目标 或者向量
    public Trigger target_tr;//目标触发器
    
}
public class inputpackage
{
    public miniG From;
    public bool wasd;public bool useCard_skill;
    //------------------------------------------
    public bool w, s, d, a;
    //------------------------------
    public int user;
    public int use_mini;
    public cardM_Action action;
    public int use_trigger;
    //-------------------
    public int target_mini;
    public int target_trigger;
    public Vector3 targetposs;
    //包括wasd/使用卡牌
}

public enum cardM_Action
{
    card_Become_mini,
    card_decompose,
    mini_useTrigger,
}

