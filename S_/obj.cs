﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
//本体
//----------------------------------------------------------------------------------------------
public abstract class SkillObj:IObj_Be_Call
{
    public CardPlayer player;public int OID;
    //0-加载obj
    public void link_load(CardPlayer p, int id)
    {
        //基础
        geteffect = addcomponet<GetEffect>();
        //load
        player = p;OID = id;
        loadHP_ATK();
        loadskillL(); loadskills();//注册通知列表//需补全

        //完成
        player.ID_obj.Add(id, this);
    }
    // 0-初始化数值
    public virtual void loadHP_ATK() {
        nowATK = baseATK;nowHP = baseHP;
    }
    //0-2初始化技能列表和普通攻击技能
    public virtual void loadskillL()
    { skills = new skill_[baseskillNum+1];skills[0] = addskill<skill_ATK>(); }
    //0-3加载其他技能
    public abstract void loadskills();

    //9-----------------测试之后立即使用
    public virtual bool test_do_skills(int which, byte[] b)
    {
        bool to = true;
        //检测&&技能是否存在&&检测是否可以使用
        if(skills.Length < which || skills[which] == null)
        { to = false; }
        else if (skills[which].data_test(b) == false)
        {Debug.Log("cantuse"); to = false; }
          
        
        if (to)
        {
            Debug.Log("touseskill");
            //接收数据
            int orderID = player.next_Orede_id; 

            //运行技能
            skills[which].do_(orderID,b);
        }
        return to;
    }

    //属性
    public abstract Target_K2 obj_K { get; }
    public abstract int baseHP { get; }//血量
    public abstract int baseATK { get; }//攻击
    public virtual bool canATK { get { return true; } }//能否普通攻击

    public int nowHP, nowATK;
    //组件  skill
    public skill_[] skills;
    public abstract int baseskillNum { get; }//主动技能数量
    //被动技能
    //public virtual void beATK() { }//被攻击

    //组件  effect
    public GetEffect geteffect;

    //加载技能
    public T addskill<T>()where T:skill_ ,new ()
    {
        T newone = new T();newone.link_load(this);
        return newone;
    }

    public T addcomponet<T>()where T:componet_obj,new()
    {
        T newone = new T();newone.obj = this;
        return newone;
    }

    //工厂方法
    public static obj_main getmain()
    { return new obj_main(); }

    public void getcall() { if (Des_test()) { DoEstory(); } }

    public virtual void DoEstory()
    {

    }
    public virtual bool Des_test()
    {
        if (nowHP <= 0) { return true; }
        else return false;
    }
}

//组件
//--------------------------------------------------------------------------------------------
public class componet_obj
{
    //组件的主人
    public SkillObj obj;
    public GetEffect geteffect_ { get { return obj.geteffect; } }
    public void output(outinfo info) { obj.player.host.output(info); }
}
public class GetEffect : componet_obj
{
    //获取这个单位作为目标
    public bool getthis(Skill_K1 k)
    {
        return true;
    }
    //get-HP
    public void getHPchange(Skill_K1 k, int number)
    {
        //报告观察者
        //
        //运行改变
        obj.nowHP += number;
        output(new outinfo( obj.player.ID,obj.OID, outinfo_K.c_hp));
    }

    //get-
    public void getBuff()
    {

    }
    public void getTrigger()
    {

    }
    //destory事件
    public class e_obj_destory : EVE_trigger
    {

    }
    //card
    //buff
}