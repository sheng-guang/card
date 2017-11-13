using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HostU : layer_ID
{
    public override miniGU Group()  {  return null;  }  public override miniU mini()  {return null;}
    
    public override HostU host()  {   return this;  }
    public override layer_kind getT()    {  return layer_kind.host;    }
    
    public NextIDs next = new NextIDs(0);
    public host_mode mode;
    public override void _load()
    {
        //list[0] = IDgroup;
        //list[1] = IDmini;
    }
    //public Dictionary<int, miniGU>[] list = new Dictionary<int, miniGU>[5];
    public Dictionary<int, miniGU> IDgroup = new Dictionary<int, miniGU>();
    public Dictionary<int, miniU> IDmini = new Dictionary<int, miniU>();



}



