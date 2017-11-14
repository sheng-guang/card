using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public struct NextIDs
{
    public NextIDs(int max) { lastmini = 0; lastorder = 0; lastPlayer = 0; lastTrigget = 0; }
    public int lastorder, lastPlayer, lastmini, lastTrigget;
    public int NextorderID { get { return ++lastorder; } }
    public int NextGID { get { return ++lastPlayer; } }
    public int NextminiID { get { return ++lastmini; } }
    public int NextTriggerID { get { return ++lastmini; } }
}
public class Host : layer_ID
{
    public override miniG Group()  {  return null;  }  public override Mini mini()  {return null;}
    
    public override Host host()  {   return this;  }
    public override layer_kind getT()    {  return layer_kind.host;    }
    
    public NextIDs next = new NextIDs(0);
    public host_mode mode;
    public override void _load()
    {
        //list[0] = IDgroup;
        //list[1] = IDmini;
    }
    //public Dictionary<int, miniGU>[] list = new Dictionary<int, miniGU>[5];
    public Dictionary<int, miniG> IDgroup = new Dictionary<int, miniG>();
    public Dictionary<int, Mini> IDmini = new Dictionary<int, Mini>();



}

