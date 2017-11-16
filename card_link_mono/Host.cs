using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Host : layerBase
{
    public Host(int modeKind) {

        mode = ADDcomponet<mode1>();
    }
    public override miniG player()  {  return null;  }  public override Mini mini()  {return null;}public override Trigger trigger() { return null; }
    public override Host host()  {   return this;  }
    public NextIDs next = new NextIDs();
    public host_mode mode;

    public Dictionary<int, miniG> IDgroup = new Dictionary<int, miniG>();
    public Dictionary<int, Mini> IDmini = new Dictionary<int, Mini>();
    //public Dictionary<int, ICall_receiver> IDcallGetter = new Dictionary<int, ICall_receiver>();
    public Dictionary<int, Trigger> IDtrigger = new Dictionary<int, Trigger>();

}
public class NextIDs
{
    public int lastorder=0, lastPlayer=0, lastmini=0, lastTrigget=0;
    //public int NextorderID { get { return ++lastorder; } }
    public int NextGID { get { return ++lastPlayer; } }
    public int NextminiID { get { return ++lastmini; } }
    public int NextTriggerID { get { return ++lastmini; } }
}
