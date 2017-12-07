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
    public void Add(miniG p) { p.ID = NextGID;IDgroup.Add(p.ID, p); G_mini.Add(p, new List<int>()); G_trigger.Add(p, new List<int>()); }
    public void Add(Mini m) { m.ID = NextminiID;IDmini.Add(m.ID, m);G_mini[m.player()].Add(m.ID); }
    public void Add(Trigger t) { }
    //-

    //find
    public miniG findGroup(int id) { return  IDgroup.ContainsKey(id) ?  IDgroup[id] : null; }
    public Mini findMini(int id) { return  IDmini.ContainsKey(id) ?  IDmini[id] : null; }
    public Trigger findTrig(int id) { return IDtrigger.ContainsKey(id) ? IDtrigger[id] : null; }

    public bool findM_inG(miniG m,int id) {return  G_mini.ContainsKey(m) && G_mini[m].Contains(id)?  true:false; }
    public bool findTr_inG(miniG m, int id) { return G_trigger.ContainsKey(m) && G_trigger[m].Contains(id) ? true : false; }
    //change


    //----------------------------------------------------------------------------
    public int lastorder=0, lastPlayer=0, lastmini=0, lastTrigget=0;
    public int NextGID { get { return ++lastPlayer; } }
    public int NextminiID { get { return ++lastmini; } }
    public int NextTriggerID { get { return ++lastmini; } }
    //public int NextorderID { get { return ++lastorder; } }

    public Dictionary<miniG, List<int>> G_mini = new Dictionary<miniG, List<int>>();
    public Dictionary<miniG, List<int>> G_trigger = new Dictionary<miniG, List<int>>();
    public Dictionary<int, miniG> IDgroup = new Dictionary<int, miniG>();
    public Dictionary<int, Mini> IDmini = new Dictionary<int, Mini>();
    //public Dictionary<int, ICall_receiver> IDcallGetter = new Dictionary<int, ICall_receiver>();
    public Dictionary<int, Trigger> IDtrigger = new Dictionary<int, Trigger>();

}
