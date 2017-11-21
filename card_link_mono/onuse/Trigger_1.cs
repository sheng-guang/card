using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_1 : Trigger {

    public void OnTriggerEnter(Collider other)
    {

        to = other.GetComponent<Mini>();
            beTrigged();
    }
    public Mini to;
    public override void beTrigged()
    {
        
    }
}
