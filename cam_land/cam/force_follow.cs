using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force_follow : move_2d
{
    //接口
    public override  Transform Tar
    { get { return rig.transform; } }
    //public override void Update()
    //{  //    base.Update(); //}
    [Header("跟随-------------------")]
    public float Fixy;
    [Range(0,100)]
    public float forceL=2;
    public Rigidbody rig;
    //距离
    Vector3 D { get { return point.position - rig.position + new Vector3(0, Fixy, 0); } }

    void FixedUpdate()
    {

        //if (forceL > 100) ;
        rig.velocity = D*forceL;
        //force.torque =roTarget.eulerAngles - transform.eulerAngles;
    }
}
