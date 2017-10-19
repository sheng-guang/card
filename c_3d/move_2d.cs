using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_2d : camera_force_tar {


	void Start () {
    }

    public Transform point;
    Vector3 tar_position { get { return point.position; } }

    public override Transform Tar
    {  get {  return point;  }}
    [Range(0,20)]
    public float v;
    public virtual void Update () {
        if (!input_txt.wasd) { return; } 
        Vector3 cameraF =  input_txt.CameraForward_3.forward;
        cameraF.Scale(new Vector3(1, 0, 1));
        
        cameraF = cameraF * input_txt.ws + input_txt.CameraForward_3.right * input_txt.ad;

        cameraF.Normalize();
        
        point.position += cameraF*Time.deltaTime*v;

    }
}
