using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hostDriver : MonoBehaviour {


    public HostU newone;
    public void newH()
    {
        onuse= Instantiate(newone);
    }
    public HostU onuse;

    void FixedUpdate()
    {
        //if (onuse)onuse
    }
}
