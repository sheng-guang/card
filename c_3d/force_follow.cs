using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class force_follow : move_2d
{
    
    public override Transform Tar
    { get { return rig.transform; } }
    //public override void Update()
    //{
    //    base.Update();

    //}
    [Header("跟随-------------------")]
    public float Fixy;
    public float forcemode = 120;

    [Tooltip("倍数*距离平方")]
    public float beg = 40, en = 20, beg_ = 2;//倍数*距离平方
    [Range(1, 20)]
    public int fixOnce = 1;
    int fixO = 1, change0 = 1;
    Vector3 dist;
    public Rigidbody rig;
    public ConstantForce force;
    bool once;
    void FixedUpdate()
    {
        if (++fixO > fixOnce)
        {
            dist = point.position + new Vector3(0, Fixy, 0) - rig. transform.position;//距离
            if (!once && dist.magnitude >= 8) { fixOnce = 2; once = true; }
            else if (++change0 > 50) { fixOnce = 10; change0 = 1; once = false; }
            //float ben_pingfang = beg - dist.magnitude * dist.magnitude * beg_;
            //rig.drag = ben_pingfang > en ? ben_pingfang : en;
            rig.drag = (-100 * dist.magnitude + 100)>=1? (-100 * dist.magnitude + 100) :10 ;//y=-kx+b
            force.force = dist.magnitude<=2? dist* forcemode:forcemode*dist.normalized*2;
            fixO = 1;
        }
        //force.torque =roTarget.eulerAngles - transform.eulerAngles;
    }
}
