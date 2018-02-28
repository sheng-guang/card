using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _0_camera : MonoBehaviour
{
    public static _0_camera camera_;
    void Awake() { camera_ = this; }

    [Header("旋转")]
    public bool useful1 = true;

    [Range(-98,10)]
    public float xup=-89;//-89~0

    [Range(-10, 89)]
    public float xdown=89;//0~89
    public bool rox, roy;
    [Tooltip("旋转速度")] public float rospeed = 4;
    Vector3 ro;

    [Header("距离")]
    public bool useful2 = true;

    public float max = -10, min = 1;
    public float vinput = 50, vreal = 20;
    public Vector3 fix;
    float targetz, nowz;


    void Start()
    {
        rig = GetComponent<Rigidbody>();
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
            if(rox)ro.x -= Input.GetAxis("Mouse Y") * rospeed;
            if(roy)ro.y += Input.GetAxis("Mouse X") * rospeed;
            if (ro.x >= xdown) ro.x =xdown;
            else if (ro.x <=xup) ro.x = xup;
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
    [Header("跟随: v=距离平方*forceL  (< maxL)")]
    public float Fixy;
    [Range(0, 6)]
    public float forceL = 1;
    public float maxL=20;
    Rigidbody rig;
    //距离
    Vector3 D { get { return Tar_position - rig.position + new Vector3(0, Fixy, 0); } }
    //fixUpdate间隔为0.01秒  要求在下面0.01秒中不能超过目标 （v*1/100）<d 
    //forcel<100;
    void FixedUpdate()
    {
        float dis = D.magnitude;
        dis *= forceL ;
        if (dis > maxL) dis = maxL;
        rig.velocity = D * dis;
    }

    public void ChangeTarget(Icamera_force_tar NewOne)
    {
        tarTest = null;
        Target = NewOne;
    }
    public void changeY(float value)
    {
        Fixy = value;
    }
    [Header("目标")]
    public Transform tar_cam;
    public Vector3 Tar_position { get { return tarTest ? tarTest.position : (Target != null ? Target.Tar.position : Vector3.zero); } }

    public Transform tarTest;
    Icamera_force_tar Target;
    

    public Transform firstro;
    public Quaternion first_rotation { get { return firstro != null ? firstro.rotation : Quaternion.identity; } }
    //方便移动使用的指向
    public Vector3 vector3_for_move { get { return new Vector3(transform.forward.x, 0, transform.forward.z).normalized; } }
}
public interface Icamera_force_tar
{
    Transform Tar { get; }
}




