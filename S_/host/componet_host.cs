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

    //总表
    public LinkedList<IBe_Call> all_obj = new LinkedList<IBe_Call>();
    
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

