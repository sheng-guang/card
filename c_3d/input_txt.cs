using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class input_txt : MonoBehaviour {
    public static Transform  CameraForward_3{ get { return _0_camera._0.tar_cam; } }
    public static float ws=0;
    public static float ad=0;
    public static bool wasd {get { return ws == 0 && ad == 0 ? false : true; } }
	void Update () {
        ws = 0;ad = 0;
        if (Input.GetKey(KeyCode.W)) { ws += 1; }
        if (Input.GetKey(KeyCode.S)) { ws -= 1; }
        if (Input.GetKey(KeyCode.A)) { ad -= 1; }
        if (Input.GetKey(KeyCode.D)) { ad += 1; }
    }
}
