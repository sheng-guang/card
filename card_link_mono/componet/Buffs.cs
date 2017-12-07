using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : layerBase {

}
public abstract  class buff_
{
    public abstract int  kind { get; }
    public void through(change_ change)
    {
        
    }
}
public enum Buffkind
{
    
    //第一位是否是第一层
    //第二位是否是第二次
}