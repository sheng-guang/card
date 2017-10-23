using System;
using System.Collections;
using System.Collections.Generic;

public abstract class Gr_base : layer_base
{
    private Host upHost;
    public override Host host()
    {
        return upHost;
    }

    public List<int> IDmini = new List<int>();
}
public class mini_G:Gr_base
{
    public override mini_G Group()  {  return this; }




    public void doCard() { }
    public void Be()
    {

    }

}
