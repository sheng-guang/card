using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card1_1fly : ca_Magic_sprit
{
    public override int CardID   {  get    {  return -1;  }  }





    public override bool move_New_pos(float deltaTime)
    {
        Vector3 fo = target.transform.position - transform.position;
        transform.position += fo.normalized * v * deltaTime;
        return true;
    }

}
