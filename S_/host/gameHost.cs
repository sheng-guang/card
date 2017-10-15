using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public struct nextNUM
{
    public  nextNUM(int n) { nextobj = 1;nextorder = 0;nextPlayer = 1; }
    public int nextorder;
    public int nextPlayer;
    public int nextobj;
}
//分开一些属性方便看
public class host_base
{
    private nextNUM next=new nextNUM(0);
    public int nextorderID { get { return next.nextorder++; } }
    public int nextobjID { get { return next.nextobj++; } }
    public int nextpID { get { return next.nextPlayer++; } }
}

public class gameHost:host_base
{
    //新建一个host
    public gameHost(int modeK)
    {
        factory= addcompponet<Hostfac>();
        switch (modeK)
        {
            case 0:mode= addcompponet<mode_sixAngle>();break;
        }
        mode.gameLoad_Link();
    }
    //模组
    public mode mode;
    //工厂
    public Hostfac factory;
    //服务器玩家 //玩家列表 
    public CardPlayer hostPlayer;
    public Dictionary<int, CardPlayer> player_L = new Dictionary<int, CardPlayer>();


    public T addcompponet<T>() where T : host_componet,new ()
    {
        T newone = new T();
        newone.host = this;
        return newone;
    }
    public event output out_;
    public void output(outinfo info) { out_(info);  }
}

public delegate void  output(outinfo info);

public enum outinfo_K
{
    c_buff_L, c_hp,c_atk,c_skilln,c_card,obj_destory,obj_new,
    getorder,T,F
}
public struct outinfo
{
    public outinfo(int IDp, int IDo, outinfo_K k_)
    {
        PID = IDp;OID = IDo;k = k_;
    }
    public int PID, OID;
    public outinfo_K k;
}