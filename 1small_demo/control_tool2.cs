using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class control_tool2 : camera_force_tar
{
    public override Transform Tar
    { get{ return transform; }}
    public buff_team_mini onControl;

    public void transport(skill_point p) {
        p.firstLoad();
        list.Add(p);
    }



    public List<skill_point> list = new List<skill_point>();
    [Range(1, 20)]
    public int fixonce;int fxx=0;
    [Range(0, 1)]
    public float speed;
    public void FixedUpdate()
    {
        if (++fxx > fixonce) fxx = 0;
        else return;

        foreach (skill_point p in list)
        {
            if (p != null) p.fix(speed);
        }
    }

}
