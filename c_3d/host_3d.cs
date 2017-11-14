using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class host_3d : layer_3d {


//    public  Host h_;
//    public override Host h  {   get  { return  h_;  }  }

//    public override void load() { }

//    public void startGame()
//    {
//        h_ = new Host(0);
//        h_.loadGame_waitLink();
//    }
//    public player_3d readyP;
//    public mini_3d readyM;
//}
//public abstract class layer_3d : MonoBehaviour
//{
//    public virtual Host h { get { return upone.h; } }

//    public void link(layer_3d b, int I) { upone = b; ID = I; }
//    public abstract void load();
//    public int ID;
//    public layer_3d upone;
//    public virtual host_3d host() { return upone.host(); }
//    public virtual player_3d Group() { return upone.Group(); }
//    public virtual mini_3d mini() { return upone.mini(); }
//    //public virtual change_G changeG() { return upone.changeG(); }
//    //public virtual change_ change() { return upone.change(); }
//    //public virtual skill_ skill() { return change() != null ? change().skill() : null; }     public virtual change_ change() { return null; }
//    //加入玩家
//    //public T addMiniG<T>() where T : Mini_G, new()
//    //{
//    //    if (GetType() != typeof(Host)) return null;
//    //    T newone = new T();
//    //    newone.link(this, host().next.NextGID);
//    //    host().IDgroup.Add(newone.ID, newone);
//    //    newone.load();
//    //    return newone;
//    //}
//    //public T addMini<T>() where T : Mini, new()
//    //{
//    //    if (GetType().BaseType != typeof(Mini_G)) return null;
//    //    T newone = new T();
//    //    newone.link(this, host().next.NextminiID);
//    //    host().IDmini.Add(newone.ID, newone);
//    //    Group().IDmini.Add(newone.ID);
//    //    newone.load();
//    //    return newone;
//    //}
//    //public T addskill<T>() where T : skill_, new()
//    //{
//    //    if (GetType() != typeof(Mini)) return null;
//    //    T newone = new T();
//    //    newone.link(this, 0);
//    //    newone.load();
//    //    return newone;
//    //}
//    //public T addcard<T>() where T : card_, new()
//    //{
//    //    if (GetType() != typeof(Mini)) return null;
//    //    T newone = new T();
//    //    newone.link(this, 0);
//    //    newone.load();
//    //    return newone;
//    //}
//    //public T addChange<T>()where T : change_, new()
//    //{
//    //    if (GetType() != typeof(change_G)) return null;
//    //    T newone = new T();
//    //    newone.link(this, 0);
//    //    newone.load();
//    //    return newone;
//    //}


//    //public virtual Mini_G find_Group(int ID)
//    //{ return host().IDgroup.ContainsKey(ID) ? host().IDgroup[ID] : null; }
//    //public virtual Mini find_mini(int ID)
//    //{ return host().IDmini.ContainsKey(ID) ? host().IDmini[ID] : null; }

//}
