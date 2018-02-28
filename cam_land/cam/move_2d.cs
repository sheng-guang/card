using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_2d :MonoBehaviour, Icamera_force_tar, move {


	void Start () {
    }

    public Transform point;
    Vector3 tar_position { get { return point.position; } }

    public virtual Transform Tar
    {  get {  return point;  }}
    [Range(0,20)]
    public float v;
    public void move()
    {
        if (!getkey.wasd) { return; }
        Vector3 cameraF = getkey.CameraForward_3.forward;
        cameraF.Scale(new Vector3(1, 0, 1));

        cameraF = cameraF * getkey.WS + getkey.CameraForward_3.right * getkey.DA;

        cameraF.Normalize();

        point.position += cameraF * Time.deltaTime * v;
    }

}
public interface move
{
    void move();
}
