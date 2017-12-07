using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Host : layerBase
{
    //public Host(int modeKind) {

    //    mode = ADDcomponet<mode1>();
    //}
    public override miniG player()  {  return null;  }  public override Mini mini()  {return null;}public override Trigger trigger() { return null; }
    public override Host host()  {   return this;  }
    
    public host_mode mode;

   
   // public List<layerBase> fix = new List<layerBase>();


    public IdGroup Beens = new IdGroup();
}

//容器
public class IdGroup
{

    //+
    public void Add(miniG p) { p.ID = NextGID;IDgroup.Add(p.ID, p);  }
    public void Add(Mini m) { m.ID = NextminiID;IDmini.Add(m.ID, m);m.player().cards.minis.Add(m.ID); }
    public void Add(Trigger t) { t.ID = NextTriggerID;IDtrigger.Add(t.ID,t);t.player().cards.triggers.Add(t.ID); }
    //-

    //find
    public miniG findGroup(int id) { return  IDgroup.ContainsKey(id) ?  IDgroup[id] : null; }
    public Mini findMini(int id) { return  IDmini.ContainsKey(id) ?  IDmini[id] : null; }
    public Trigger findTrig(int id) { return IDtrigger.ContainsKey(id) ? IDtrigger[id] : null; }

    public bool findM_inG(miniG m,int id) {return  m.cards.minis.Contains(id)?  true:false; }
    public bool findTr_inG(miniG m, int id) { return  m.cards.triggers.Contains(id) ? true : false; }
    //change

    //clean
    public void relink(Mini m,miniG p) { m.player().cards.minis.Remove(m.ID);}
    public void relink(Trigger t, miniG p) { t.player().cards.triggers.Remove(t.ID); }
    //----------------------------------------------------------------------------
    int lastorder=0, lastPlayer=0, lastmini=0, lastTrigger=0;
     int NextGID { get { return ++lastPlayer; } }
     int NextminiID { get { return ++lastmini; } }
     int NextTriggerID { get { return ++lastTrigger; } }
    //public int NextorderID { get { return ++lastorder; } }

    //主列表
     Dictionary<int, miniG> IDgroup = new Dictionary<int, miniG>();
     Dictionary<int, Mini> IDmini = new Dictionary<int, Mini>();
    //public Dictionary<int, ICall_receiver> IDcallGetter = new Dictionary<int, ICall_receiver>();
     Dictionary<int, Trigger> IDtrigger = new Dictionary<int, Trigger>();
    //副列表在mini里



    //host1
    //player2
    public T addplayer<T>() where T : miniG, new()
    {
       
        T newone = new T();
        newone.link_GetID(this); return newone;
    }
    //mini3
    public T addminiBase<T>(bool card) where T : Mini, new()
    {//由玩家创建
        
        T newone = new T();

        newone.link_GetID(this);
        //if (card) mini().becomeCard();
        //else mini().becomeMini();
        return newone;
    }
    //trigger4
    public T addtriggerBase<T>(bool forp) where T : Trigger, new()
    {//由mini创建
        if (trigger() != null || mini() == null) return null;
        T newone = new T(); newone.forPlayer = forp;
        newone.link_GetID(this); return newone;
    }
    //card5
    //public void outputchange(Call_ c) { }


}
