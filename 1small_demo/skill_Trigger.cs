using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_Trigger : MonoBehaviour {
    public skill_point upone;
    public skill_point totriggrt;
    public bool hit_trig  ,enter_trig  ,now_trig   ,destory_trig;
    public virtual void test_trigger() {
        if (upone.disTO <= 0.2) { transform.localScale = new Vector3(10, 10, 10); }
    }
}


public class skill_base : MonoBehaviour
{
   
}
