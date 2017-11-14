using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hostDriver : MonoBehaviour {


    public Host newone;
    public void newH()
    {
        onuse= Instantiate(newone);
    }
    public Host onuse;

    void FixedUpdate()
    {
        //if (onuse)onuse
    }
}
