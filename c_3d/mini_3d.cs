using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mini_3d :layer_3d{
    public force_follow move;
    
    public Transform Tar   {  get  { return move.Tar; }  }

    public override void load()
    {
       
    }
}
