using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class miniG : layer_ID
{
    public override miniG Group()  {    return this;}
    public override layer_kind getT()   {    return layer_kind.miniG; }

}


public class order
{
    int miniID;
    Mini the;
}