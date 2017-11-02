using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _0_camera : MonoBehaviour {
    public static _0_camera camera_;
    void Awake() { camera_ = this;  }
    
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
    [Range(0,10)]
    public float forceL = 10 ;

    Rigidbody rig;

    Vector3 D { get { return Tar_position - rig.position + new Vector3(0, Fixy, 0); } }
    void FixedUpdate()
    {

        forceL = D.magnitude * D.magnitude;
        if (forceL > 10) print(forceL);
        if (forceL > 90) forceL = 90;
        rig.velocity =D * forceL;

    }

    public void ChangeTarget(camera_force_tar NewOne)
    {
        Target = NewOne;
    }
    public void changeY(float value)
    { 
        Fixy = value;
    }
    [Header("目标")]
    public Transform tar_cam;
    public camera_force_tar Target;
    public Vector3 Tar_position { get { return Target != null ? Target.Tar.position : Vector3.zero; } }
    public Transform firstro;
    public Quaternion first_rotation { get { return firstro != null ? firstro.rotation : Quaternion.identity; } }

}

public abstract class camera_force_tar:MonoBehaviour
{
   public abstract  Transform Tar { get; }
}



