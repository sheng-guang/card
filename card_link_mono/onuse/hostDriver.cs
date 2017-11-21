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


    public bool gameRun;

    void FixedUpdate()
    {
        if (gameRun && onuse) {
            foreach (layerBase l in onuse.fix) {
                l.fixedUpD();
            }
        }     
    }
}
