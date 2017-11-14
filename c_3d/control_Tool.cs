using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class control_Tool :camera_force_tar {
//    public static control_Tool self;
//    public void Awake() { self = this; }

//    public ui_tool ready;
//    [Header("--------------")]
//    public mini_3d mini;
//    public player_3d player { get { return mini.Group(); } }

//    public host_3d Host { get { return player.host(); } }
    
//    public override Transform Tar
//    { get {return mini==null?transform: mini.Tar; }}

    
//    public Dictionary<player_3d, ui_tool> p_ui = new Dictionary<player_3d, ui_tool>();
//    public ui_tool now;
//    public void change_(mini_3d mi)
//    {
//        mini = mi;
//        player_3d p=player;
//        ui_tool to;now.gameObject.SetActive(false);
//        if (p_ui.ContainsKey(p)) { to = p_ui[p];to.gameObject.SetActive(true);  }
//        else to=Instantiate(ready);
//        to.mini = player.miniG;
//        to.all();
//    }
//    public void Update()
//    {
//        if (mini!=null)
//        mini.move.move();
//    }

//}
