using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_2d : MonoBehaviour {


	void Start () {
        tar_position = p.position;
    }

    public Transform p;
    Vector3 tar_position ;
    Vector3 wasd = new Vector3();
	void Update () {
        wasd = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.W)) { wasd.z += 1; }
        if (Input.GetKeyDown(KeyCode.A)) { wasd.x -= 1; }
        if (Input.GetKeyDown(KeyCode.S)) { wasd.z -= 1; }
        if (Input.GetKeyDown(KeyCode.D)) { wasd.x += 1; }
        if (wasd.magnitude > 1) { wasd.Normalize(); }
    }
}
