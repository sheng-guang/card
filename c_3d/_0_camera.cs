using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _0_camera : MonoBehaviour {
    [Header("旋转")]
    public bool useful1 = true;
    [Tooltip("旋转速度")]public float rospeed = 4;
    Vector3 ro;

    [Header("距离")]
    public bool useful2 = true;

    public float max = -10, min = 1;
    public float vinput = 50, vreal = 20;
    public Vector3 fix;

    float targetz, nowz;

    void Start()
    {
        rg = GetComponent<Rigidbody>();
        force = GetComponent<ConstantForce>();
        transform.position = Tar_position + new Vector3(0, Fixy, 0);


        transform.rotation = first_rotation;
        ro = transform.eulerAngles;
        //------------------------------------------
        targetz = tar_cam.localPosition.z;
        nowz = targetz;
    }


    void Update()
    {
        //print(Input.GetAxis("Mouse X"));
        if (useful1 && Input.GetMouseButton(1))
        {

            ro.x -= Input.GetAxis("Mouse Y") * rospeed;
            ro.y += Input.GetAxis("Mouse X") * rospeed;
            if (ro.x >= 89) ro.x = 89;
            else if (ro.x <= -89) ro.x = -89;
            transform.eulerAngles = ro;
        }
        //--------------------------------------------------------
        if (useful2)
        {
            if (Input.GetAxis("Mouse ScrollWheel") < 0 && targetz >= max)
            { targetz -= vinput * Time.deltaTime; }

            if (Input.GetAxis("Mouse ScrollWheel") > 0 && targetz <= min)
            { targetz += vinput * Time.deltaTime; }

            if (tar_cam.localPosition.z <= targetz - 0.5) nowz += vreal * Time.deltaTime;

            if (tar_cam.localPosition.z >= targetz + 0.5) nowz -= vreal * Time.deltaTime;

            tar_cam.localPosition = fix + new Vector3(0, 0, nowz);
        }
    }
    [Header("跟随")]
    public float Fixy;
    public float forcemode = 120 ;

    [Tooltip("倍数*距离平方")] public float beg = 40, en = 20, beg_ = 2;//倍数*距离平方
    [Range(1, 20)]
    public int fixOnce = 1;
    int fixO = 1, change0 = 1;
    Vector3 dist;
    Rigidbody rg;
    ConstantForce force;
    bool once;

    void FixedUpdate()
    {
        if (++fixO > fixOnce)
        {
            dist = Tar_position + new Vector3(0, Fixy, 0) - transform.position;
            if (!once && dist.magnitude >= 8) { fixOnce = 2; once = true; }
            else if (++change0 > 50) { fixOnce = 10; change0 = 1; once = false; }
            float ben_pingfang = beg - dist.magnitude * dist.magnitude * beg_;
            rg.drag = ben_pingfang > en ? ben_pingfang : en;
            force.force = dist * forcemode;
            fixO = 1;
        }
        //force.torque =roTarget.eulerAngles - transform.eulerAngles;
    }

    public void ChangeTarget(Transform NewOne)
    {
        Target = NewOne;
    }
    public void changeY(float value)
    { //float a=1;
        Fixy = value;
    }
    [Header("目标")]
    public Transform tar_cam;
    public Transform Target;
    public Vector3 Tar_position { get { return Target != null ? Target.position : Vector3.zero; } }
    public Transform firstro;
    public Quaternion first_rotation { get { return firstro != null ? firstro.rotation : Quaternion.identity; } }

}



