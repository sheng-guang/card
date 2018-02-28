using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//职业选手的APM通常高达200-300甚至更高/一秒大概五次需要传输的操作
//按键精灵手速测试结果：多个按键直接间隔最快50ms一秒20次
//按下之后抬起约为100ms
//按下第一次q到第按下第二次间隔150s
//帧同步可能 每秒上传10-20-30次操作
public enum layer_kind
{
    N,
    host,miniG,mini,
}

/// <summary>
/// 可重写方法：fix()   load()
/// </summary>
public abstract class layerBase :MonoBehaviour
{
    [Header("layer--------------------|")]
    public layerBase upone;

    public virtual void load_logic() { }

    public virtual Host host() { return upone.host(); }
    //指定位置ID
    public virtual miniG player() { return upone.player(); }
    //有位置 实体ID
    public virtual Card_m mini() { return upone.mini(); }
    //附着位置ID(比如亡语，回合结束触发，)
    public virtual Trigger trigger() { return upone.trigger(); }
    //单纯的结构体（准备做成结构体）
    public virtual CardTxt cardTxt() { return upone.cardTxt(); }
    //-----------------------------------------------
    public miniG player(int which) { return beens.findGroup(which); }
    public  Card_m mini(int which) { return beens.findMini(which); }
    public Trigger trigger(int which) { return beens.findTrig(which); }

    public bool findM_inG(miniG m, int id) { return m.cards.Contains(id) ? true : false; }
    //public bool findTr_inG(miniG m, int id) { return m.triggers.Contains(id) ? true : false; }

    public Icreater factory { get { return host().creater; } }
    public IdGroup beens { get { return host().Beens; } }
    //创建------------------------------------------------------------------
    //----------------------------------------------------------------

    public void output(out_info info) { host().outGeter(info); }
}
public abstract class layerVirtual 
{
    public layerVirtual(layerBase b)
    {
        upone = b;
    }
    public layerBase upone;

    public virtual void load_logic() { }

    public virtual Host host() { return upone.host(); }
    //指定位置ID
    public virtual miniG player() { return upone.player(); }
    //有位置 实体ID
    public virtual Card_m mini() { return upone.mini(); }
    //附着位置ID(比如亡语，回合结束触发，)
    public virtual Trigger trigger() { return upone.trigger(); }
    //单纯的结构体（准备做成结构体）
    public virtual CardTxt cardTxt() { return upone.cardTxt(); }
    //-----------------------------------------------
    public miniG player(int which) { return beens.findGroup(which); }
    public Card_m mini(int which) { return beens.findMini(which); }
    public Trigger trigger(int which) { return beens.findTrig(which); }

    public bool findM_inG(miniG m, int id) { return m.cards.Contains(id) ? true : false; }
    //public bool findTr_inG(miniG m, int id) { return m.triggers.Contains(id) ? true : false; }

    public Icreater factory { get { return host().creater; } }
    public IdGroup beens { get { return host().Beens; } }
    //创建------------------------------------------------------------------
    //----------------------------------------------------------------

    public void output(out_info info) { host().outGeter(info); }
}
public delegate void  getLayer_Information(out_info info);

