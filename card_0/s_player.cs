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
public class Mini_G:Gr_base
{
    public override Mini_G Group()  {  return this; }
    public void getOrder(List<byte> d) {
        if (testOrder(d)) { doOrder(); }
    }
    public bool testOrder(List<byte> d) {

        return false;
    }
    public void doOrder()
    {

    }


    public void doCards(int which) { }
    
    public void doskills(int miniID,int which) { }

    public void Be()
    {

    }

}
