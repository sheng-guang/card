using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getkey : MonoBehaviour {

    public static bool W { get { return Input.GetKey(KeyCode.W); } }
    public static bool S { get { return Input.GetKey(KeyCode.S); } }
    public static bool D { get { return Input.GetKey(KeyCode.D); } }
    public static bool A { get { return Input.GetKey(KeyCode.A); } }
    public static int WS { get { return (W ? 1 : 0) + (S ? -1 : 0); } }
    public static int DA { get { return (D ? 1 : 0) + (A ? -1 : 0); } }
    public static bool wasd { get { return W || A || S || D; } }
    public static _0_camera cam;
    public static Transform CameraForward_3 { get { return cam.transform; } }
}
