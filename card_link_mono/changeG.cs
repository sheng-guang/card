using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class change_
{
    public void run(mini_be be) {
        
    }
}

public abstract class changeG : layerBase {
    public Queue<change_> list = new Queue<change_>();
    protected virtual void upToHost() { }
}
public abstract class skill_ : changeG
{
    public abstract int ID { get; }
    public virtual bool getDataToDo(order o)
    {
        if (true) { }
        return false;
    }

}
public abstract class card_ : skill_
{
    public abstract void decpmpose();
}
